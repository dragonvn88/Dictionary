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
using System.Speech.Synthesis;
using Synthesizer = System.Speech.Synthesis.SpeechSynthesizer;
namespace Japanese_Dictionary
{
    public partial class frMain : Form
    {
        private OleDbConnection cn;
        private OleDbDataReader reader;
        private OleDbCommand com;
        private DataSet rs;
        private OleDbDataAdapter ad;
        //private DataTable dt;
        //private OleDbCommandBuilder cbr;
        private Synthesizer s = new Synthesizer();
        VoiceGender gender = VoiceGender.Female;
        VoiceAge age = VoiceAge.Adult;

        public frMain()
        {
            InitializeComponent();
        }
        #region"Connect & disconnect database
        private void MyConnect()
        {
            try
            {
                //Connect to database
                rs = new DataSet();
                cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\JPDict.accdb;");
                cn.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }

        }
        private void DestroyConnect()
        {
            //disconnect
            cn.Close(); 
            cn.Dispose();
            cn = null; 
        }
        #endregion

        #region"Load dictionary"
        private void cmbJisho_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyConnect();

            if (cmbJisho.Text == "英語－日本語")
            {
                try
                {

                    ad = new OleDbDataAdapter("SELECT * FROM tblEnJp ORDER BY EnWord", cn);
                    ad.Fill(rs, "tblEnJp");
                    com = new OleDbCommand("SELECT EnWord FROM tblEnJp ORDER BY EnWord", cn);
                    reader = com.ExecuteReader();
                    //Clear Word's ListBox
                    lstItems.Items.Clear();
                    //Clear Mean's Box
                    rtbKekka.Text = "";
                    //Load data to ListBox
                    while (reader.Read())
                    {
                        lstItems.Items.Add(reader[0].ToString());
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("Error: " + ex);
                }
                txtSearch.Focus();

            }
            else if (cmbJisho.Text == "日本語ー英語")
            {
                try
                {

                    ad = new OleDbDataAdapter("SELECT * FROM tblJpEn ORDER BY JpWord", cn);
                    ad.Fill(rs, "tblJpEn");
                    com = new OleDbCommand("SELECT JpWord FROM tblJpEn ORDER BY JpWord", cn);
                    reader = com.ExecuteReader();
                    //Clear Word's ListBox
                    lstItems.Items.Clear();
                    //Clear Mean's Box
                    rtbKekka.Text = "";
                    //Load data to ListBox
                    while (reader.Read())
                    {
                        lstItems.Items.Add(reader[0].ToString());
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("Error: " + ex);
                }
                txtSearch.Focus();

            }
            else if (cmbJisho.Text == "日本語ーベトナム語")
            {
                try
                {

                    ad = new OleDbDataAdapter("SELECT * FROM tblJpVn ORDER BY JpWord", cn);
                    ad.Fill(rs, "tblJpVn");
                    com = new OleDbCommand("SELECT JpWord FROM tblJpVn ORDER BY JpWord", cn);
                    reader = com.ExecuteReader();
                    //Clear Word's ListBox
                    lstItems.Items.Clear();
                    //Clear Mean's Box
                    rtbKekka.Text = "";
                    //Load data to ListBox
                    while (reader.Read())
                    {
                        lstItems.Items.Add(reader[0].ToString());
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("Error: " + ex);
                }
                txtSearch.Focus();
            }
            else if(cmbJisho.Text=="ベトナム語ー日本語")
            {
                try
                {

                    ad = new OleDbDataAdapter("SELECT * FROM tblVnJp ORDER BY VnWord", cn);
                    ad.Fill(rs, "tblVnJp");
                    com = new OleDbCommand("SELECT VnWord FROM tblVnJp ORDER BY VnWord", cn);
                    reader = com.ExecuteReader();
                    //Clear Word's ListBox
                    lstItems.Items.Clear();
                    //Clear Mean's Box
                    rtbKekka.Text = "";
                    //Load data to ListBox
                    while (reader.Read())
                    {
                        lstItems.Items.Add(reader[0].ToString());
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("Error: " + ex);
                }
                txtSearch.Focus();

            }
            else
            {
                //Clear Word's ListBox
                lstItems.Items.Clear();
                //Clear Mean's Box
                rtbKekka.Text = "";
                
            }
       
        }

        #endregion

        #region"Search"
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        	int i;
            DataRow dr;
            try
            {
                for (i = 0; i <= lstItems.Items.Count - 1; i++)
                {

                    if (txtSearch.Text.Trim().ToUpper() == lstItems.Items[i].ToString().ToUpper().Substring(0, txtSearch.TextLength))
                {
                    //Compare selected item
                    lstItems.SelectedIndex = i;
                    //show searched word's mean
                    dr = rs.Tables[0].Rows[i];
                    rtbKekka.Clear();
                    rtbKekka.Text = "単語：" + "\n" + lstItems.SelectedItem.ToString() + "\n" + "意味：" + "\n" + dr[2].ToString().Trim();
                    HighLight();
                    
                    break;
                } 
                }
            }
            catch  {
                MessageBox.Show("検索した単語がありません。", "Message", MessageBoxButtons.OK);
            }

            
        }
        #endregion

        #region"Select Word & Insert Word to Recent Table"
        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataRow dr;
            dr = rs.Tables[0].Rows[lstItems.SelectedIndex];
            rtbKekka.Clear(); 
            rtbKekka.Text = "単語：" + "\n" + lstItems.SelectedItem.ToString() + "\n" + "意味：" + "\n" + dr[2].ToString().Trim();

            HighLight();
     
            //Insert to Recent Table
            com.CommandType = CommandType.Text;
            com = new OleDbCommand("insert into tblRecent(Word,Mean) values('" + lstItems.SelectedItem.ToString() + "'" + "," +
                                    "'" + dr[2].ToString().Trim() + "')", cn);
            com.ExecuteNonQuery();
 
        }
        #endregion

        #region"Save favorite word"
        private void btnSave_Click(object sender, EventArgs e)
        {                       
            try
            {
                cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\JPDict.accdb;");
                cn.Open();
                DataRow dr;
                dr = rs.Tables[0].Rows[lstItems.SelectedIndex];
                com.CommandType = CommandType.Text;

                com = new OleDbCommand("insert into tblFavorite(Word,Mean) values('" + lstItems.SelectedItem.ToString() + "'" + "," +
                                        "'" + dr[2].ToString().Trim() + "')", cn);
                com.ExecuteNonQuery();
                MessageBox.Show("単語を追加された!", "Message", MessageBoxButtons.OK);
            }
            catch
            {
                MessageBox.Show("単語を選んでください。","Message"); 
            }
        }
        #endregion

        #region"Text to speech"
        private void btnYomu_Click(object sender, EventArgs e)
        {
            if (rtbKekka.Text == "")
            {
                MessageBox.Show("先に辞書を使っててください!", "Message", MessageBoxButtons.OK);
            }
            else
            {
                DataRow dr;
                dr = rs.Tables[0].Rows[lstItems.SelectedIndex];
                s.SetOutputToDefaultAudioDevice();
                s.Speak(dr[2].ToString().Trim());
            }

        }
        #endregion

        #region"Word's color"
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
        #endregion

        #region"Menu/Button click"
        private void btnOnline_Click(object sender, EventArgs e)
        {
            frOnline frMain = new frOnline();

            this.Hide();
            frMain.Show();
        }

        private void バージョンToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frVersion frMain = new frVersion();
            frMain.Show();
        }

        private void btnManager_Click(object sender, EventArgs e)
        {
            frLogin frMain = new frLogin();

            this.Hide();
            frMain.Show();
        }

        private void 辞書管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frLogin frMain = new frLogin();

            this.Hide();
            frMain.Show();
        }
        private void frMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                lstItems.Height = this.Height;
                txtSearch.Height = this.Height;
                rtbKekka.Width = this.Width;
            }
        }

       private void frMain_FormClosed(object sender, FormClosedEventArgs e)
        {

            DestroyConnect();
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNinki_Click(object sender, EventArgs e)
        {
            frFavorite frMain = new frFavorite();
            this.Hide();
            frMain.Show();

        }
        private void ヘルプToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frHelp frMain = new frHelp();
            frMain.Show();
        }

        private void btnRecent_Click(object sender, EventArgs e)
        {
            frRecent frMain = new frRecent();
            this.Hide();
            frMain.Show();
        }
        #endregion
    }
}
