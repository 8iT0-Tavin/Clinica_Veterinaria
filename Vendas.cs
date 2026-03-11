using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ClinicaVeterinaria
{
    public partial class Vendas : Form
    {
        public Vendas()
        {
            InitializeComponent();
            cboFormaPagamento.Items.AddRange(new string[] { "Dinheiro", "Cartão", "Pix", "Boleto" });

            dgvItens.CellValueChanged += dgvItens_CellValueChanged;
        }

        private void Vendas_Load(object sender, EventArgs e)
        {
            dgvItens.AutoGenerateColumns = false;

            // Coluna ComboBox de Produtos
            DataGridViewComboBoxColumn colProduto = new DataGridViewComboBoxColumn();
            colProduto.HeaderText = "Produto";
            colProduto.Name = "colProduto";
            dgvItens.Columns.Add(colProduto);

            // Quantidade
            DataGridViewTextBoxColumn colQtd = new DataGridViewTextBoxColumn();
            colQtd.HeaderText = "Quantidade";
            colQtd.Name = "colQtd";
            dgvItens.Columns.Add(colQtd);

            // Preço
            DataGridViewTextBoxColumn colPreco = new DataGridViewTextBoxColumn();
            colPreco.HeaderText = "Preço Unitário";
            colPreco.Name = "colPreco";
            colPreco.ReadOnly = true;
            dgvItens.Columns.Add(colPreco);

            // Subtotal
            DataGridViewTextBoxColumn colSubtotal = new DataGridViewTextBoxColumn();
            colSubtotal.HeaderText = "Subtotal";
            colSubtotal.Name = "colSubtotal";
            colSubtotal.ReadOnly = true;
            dgvItens.Columns.Add(colSubtotal);

            dgvItens.RowsAdded += (s, ev) =>
            {
                dgvItens.Rows[ev.RowIndex].Cells["colQtd"].Value = 1;
            };

            CarregarProdutosNoComboBox();
        }

        private void CarregarProdutosNoComboBox()
        {
            string sql = @"
                SELECT id_medicamentos AS id, nome_med AS nome, preco_venda AS preco, 'Medicamento' AS tipo 
                FROM Medicamentos
                UNION
                SELECT id_vacinas AS id, Nome_Vacinas AS nome, 0 AS preco, 'Vacina' AS tipo 
                FROM Vacinas";

            using (MySqlConnection con = BancoDados.Conectar())
            {
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                var col = (DataGridViewComboBoxColumn)dgvItens.Columns["colProduto"];
                col.DataSource = dt;
                col.DisplayMember = "nome";
                col.ValueMember = "id";
                col.FlatStyle = FlatStyle.Popup;
            }
        }

        private void dgvItens_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dgvItens.Columns["colProduto"].Index)
            {
                DataGridViewRow row = dgvItens.Rows[e.RowIndex];
                if (row.Cells["colProduto"].Value == null) return;

                int idProduto = Convert.ToInt32(row.Cells["colProduto"].Value);

                string sql = @"SELECT preco_venda FROM Medicamentos WHERE id_medicamentos = @id";

                decimal preco = 0;

                using (MySqlConnection con = BancoDados.Conectar())
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", idProduto);

                    var precoBD = cmd.ExecuteScalar();
                    if (precoBD != null && precoBD != DBNull.Value)
                    {
                        preco = Convert.ToDecimal(precoBD);
                    }
                }

                row.Cells["colPreco"].Value = preco;

                int qtd = row.Cells["colQtd"].Value != null ? Convert.ToInt32(row.Cells["colQtd"].Value) : 1;
                row.Cells["colSubtotal"].Value = qtd * preco;

                AtualizarTotal();
            }
            else if (e.ColumnIndex == dgvItens.Columns["colQtd"].Index)
            {
                DataGridViewRow row = dgvItens.Rows[e.RowIndex];
                if (row.Cells["colPreco"].Value == null) return;

                int qtd = Convert.ToInt32(row.Cells["colQtd"].Value);
                decimal preco = Convert.ToDecimal(row.Cells["colPreco"].Value);

                row.Cells["colSubtotal"].Value = qtd * preco;
                AtualizarTotal();
            }
        }

        private void AtualizarTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvItens.Rows)
            {
                if (row.Cells["colSubtotal"].Value != null)
                    total += Convert.ToDecimal(row.Cells["colSubtotal"].Value);
            }

            txtTotal.Text = total.ToString("F2");
        }
        public int idTutor;
        private void btnSalvarVenda_Click(object sender, EventArgs e)
        {
            using (MySqlConnection cn = BancoDados.Conectar())
            {
                cn.Open();
                MySqlTransaction transacao = cn.BeginTransaction();

                try
                {
                    string sqlVenda = @"INSERT INTO Venda (data_venda, valor_total, forma_pagamento, Tutores_idTutores) VALUES (@data, @total, @forma, @tutor)";
                    MySqlCommand cmdVenda = new MySqlCommand(sqlVenda, cn, transacao);
                    cmdVenda.Parameters.AddWithValue("@data", dtpDataVenda.Value);
                    cmdVenda.Parameters.AddWithValue("@total", Convert.ToDecimal(txtTotal.Text));
                    cmdVenda.Parameters.AddWithValue("@forma", cboFormaPagamento.SelectedItem.ToString());
                    cmdVenda.Parameters.AddWithValue("@tutor", idTutor);
                    cmdVenda.ExecuteNonQuery();

                    int idVenda = (int)cmdVenda.LastInsertedId;

                    foreach (DataGridViewRow row in dgvItens.Rows)
                    {
                        if (row.Cells["colProduto"].Value == null) continue;
                        string sqlItem = @"INSERT INTO Item_Venda (quantidade, preco_unitario, Venda_id_Venda) VALUES (@qtd, @preco, @venda)";
                        MySqlCommand cmdItem = new MySqlCommand(sqlItem, cn, transacao);
                        cmdItem.Parameters.AddWithValue("@qtd", Convert.ToInt32(row.Cells["colQtd"].Value));
                        cmdItem.Parameters.AddWithValue("@preco", Convert.ToDecimal(row.Cells["colPreco"].Value));
                        cmdItem.Parameters.AddWithValue("@venda", idVenda);
                        cmdItem.ExecuteNonQuery();
                    }

                    transacao.Commit();
                    MessageBox.Show("Venda registrada com sucesso!");
                }
                catch (Exception ex)
                {
                    transacao.Rollback();
                    MessageBox.Show("Erro ao salvar venda: " + ex.Message);
                }
            }
        }

        private void txtComprador_TextChanged(object sender, EventArgs e)
        {
            dtgBuscaTutor.Visible = true;
            configuraGridAgendamento();
            carregaDadosGrid();
        }
        private void carregaDadosGrid()
        {
            using (MySqlConnection cn = BancoDados.Conectar())
            {
                try
                {
                    cn.Open();
                    string query = "SELECT * FROM tutores LIKE @busca";
                    using (MySqlCommand cmd = new MySqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@busca", "%" + txtComprador.Text + "%");
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dtgBuscaTutor.DataSource = dt;
                        }
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                idTutor = Convert.ToInt32(reader["id_Tutores"]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar dados: " + ex.Message);
                }
            }
        }
        private void dtgBusca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            insertDadosGrid(e);
            dtgBuscaTutor.Visible = false;
        }

        private void insertDadosGrid(DataGridViewCellEventArgs e)
        {
            if (dtgBuscaTutor.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dtgBuscaTutor.SelectedRows[0];
                txtComprador.Text = row.Cells["Nome"].Value.ToString();
            }
        }

        private void configuraGridAgendamento()
        {
            dtgBuscaTutor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgBuscaTutor.MultiSelect = false;
            dtgBuscaTutor.ReadOnly = true;
            dtgBuscaTutor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgBuscaTutor.AllowUserToAddRows = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
