
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
            Txt_data = new TextBox();
            menuStrip1 = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            novoRegistroDeMatériatópicoToolStripMenuItem = new ToolStripMenuItem();
            consultaMatériastópicosToolStripMenuItem = new ToolStripMenuItem();
            registraSessãoToolStripMenuItem = new ToolStripMenuItem();
            consultaRegistrosToolStripMenuItem = new ToolStripMenuItem();
            sairToolStripMenuItem = new ToolStripMenuItem();
            configuraçõesToolStripMenuItem = new ToolStripMenuItem();
            configuraTempoDeEstudoToolStripMenuItem = new ToolStripMenuItem();
            txt_TempoEstudo = new TextBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // Txt_data
            // 
            Txt_data.BackColor = Color.White;
            Txt_data.BorderStyle = BorderStyle.None;
            Txt_data.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Txt_data.ForeColor = Color.Black;
            Txt_data.Location = new Point(752, 4);
            Txt_data.Name = "Txt_data";
            Txt_data.Size = new Size(125, 16);
            Txt_data.TabIndex = 8;
            Txt_data.TextAlign = HorizontalAlignment.Right;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem, configuraçõesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(884, 24);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { novoRegistroDeMatériatópicoToolStripMenuItem, consultaMatériastópicosToolStripMenuItem, registraSessãoToolStripMenuItem, consultaRegistrosToolStripMenuItem, sairToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(50, 20);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // novoRegistroDeMatériatópicoToolStripMenuItem
            // 
            novoRegistroDeMatériatópicoToolStripMenuItem.Image = Properties.Resources.Novo;
            novoRegistroDeMatériatópicoToolStripMenuItem.Name = "novoRegistroDeMatériatópicoToolStripMenuItem";
            novoRegistroDeMatériatópicoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            novoRegistroDeMatériatópicoToolStripMenuItem.Size = new Size(286, 22);
            novoRegistroDeMatériatópicoToolStripMenuItem.Text = "Novo registro de matéria/tópico";
            novoRegistroDeMatériatópicoToolStripMenuItem.Click += novoRegistroDeMatériatópicoToolStripMenuItem_Click;
            // 
            // consultaMatériastópicosToolStripMenuItem
            // 
            consultaMatériastópicosToolStripMenuItem.Image = Properties.Resources.lupa;
            consultaMatériastópicosToolStripMenuItem.Name = "consultaMatériastópicosToolStripMenuItem";
            consultaMatériastópicosToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.B;
            consultaMatériastópicosToolStripMenuItem.Size = new Size(286, 22);
            consultaMatériastópicosToolStripMenuItem.Text = "Consulta matérias/tópicos";
            // 
            // registraSessãoToolStripMenuItem
            // 
            registraSessãoToolStripMenuItem.Image = Properties.Resources.Novo;
            registraSessãoToolStripMenuItem.Name = "registraSessãoToolStripMenuItem";
            registraSessãoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D;
            registraSessãoToolStripMenuItem.Size = new Size(286, 22);
            registraSessãoToolStripMenuItem.Text = "Registra sessão";
            // 
            // consultaRegistrosToolStripMenuItem
            // 
            consultaRegistrosToolStripMenuItem.Image = Properties.Resources.lupa1;
            consultaRegistrosToolStripMenuItem.Name = "consultaRegistrosToolStripMenuItem";
            consultaRegistrosToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            consultaRegistrosToolStripMenuItem.Size = new Size(286, 22);
            consultaRegistrosToolStripMenuItem.Text = "Consulta sessões";
            consultaRegistrosToolStripMenuItem.Click += consultaRegistrosToolStripMenuItem_Click;
            // 
            // sairToolStripMenuItem
            // 
            sairToolStripMenuItem.Image = Properties.Resources.sair;
            sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            sairToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            sairToolStripMenuItem.Size = new Size(286, 22);
            sairToolStripMenuItem.Text = "Sair";
            sairToolStripMenuItem.Click += sairToolStripMenuItem_Click;
            // 
            // configuraçõesToolStripMenuItem
            // 
            configuraçõesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { configuraTempoDeEstudoToolStripMenuItem });
            configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            configuraçõesToolStripMenuItem.Size = new Size(96, 20);
            configuraçõesToolStripMenuItem.Text = "Configurações";
            // 
            // configuraTempoDeEstudoToolStripMenuItem
            // 
            configuraTempoDeEstudoToolStripMenuItem.Name = "configuraTempoDeEstudoToolStripMenuItem";
            configuraTempoDeEstudoToolStripMenuItem.Size = new Size(220, 22);
            configuraTempoDeEstudoToolStripMenuItem.Text = "Configura tempo de estudo";
            configuraTempoDeEstudoToolStripMenuItem.Click += configuraTempoDeEstudoToolStripMenuItem_Click;
            // 
            // txt_TempoEstudo
            // 
            txt_TempoEstudo.BorderStyle = BorderStyle.None;
            txt_TempoEstudo.Font = new Font("Franklin Gothic Medium", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            txt_TempoEstudo.ForeColor = Color.Red;
            txt_TempoEstudo.Location = new Point(762, 51);
            txt_TempoEstudo.Name = "txt_TempoEstudo";
            txt_TempoEstudo.ReadOnly = true;
            txt_TempoEstudo.Size = new Size(100, 24);
            txt_TempoEstudo.TabIndex = 10;
            txt_TempoEstudo.Text = "03:00:00";
            txt_TempoEstudo.TextAlign = HorizontalAlignment.Center;
            txt_TempoEstudo.TextChanged += txt_TempoEstudo_TextChanged;
            // 
            // Frm_StudyCenter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = Properties.Resources.NovoIcone;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(884, 611);
            Controls.Add(txt_TempoEstudo);
            Controls.Add(Txt_data);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Frm_StudyCenter";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Study Center";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

#endregion
        private TextBox Txt_data;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem novoRegistroDeMatériatópicoToolStripMenuItem;
        private ToolStripMenuItem sairToolStripMenuItem;
        private ToolStripMenuItem consultaRegistrosToolStripMenuItem;
        private ToolStripMenuItem registraSessãoToolStripMenuItem;
        private ToolStripMenuItem consultaMatériastópicosToolStripMenuItem;
        private ToolStripMenuItem configuraçõesToolStripMenuItem;
        private ToolStripMenuItem configuraTempoDeEstudoToolStripMenuItem;
        private TextBox txt_TempoEstudo;
    }
}
