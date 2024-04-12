using StudyCenter.Models;

namespace StudyCenter
{
    public partial class Frm_StudyCenter : Form
    {
        private StudyCenterContext _dbContext;
        public Frm_StudyCenter(StudyCenterContext dbContext)
        {
            _dbContext = dbContext;
            InitializeComponent();
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

        private void Btn_Registrar_Click(object sender, EventArgs e)
        {
            Frm_RegistrarMateriaTopico f = new Frm_RegistrarMateriaTopico();
            f.ShowDialog();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm";
        }

        private void Btn_FecharAplicacao_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
