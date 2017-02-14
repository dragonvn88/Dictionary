using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.WebSockets;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Web;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Speech.Synthesis;
using Synthesizer = System.Speech.Synthesis.SpeechSynthesizer;
using System.Data.OleDb;


namespace Japanese_Dictionary
{
    public partial class frOnline : Form
    {
        private OleDbConnection cn;
        private OleDbDataReader reader;
        private OleDbCommand com;
        private DataSet rs;
        private OleDbDataAdapter ad;
        private Synthesizer s = new Synthesizer();
        VoiceGender gender = VoiceGender.Female;
        VoiceAge age = VoiceAge.Adult;
        private AdmAuthentication _auth;
        string kara;
        string made;
        public frOnline()
        {
            InitializeComponent();
            s.SelectVoiceByHints(gender, age);
            try
            {
                _auth = new AdmAuthentication("***clientId***", "***clientSecret***");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
            cn.Close(); //Đóng kết nối
            cn.Dispose();//Giải phóng tài nguyên
            cn = null; //Hủy đối tượng
        }
        #endregion

        private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTo.Text == "ベトナム語")
            {
                made = "vi";
            }
            else if (cmbTo.Text == "日本語")
            {
                made = "ja";
            }
            else
            {
                made = "en";
            }

        }
        private void cmbFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFrom.Text == "ベトナム語")
            {
                kara = "vi";
            }
            else if (cmbFrom.Text == "日本語")
            {
                kara = "ja";
            }
            else
            {
                kara = "en";
            }
          
        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            if (cmbFrom.Text != cmbTo.Text)
            {
                string from = kara;
                string to = made;
                txbTo.Text = Translate(txbFrom.Text, from, to);
            }
            else
            {
                MessageBox.Show("言語を選んでください。!");
            }

        }
        private string Translate(string text, string from, string to)
        {
            string uri = "http://api.microsofttranslator.com/v2/Http.svc/Translate?text=" + System.Web.HttpUtility.UrlEncode(text) + "&from=" + from + "&to=" + to;
            string authToken = "Bearer" + " " + _auth.GetAccessToken().access_token;
            string translation = string.Empty;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.Headers.Add("Authorization", authToken);

            WebResponse response = null;
            try
            {
                response = httpWebRequest.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    System.Runtime.Serialization.DataContractSerializer dcs =
                        new System.Runtime.Serialization.DataContractSerializer(Type.GetType("System.String"));
                    translation = (string)dcs.ReadObject(stream);
                }
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
            }

            return translation;
        }

        private void frOnline_Closed(object sender, EventArgs e)
        {
            frMain frOnline = new frMain();
            this.Hide();
            frOnline.Show();
        }

        private void btnSpeak_Click(object sender, EventArgs e)
        {
            if (txbTo.Text == "")
            {
                MessageBox.Show("先に翻訳してください!", "Message", MessageBoxButtons.OK);
            }
            else
            {
                s.SetOutputToDefaultAudioDevice();
                s.Speak(txbTo.Text);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //MyConnect();

            if ((cmbFrom.Text == "英語") && (cmbTo.Text == "日本語"))
            {
                try
                {
                    MyConnect();
                    //Insert to tblEnJP
                    ad = new OleDbDataAdapter("SELECT * FROM tblEnJp ORDER BY EnWord", cn);
                    ad.Fill(rs, "tblEnJp");
                    com = new OleDbCommand("SELECT EnWord FROM tblEnJp ORDER BY EnWord", cn);
                    reader = com.ExecuteReader();
                    com.CommandType = CommandType.Text;
                    com = new OleDbCommand("insert into tblEnJp(EnWord,JpMean) values('" + txbFrom.Text + "'" + "," +
                                            "'" + txbTo.Text + "')", cn);
                    com.ExecuteNonQuery();

                    MessageBox.Show("単語を追加された!", "Message", MessageBoxButtons.OK);
                    cn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            }
            else if ((cmbFrom.Text == "日本語") && (cmbTo.Text == "英語"))
            {
                try
                {
                    MyConnect();
                    //Insert to tblJpEn
                    ad = new OleDbDataAdapter("SELECT * FROM tblJpEn ORDER BY JpWord", cn);
                    ad.Fill(rs, "tblJpEn");
                    com = new OleDbCommand("SELECT JpWord FROM tblJpEn ORDER BY JpWord", cn);
                    reader = com.ExecuteReader();
                    com.CommandType = CommandType.Text;
                    com = new OleDbCommand("insert into tblJpEn(JpWord,EnMean) values('" + txbFrom.Text + "'" + "," +
                                            "'" + txbTo.Text + "')", cn);
                    com.ExecuteNonQuery();

                    MessageBox.Show("単語を追加された!", "Message", MessageBoxButtons.OK);
                    cn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }

            }
            else if ((cmbFrom.Text == "日本語") && (cmbTo.Text == "ベトナム語"))
            {
                try
                {
                    MyConnect();
                    //Insert to tblJpVn
                    ad = new OleDbDataAdapter("SELECT * FROM tblJpVn ORDER BY JpWord", cn);
                    ad.Fill(rs, "tblJpVn");
                    com = new OleDbCommand("SELECT JpWord FROM tblJpVn ORDER BY JpWord", cn);
                    reader = com.ExecuteReader();
                    com.CommandType = CommandType.Text;
                    com = new OleDbCommand("insert into tblJpVn(JpWord,VnMean) values('" + txbFrom.Text + "'" + "," +
                                            "'" + txbTo.Text + "')", cn);
                    com.ExecuteNonQuery();

                    MessageBox.Show("単語を追加された!", "Message", MessageBoxButtons.OK);
                    cn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }

            }
            else if ((cmbFrom.Text == "ベトナム語") && (cmbTo.Text == "日本語"))
            {
                try
                {
                    MyConnect();
                    //Insert to tblVnJp
                    ad = new OleDbDataAdapter("SELECT * FROM tblVnJp ORDER BY VnWord", cn);
                    ad.Fill(rs, "tblVnJp");
                    com = new OleDbCommand("SELECT VnWord FROM tblVnJp ORDER BY VnWord", cn);
                    reader = com.ExecuteReader();
                    com.CommandType = CommandType.Text;
                    com = new OleDbCommand("insert into tblVnJp(VnWord,JpMean) values('" + txbFrom.Text + "'" + "," +
                                            "'" + txbTo.Text + "')", cn);
                    com.ExecuteNonQuery();

                    MessageBox.Show("単語を追加された!", "Message", MessageBoxButtons.OK);
                    cn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            }
            else
            {
                MessageBox.Show("言語を正しく選んでください。(英語ー日本語/日本語ー英語/ベトナム語ー日本語/日本語ーベトナム語だけ保存することができます。)", "Message", MessageBoxButtons.OK);
            }

        }


    }
}
