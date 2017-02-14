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
    public partial class frFavorite : Form
    {
        private OleDbConnection cn;
        private OleDbDataReader reader;
        private OleDbCommand com;
        private DataSet rs;
        private OleDbDataAdapter ad;
        private DataTable dt;
        private OleDbCommandBuilder cbr;
        private DataRow dr;
  
        public frFavorite()
        {
            InitializeComponent();
        }

        private void frFavorite_FormClosed(object sender, FormClosedEventArgs e)
        {

            frMain frFavorite = new frMain();
            this.Hide();
            frFavorite.Show();
            cn.Close();
        
        }

        private void frFavorite_Load(object sender, EventArgs e)
        {
            MyConnect();

                                   
            try
            {
                ad = new OleDbDataAdapter("SELECT * FROM tblFavorite ORDER BY Word", cn);
                ad.Fill(rs, "tblFavorite");
                com = new OleDbCommand("SELECT Word FROM tblFavorite ORDER BY Word", cn);
                //reader = com.ExecuteReader();
                //OleDbDataReader reader = null;
                //com = new OleDbCommand("select Word from tblFavorite", cn);
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

            MyConnect();
            ad = new OleDbDataAdapter("SELECT * FROM tblFavorite ORDER BY Word", cn);
            ad.Fill(rs, "tblFavorite");
            com = new OleDbCommand("SELECT Word FROM tblFavorite ORDER BY Word", cn);
            reader = com.ExecuteReader();
            dr = rs.Tables[0].Rows[lstItems.SelectedIndex];
            rtbKekka.Clear();

            rtbKekka.Text = "単語：" + "\n" + lstItems.SelectedItem.ToString() + "\n" + "意味：" + "\n" + dr[2].ToString().Trim();

            HighLight();
            com.Dispose();
            com = null;
            cn.Close();
        }
        private void MyConnect()
        {
            try
            {

                rs = new DataSet();
                //Provider=Microsoft.Jet.OLEDB.4.0;Data Source="D:\21 HIEU\11 卒業制作\Japanese Dictionary\Japanese Dictionary\bin\Debug\JPDict.accdb"
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Delete Favorite Table data
            MyConnect();
            com = new OleDbCommand("Delete From tblFavorite", cn);
            com.ExecuteNonQuery();
            MessageBox.Show("単語をクリアされた!", "Message", MessageBoxButtons.OK);
            lstItems.Items.Clear();
            rtbKekka.Text = "";
            loadData();
            cn.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frMain frFavorite = new frMain();
            this.Hide();
            frFavorite.Show();
            cn.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Delete Favorite Table Record
            MyConnect();
            //com = new OleDbCommand();
            //com.Connection = cn;
            //com.CommandType = CommandType.Text;
            com = new OleDbCommand("Delete From tblFavorite where Word = '" + lstItems.SelectedItem.ToString() + "'", cn);
            com.ExecuteNonQuery();
            MessageBox.Show("単語を削除された!", "Message", MessageBoxButtons.OK);
            rtbKekka.Text = "";
            loadData();
            com.Dispose();
            com = null;
            cn.Close();

        }
        private void loadData()
        {
            MyConnect();
            ad = new OleDbDataAdapter("SELECT * FROM tblFavorite ORDER BY Word", cn);
            ad.Fill(rs, "tblFavorite");
            com = new OleDbCommand("SELECT Word FROM tblFavorite ORDER BY Word", cn);
            //reader = com.ExecuteReader();
            //OleDbDataReader reader = null;
            //com = new OleDbCommand("select Word from tblFavorite", cn);
            reader = com.ExecuteReader();
            lstItems.Items.Clear();
            while (reader.Read())
            {
                lstItems.Items.Add(reader[0].ToString());

            }
        }
    }
}
