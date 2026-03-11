using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ClinicaVeterinaria
{
    public partial class Agendamentos : Form
    {
        private Timer timerAtualizaGrid;
        private bool filtroConcluidosAtivo = false;
        public Agendamentos()
        {
            InitializeComponent();
            txtIdAnimal.Text = "";
            dtpDataHoraAgendamento.CustomFormat = "dd MM yyyy HH:mm";
            timerAtualizaGrid = new Timer();
            timerAtualizaGrid.Interval = 5000;
            timerAtualizaGrid.Tick += TimerAtualizaGrid_Tick;
            timerAtualizaGrid.Start();
            carregaDadosGridAgendamento();

        }

        public int idServico;
        public int idVeterinario;
        public int idAnimal;
        private void Agendamentos_Load(object sender, EventArgs e)
        {
            using (MySqlConnection cn = BancoDados.Conectar())
            {
                try
                {
                    cn.Open();
                    string sql = "SELECT * FROM servicos ";
                    using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbxServicos.Items.Add(reader["nome_servico"].ToString());
                                idServico = Convert.ToInt32(reader["id_servicos"]);
                            }
                        }
                    }
                    string sql2 = "SELECT * FROM veterinario ";
                    using (MySqlCommand cmd = new MySqlCommand(sql2, cn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbVaterinarios.Items.Add(reader["nome"].ToString());
                                idVeterinario = Convert.ToInt32(reader["id_veterinario"]);
                            }
                        }
                    }
                    string sql3 = "Select * from animais";
                    using (MySqlCommand cmd = new MySqlCommand(sql3, cn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                idAnimal = Convert.ToInt32(reader["id_Paciente"]);
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
        private void txtBuscaPaciente_TextChanged(object sender, EventArgs e)
        {
            dtgBuscaPaciente.Visible = true;
            configuraGrid();
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
                    string query = $"SELECT Nome_Animal as Nome, Especie FROM animais WHERE nome_animal LIKE @busca";
                    using (MySqlCommand cmd = new MySqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@busca", "%" + txtBuscaPaciente.Text + "%");
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dtgBuscaPaciente.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar dados: " + ex.Message);
                }
            }
        }
        private void TimerAtualizaGrid_Tick(object sender, EventArgs e)
        {
            carregaDadosGrid();
        }
        private void dtgBusca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            insertDadosGrid(e);
            dtgBuscaPaciente.Visible = false;
        }

        private void insertDadosGrid(DataGridViewCellEventArgs e)
        {
            if (dtgBuscaPaciente.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dtgBuscaPaciente.SelectedRows[0];
                txtBuscaPaciente.Text = row.Cells["Nome"].Value.ToString();
                dtgBuscaPaciente.Visible = false;
            }
        }

        private void btnSalvarAgendamento_Click(object sender, EventArgs e)
        {
            using (MySqlConnection cn = BancoDados.Conectar())
            {
                string agendamento = "agendamento";
                try
                {
                    cn.Open();
                    bool isUpdate = !string.IsNullOrEmpty(txtIdAgendamento.Text);
                    string sql;
                    if (isUpdate)
                    {
                        sql = "UPDATE agendamentos SET data_hora_agendamento = @data_hora_agendamento, tipo_agendamento = @tipo_agendamento, status = @status, Servicos_id_Servicos = @id_servico, Animais_id_Paciente = @id_animal, Veterinario_id_Veterinario = @id_veterinario where id_agendamentos = @id_agendamentos";
                    }
                    else
                    {
                        sql = "INSERT INTO agendamentos (data_hora_agendamento, tipo_agendamento, status, Servicos_id_Servicos, Animais_id_Paciente, Veterinario_id_Veterinario) VALUES (@data_hora_agendamento, @id_servico, @status, @id_servico, @id_animal, @id_veterinario)";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@data_hora_agendamento", dtpDataHoraAgendamento.Value);
                        cmd.Parameters.AddWithValue("@tipo_agendamento", txtTipoAgendamento.Text);
                        cmd.Parameters.AddWithValue("@status", txtStatus.Text);
                        cmd.Parameters.AddWithValue("@id_servico", idServico);
                        cmd.Parameters.AddWithValue("@id_animal", idAnimal);
                        cmd.Parameters.AddWithValue("@id_veterinario", idVeterinario);
                        if (isUpdate)
                            cmd.Parameters.AddWithValue("@id_agendamentos", Convert.ToInt32(txtIdAgendamento.Text));
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show(isUpdate ? "Agendamento atualizado com sucesso!" : "Agendamento cadastrado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar animal: " + ex.Message);
                }
            }
        }

        private void btnServicos_Click(object sender, EventArgs e)
        {
            Form Servico = new Cadastros(6);
            DialogResult resp = Servico.ShowDialog();
        }
        private void configuraGrid()
        {
            dtgBuscaPaciente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgBuscaPaciente.MultiSelect = false;
            dtgBuscaPaciente.ReadOnly = true;
            dtgBuscaPaciente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgBuscaPaciente.AllowUserToAddRows = false;
        }

        private void carregaDadosGridAgendamento()
        {
            using (MySqlConnection cn = BancoDados.Conectar())
            {
                try
                {
                    cn.Open();

                    // Lógica para alternar o filtro
                    string condicaoFiltro;
                    if (filtroConcluidosAtivo)
                    {
                        // Filtro para CONCLUÍDOS
                        condicaoFiltro = " status = 'Concluído' ";
                    }
                    else
                    {
                        // Filtro PADRÃO (Não Concluído)
                        condicaoFiltro = " status != 'Concluído' ";
                    }

                    // Monta a query usando a condição de filtro
                    string query = $@" 
                        SELECT 
                            id_agendamentos, 
                            data_hora_agendamento AS 'Data e Hora', 
                            tipo_agendamento AS Tipo, 
                            status AS Status,
                            Animais_id_Paciente, 
                            Servicos_id_Servicos,
                            Veterinario_id_Veterinario
                        FROM Agendamentos 
                        WHERE {condicaoFiltro} 
                        ORDER BY data_hora_agendamento;";

                    using (MySqlCommand cmd = new MySqlCommand(query, cn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dtgAgendamentos.DataSource = dt;

                            // Ocultar colunas de ID (MUITO IMPORTANTE!)
                            if (dtgAgendamentos.Columns.Contains("id_agendamentos"))
                                dtgAgendamentos.Columns["id_agendamentos"].Visible = false;
                            if (dtgAgendamentos.Columns.Contains("Animais_id_Paciente"))
                                dtgAgendamentos.Columns["Animais_id_Paciente"].Visible = false;
                            if (dtgAgendamentos.Columns.Contains("Servicos_id_Servicos"))
                                dtgAgendamentos.Columns["Servicos_id_Servicos"].Visible = false;
                            if (dtgAgendamentos.Columns.Contains("Veterinario_id_Veterinario"))
                                dtgAgendamentos.Columns["Veterinario_id_Veterinario"].Visible = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar agendamentos: " + ex.Message);
                }
            }
        }
        private void dtgAgendamento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            insertDadosGridAgendamento(e);
        }
        private void insertDadosGridAgendamento(DataGridViewCellEventArgs e)
        {
            if (dtgAgendamentos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dtgAgendamentos.SelectedRows[0];

                txtIdAgendamento.Text = row.Cells["id_agendamentos"].Value.ToString();
                txtIdAnimal.Text = row.Cells["Animais_id_Paciente"].Value.ToString();
                txtStatus.Text = row.Cells["Status"].Value.ToString();
                txtTipoAgendamento.Text = row.Cells["Tipo"].Value.ToString();
                dtpDataHoraAgendamento.Value = Convert.ToDateTime(row.Cells["Data e Hora"].Value);
                cbxServicos.Text = row.Cells["Servicos_id_Servicos"].Value.ToString();
                int.TryParse(txtIdAnimal.Text, out idAnimal);
            }
        }

        private void btnFiltrarConcluidos_Click(object sender, EventArgs e)
        {
            // 1. Inverte o estado do filtro
            filtroConcluidosAtivo = !filtroConcluidosAtivo;

            // 2. Atualiza o texto do botão
            if (filtroConcluidosAtivo)
            {
                btnFiltrarConcluidos.Text = "Mostrar Pendentes";
            }
            else
            {
                btnFiltrarConcluidos.Text = "Mostrar Concluídos";
            }

            // 3. Atualiza o DataGrid com a nova query
            carregaDadosGridAgendamento();
        }
        private void configuraGridAgendamento()
        {
            dtgAgendamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgAgendamentos.MultiSelect = false;
            dtgAgendamentos.ReadOnly = true;
            dtgAgendamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgAgendamentos.AllowUserToAddRows = false;
        }
    }
}

