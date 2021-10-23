using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tabu
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TabuDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == ""  || textBox2.Text == ""  || textBox3.Text == "" || textBox4.Text == ""  || textBox5.Text == "" )
            {
                MessageBox.Show("Incorrect operation! No fields can be left blank");
            }

            else
            {
                baglanti.Open();
                textBox1.Text = textBox1.Text.ToUpper();
                SqlCommand arakomut = new SqlCommand("Select *from Words where word like '%" + textBox1.Text + "%' ", baglanti);
                SqlDataReader oku = arakomut.ExecuteReader();
                if (oku.Read())
                {
                    MessageBox.Show("This word already exists!!");
                    oku.Close();
                }

                else
                {
                    oku.Close();
                    SqlCommand komut = new SqlCommand("INSERT INTO Words(word,tip1,tip2,tip3,tip4) VALUES('" + textBox1.Text.ToUpper() + "','" + textBox2.Text.ToUpper() + "', '" + textBox3.Text.ToUpper() + "' , '" + textBox4.Text.ToUpper() + "' , '" + textBox5.Text.ToUpper() + "')", baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Added successfully!");
                    ShowData("SELECT *FROM Words");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    baglanti.Close();
                }


            }


        }

        public void ShowData(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglanti);
            DataTable tb = new DataTable();
            da.Fill(tb);
            dataGridView1.DataSource = tb;

        }

        public void Clear_Data()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

        }


        private void Admin_Load(object sender, EventArgs e)
        {
            ShowData("SELECT *FROM Words");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Incorrect operation! No fields can be left blank!");
            }

            else
            {
                baglanti.Open();
                SqlCommand arakomut = new SqlCommand("SELECT *FROM Words WHERE word LIKE '%" + textBox1.Text.ToUpper() + "%' ", baglanti);
                SqlDataReader oku = arakomut.ExecuteReader();
                if (!oku.Read())
                {
                    MessageBox.Show("There is no such word!!!");
                    oku.Close();
                }

                else
                {
                    oku.Close();
                    SqlCommand cmd = new SqlCommand("UPDATE Words SET word='" + textBox1.Text.ToUpper() + "'," +
                        "tip1='" + textBox2.Text.ToUpper() + "' ," +
                        "tip2='" + textBox3.Text.ToUpper() + "' , " +
                        "tip3='" + textBox4.Text.ToUpper() + "' , " +
                        "tip4='" + textBox5.Text.ToUpper() + "' WHERE word='" + textBox1.Text.ToUpper() + "'  ", baglanti);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully updated!");
                    Clear_Data();
                    ShowData("SELECT *FROM Words");
                    baglanti.Close();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox6.Text == "")
            {
                MessageBox.Show("Incorrect operation! Write the word in the required field!");
            }

            else
            {
                baglanti.Open();
                textBox6.Text = textBox6.Text.ToUpper();

                SqlCommand arakomut = new SqlCommand("SELECT *FROM Words WHERE word LIKE '%" + textBox6.Text.ToUpper() + "%' ", baglanti);
                SqlDataReader oku = arakomut.ExecuteReader();
                if (!oku.Read())
                {
                    MessageBox.Show("There is no such word!");
                    oku.Close();
                }



                else
                {
                    oku.Close();
                    SqlCommand komut = new SqlCommand("DELETE FROM Words WHERE word=@word", baglanti);
                    komut.Parameters.AddWithValue("@word", textBox6.Text);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Successfully deleted!");
                    textBox6.Clear();
                    ShowData("SELECT *FROM Words");
                    baglanti.Close();
                }
            }

           


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Menu menuPage = new Menu();
            menuPage.Show();
            this.Hide();
        }
    }
}
