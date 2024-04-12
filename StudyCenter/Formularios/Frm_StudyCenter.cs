using StudyCenter.Models;
using System.Drawing.Drawing2D;
using System.Dynamic;

namespace StudyCenter
{
    public partial class Frm_StudyCenter : Form
    {
        private StudyCenterContext _dbContext;

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

        private void novoRegistroDeMatériatópicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_RegistrarMateriaTopico f = new Frm_RegistrarMateriaTopico();
            f.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void consultaRegistrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //private void Txt_data_TextChanged(object sender, EventArgs e)
        //{
        //    string input = Microsoft.VisualBasic.Interaction.InputBox("Digite o valor:", "Inserir o valor", "0");
        //    decimal horas;

        //    if (decimal.TryParse(input, out horas))
        //    {
        //        txt_TempoEstudo.Text = horas.ToString();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Valor inserido inválido!","Erro",MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
        //    }
        //}

        private void configuraTempoDeEstudoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Insira a quantidade de horas:", "Configuração das horas", txt_TempoEstudo.Text);
            TimeSpan horas;

            if (TimeSpan.TryParse(input, out horas))
            {
                txt_TempoEstudo.Text = horas.ToString();
            }
            else
            {
                MessageBox.Show("Valor inserido inválido!", "Erro", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
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
    }
}
