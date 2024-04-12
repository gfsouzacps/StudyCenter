
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
            menuStrip1 = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            novoRegistroDeMatériatópicoToolStripMenuItem = new ToolStripMenuItem();
            sairToolStripMenuItem = new ToolStripMenuItem();
            consultaRegistrosToolStripMenuItem = new ToolStripMenuItem();
            registraSessãoToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
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
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(884, 24);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { novoRegistroDeMatériatópicoToolStripMenuItem, registraSessãoToolStripMenuItem, consultaRegistrosToolStripMenuItem, sairToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(50, 20);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // novoRegistroDeMatériatópicoToolStripMenuItem
            // 
            novoRegistroDeMatériatópicoToolStripMenuItem.Image = Properties.Resources.Novo;
            novoRegistroDeMatériatópicoToolStripMenuItem.Name = "novoRegistroDeMatériatópicoToolStripMenuItem";
            novoRegistroDeMatériatópicoToolStripMenuItem.Size = new Size(244, 22);
            novoRegistroDeMatériatópicoToolStripMenuItem.Text = "Novo registro de matéria/tópico";
            novoRegistroDeMatériatópicoToolStripMenuItem.Click += novoRegistroDeMatériatópicoToolStripMenuItem_Click;
            // 
            // sairToolStripMenuItem
            // 
            sairToolStripMenuItem.Image = Properties.Resources.sair;
            sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            sairToolStripMenuItem.Size = new Size(244, 22);
            sairToolStripMenuItem.Text = "Sair";
            sairToolStripMenuItem.Click += sairToolStripMenuItem_Click;
            // 
            // consultaRegistrosToolStripMenuItem
            // 
            consultaRegistrosToolStripMenuItem.Image = Properties.Resources.lupa1;
            consultaRegistrosToolStripMenuItem.Name = "consultaRegistrosToolStripMenuItem";
            consultaRegistrosToolStripMenuItem.Size = new Size(244, 22);
            consultaRegistrosToolStripMenuItem.Text = "Consulta sessões";
            consultaRegistrosToolStripMenuItem.Click += consultaRegistrosToolStripMenuItem_Click;
            // 
            // registraSessãoToolStripMenuItem
            // 
            registraSessãoToolStripMenuItem.Image = Properties.Resources.Novo;
            registraSessãoToolStripMenuItem.Name = "registraSessãoToolStripMenuItem";
            registraSessãoToolStripMenuItem.Size = new Size(244, 22);
            registraSessãoToolStripMenuItem.Text = "Registra sessão";
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
        private Button Btn_RegistrarMateriaTopico;
        private Button Btn_FecharAplicacao;
        private TextBox Txt_data;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem novoRegistroDeMatériatópicoToolStripMenuItem;
        private ToolStripMenuItem sairToolStripMenuItem;
        private ToolStripMenuItem consultaRegistrosToolStripMenuItem;
        private ToolStripMenuItem registraSessãoToolStripMenuItem;
    }
}
