using StudyCenter.Formularios;
using StudyCenter.Models;
using System.Drawing.Drawing2D;
using System.Dynamic;

namespace StudyCenter
{
    public partial class Frm_StudyCenter : Form
    {
        private StudyCenterContext _dbContext;

        public int ContadorTabs = 0;

        public Frm_StudyCenter(StudyCenterContext dbContext)
        {
            _dbContext = dbContext;
            InitializeComponent();
            Color corFundo = Color.FromArgb(42, 50, 63);
            //Txt_data.BackColor = corFundo;
            txt_TempoEstudo.BackColor = corFundo;
            Txt_data.Text = DateTime.Now.ToString();
        }
        private void Frm_StudyCenter_Load(object sender, EventArgs e)
        {
        }
        private void Btn_exemploMessageBox_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voce tem certeza que quer continuar", "teste", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) //Exemplo de uso de uma condicao anterior a seguir com a acao do botao, utilizando YesNo e o DialogResult
            {
                MessageBox.Show("Voce clicou no botao", "Mensagem de teste", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Posso usar outros botoes no meu messageBox e dessa forma ter tratativas diferentes, como o MessageBoxButtons.CancelTryContinue ou o RetryCancel que me permite cancelar ou tentar novamente.
        }
        private void Btn_FecharAplicacao_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void novoRegistroDeMat�riat�picoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* Codigo anterior utilizando um form comum
            Frm_RegistrarMateriaTopico f = new Frm_RegistrarMateriaTopico();
            f.MdiParent = this;
            f.Show();
            */


            //Utilizando um Form UserControl
            ContadorTabs++;
            Frm_RegistrarMateriaTopicoUc f = new Frm_RegistrarMateriaTopicoUc();
            TabPage t = new TabPage();
            f.Dock = DockStyle.Fill;
            Tbc_Formularios.Visible = true;
            t.Name = "Registra mat�ria/t�pico";
            t.Text = "Registra mat�ria/t�pico";
            t.ImageIndex = 1;
            t.Controls.Add(f);
            Tbc_Formularios.TabPages.Add(t);
            if (Tbc_Formularios.TabCount > 1)
            {
                t.Name = t.Name + " (" + ContadorTabs + ")";
                t.Text = t.Text + " (" + ContadorTabs + ")";
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void consultaRegistrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void configuraTempoDeEstudoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Insira a quantidade de horas:", "Configura��o das horas", txt_TempoEstudo.Text);
            TimeSpan horas;

            if (TimeSpan.TryParse(input, out horas))
            {
                txt_TempoEstudo.Text = horas.ToString();
            }
            else
            {
                MessageBox.Show("Valor inserido inv�lido!", "Erro", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void txt_TempoEstudo_TextChanged(object sender, EventArgs e)
        {
            TimeSpan horas;
            if (TimeSpan.TryParse(txt_TempoEstudo.Text, out horas))
            {
                if (horas.TotalMinutes >= 180)
                {
                    txt_TempoEstudo.ForeColor = Color.Red;
                }
                else if (horas.TotalMinutes >= 91 && horas.TotalMinutes <= 179)
                {
                    txt_TempoEstudo.ForeColor = Color.Yellow;
                }
                else
                {
                    txt_TempoEstudo.ForeColor = Color.Green;
                }
            }
        }

        private void fecharAbaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!(Tbc_Formularios.SelectedTab == null))
            {
                Tbc_Formularios.TabPages.Remove(Tbc_Formularios.SelectedTab);

                if (Tbc_Formularios.TabCount == 0)
                {
                    Tbc_Formularios.Visible = false;
                }
            }
        }

        private void Tbc_Formularios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
