using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalloWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var autos = new List<Auto>();
            for (int i = 0; i < 100; i++)
            {
                autos.Add(new Auto()
                {
                    Id = i,
                    Hersteller = "Baudi",
                    Modell = $"A{i:00}",
                    Besitzer = "Fred",
                    Baujahr = DateTime.Now.AddYears(-20).AddDays(i * 17)
                });
            }

            dataGridView1.DataSource = autos;
        }
    }
}
