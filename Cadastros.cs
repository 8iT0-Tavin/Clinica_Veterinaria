using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ClinicaVeterinaria
{
    public partial class Cadastros : Form
    {
        public Cadastros(int VisibilidadePanel)
        {
            InitializeComponent();
            if (VisibilidadePanel == 1)
            {
                pnlTutor.Visible = true;
                pnlAnimal.Visible = false;
                pnlMedicamentos.Visible = false;
                pnlServicos.Visible = false;
                pnlVacinas.Visible = false;
                pnlVeterinario.Visible = false;
                lblTituloBusca.Text = "Tutores";
                lblTituloCadastro.Text = "Cadastro de Tutores";
                btnNovoCadastro.Text = "Novo Tutor";
                txtIdTutor.Text = "";
            }
            if (VisibilidadePanel == 2)
            {
                pnlTutor.Visible = false;
                pnlAnimal.Visible = true;
                pnlMedicamentos.Visible = false;
                pnlServicos.Visible = false;
                pnlVacinas.Visible = false;
                pnlVeterinario.Visible = false;
                lblTituloBusca.Text = "Animais";
                lblTituloCadastro.Text = "Cadastro de Animais";
                btnNovoCadastro.Text = "Novo Animal";
                txtIdAnimal.Text = "";
            }
            if (VisibilidadePanel == 3)
            {
                pnlTutor.Visible = false;
                pnlAnimal.Visible = false;
                pnlMedicamentos.Visible = true;
                pnlServicos.Visible = false;
                pnlVacinas.Visible = false;
                pnlVeterinario.Visible = false;
                lblTituloBusca.Text = "Medicamentos";
                lblTituloCadastro.Text = "Cadastro Medicamentos";
                btnNovoCadastro.Text = "Novo Medicamento";
                txtIdMedicamento.Text = "";

            }
            if (VisibilidadePanel == 4)
            {
                pnlTutor.Visible = false;
                pnlAnimal.Visible = false;
                pnlMedicamentos.Visible = false;
                pnlServicos.Visible = false;
                pnlVacinas.Visible = true;
                pnlVeterinario.Visible = false;
                lblTituloBusca.Text = "Vacinas";
                lblTituloCadastro.Text = "Cadastro Vacinas";
                btnNovoCadastro.Text = "Nova Vacina";
                txtIdVacina.Text = "";
            }
            if (VisibilidadePanel == 5)
            {
                pnlTutor.Visible = false;
                pnlAnimal.Visible = false;
                pnlMedicamentos.Visible = false;
                pnlServicos.Visible = false;
                pnlVacinas.Visible = false;
                pnlVeterinario.Visible = true;
                lblTituloBusca.Text = "Veterinários";
                lblTituloCadastro.Text = "Cadastro Veterinário";
                btnNovoCadastro.Text = "Novo Veterinário";
                txtIdVeterinario.Text = "";

            }
            if(VisibilidadePanel == 6)
            {
                pnlTutor.Visible = false;
                pnlAnimal.Visible = false;
                pnlMedicamentos.Visible = false;
                pnlServicos.Visible = true;
                pnlVacinas.Visible = false;
                pnlVeterinario.Visible = false;
                lblTituloBusca.Text = "Serviços";
                lblTituloCadastro.Text = "Cadastro Serviços";
                btnNovoCadastro.Text = "Novo Serviço";
                txtIdServico.Text = "";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void btnSalvarVacina_Click(object sender, EventArgs e)
        {
            using(MySqlConnection cn = BancoDados.Conectar())
            {
                try
                {
                    cn.Open();
                    string sql;
                    bool isUpdate = !string.IsNullOrEmpty(txtIdVacina.Text);
                    if (isUpdate)
                    {
                        sql = "UPDATE vacinas SET Nome_Vacinas = @nome_vacina, Lote_Vacina = @lote, Validade = @validade, Doses = @doses WHERE id_Vacinas = @id_Vacinas";
                    }
                    else
                    {
                        sql = "INSERT INTO vacinas (Nome_Vacinas, Lote_Vacina, Validade, Doses) VALUES (@nome_vacina, @lote, @validade, @doses)";
                    }
                    using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@nome_vacina", txtVacina.Text);
                        cmd.Parameters.AddWithValue("@lote", txtLoteVacina.Text);
                        cmd.Parameters.AddWithValue("@doses", txtDoses.Text);
                        cmd.Parameters.AddWithValue("@validade", dtpValidadeVacina.Value);
                        if (isUpdate)
                            cmd.Parameters.AddWithValue("@id_Vacinas", Convert.ToInt32(txtIdVacina.Text));
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Vacina cadastrada com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar vacina: " + ex.Message);
                }
            }
        }
        private void btnSalvarMedicamento_Click(object sender, EventArgs e)
        {
            using (MySqlConnection cn = BancoDados.Conectar())
            {
                try
                {
                    cn.Open();
                    string sql;
                    bool isUpdate = !string.IsNullOrEmpty(txtIdMedicamento.Text);
                    if (isUpdate)
                    {
                        sql = "UPDATE medicamentos SET nome_med = @nome_med, validade_med = @validade_med, dosagem = @dosagem, Preco_venda = @preco_venda, Preco_custo = @preco_custo, quantidade_estoque = @quantidade_estoque WHERE id_medicamentos = @id_medicamentos";
                    }
                    else 
                    {
                        sql = "INSERT INTO medicamentos (nome_med, validade_med, dosagem, Preco_venda, Preco_custo, quantidade_estoque) VALUES (@nome_med, @validade_med, @dosagem, @preco_venda, @preco_custo, @quantidade_estoque)";
                    }
                    using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@nome_med", txtMedicamento.Text);
                        cmd.Parameters.AddWithValue("@validade_med", dtpValidadeMed.Value);
                        cmd.Parameters.AddWithValue("@dosagem", txtDosagem.Text);
                        cmd.Parameters.AddWithValue("@preco_venda", txtPrecoVendaMed.Text);
                        cmd.Parameters.AddWithValue("@preco_custo", txtPrecoCustoMed.Text);
                        cmd.Parameters.AddWithValue("@quantidade_estoque", txtQuantidadeMed.Text);
                        if (isUpdate)
                            cmd.Parameters.AddWithValue("@id_medicamentos", Convert.ToInt32(txtIdMedicamento.Text));
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show(isUpdate ? "Medicamento atualizado com sucesso!" : "Medicamento cadastrado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar medicamento: " + ex.Message);
                }
            }
        }

        private void btnSalvarVet_Click(object sender, EventArgs e)
        {
            using(MySqlConnection cn = BancoDados.Conectar())
            {
                try
                {
                    cn.Open();
                    string sql;
                    bool isUpdate = !string.IsNullOrEmpty(txtIdVeterinario.Text);
                    if (isUpdate)
                    {
                        sql = "UPDATE Veterinario SET Nome = @nome_vet, Sobrenome = @sobrenome_vet, CRMV = @crmv, Especialidade = @especialidade, Telefone = @telefone WHERE id_Veterinario = @id_Veterinario";
                    }
                    else
                    {
                        sql = "INSERT INTO Veterinario (Nome, Sobrenome, CRMV, Especialidade, Telefone) VALUES (@nome_vet, @sobrenome_vet, @crmv, @especialidade, @telefone)";
                    }
                    using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@nome_vet", txtNomeVeterinario.Text);
                        cmd.Parameters.AddWithValue("@sobrenome_vet", txtSobrenomeVeterinario);
                        cmd.Parameters.AddWithValue("@crmv", txtCMRV.Text);
                        cmd.Parameters.AddWithValue("@especialidade", txtEspecialidade.Text);
                        cmd.Parameters.AddWithValue("@telefone", txtTelefoneVeterinario);
                        if (isUpdate)
                            cmd.Parameters.AddWithValue("@id_Veterinario", Convert.ToInt32(txtIdVeterinario.Text));
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show(isUpdate ? "Veterinário atualizado com sucesso!" : "Veterinário cadastrado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar veterinário: " + ex.Message);
                }
            }
        }

        private void btnSalvarServico_Click(object sender, EventArgs e)
        {
            using(MySqlConnection cn = BancoDados.Conectar())
            {
                try
                {
                    cn.Open();
                    string sql;
                    bool isUpdate = !string.IsNullOrEmpty(txtIdServico.Text);
                    if (isUpdate)
                    {
                        sql = "UPDATE Servicos SET nome_servico = @nome_servico, descricao = @descricao, valor_servico = @preco WHERE id_Servicos = @id_Servicos";
                    }
                    else
                    {
                        sql = "INSERT INTO Servicos (nome_servico, descricao, valor_servico) VALUES (@nome_servico, @descricao, @preco)";
                    }
                    using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@nome_servico", txtNomeServico.Text);
                        cmd.Parameters.AddWithValue("@descricao", rtxDescricaoServico.Text);
                        cmd.Parameters.AddWithValue("@preco", txtValorServico.Text);
                        if (isUpdate)
                            cmd.Parameters.AddWithValue("@id_Servicos", Convert.ToInt32(txtIdServico.Text));
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show(isUpdate ? "Serviço atualizado com sucesso!" : "Serviço cadastrado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar serviço: " + ex.Message);
                }
            }
        }

        private void btnSalvarAnimal_Click(object sender, EventArgs e)
        {
            using(MySqlConnection cn = BancoDados.Conectar())
            {
                try
                {
                    cn.Open();
                    bool isUpdate = !string.IsNullOrEmpty(txtIdAnimal.Text);
                    string sql;
                    if (isUpdate)
                    {
                        sql = "UPDATE Animais SET Nome_Animal = @nome_animal, Especie = @especie, Raca = @raca, data_Nascimento = @idade, Sexo = @sexo, Peso = @peso, Tutores_idTutores = @tutor_id WHERE id_Paciente = @id_Paciente";
                    }
                    else 
                    {
                        sql = "INSERT INTO Animais (Nome_Animal, Especie, Raca, data_Nascimento, Sexo, Peso, Tutores_idTutores) VALUES (@nome_animal, @especie, @raca, @idade, @sexo, @peso, @tutor_id)";
                    }
                    
                    using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@nome_animal", txtNomeAnimal.Text);
                        cmd.Parameters.AddWithValue("@especie", txtEspecie.Text);
                        cmd.Parameters.AddWithValue("@raca", txtRaca.Text);
                        cmd.Parameters.AddWithValue("@idade", dtpNascimentoAnimal.Value); 
                        cmd.Parameters.AddWithValue("@sexo", cmbSexo.SelectedItem?.ToString() ?? ""); 
                        cmd.Parameters.AddWithValue("@peso", Convert.ToDecimal(txtPeso.Text));
                        cmd.Parameters.AddWithValue("@tutor_id", Convert.ToInt32(txtTutorAnimal.Text));
                        if (isUpdate)
                            cmd.Parameters.AddWithValue("@id_Paciente", Convert.ToInt32(txtIdAnimal.Text));
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show(isUpdate ? "Animal atualizado com sucesso!" : "Animal cadastrado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar animal: " + ex.Message);
                }
            }
        }
        private void btnSalvarTutor_Click(object sender, EventArgs e)
        {
            using (MySqlConnection cn = BancoDados.Conectar())
            {
                try
                {
                    bool isUpdate = !string.IsNullOrEmpty(txtIdTutor.Text);
                    cn.Open();
                    if (isUpdate == true)
                    {
                        string updateTutor = "UPDATE Tutores SET Nome = @nome_tutor, Sobrenome = @sobrenome_tutor, CPF = @cpf, Telefone = @telefone, Email = @email, Endereco = @endereco WHERE id_Tutores = @id_Tutores";
                        using (MySqlCommand cmd = new MySqlCommand(updateTutor, cn))
                        {
                            cmd.Parameters.AddWithValue("@nome_tutor", txtNomeTutor.Text);
                            cmd.Parameters.AddWithValue("@sobrenome_tutor", txtSobrenomeTutor.Text);
                            cmd.Parameters.AddWithValue("@cpf", txtCPFTutor.Text);
                            cmd.Parameters.AddWithValue("@telefone", txtTelefoneTutor.Text);
                            cmd.Parameters.AddWithValue("@email", txtEmailTutor.Text);
                            cmd.Parameters.AddWithValue("@endereco", txtEnderecoTutor.Text);
                            cmd.Parameters.AddWithValue("@id_Tutores", Convert.ToInt32(txtIdTutor.Text));
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Tutor atualizado com sucesso!");
                    }
                    else
                    {
                        string insertTutor = "INSERT INTO Tutores (Nome, Sobrenome, CPF, Telefone, Email, Endereco) VALUES (@nome_tutor, @sobrenome_tutor, @cpf, @telefone, @email, @endereco)";
                        using (MySqlCommand cmd = new MySqlCommand(insertTutor, cn))
                        {
                            cmd.Parameters.AddWithValue("@nome_tutor", txtNomeTutor.Text);
                            cmd.Parameters.AddWithValue("@sobrenome_tutor", txtSobrenomeTutor.Text);
                            cmd.Parameters.AddWithValue("@cpf", txtCPFTutor.Text);
                            cmd.Parameters.AddWithValue("@telefone", txtTelefoneTutor.Text);
                            cmd.Parameters.AddWithValue("@email", txtEmailTutor.Text);
                            cmd.Parameters.AddWithValue("@endereco", txtEnderecoTutor.Text);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Tutor cadastrado com sucesso!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar tutor: " + ex.Message);
                }
            }
        }

        private void btnNovoCadastro_Click(object sender, EventArgs e)
        {
            if (pnlAnimal.Visible == true) {
                limpaDadosAnimal();
            }
            if (pnlTutor.Visible == true)
            {
                limpaDadosTutor();
            }
            if(pnlMedicamentos.Visible == true)
            {
                limpaDadosMedicamento();
            }
            if (pnlServicos.Visible == true)
            {
                txtNomeServico.Clear();
                rtxDescricaoServico.Clear();
                txtValorServico.Clear();
            }
            if (pnlVacinas.Visible == true)
            {
                txtVacina.Clear();
                txtLoteVacina.Clear();
                txtDoses.Clear();
                dtpValidadeVacina.Value = DateTime.Now;
            }
            if (pnlVeterinario.Visible == true)
            {
                limpaDadosVeterinario();
            }
        }

        private void limpaDadosAnimal()
        {
            txtNomeAnimal.Clear();
            txtEspecie.Clear();
            txtRaca.Clear();
            dtpNascimentoAnimal.Value = DateTime.Now;
            cmbSexo.SelectedIndex = -1;
            txtPeso.Clear();
            txtTutorAnimal.Clear();
        }

        private void limpaDadosTutor()
        {
            txtNomeTutor.Clear();
            txtSobrenomeTutor.Clear();
            txtCPFTutor.Clear();
            txtTelefoneTutor.Clear();
            txtEmailTutor.Clear();
            txtEnderecoTutor.Clear();
        }

        private void limpaDadosMedicamento()
        {
            txtMedicamento.Clear();
            dtpValidadeMed.Value = DateTime.Now;
            txtDosagem.Clear();
            txtPrecoVendaMed.Clear();
            txtPrecoCustoMed.Clear();
            txtQuantidadeMed.Clear();
        }
        private void limpaDadosVeterinario()
        {
            txtNomeVeterinario.Clear();
            txtSobrenomeVeterinario.Clear();
            txtCMRV.Clear();
            txtEspecialidade.Clear();
            txtTelefoneVeterinario.Clear();
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            dtgBusca.Visible = true;
            configuraGrid();
            if (txtBusca.Text == "")
            {
                dtgBusca.Visible = false;
            }
            if (lblTituloBusca.Text == "Tutores")
            {
                string tabela = "tutores";
                string coluna = "Nome";
                carregaDadosGrid(tabela, coluna);
            }
            if (lblTituloBusca.Text == "Animais")
            {
                string tabela = "animais";
                string coluna = "Nome_Animal";
                carregaDadosGrid(tabela, coluna);
            }
            if (lblTituloBusca.Text == "Medicamentos")
            {
                string tabela = "medicamentos";
                string coluna = "nome_med";
                carregaDadosGrid(tabela, coluna);
            }
            if (lblTituloBusca.Text == "Vacinas")
            {
                string tabela = "vacinas";
                string coluna = "Nome_Vacinas";
                carregaDadosGrid(tabela, coluna);
            }
            if (lblTituloBusca.Text == "Veterinários")
            {
                string tabela = "veterinario";
                string coluna = "Nome";
                carregaDadosGrid(tabela,coluna);
            }
            if (lblTituloBusca.Text == "Serviços")
            {
                string tabela = "servicos";
                string coluna = "nome_servico";
                carregaDadosGrid(tabela, coluna);
            }
        }
        private void carregaDadosGrid(string tabela, string coluna)
        {
            using (MySqlConnection cn = BancoDados.Conectar())
            {
                try
                {
                    cn.Open();
                    string query = $"SELECT * FROM {tabela} WHERE {coluna} LIKE @busca ";
                    using (MySqlCommand cmd = new MySqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@busca", "%" + txtBusca.Text + "%");
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dtgBusca.DataSource = dt;
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
            dtgBusca.Visible = false;
        }
        private void insertDadosGrid(DataGridViewCellEventArgs e)
        {
            if(dtgBusca.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dtgBusca.SelectedRows[0];
                if (lblTituloBusca.Text == "Tutores")
                {
                    txtIdTutor.Text = row.Cells["id_Tutores"].Value.ToString();
                    txtNomeTutor.Text = row.Cells["Nome"].Value.ToString();
                    txtSobrenomeTutor.Text = row.Cells["Sobrenome"].Value.ToString();
                    txtCPFTutor.Text = row.Cells["CPF"].Value.ToString();
                    txtTelefoneTutor.Text = row.Cells["Telefone"].Value.ToString();
                    txtEmailTutor.Text = row.Cells["Email"].Value.ToString();
                    txtEnderecoTutor.Text = row.Cells["Endereco"].Value.ToString();
                }
                if (lblTituloBusca.Text == "Animais")
                {
                    txtIdAnimal.Text = row.Cells["id_Paciente"].Value.ToString();
                    txtNomeAnimal.Text = row.Cells["Nome_Animal"].Value.ToString();
                    txtEspecie.Text = row.Cells["Especie"].Value.ToString();
                    txtRaca.Text = row.Cells["Raca"].Value.ToString();
                    dtpNascimentoAnimal.Value = Convert.ToDateTime(row.Cells["data_Nascimento"].Value);
                    cmbSexo.SelectedItem = row.Cells["Sexo"].Value.ToString();
                    txtPeso.Text = row.Cells["Peso"].Value.ToString();
                    txtTutorAnimal.Text = row.Cells["Tutores_idTutores"].Value.ToString();
                }
                if (lblTituloBusca.Text == "Medicamentos")
                {
                    txtMedicamento.Text = row.Cells["id_medicamentos"].Value.ToString();
                    txtMedicamento.Text = row.Cells["nome_med"].Value.ToString();
                    dtpValidadeMed.Value = Convert.ToDateTime(row.Cells["validade_med"].Value);
                    txtDosagem.Text = row.Cells["dosagem"].Value.ToString();
                    txtPrecoVendaMed.Text = row.Cells["Preco_venda"].Value.ToString();
                    txtPrecoCustoMed.Text = row.Cells["Preco_custo"].Value.ToString();
                    txtQuantidadeMed.Text = row.Cells["quantidade_estoque"].Value.ToString();
                }
                if (lblTituloBusca.Text == "Vacinas")
                {
                    txtIdVacina.Text = row.Cells["id_Vacinas"].Value.ToString();
                    txtVacina.Text = row.Cells["Nome_Vacinas"].Value.ToString();
                    txtLoteVacina.Text = row.Cells["Lote_Vacina"].Value.ToString();
                    dtpValidadeVacina.Value = Convert.ToDateTime(row.Cells["Validade"].Value);
                    txtDoses.Text = row.Cells["Doses"].Value.ToString();
                }
                if (lblTituloBusca.Text == "Veterinários")
                {
                    txtIdVeterinario.Text = row.Cells["id_Veterinario"].Value.ToString();
                    txtNomeVeterinario.Text = row.Cells["Nome"].Value.ToString();
                    txtSobrenomeVeterinario.Text = row.Cells["Sobrenome"].Value.ToString();
                    txtCMRV.Text = row.Cells["CRMV"].Value.ToString();
                    txtEspecialidade.Text = row.Cells["Especialidade"].Value.ToString();
                    txtTelefoneVeterinario.Text = row.Cells["Telefone"].Value.ToString();
                }
                if (lblTituloBusca.Text == "Serviços")
                {
                    txtIdServico.Text = row.Cells["id_Servicos"].Value.ToString();
                    txtNomeServico.Text = row.Cells["nome_servico"].Value.ToString();
                    rtxDescricaoServico.Text = row.Cells["descricao"].Value.ToString();
                    txtValorServico.Text = row.Cells["valor_servico"].Value.ToString();
                }
            }
        }
        private void configuraGrid()
        {
            dtgBusca.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgBusca.MultiSelect = false;
            dtgBusca.ReadOnly = true;
            dtgBusca.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgBusca.AllowUserToAddRows = false;
        }
    }
}

