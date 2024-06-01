
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_StudyCenter));
            Txt_data = new TextBox();
            menuStrip1 = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            registrarMatériatópicoToolStripMenuItem = new ToolStripMenuItem();
            consultaMatériastópicosToolStripMenuItem = new ToolStripMenuItem();
            registraSessãoToolStripMenuItem = new ToolStripMenuItem();
            consultaRegistrosToolStripMenuItem = new ToolStripMenuItem();
            sairToolStripMenuItem = new ToolStripMenuItem();
            novoRegistroDeMatériatópicoToolStripMenuItem = new ToolStripMenuItem();
            configuraçõesToolStripMenuItem = new ToolStripMenuItem();
            configuraTempoDeEstudoToolStripMenuItem = new ToolStripMenuItem();
            fecharAbaToolStripMenuItem = new ToolStripMenuItem();
            txt_TempoEstudo = new TextBox();
            Tbc_Formularios = new TabControl();
            Iml_Imagens = new ImageList(components);
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // Txt_data
            // 
            Txt_data.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem, configuraçõesToolStripMenuItem, fecharAbaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(884, 24);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { registrarMatériatópicoToolStripMenuItem, consultaMatériastópicosToolStripMenuItem, registraSessãoToolStripMenuItem, consultaRegistrosToolStripMenuItem, sairToolStripMenuItem, novoRegistroDeMatériatópicoToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(50, 20);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // registrarMatériatópicoToolStripMenuItem
            // 
            registrarMatériatópicoToolStripMenuItem.Image = WinForms.UI.Descontinuado.Properties.Resources.Novo;
            registrarMatériatópicoToolStripMenuItem.Name = "registrarMatériatópicoToolStripMenuItem";
            registrarMatériatópicoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            registrarMatériatópicoToolStripMenuItem.Size = new Size(311, 22);
            registrarMatériatópicoToolStripMenuItem.Text = "Registrar matéria/tópico";
            registrarMatériatópicoToolStripMenuItem.Click += registrarMatériatópicoToolStripMenuItem_Click;
            // 
            // consultaMatériastópicosToolStripMenuItem
            // 
            consultaMatériastópicosToolStripMenuItem.Image = WinForms.UI.Descontinuado.Properties.Resources.lupa;
            consultaMatériastópicosToolStripMenuItem.Name = "consultaMatériastópicosToolStripMenuItem";
            consultaMatériastópicosToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.B;
            consultaMatériastópicosToolStripMenuItem.Size = new Size(311, 22);
            consultaMatériastópicosToolStripMenuItem.Text = "Consultar matérias/tópicos";
            // 
            // registraSessãoToolStripMenuItem
            // 
            registraSessãoToolStripMenuItem.Image = WinForms.UI.Descontinuado.Properties.Resources.Novo;
            registraSessãoToolStripMenuItem.Name = "registraSessãoToolStripMenuItem";
            registraSessãoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D;
            registraSessãoToolStripMenuItem.Size = new Size(311, 22);
            registraSessãoToolStripMenuItem.Text = "Registrar sessão";
            registraSessãoToolStripMenuItem.Click += registraSessãoToolStripMenuItem_Click;
            // 
            // consultaRegistrosToolStripMenuItem
            // 
            consultaRegistrosToolStripMenuItem.Image = WinForms.UI.Descontinuado.Properties.Resources.lupa1;
            consultaRegistrosToolStripMenuItem.Name = "consultaRegistrosToolStripMenuItem";
            consultaRegistrosToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            consultaRegistrosToolStripMenuItem.Size = new Size(311, 22);
            consultaRegistrosToolStripMenuItem.Text = "Consultar sessões";
            // 
            // sairToolStripMenuItem
            // 
            sairToolStripMenuItem.Image = WinForms.UI.Descontinuado.Properties.Resources.sair;
            sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            sairToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            sairToolStripMenuItem.Size = new Size(311, 22);
            sairToolStripMenuItem.Text = "Sair";
            sairToolStripMenuItem.Click += sairToolStripMenuItem_Click;
            // 
            // novoRegistroDeMatériatópicoToolStripMenuItem
            // 
            novoRegistroDeMatériatópicoToolStripMenuItem.Image = WinForms.UI.Descontinuado.Properties.Resources.Novo;
            novoRegistroDeMatériatópicoToolStripMenuItem.Name = "novoRegistroDeMatériatópicoToolStripMenuItem";
            novoRegistroDeMatériatópicoToolStripMenuItem.Size = new Size(311, 22);
            novoRegistroDeMatériatópicoToolStripMenuItem.Text = "Registrar matéria/tópico UC (descontinuado)";
            novoRegistroDeMatériatópicoToolStripMenuItem.Click += novoRegistroDeMatériatópicoDescontinuadoToolStripMenuItem_Click;
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
            configuraTempoDeEstudoToolStripMenuItem.Size = new Size(224, 22);
            configuraTempoDeEstudoToolStripMenuItem.Text = "Configurar tempo de estudo";
            configuraTempoDeEstudoToolStripMenuItem.Click += configuraTempoDeEstudoToolStripMenuItem_Click;
            // 
            // fecharAbaToolStripMenuItem
            // 
            fecharAbaToolStripMenuItem.Name = "fecharAbaToolStripMenuItem";
            fecharAbaToolStripMenuItem.Size = new Size(76, 20);
            fecharAbaToolStripMenuItem.Text = "Fechar aba";
            fecharAbaToolStripMenuItem.Click += fecharAbaToolStripMenuItem_Click;
            // 
            // txt_TempoEstudo
            // 
            txt_TempoEstudo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
            // Tbc_Formularios
            // 
            Tbc_Formularios.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Tbc_Formularios.ImageList = Iml_Imagens;
            Tbc_Formularios.Location = new Point(133, 180);
            Tbc_Formularios.Name = "Tbc_Formularios";
            Tbc_Formularios.SelectedIndex = 0;
            Tbc_Formularios.Size = new Size(299, 332);
            Tbc_Formularios.TabIndex = 12;
            Tbc_Formularios.Visible = false;
            // 
            // Iml_Imagens
            // 
            Iml_Imagens.ColorDepth = ColorDepth.Depth8Bit;
            Iml_Imagens.ImageStream = (ImageListStreamer)resources.GetObject("Iml_Imagens.ImageStream");
            Iml_Imagens.TransparentColor = Color.Transparent;
            Iml_Imagens.Images.SetKeyName(0, "lupa.png");
            Iml_Imagens.Images.SetKeyName(1, "Novo.png");
            Iml_Imagens.Images.SetKeyName(2, "sair.png");
            // 
            // Frm_StudyCenter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = WinForms.UI.Descontinuado.Properties.Resources.NovoIcone;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(884, 611);
            Controls.Add(Tbc_Formularios);
            Controls.Add(txt_TempoEstudo);
            Controls.Add(Txt_data);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "Frm_StudyCenter";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Study Center";
            Load += Frm_StudyCenter_Load_1;
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
        private TabControl Tbc_Formularios;
        private ImageList Iml_Imagens;
        private ToolStripMenuItem fecharAbaToolStripMenuItem;
        private ToolStripMenuItem registrarMatériatópicoToolStripMenuItem;
    }
}
