namespace StudyCenter.Formularios
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
            components = new System.ComponentModel.Container();
            Iml_Imagens = new ImageList(components);
            SuspendLayout();
            // 
            // Iml_Imagens
            // 
            Iml_Imagens.ColorDepth = ColorDepth.Depth8Bit;
            Iml_Imagens.ImageSize = new Size(16, 16);
            Iml_Imagens.TransparentColor = Color.Transparent;
            // 
            // Frm_RegistrarMateriaTopico
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = Properties.Resources.NovoIcone;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(734, 361);
            Name = "Frm_RegistrarMateriaTopico";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registrar matéria/tópico";
            ResumeLayout(false);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private ImageList Iml_Imagens;
    }
}