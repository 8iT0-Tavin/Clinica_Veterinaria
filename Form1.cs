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
    public partial class MENU : Form
    {
        private Timer timerAtualizaGrid;

        public MENU()
        {
            InitializeComponent();
            configuraGrid();
            // Configuração do Timer para Agendamentos
            timerAtualizaGrid = new Timer();
            timerAtualizaGrid.Interval = 5000;
            timerAtualizaGrid.Tick += TimerAtualizaGrid_Tick;
            timerAtualizaGrid.Start();
            carregaDadosGrid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form f = new LoginForm();
            DialogResult resp = f.ShowDialog();

            // Inicialização do Relógio
            lblHoraAtual.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            timerRelogio.Start();

            // CHAMA O NOVO RELATÓRIO DE VENDAS (Últimos 7 dias)
            try
            {
                // 1. CHAMA A FUNÇÃO DE ACESSO A DADOS (Sem parâmetros!)
                DataTable dadosRelatorio = ObterResumoVendas7Dias();

                // 2. VERIFICA SE O RESULTADO TEM LINHAS
                if (dadosRelatorio != null && dadosRelatorio.Rows.Count > 0)
                {
                    // Caso de SUCESSO: DataGridView é preenchida
                    dtgResumo.DataSource = dadosRelatorio;
                    dtgResumo.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
                else
                {
                    // Caso de RESULTADO VAZIO
                    dtgResumo.DataSource = null;
                    MessageBox.Show(
                        "Nenhuma venda encontrada nos últimos 7 dias.",
                        "Relatório Vazio",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                // Caso de ERRO DE BANCO DE DADOS
                MessageBox.Show(
                    "Ocorreu um erro ao carregar o relatório de vendas. Detalhes: " + ex.Message,
                    "Erro de Conexão com o Banco de Dados",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // NOVO MÉTODO: OBTEM RESUMO DE VENDAS (Corrigido para 7 dias e lógica de retorno de DataTable)
        public DataTable ObterResumoVendas7Dias() // Removido o parâmetro de data
        {
            // Alterado o nome para chamar a nova procedure
            string procedureName = "Relatorio_Resumo_Vendas_Ultimos_7_Dias";
            DataTable resumoVendas = new DataTable();

            // Assumindo que BancoDados.Conectar() retorna MySqlConnection
            using (MySqlConnection cn = BancoDados.Conectar())
            {
                try
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(procedureName, cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // REMOVIDO: Linha de adição de parâmetros (procedure não usa mais)

                        using (MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd))
                        {
                            // Preenche a DataTable que será retornada.
                            adaptador.Fill(resumoVendas);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Apenas informa o erro e retorna a DataTable vazia.
                    MessageBox.Show("Erro ao obter o relatório de vendas: " + ex.Message);
                    // Não retorna nada aqui, pois o retorno é feito no final da função.
                }
            }
            return resumoVendas;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void btnTutor_Click(object sender, EventArgs e)
        {
            Form Tutor = new Cadastros(1);
            DialogResult resp = Tutor.ShowDialog();
        }
        private void btnAnimal_Click(object sender, EventArgs e)
        {
            Form Animal = new Cadastros(2);
            DialogResult resp = Animal.ShowDialog();
        }
        private void btnMedicamento_Click(object sender, EventArgs e)
        {
            Form Medicamento = new Cadastros(3);
            DialogResult resp = Medicamento.ShowDialog();
        }
        private void btnVacina_Click(object sender, EventArgs e)
        {
            Form Vacina = new Cadastros(4);
            DialogResult resp = Vacina.ShowDialog();
        }
        private void btnVeterinario_Click(object sender, EventArgs e)
        {
            Form Veterinario = new Cadastros(5);
            DialogResult resp = Veterinario.ShowDialog();
        }
        private void btnAgendamentos_Click(object sender, EventArgs e)
        {
            Form Agendamento = new Agendamentos();
            DialogResult resp = Agendamento.ShowDialog();

        }
        private void carregaDadosGrid()
        {
            using (MySqlConnection cn = BancoDados.Conectar())
            {
                try
                {
                    cn.Open();
                    string query = @" SELECT data_hora_agendamento AS 'Data e Hora', tipo_agendamento AS Tipo, status AS Status FROM Agendamentos WHERE status != 'Concluído' ORDER BY data_hora_agendamento;";
                    using (MySqlCommand cmd = new MySqlCommand(query, cn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dtgAgendamentos.DataSource = dt;
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
            btnAgendamentos_Click(sender, e);
        }

        private void configuraGrid()
        {
            dtgAgendamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgAgendamentos.MultiSelect = false;
            dtgAgendamentos.ReadOnly = true;
            dtgAgendamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgAgendamentos.AllowUserToAddRows = false;
        }
        private void TimerAtualizaGrid_Tick(object sender, EventArgs e)
        {
            carregaDadosGrid();
        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            Form Vendas = new Vendas();
            DialogResult resp = Vendas.ShowDialog();
        }

        private void timerRelogio_Tick(object sender, EventArgs e)
        {
            lblHoraAtual.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }

        private void btnRelatorioVendas_Click(object sender, EventArgs e)
        {
            Form RelatorioVendas = new RelatorioVendas();
            DialogResult resp = RelatorioVendas.ShowDialog();
        }
    }
}