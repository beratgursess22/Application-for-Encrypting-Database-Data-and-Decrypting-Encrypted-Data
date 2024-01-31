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

namespace EncryptingData
{
    public partial class EncryptinAndDecrypting : Form
    {
        public EncryptinAndDecrypting()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-FPTE8E0E\SQLEXPRESS;Initial Catalog=passowordfind;Integrated Security=True");

        void list()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from data", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            string name = txtname.Text;
            byte[] namearray = ASCIIEncoding.ASCII.GetBytes(name);
            string namepasso = Convert.ToBase64String(namearray);
           

            string surname = txtsurname.Text;
            byte[] surnamearray = ASCIIEncoding.ASCII.GetBytes(surname);
            string surnamepasso = Convert.ToBase64String(surnamearray);

            string mail = txtmail.Text;
            byte[] mailarray = ASCIIEncoding.ASCII.GetBytes(mail);
            string mailpasso = Convert.ToBase64String(mailarray);

            string passoword = txtpassoword.Text;
            byte[] passowordarray = ASCIIEncoding.ASCII.GetBytes(passoword);
            string passowrodpasso = Convert.ToBase64String(passowordarray);

            string acountno = txtno.Text;
            byte[] acountnoarray = ASCIIEncoding.ASCII.GetBytes(acountno);
            string acountnopasso = Convert.ToBase64String(acountnoarray);


            connection.Open();
            SqlCommand order = new SqlCommand("insert into data (name,surname,mail,pasoword,acountno) values(@p1,@p2,@p3,@p4,@p5)", connection);
            order.Parameters.AddWithValue("@p1", namepasso);
            order.Parameters.AddWithValue("@p2", surnamepasso);
            order.Parameters.AddWithValue("@p3", mailpasso);
            order.Parameters.AddWithValue("@p4", passowrodpasso);
            order.Parameters.AddWithValue("@p5", acountnopasso);
            order.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Personal is saved", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
  
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            list();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string namefind = txtname1.Text;
            byte[] namefinarray = Convert.FromBase64String(namefind);
            string namedata = ASCIIEncoding.ASCII.GetString(namefinarray);
            txtname1.Text = namedata;

            string surnamefind = txtsurname1.Text;
            byte[] surnamefindarray = Convert.FromBase64String(surnamefind);
            string surnamedata = ASCIIEncoding.ASCII.GetString(surnamefindarray);
            txtsurname1.Text = surnamedata;

            string mailfind = txtmail1.Text;
            byte[] mailfindarray = Convert.FromBase64String(mailfind);
            string mailfinddata = ASCIIEncoding.ASCII.GetString(mailfindarray);
            txtmail1.Text = mailfinddata;
           

            string passowrodfind = txtpassowrod1.Text;
            byte[] passowrodfindarray = Convert.FromBase64String(passowrodfind);
            string passowordfindata = ASCIIEncoding.ASCII.GetString(passowrodfindarray);
            txtpassowrod1.Text = passowordfindata;

            string acountnofind = txtacountno.Text;
            byte[] acountnofindarray = Convert.FromBase64String(acountnofind);
            string acounnofinddata = ASCIIEncoding.ASCII.GetString(acountnofindarray);
            txtacountno.Text = acounnofinddata;
            
            
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int chosen = dataGridView1.SelectedCells[0].RowIndex;
            txtname1.Text = dataGridView1.Rows[chosen].Cells[1].Value.ToString();
            txtsurname1.Text = dataGridView1.Rows[chosen].Cells[2].Value.ToString();
            txtmail1.Text = dataGridView1.Rows[chosen].Cells[3].Value.ToString();
            txtpassowrod1.Text = dataGridView1.Rows[chosen].Cells[4].Value.ToString();
            txtacountno.Text = dataGridView1.Rows[chosen].Cells[5].Value.ToString();
        }
    }
}
