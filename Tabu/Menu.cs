using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tabu
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        Form1 gamePage = new Form1();
        Admin adminPage = new Admin(); 

        private void button1_Click(object sender, EventArgs e)
        {
            gamePage.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adminPage.Show();
            this.Hide();
        }
    }
}
