
namespace StudyCenter
{
    partial class Frm_StudyCenter
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_StudyCenter));
            Btn_RegistrarMateriaTopico = new Button();
            Btn_FecharAplicacao = new Button();
            Txt_data = new TextBox();
            SuspendLayout();
            // 
            // Btn_RegistrarMateriaTopico
            // 
            Btn_RegistrarMateriaTopico.BackColor = Color.Black;
            Btn_RegistrarMateriaTopico.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_RegistrarMateriaTopico.ForeColor = Color.White;
            Btn_RegistrarMateriaTopico.Location = new Point(12, 80);
            Btn_RegistrarMateriaTopico.Name = "Btn_RegistrarMateriaTopico";
            Btn_RegistrarMateriaTopico.Size = new Size(218, 25);
            Btn_RegistrarMateriaTopico.TabIndex = 1;
            Btn_RegistrarMateriaTopico.Text = "Regitrar matéria ou tópico";
            Btn_RegistrarMateriaTopico.UseVisualStyleBackColor = false;
            Btn_RegistrarMateriaTopico.Click += Btn_Registrar_Click;
            // 
            // Btn_FecharAplicacao
            // 
            Btn_FecharAplicacao.BackColor = Color.Black;
            Btn_FecharAplicacao.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_FecharAplicacao.ForeColor = Color.White;
            Btn_FecharAplicacao.Location = new Point(733, 518);
            Btn_FecharAplicacao.Name = "Btn_FecharAplicacao";
            Btn_FecharAplicacao.Size = new Size(139, 27);
            Btn_FecharAplicacao.TabIndex = 7;
            Btn_FecharAplicacao.Text = "Fechar programa";
            Btn_FecharAplicacao.UseVisualStyleBackColor = false;
            Btn_FecharAplicacao.Click += Btn_FecharAplicacao_Click;
            // 
            // Txt_data
            // 
            Txt_data.BackColor = Color.Black;
            Txt_data.BorderStyle = BorderStyle.None;
            Txt_data.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            Txt_data.ForeColor = Color.White;
            Txt_data.Location = new Point(755, 6);
            Txt_data.Name = "Txt_data";
            Txt_data.Size = new Size(125, 15);
            Txt_data.TabIndex = 8;
            Txt_data.TextAlign = HorizontalAlignment.Center;
            // 
            // Frm_StudyCenter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = Properties.Resources.NovoIcone;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(884, 611);
            Controls.Add(Txt_data);
            Controls.Add(Btn_FecharAplicacao);
            Controls.Add(Btn_RegistrarMateriaTopico);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Frm_StudyCenter";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Study Center";
            ResumeLayout(false);
            PerformLayout();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

#endregion
        private Button Btn_RegistrarMateriaTopico;
        private Button Btn_FecharAplicacao;
        private TextBox Txt_data;
    }
}
