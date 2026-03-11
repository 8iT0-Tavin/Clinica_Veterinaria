namespace ClinicaVeterinaria
{
    partial class Agendamentos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtStatus = new System.Windows.Forms.ComboBox();
            this.txtIdAnimal = new System.Windows.Forms.Label();
            this.dtgBuscaPaciente = new System.Windows.Forms.DataGridView();
            this.txtTipoAgendamento = new System.Windows.Forms.TextBox();
            this.txtIdAgendamento = new System.Windows.Forms.Label();
            this.btnSalvarAgendamento = new System.Windows.Forms.Button();
            this.cbxServicos = new System.Windows.Forms.ComboBox();
            this.txtBuscaPaciente = new System.Windows.Forms.TextBox();
            this.cmbVaterinarios = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDataHoraAgendamento = new System.Windows.Forms.DateTimePicker();
            this.btnServicos = new System.Windows.Forms.Button();
            this.dtgAgendamentos = new System.Windows.Forms.DataGridView();
            this.btnFiltrarConcluidos = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBuscaPaciente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAgendamentos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtStatus);
            this.panel1.Controls.Add(this.txtIdAnimal);
            this.panel1.Controls.Add(this.dtgBuscaPaciente);
            this.panel1.Controls.Add(this.txtTipoAgendamento);
            this.panel1.Controls.Add(this.txtIdAgendamento);
            this.panel1.Controls.Add(this.btnSalvarAgendamento);
            this.panel1.Controls.Add(this.cbxServicos);
            this.panel1.Controls.Add(this.txtBuscaPaciente);
            this.panel1.Controls.Add(this.cmbVaterinarios);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpDataHoraAgendamento);
            this.panel1.Controls.Add(this.btnServicos);
            this.panel1.Location = new System.Drawing.Point(21, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(831, 503);
            this.panel1.TabIndex = 1;
            // 
            // txtStatus
            // 
            this.txtStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.FormattingEnabled = true;
            this.txtStatus.Items.AddRange(new object[] {
            "Agendado",
            "Pendente",
            "Concluído",
            "Cancelado"});
            this.txtStatus.Location = new System.Drawing.Point(33, 225);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(342, 33);
            this.txtStatus.TabIndex = 18;
            // 
            // txtIdAnimal
            // 
            this.txtIdAnimal.AutoSize = true;
            this.txtIdAnimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdAnimal.Location = new System.Drawing.Point(541, 27);
            this.txtIdAnimal.Name = "txtIdAnimal";
            this.txtIdAnimal.Size = new System.Drawing.Size(93, 25);
            this.txtIdAnimal.TabIndex = 17;
            this.txtIdAnimal.Text = "Id Animal";
            // 
            // dtgBuscaPaciente
            // 
            this.dtgBuscaPaciente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBuscaPaciente.Location = new System.Drawing.Point(395, 78);
            this.dtgBuscaPaciente.Name = "dtgBuscaPaciente";
            this.dtgBuscaPaciente.RowHeadersWidth = 51;
            this.dtgBuscaPaciente.RowTemplate.Height = 24;
            this.dtgBuscaPaciente.Size = new System.Drawing.Size(420, 116);
            this.dtgBuscaPaciente.TabIndex = 16;
            this.dtgBuscaPaciente.Visible = false;
            this.dtgBuscaPaciente.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBusca_CellClick);
            // 
            // txtTipoAgendamento
            // 
            this.txtTipoAgendamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoAgendamento.Location = new System.Drawing.Point(33, 123);
            this.txtTipoAgendamento.Name = "txtTipoAgendamento";
            this.txtTipoAgendamento.Size = new System.Drawing.Size(342, 30);
            this.txtTipoAgendamento.TabIndex = 14;
            // 
            // txtIdAgendamento
            // 
            this.txtIdAgendamento.AutoSize = true;
            this.txtIdAgendamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdAgendamento.Location = new System.Drawing.Point(42, 352);
            this.txtIdAgendamento.Name = "txtIdAgendamento";
            this.txtIdAgendamento.Size = new System.Drawing.Size(0, 25);
            this.txtIdAgendamento.TabIndex = 13;
            // 
            // btnSalvarAgendamento
            // 
            this.btnSalvarAgendamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvarAgendamento.Location = new System.Drawing.Point(624, 409);
            this.btnSalvarAgendamento.Name = "btnSalvarAgendamento";
            this.btnSalvarAgendamento.Size = new System.Drawing.Size(191, 73);
            this.btnSalvarAgendamento.TabIndex = 12;
            this.btnSalvarAgendamento.Text = "Salvar Agendamento";
            this.btnSalvarAgendamento.UseVisualStyleBackColor = true;
            this.btnSalvarAgendamento.Click += new System.EventHandler(this.btnSalvarAgendamento_Click);
            // 
            // cbxServicos
            // 
            this.cbxServicos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxServicos.FormattingEnabled = true;
            this.cbxServicos.Location = new System.Drawing.Point(33, 316);
            this.cbxServicos.Name = "cbxServicos";
            this.cbxServicos.Size = new System.Drawing.Size(342, 33);
            this.cbxServicos.TabIndex = 11;
            // 
            // txtBuscaPaciente
            // 
            this.txtBuscaPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscaPaciente.Location = new System.Drawing.Point(395, 51);
            this.txtBuscaPaciente.Name = "txtBuscaPaciente";
            this.txtBuscaPaciente.Size = new System.Drawing.Size(420, 30);
            this.txtBuscaPaciente.TabIndex = 10;
            this.txtBuscaPaciente.TextChanged += new System.EventHandler(this.txtBuscaPaciente_TextChanged);
            // 
            // cmbVaterinarios
            // 
            this.cmbVaterinarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVaterinarios.FormattingEnabled = true;
            this.cmbVaterinarios.Location = new System.Drawing.Point(395, 225);
            this.cmbVaterinarios.Name = "cmbVaterinarios";
            this.cmbVaterinarios.Size = new System.Drawing.Size(420, 33);
            this.cmbVaterinarios.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(390, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(196, 25);
            this.label6.TabIndex = 8;
            this.label6.Text = "Nome do Veterinário:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(390, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Nome Paciente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 288);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Serviço:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(229, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Status do Agendamento:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tipo de Agendamento:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Data e hora:";
            // 
            // dtpDataHoraAgendamento
            // 
            this.dtpDataHoraAgendamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDataHoraAgendamento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataHoraAgendamento.Location = new System.Drawing.Point(35, 49);
            this.dtpDataHoraAgendamento.Name = "dtpDataHoraAgendamento";
            this.dtpDataHoraAgendamento.Size = new System.Drawing.Size(340, 30);
            this.dtpDataHoraAgendamento.TabIndex = 2;
            // 
            // btnServicos
            // 
            this.btnServicos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServicos.Location = new System.Drawing.Point(11, 447);
            this.btnServicos.Name = "btnServicos";
            this.btnServicos.Size = new System.Drawing.Size(103, 35);
            this.btnServicos.TabIndex = 1;
            this.btnServicos.Text = "Serviços";
            this.btnServicos.UseVisualStyleBackColor = true;
            this.btnServicos.Click += new System.EventHandler(this.btnServicos_Click);
            // 
            // dtgAgendamentos
            // 
            this.dtgAgendamentos.AllowUserToAddRows = false;
            this.dtgAgendamentos.AllowUserToDeleteRows = false;
            this.dtgAgendamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAgendamentos.Location = new System.Drawing.Point(885, 51);
            this.dtgAgendamentos.Name = "dtgAgendamentos";
            this.dtgAgendamentos.ReadOnly = true;
            this.dtgAgendamentos.RowHeadersWidth = 51;
            this.dtgAgendamentos.RowTemplate.Height = 24;
            this.dtgAgendamentos.Size = new System.Drawing.Size(588, 490);
            this.dtgAgendamentos.TabIndex = 2;
            this.dtgAgendamentos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgAgendamento_CellClick);
            // 
            // btnFiltrarConcluidos
            // 
            this.btnFiltrarConcluidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrarConcluidos.Location = new System.Drawing.Point(885, 559);
            this.btnFiltrarConcluidos.Name = "btnFiltrarConcluidos";
            this.btnFiltrarConcluidos.Size = new System.Drawing.Size(221, 50);
            this.btnFiltrarConcluidos.TabIndex = 19;
            this.btnFiltrarConcluidos.Text = "Mostrar Pendentes";
            this.btnFiltrarConcluidos.UseVisualStyleBackColor = true;
            this.btnFiltrarConcluidos.Click += new System.EventHandler(this.btnFiltrarConcluidos_Click);
            // 
            // Agendamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1496, 778);
            this.Controls.Add(this.btnFiltrarConcluidos);
            this.Controls.Add(this.dtgAgendamentos);
            this.Controls.Add(this.panel1);
            this.Name = "Agendamentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Agendamentos";
            this.Load += new System.EventHandler(this.Agendamentos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBuscaPaciente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAgendamentos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDataHoraAgendamento;
        private System.Windows.Forms.Button btnServicos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbVaterinarios;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxServicos;
        private System.Windows.Forms.TextBox txtBuscaPaciente;
        private System.Windows.Forms.Button btnSalvarAgendamento;
        private System.Windows.Forms.Label txtIdAgendamento;
        private System.Windows.Forms.TextBox txtTipoAgendamento;
        private System.Windows.Forms.DataGridView dtgBuscaPaciente;
        private System.Windows.Forms.Label txtIdAnimal;
        private System.Windows.Forms.DataGridView dtgAgendamentos;
        private System.Windows.Forms.ComboBox txtStatus;
        private System.Windows.Forms.Button btnFiltrarConcluidos;
    }
}