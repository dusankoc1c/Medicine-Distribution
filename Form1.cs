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

namespace DISTRIBUCIJA_LEKOVA_PROJEKAT
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source =.; Initial Catalog = DistribucijaLekova; Integrated Security = True");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string upit = "select [dbo].[Lek].[LekID], [dbo].[Lek].[ProizvodjacID], [dbo].[Lek].[NazivLeka], [dbo].[Lek].[NezasticenoIme], [dbo].[Proizvodjac].[Naziv] from [dbo].[Lek], [dbo].[Proizvodjac] where [dbo].[Lek].[ProizvodjacID] = [dbo].[Proizvodjac].[ProizvodjacID] order by NazivLeka";
            SqlCommand cmd = new SqlCommand(upit, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            textBox1.Text = dataGridView1[2, 0].Value.ToString();
            textBox2.Text = dataGridView1[4, 0].Value.ToString();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string upit1 = "delete from Proizvodjac where @Naziv = Naziv";
            SqlCommand cmd1 = new SqlCommand(upit1, conn);
            cmd1.Parameters.AddWithValue("@Naziv", textBox2.Text);
            cmd1.ExecuteNonQuery();
            /**/
            string upit = "delete from Lek where @NazivLeka = NazivLeka";
            SqlCommand cmd = new SqlCommand(upit, conn);
            cmd.Parameters.AddWithValue("@NazivLeka", textBox1.Text);
            cmd.ExecuteNonQuery();
            /**/
            string upit2 = "select [dbo].[Lek].[LekID], [dbo].[Lek].[ProizvodjacID], [dbo].[Lek].[NazivLeka], [dbo].[Lek].[NezasticenoIme], [dbo].[Proizvodjac].[Naziv] from [dbo].[Lek], [dbo].[Proizvodjac] where [dbo].[Lek].[ProizvodjacID] = [dbo].[Proizvodjac].[ProizvodjacID] order by NazivLeka";
            SqlCommand cmd2 = new SqlCommand(upit2, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            
            Form3 form = new Form3();
            form.ShowDialog();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            textBox1.Text = Convert.ToString(dataGridView1[2, row].Value);
            textBox2.Text = Convert.ToString(dataGridView1[4, row].Value);
        }
    }
}
