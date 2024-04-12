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

        private void Btn_Registrar_Click(object sender, EventArgs e)
        {
           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm";
        }
    }
}
