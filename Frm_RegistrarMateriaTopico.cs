using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudyCenterBiblioteca;

namespace StudyCenter
{
    public partial class Frm_RegistrarMateriaTopico : Form
    {
        public Frm_RegistrarMateriaTopico()
        {
            InitializeComponent();
        }
        private void Btn_FecharAplicacao_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
