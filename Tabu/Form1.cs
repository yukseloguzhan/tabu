using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Tabu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TabuDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        int time = 15;
        int score = 0;
        
        int Click_Start_Button = 0;
        int B_score = 0;
        int level = 0;

        Score_Tablo yeni = new Score_Tablo(); 

        List<string> WordsComingOut = new List<string>();

        public static int sendData=0;
        public static int sendData_B=0;

        private void ShowData()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select TOP 1 * from Words order by NEWID()", connection);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
            
                if(WordsComingOut.Contains(oku["word"])) {                             
                    
                }

                else
                {
                   
                    WordsComingOut.Add(oku["word"].ToString());
                    label1.Text = (oku["word"].ToString());
                    label2.Text = (oku["tip1"].ToString());
                    label3.Text = (oku["tip2"].ToString());
                    label4.Text = (oku["tip3"].ToString());
                    label5.Text = (oku["tip4"].ToString());
                }


            }

            connection.Close();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time -= 1;
            label6.Text = time.ToString();

            if (time == 0)
            {
                level +=1;
                timer1.Stop();
                button1.Enabled = true;

                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
             
                button2.Visible = true;

        

            }

            if(Click_Start_Button==3)
            {
                Click_Start_Button = 0;
                yeni.Show();
                this.Hide();
            }

            if(level==2)
            {
                yeni.Show();
                this.Hide();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label7.Text = "0";
            Click_Start_Button += 1;
            ShowData();
            time = 15;
            timer1.Start();
            button1.Enabled = false;       
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = @"C:\Users\oğuzhan\Desktop\c#\Tabu\Tabu\SoundEffect\dogru.mp3";

            if (Click_Start_Button==2)
            {
                B_score += 1;
                label7.Text = B_score.ToString();
                sendData_B = B_score;
                ShowData();
            }
            
            else
            {
                score += 1;
                label7.Text = score.ToString();
                sendData = score;
                ShowData();

            }
   
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ShowData();
            axWindowsMediaPlayer1.URL = @"C:\Users\oğuzhan\Desktop\c#\Tabu\Tabu\SoundEffect\yanlis.mp3";
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {         
            ShowData();
            axWindowsMediaPlayer1.URL = @"C:\Users\oğuzhan\Desktop\c#\Tabu\Tabu\SoundEffect\pas3.mp3";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
            pictureBox5.Visible = true;
            pictureBox6.Visible = true;

            label9.Text = "B TAKIMI";
            button2.Visible = false;
        }


    }
}
