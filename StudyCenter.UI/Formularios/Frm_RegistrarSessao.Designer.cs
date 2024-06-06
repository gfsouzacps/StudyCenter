namespace StudyCenter.Formularios
{
    partial class Frm_RegistrarSessao
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_RegistrarSessao));
            Iml_Imagens = new ImageList(components);
            Txt_data = new TextBox();
            SuspendLayout();
            // 
            // Iml_Imagens
            // 
            Iml_Imagens.ColorDepth = ColorDepth.Depth8Bit;
            Iml_Imagens.ImageSize = new Size(16, 16);
            Iml_Imagens.TransparentColor = Color.Transparent;
            // 
            // Txt_data
            // 
            Txt_data.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Txt_data.BackColor = Color.White;
            Txt_data.BorderStyle = BorderStyle.None;
            Txt_data.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Txt_data.ForeColor = Color.Black;
            Txt_data.Location = new Point(602, 4);
            Txt_data.Name = "Txt_data";
            Txt_data.Size = new Size(125, 16);
            Txt_data.TabIndex = 8;
            Txt_data.TextAlign = HorizontalAlignment.Right;
            // 
            // Frm_RegistrarSessao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = WinForms.UI.Descontinuado.Properties.Resources.NovoIcone;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(734, 361);
            Controls.Add(Txt_data);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Frm_RegistrarSessao";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registrar Sessão";
            Load += Frm_RegistrarSessao_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

#endregion
        private ImageList Iml_Imagens;
        private TextBox Txt_data;
    }
}