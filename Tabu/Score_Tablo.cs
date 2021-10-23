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
    public partial class Score_Tablo : Form
    {
        public Score_Tablo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 gamePage = new Form1();
            gamePage.Show();
            this.Hide();
        }

        public void A_puan_Click(object sender, EventArgs e)
        {

        }

        private void Score_Tablo_Load(object sender, EventArgs e)
        {
            A_puan.Text = Form1.sendData.ToString();
            label4.Text = Form1.sendData_B.ToString();

            if (Convert.ToInt32(A_puan.Text) > Convert.ToInt32(label4.Text))
            {
                MessageBox.Show("A takımı oyunu kazandı!!!");
                label3.Text = "A TAKIMI OYUNU KAZANDI!";

            }

            else
                    if (Convert.ToInt32(A_puan.Text) < Convert.ToInt32(label4.Text))
                    {
                        MessageBox.Show("B takımı oyunu kazandı!!!");
                        label3.Text = "B TAKIMI OYUNU KAZANDI!";
                    }

                    else
                    {
                        MessageBox.Show("Puanlar Eşit!!!");
                        label3.Text = "BERABERLİK İLE SONUÇLANDI!";
                    }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu page = new Menu();
            page.Show();
            this.Hide();
        }
    }
}
