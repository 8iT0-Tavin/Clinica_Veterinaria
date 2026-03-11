using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Globalization; // Necessário para Parse de decimal

namespace ClinicaVeterinaria
{
    public partial class RelatorioVendas : Form
    {
        public RelatorioVendas()
        {
            InitializeComponent();
        }

        private void RelatorioVendas_Load(object sender, EventArgs e)
        {

        }

        public void CarregarGridVendas()
        {
            // --- 1. COLETA E TRATAMENTO DOS FILTROS ---

            DateTime? dtIni = dtpDataInicio.Checked ? dtpDataInicio.Value.Date : (DateTime?)null;
            DateTime? dtFim = dtpDataFim.Checked ? dtpDataFim.Value.Date : (DateTime?)null;
            decimal? valMin = null;

            if (!string.IsNullOrEmpty(txtValorMinimo.Text))
            {
                // Tenta converter o texto para decimal (usando cultura pt-BR para vírgula, se aplicável)
                if (decimal.TryParse(txtValorMinimo.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-BR"), out decimal valor))
                {
                    valMin = valor;
                }
                else
                {
                    MessageBox.Show("Valor mínimo inválido. Por favor, insira um número válido.", "Erro de Filtro");
                    return;
                }
            }

            // --- 2. EXECUÇÃO DA CONSULTA ---
            using (MySqlConnection cn = BancoDados.Conectar())
            {
                try
                {
                    cn.Open();
                    // Chamada da Stored Procedure corrigida
                    string sql = "CALL Consultar_Vendas_Resumo(@data_inicio, @data_fim, @valor_min);";

                    using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    {
                        // Mapeamento dos filtros para os parâmetros da Stored Procedure (Chave do Filtro Opcional)
                        cmd.Parameters.AddWithValue("@data_inicio", dtIni.HasValue ? (object)dtIni.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@data_fim", dtFim.HasValue ? (object)dtFim.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@valor_min", valMin.HasValue ? (object)valMin.Value : DBNull.Value);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dtVendas = new DataTable();
                            adapter.Fill(dtVendas);

                            dtgVendasResumo.DataSource = dtVendas;

                            if (dtgVendasResumo.Columns.Contains("id_Venda"))
                            {
                                dtgVendasResumo.Columns["id_Venda"].Visible = false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar vendas: " + ex.Message);
                }
            }
        }

        // Este é o código do evento que você conecta ao botão 'btnBuscar'
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CarregarGridVendas();
        }
    }
}
