namespace StudyCenter
{
    partial class Frm_RegistrarMateriaTopico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_RegistrarMateriaTopico));
            Btn_RegistrarMateriaTopico = new Button();
            dateTimePicker1 = new DateTimePicker();
            txt_Exemplo = new TextBox();
            textBox1 = new TextBox();
            Btn_exemploMessageBox = new Button();
            Btn_FecharAplicacao = new Button();
            SuspendLayout();
            // 
            // Btn_RegistrarMateriaTopico
            // 
            Btn_RegistrarMateriaTopico.BackColor = Color.Transparent;
            Btn_RegistrarMateriaTopico.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_RegistrarMateriaTopico.Location = new Point(12, 22);
            Btn_RegistrarMateriaTopico.Name = "Btn_RegistrarMateriaTopico";
            Btn_RegistrarMateriaTopico.Size = new Size(218, 25);
            Btn_RegistrarMateriaTopico.TabIndex = 1;
            Btn_RegistrarMateriaTopico.Text = "Regitrar matéria ou tópico";
            Btn_RegistrarMateriaTopico.UseVisualStyleBackColor = false;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(363, 39);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(243, 23);
            dateTimePicker1.TabIndex = 2;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // txt_Exemplo
            // 
            txt_Exemplo.Location = new Point(80, 135);
            txt_Exemplo.Multiline = true;
            txt_Exemplo.Name = "txt_Exemplo";
            txt_Exemplo.ScrollBars = ScrollBars.Vertical;
            txt_Exemplo.Size = new Size(181, 98);
            txt_Exemplo.TabIndex = 3;
            txt_Exemplo.Text = "Exemplo de texto com ScrollBars ativo";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(337, 135);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(214, 70);
            textBox1.TabIndex = 4;
            textBox1.Text = "Quando eu clicar no + para inserir um novo assunto ou novo topico, eu uso o focus para o cursor já ir para o textbox";
            // 
            // Btn_exemploMessageBox
            // 
            Btn_exemploMessageBox.Location = new Point(92, 318);
            Btn_exemploMessageBox.Name = "Btn_exemploMessageBox";
            Btn_exemploMessageBox.Size = new Size(179, 27);
            Btn_exemploMessageBox.TabIndex = 6;
            Btn_exemploMessageBox.Text = "Btn_exemploMessageBox";
            Btn_exemploMessageBox.UseVisualStyleBackColor = true;
            // 
            // Btn_FecharAplicacao
            // 
            Btn_FecharAplicacao.Location = new Point(722, 519);
            Btn_FecharAplicacao.Name = "Btn_FecharAplicacao";
            Btn_FecharAplicacao.Size = new Size(139, 27);
            Btn_FecharAplicacao.TabIndex = 7;
            Btn_FecharAplicacao.Text = "Fechar programa";
            Btn_FecharAplicacao.UseVisualStyleBackColor = true;
            Btn_FecharAplicacao.Click += Btn_FecharAplicacao_Click;
            // 
            // Frm_RegistrarMateriaTopico
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = Properties.Resources.NovoBackground;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(745, 403);
            Controls.Add(Btn_FecharAplicacao);
            Controls.Add(Btn_exemploMessageBox);
            Controls.Add(textBox1);
            Controls.Add(txt_Exemplo);
            Controls.Add(dateTimePicker1);
            Controls.Add(Btn_RegistrarMateriaTopico);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Frm_RegistrarMateriaTopico";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Study Center";
            Load += Frm_RegistrarMateriaTopico_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private Button Btn_RegistrarMateriaTopico;
        private DateTimePicker dateTimePicker1;
        private TextBox txt_Exemplo;
        private TextBox textBox1;
        private Button Btn_exemploMessageBox;
        private Button Btn_FecharAplicacao;
    }
}
