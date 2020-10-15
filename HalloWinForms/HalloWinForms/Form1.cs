using Bogus;
using HalloWinForms.Data;
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

            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is IEnumerable<Person> pl)
                e.Value = string.Join(", ", pl.Select(x => x.Name));
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
                    Baujahr = DateTime.Now.AddYears(-20).AddDays(i * 17)
                });
            }

            dataGridView1.DataSource = autos;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var faker = new Faker<Auto>()
                               .RuleFor(x => x.Hersteller, f => f.Vehicle.Manufacturer())
                               .RuleFor(x => x.Modell, f => f.Vehicle.Model())
                               .RuleFor(x => x.Baujahr, f => f.Date.Past(10));

            var autos = new List<Auto>();
            for (int i = 0; i < 100; i++)
            {
                autos.Add(faker.Generate());
            }

            dataGridView1.DataSource = autos;
        }
        EfContext con = null;
        private void button3_Click(object sender, EventArgs e)
        {
            con = new EfContext();
            dataGridView1.DataSource = con.Autos.Where(x => x.Baujahr.Month > 4).ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (con = new EfContext())
            {
                var faker = new Faker<Auto>()
                                 .RuleFor(x => x.Hersteller, f => f.Vehicle.Manufacturer())
                                 .RuleFor(x => x.Modell, f => f.Vehicle.Model())
                                 .RuleFor(x => x.Baujahr, f => f.Date.Past(10));

                for (int i = 0; i < 100; i++)
                {
                    var a = faker.Generate();
                    a.Besitzer.Add(new Person() { Name = $"Fred #{i:00}" });
                    con.Autos.Add(a);
                }

                con.SaveChanges();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.SaveChanges();
        }
    }
}
