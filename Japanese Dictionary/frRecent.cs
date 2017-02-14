using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.OleDb;

namespace Japanese_Dictionary
{
    public partial class frRecent : Form
    {
        private OleDbConnection cn;
        private OleDbDataReader reader;
        private OleDbCommand com;
        private DataSet rs;
        private OleDbDataAdapter ad;
        private DataTable dt;
        private OleDbCommandBuilder cbr;
        public frRecent()
        {
            InitializeComponent();
        }

        private void frRecent_FormClosed(object sender, FormClosedEventArgs e)
        {
            frMain frRecent = new frMain();
            this.Hide();
            frRecent.Show();
            cn.Close();
        }

        private void frRecent_Load(object sender, EventArgs e)
        {
            MyConnect();

            try
            {

                ad = new OleDbDataAdapter("SELECT * FROM tblRecent ORDER BY Word", cn);
                ad.Fill(rs, "tblRecent");
                com = new OleDbCommand("SELECT Word FROM tblRecent ORDER BY Word", cn);
                reader = com.ExecuteReader();
                lstItems.Items.Clear();
                while (reader.Read())
                {
                    lstItems.Items.Add(reader[0].ToString());

                }
            }

            catch (Exception ex) {
                MessageBox.Show("Error: " + ex);
            }
            
        }
        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\JPDict.accdb;");
            cn.Open();
            ad = new OleDbDataAdapter("SELECT * FROM tblRecent ORDER BY Word", cn);
            ad.Fill(rs, "tblRecent");
            com = new OleDbCommand("SELECT Word FROM tblRecent ORDER BY Word", cn);
            reader = com.ExecuteReader();
            DataRow dr;
            dr = rs.Tables[0].Rows[lstItems.SelectedIndex];
            rtbKekka.Clear(); //xóa kết quả

            rtbKekka.Text = "単語：" + "\n" + lstItems.SelectedItem.ToString() + "\n" + "意味：" + "\n" + dr[2].ToString().Trim();

            HighLight();
            cn.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Delete Recent Table data
            MyConnect();
            //com = new OleDbCommand("delete from tblRecent where Word = " +lstItems.SelectedItem.ToString()+")", cn);
            com = new OleDbCommand("Delete From tblRecent", cn);
            com.ExecuteNonQuery();
            loadData();
            rtbKekka.Text = "";
            MessageBox.Show("単語をクリアされた!", "Message", MessageBoxButtons.OK);
            cn.Close();
        }

        private void MyConnect()
        {
            try
            {
                rs = new DataSet();             
                cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\JPDict.accdb;");
                cn.Open();

            }
            catch (Exception ex) {
                MessageBox.Show("Error: " + ex);
            }

        }

        private void HighLight()
        {
            try
            {
                //Word's Color
                Regex rex = new Regex(lstItems.SelectedItem.ToString());
                MatchCollection mc = rex.Matches(rtbKekka.Text);
                int StarCursorPosition = rtbKekka.SelectionStart;
                foreach (Match m in mc)
                {
                    int starIndex = m.Index;
                    int StopIndex = m.Length;
                    rtbKekka.Select(starIndex, StopIndex);
                    rtbKekka.SelectionColor = Color.Blue;
                    rtbKekka.SelectionStart = StarCursorPosition;
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frMain frRecent = new frMain();
            this.Hide();
            frRecent.Show();
            cn.Close();

        }
        private void loadData()
        {
            //MyConnect();
            ad = new OleDbDataAdapter("SELECT * FROM tblRecent ORDER BY Word", cn);
            ad.Fill(rs, "tblRecent");
            com = new OleDbCommand("SELECT Word FROM tblRecent ORDER BY Word", cn);
            reader = com.ExecuteReader();
            lstItems.Items.Clear();
            while (reader.Read())
            {
                lstItems.Items.Add(reader[0].ToString());

            }
        }



        
    }
}
