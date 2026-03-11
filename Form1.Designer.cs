namespace ClinicaVeterinaria
{
    partial class MENU
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MENU));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnVeterinario = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnVendas = new System.Windows.Forms.Button();
            this.btnAgendamento = new System.Windows.Forms.Button();
            this.btnMedicamento = new System.Windows.Forms.Button();
            this.btnVacina = new System.Windows.Forms.Button();
            this.btnAnimal = new System.Windows.Forms.Button();
            this.btnTutor = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dtgAgendamentos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtgResumo = new System.Windows.Forms.DataGridView();
            this.lblHoraAtual = new System.Windows.Forms.Label();
            this.timerRelogio = new System.Windows.Forms.Timer(this.components);
            this.btnRelatorioVendas = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAgendamentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResumo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRelatorioVendas);
            this.panel1.Controls.Add(this.btnVeterinario);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Controls.Add(this.btnVendas);
            this.panel1.Controls.Add(this.btnAgendamento);
            this.panel1.Controls.Add(this.btnMedicamento);
            this.panel1.Controls.Add(this.btnVacina);
            this.panel1.Controls.Add(this.btnAnimal);
            this.panel1.Controls.Add(this.btnTutor);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(1, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 715);
            this.panel1.TabIndex = 0;
            // 
            // btnVeterinario
            // 
            this.btnVeterinario.Location = new System.Drawing.Point(13, 401);
            this.btnVeterinario.Name = "btnVeterinario";
            this.btnVeterinario.Size = new System.Drawing.Size(225, 42);
            this.btnVeterinario.TabIndex = 9;
            this.btnVeterinario.Text = "Novo Veterinário";
            this.btnVeterinario.UseVisualStyleBackColor = true;
            this.btnVeterinario.Click += new System.EventHandler(this.btnVeterinario_Click);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(13, 654);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(225, 42);
            this.btnSair.TabIndex = 8;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnVendas
            // 
            this.btnVendas.Location = new System.Drawing.Point(13, 497);
            this.btnVendas.Name = "btnVendas";
            this.btnVendas.Size = new System.Drawing.Size(225, 42);
            this.btnVendas.TabIndex = 7;
            this.btnVendas.Text = "Nova Venda";
            this.btnVendas.UseVisualStyleBackColor = true;
            this.btnVendas.Click += new System.EventHandler(this.btnVendas_Click);
            // 
            // btnAgendamento
            // 
            this.btnAgendamento.Location = new System.Drawing.Point(13, 449);
            this.btnAgendamento.Name = "btnAgendamento";
            this.btnAgendamento.Size = new System.Drawing.Size(225, 42);
            this.btnAgendamento.TabIndex = 5;
            this.btnAgendamento.Text = "Agendamentos";
            this.btnAgendamento.UseVisualStyleBackColor = true;
            this.btnAgendamento.Click += new System.EventHandler(this.btnAgendamentos_Click);
            // 
            // btnMedicamento
            // 
            this.btnMedicamento.Location = new System.Drawing.Point(11, 305);
            this.btnMedicamento.Name = "btnMedicamento";
            this.btnMedicamento.Size = new System.Drawing.Size(225, 42);
            this.btnMedicamento.TabIndex = 4;
            this.btnMedicamento.Text = "Novo Medicamento";
            this.btnMedicamento.UseVisualStyleBackColor = true;
            this.btnMedicamento.Click += new System.EventHandler(this.btnMedicamento_Click);
            // 
            // btnVacina
            // 
            this.btnVacina.Location = new System.Drawing.Point(12, 353);
            this.btnVacina.Name = "btnVacina";
            this.btnVacina.Size = new System.Drawing.Size(225, 42);
            this.btnVacina.TabIndex = 3;
            this.btnVacina.Text = "Nova Vacina";
            this.btnVacina.UseVisualStyleBackColor = true;
            this.btnVacina.Click += new System.EventHandler(this.btnVacina_Click);
            // 
            // btnAnimal
            // 
            this.btnAnimal.Location = new System.Drawing.Point(11, 257);
            this.btnAnimal.Name = "btnAnimal";
            this.btnAnimal.Size = new System.Drawing.Size(225, 42);
            this.btnAnimal.TabIndex = 2;
            this.btnAnimal.Text = "Novo Animal";
            this.btnAnimal.UseVisualStyleBackColor = true;
            this.btnAnimal.Click += new System.EventHandler(this.btnAnimal_Click);
            // 
            // btnTutor
            // 
            this.btnTutor.Location = new System.Drawing.Point(11, 209);
            this.btnTutor.Name = "btnTutor";
            this.btnTutor.Size = new System.Drawing.Size(225, 42);
            this.btnTutor.TabIndex = 1;
            this.btnTutor.Text = "Novo Tutor";
            this.btnTutor.UseVisualStyleBackColor = true;
            this.btnTutor.Click += new System.EventHandler(this.btnTutor_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(11, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(227, 190);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dtgAgendamentos
            // 
            this.dtgAgendamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAgendamentos.Location = new System.Drawing.Point(284, 214);
            this.dtgAgendamentos.Name = "dtgAgendamentos";
            this.dtgAgendamentos.RowHeadersWidth = 51;
            this.dtgAgendamentos.RowTemplate.Height = 24;
            this.dtgAgendamentos.Size = new System.Drawing.Size(579, 378);
            this.dtgAgendamentos.TabIndex = 1;
            this.dtgAgendamentos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBusca_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(278, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "AGENDAMENTOS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(893, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(311, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "RESUMO FINANCEIRO";
            // 
            // dtgResumo
            // 
            this.dtgResumo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgResumo.Location = new System.Drawing.Point(899, 214);
            this.dtgResumo.Name = "dtgResumo";
            this.dtgResumo.RowHeadersWidth = 51;
            this.dtgResumo.RowTemplate.Height = 24;
            this.dtgResumo.Size = new System.Drawing.Size(579, 378);
            this.dtgResumo.TabIndex = 4;
            // 
            // lblHoraAtual
            // 
            this.lblHoraAtual.AutoSize = true;
            this.lblHoraAtual.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoraAtual.Location = new System.Drawing.Point(1325, 30);
            this.lblHoraAtual.Name = "lblHoraAtual";
            this.lblHoraAtual.Size = new System.Drawing.Size(164, 32);
            this.lblHoraAtual.TabIndex = 5;
            this.lblHoraAtual.Text = "Data e hora";
            // 
            // timerRelogio
            // 
            this.timerRelogio.Enabled = true;
            this.timerRelogio.Interval = 1000;
            this.timerRelogio.Tick += new System.EventHandler(this.timerRelogio_Tick);
            // 
            // btnRelatorioVendas
            // 
            this.btnRelatorioVendas.Location = new System.Drawing.Point(13, 545);
            this.btnRelatorioVendas.Name = "btnRelatorioVendas";
            this.btnRelatorioVendas.Size = new System.Drawing.Size(225, 42);
            this.btnRelatorioVendas.TabIndex = 10;
            this.btnRelatorioVendas.Text = "Vendas";
            this.btnRelatorioVendas.UseVisualStyleBackColor = true;
            this.btnRelatorioVendas.Click += new System.EventHandler(this.btnRelatorioVendas_Click);
            // 
            // MENU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1490, 722);
            this.Controls.Add(this.lblHoraAtual);
            this.Controls.Add(this.dtgResumo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgAgendamentos);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MENU";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAgendamentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResumo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnVendas;
        private System.Windows.Forms.Button btnMedicamento;
        private System.Windows.Forms.Button btnVacina;
        private System.Windows.Forms.Button btnAnimal;
        private System.Windows.Forms.Button btnTutor;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dtgAgendamentos;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnVeterinario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dtgResumo;
        private System.Windows.Forms.Label lblHoraAtual;
        private System.Windows.Forms.Timer timerRelogio;
        private System.Windows.Forms.Button btnAgendamento;
        private System.Windows.Forms.Button btnRelatorioVendas;
    }
}

