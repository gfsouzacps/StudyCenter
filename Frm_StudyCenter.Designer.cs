﻿
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
            dateTimePicker1 = new DateTimePicker();
            txt_Exemplo = new TextBox();
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
            Btn_RegistrarMateriaTopico.Click += Btn_Registrar_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(725, 12);
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
            // Frm_StudyCenter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(980, 588);
            Controls.Add(txt_Exemplo);
            Controls.Add(dateTimePicker1);
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
        private DateTimePicker dateTimePicker1;
        private TextBox txt_Exemplo;
    }
}
