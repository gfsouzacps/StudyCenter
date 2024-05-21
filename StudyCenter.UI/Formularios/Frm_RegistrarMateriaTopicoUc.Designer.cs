namespace StudyCenter.Formularios
{
    partial class Frm_RegistrarMateriaTopicoUc
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

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
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
            Btn_RegistrarMateriaTopico.Font = new Font("Arial", 9.75F, FontStyle.Bold);
            Btn_RegistrarMateriaTopico.Location = new Point(14, 29);
            Btn_RegistrarMateriaTopico.Margin = new Padding(3, 4, 3, 4);
            Btn_RegistrarMateriaTopico.Name = "Btn_RegistrarMateriaTopico";
            Btn_RegistrarMateriaTopico.Size = new Size(249, 33);
            Btn_RegistrarMateriaTopico.TabIndex = 1;
            Btn_RegistrarMateriaTopico.Text = "Regitrar matéria ou tópico";
            Btn_RegistrarMateriaTopico.UseVisualStyleBackColor = false;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(415, 52);
            dateTimePicker1.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(277, 27);
            dateTimePicker1.TabIndex = 2;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // txt_Exemplo
            // 
            txt_Exemplo.Location = new Point(91, 180);
            txt_Exemplo.Margin = new Padding(3, 4, 3, 4);
            txt_Exemplo.Multiline = true;
            txt_Exemplo.Name = "txt_Exemplo";
            txt_Exemplo.ScrollBars = ScrollBars.Vertical;
            txt_Exemplo.Size = new Size(206, 129);
            txt_Exemplo.TabIndex = 3;
            txt_Exemplo.Text = "Exemplo de texto com ScrollBars ativo";
            txt_Exemplo.TextChanged += txt_Exemplo_TextChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(385, 180);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(244, 92);
            textBox1.TabIndex = 4;
            textBox1.Text = "Quando eu clicar no + para inserir um novo assunto ou novo topico, eu uso o focus para o cursor já ir para o textbox";
            // 
            // Btn_exemploMessageBox
            // 
            Btn_exemploMessageBox.Location = new Point(105, 424);
            Btn_exemploMessageBox.Margin = new Padding(3, 4, 3, 4);
            Btn_exemploMessageBox.Name = "Btn_exemploMessageBox";
            Btn_exemploMessageBox.Size = new Size(205, 36);
            Btn_exemploMessageBox.TabIndex = 6;
            Btn_exemploMessageBox.Text = "Btn_exemploMessageBox";
            Btn_exemploMessageBox.UseVisualStyleBackColor = true;
            // 
            // Btn_FecharAplicacao
            // 
            Btn_FecharAplicacao.Location = new Point(825, 692);
            Btn_FecharAplicacao.Margin = new Padding(3, 4, 3, 4);
            Btn_FecharAplicacao.Name = "Btn_FecharAplicacao";
            Btn_FecharAplicacao.Size = new Size(159, 36);
            Btn_FecharAplicacao.TabIndex = 7;
            Btn_FecharAplicacao.Text = "Fechar programa";
            Btn_FecharAplicacao.UseVisualStyleBackColor = true;
            Btn_FecharAplicacao.Click += Btn_FecharAplicacao_Click;
            // 
            // Frm_RegistrarMateriaTopicoUc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(Btn_FecharAplicacao);
            Controls.Add(Btn_exemploMessageBox);
            Controls.Add(textBox1);
            Controls.Add(txt_Exemplo);
            Controls.Add(dateTimePicker1);
            Controls.Add(Btn_RegistrarMateriaTopico);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Frm_RegistrarMateriaTopicoUc";
            Size = new Size(851, 537);
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
