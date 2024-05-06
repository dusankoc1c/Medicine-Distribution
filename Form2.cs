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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DISTRIBUCIJA_LEKOVA_PROJEKAT
{
    public partial class Form2 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=DistribucijaLekova;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            conn.Open();
            string upit = "select Naziv from Proizvodjac";
            SqlCommand cmd = new SqlCommand(upit, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                checkedListBox1.Items.Add(dr[0].ToString());
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*SELEKTOVANJE IZ CHECKBOX U STRING*/

            //string s = "";
            //if (checkedListBox1.CheckedItems.Count != 0)
            //{
            //    // If so, loop through all checked items and print results.  
            //    for (int x = 0; x < checkedListBox1.CheckedItems.Count; x++)
            //    {
            //        s = s + checkedListBox1.CheckedItems[x].ToString() + "\n";
            //    }
            //    //MessageBox.Show(s);
            //}
            conn.Open();
            //List<string> checkedValues = new List<string>();
            //foreach (var item in checkedListBox1.CheckedItems)
            //{
            //    checkedValues.Add(item.ToString());
            //}
            //Console.WriteLine("All checked items:");
            //foreach (var item in checkedValues)
            //{

                
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SELECT Naziv, COUNT([LekID]) as lekovi \r\nFROM [dbo].[Lek]\r\njoin [dbo].[Proizvodjac] on [dbo].[Lek].[ProizvodjacID] = [dbo].[Proizvodjac].[ProizvodjacID]\r\ngroup by [dbo].[Proizvodjac].[Naziv]", conn);
                da.Fill(dt);
                chart1.DataSource = dt;
                chart1.Series["Proizvodnja"].XValueMember = "Naziv";
                chart1.Series["Proizvodnja"].YValueMembers = "lekovi";
                chart1.Titles.Add("Proizvodnja po proizvodjacu");
           
            conn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

