using StudyCenter.Dominio.Entidades.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json; // Adicione a referência ao Newtonsoft.Json

namespace StudyCenter.Formularios
{
    public partial class Frm_RegistrarMateriaTopico : Form
    {
        private List<TextBox> textBoxes;

        public Frm_RegistrarMateriaTopico()
        {
            InitializeComponent();
            textBoxes = new List<TextBox>();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextBox newTextBox = new TextBox();

            newTextBox.Location = new System.Drawing.Point(12, 152 + (textBoxes.Count * 30));
            newTextBox.Size = new System.Drawing.Size(400, 27);

            this.Controls.Add(newTextBox);
            textBoxes.Add(newTextBox);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Materias materia = new Materias
            {
                NomeMateria = textBoxNomeMateria.Text,
                Topicos = new List<Topicos>()
            };

            foreach (TextBox textBox in textBoxes)
            {
                Topicos topico = new Topicos
                {
                    NomeTopico = textBox.Text,
                    IdMateria = materia.IdMateria
                };
                materia.Topicos.Add(topico);
            }

            string json = JsonConvert.SerializeObject(materia);

            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("https://localhost:7025/api/Materias/CriarMateria", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Materia registrada com sucesso!");
                }
                else
                {
                    MessageBox.Show("Erro ao registrar materia.");
                }
            }
        }
    }
}
