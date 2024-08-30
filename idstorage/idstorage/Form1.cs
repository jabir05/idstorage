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

namespace idstorage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=JABIR\SQLEXPRESS;Initial Catalog=idstore;Integrated Security=True;Encrypt=False");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username, user_password;

            username = txt_username.Text;
            user_password = txt_password.Text;

            try
            {
                string querry = "SELECT * FROM login_new WHERE username = '" + txt_username.Text+ "' AND password ='"+txt_password.Text+"'";
                SqlDataAdapter sda= new SqlDataAdapter(querry, conn);

                DataTable Dtable = new DataTable();
                sda.Fill(Dtable);

                if (Dtable.Rows.Count > 0)
                {
                    username = txt_username.Text;
                    user_password = txt_password.Text;

                    Menuform form2 = new Menuform();
                    form2.Show();
                    this.Hide();
                }

                else 
                {
                    MessageBox.Show("invalid login deatails","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txt_username.Clear();
                    txt_password.Clear();

                    txt_username.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            { 
             conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt_username.Clear() ;
            txt_password.Clear() ;

            txt_username.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
