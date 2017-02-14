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
    public partial class frManager : Form
    {
        private OleDbConnection cn;
        private OleDbDataReader reader;
        private OleDbCommand com;
        private DataSet rs;
        private OleDbDataAdapter ad;
        private DataTable dt;

        public frManager()
        {
            InitializeComponent();
        }
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
        private void frManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            frMain frManager = new frMain();
            this.Hide();
            frManager.Show();

        }

        #region"Load data into DataGridWiew"


        private void cmbJisho_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyConnect();

            if (cmbJisho.Text == "英語－日本語")
            {
                try
                {

                    ad = new OleDbDataAdapter("SELECT * FROM tblEnJp ORDER BY EnWord", cn);
                    ad.Fill(rs, "tblEnJp");
                    com = new OleDbCommand("SELECT ID,EnWord,JpMean FROM tblEnJp ORDER BY EnWord", cn);
                    reader = com.ExecuteReader();

                    dt = new DataTable("abc");
                    dt.Load(reader);
                    dataGridView.DataSource = null;

                    dataGridView.DataSource = dt;
                    com.Dispose();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }


            }
            else if (cmbJisho.Text == "日本語ー英語")
            {
                try
                {

                    ad = new OleDbDataAdapter("SELECT * FROM tblJpEn ORDER BY JpWord", cn);
                    ad.Fill(rs, "tblJpEn");
                    com = new OleDbCommand("SELECT ID,JpWord,EnMean FROM tblJpEn ORDER BY JpWord", cn);
                    reader = com.ExecuteReader();

                    dt = new DataTable("abc");
                    dt.Load(reader);
                    dataGridView.DataSource = null;

                    dataGridView.DataSource = dt;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }


            }
            else if (cmbJisho.Text == "日本語ーベトナム語")
            {
                try
                {

                    ad = new OleDbDataAdapter("SELECT * FROM tblJpVn ORDER BY JpWord", cn);
                    ad.Fill(rs, "tblJpVn");
                    com = new OleDbCommand("SELECT ID,JpWord,VnMean FROM tblJpVn ORDER BY JpWord", cn);
                    reader = com.ExecuteReader();

                    dt = new DataTable("abc");
                    dt.Load(reader);
                    dataGridView.DataSource = null;

                    dataGridView.DataSource = dt;
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }

            }
            else if (cmbJisho.Text == "ベトナム語ー日本語")
            {
                try
                {

                    ad = new OleDbDataAdapter("SELECT * FROM tblVnJp ORDER BY VnWord", cn);
                    ad.Fill(rs, "tblVnJp");
                    com = new OleDbCommand("SELECT ID,VnWord,JpMean FROM tblVnJp ORDER BY VnWord", cn);
                    reader = com.ExecuteReader();

                    dt = new DataTable("abc");
                    dt.Load(reader);
                    dataGridView.DataSource = null;

                    dataGridView.DataSource = dt;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }


            }
            else
            {

                MessageBox.Show("Please Choose Dictionary");
            }
        }
        #endregion
        #region "Add button"
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbJisho.Text == "英語－日本語")
            {
                try
                {
                    //Insert to tblEnJP
                    com.CommandType = CommandType.Text;
                    com = new OleDbCommand("insert into tblEnJp(EnWord,JpMean) values('" + txtWord.Text + "'" + "," +
                                            "'" + txtMean.Text + "')", cn);
                    com.ExecuteNonQuery();

                    //Update
                    ad = new OleDbDataAdapter("SELECT * FROM tblEnJp ORDER BY EnWord", cn);
                    ad.Fill(rs, "tblEnJp");
                    com = new OleDbCommand("SELECT ID,EnWord,JpMean FROM tblEnJp ORDER BY EnWord", cn);
                    reader = com.ExecuteReader();

                    dt = new DataTable("abc");
                    dt.Load(reader);
                    dataGridView.DataSource = null;

                    dataGridView.DataSource = dt;
                    MessageBox.Show("単語を追加された!", "Message", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }


            }
            else if (cmbJisho.Text == "日本語ー英語")
            {
                try
                {

                    //Insert to tblJpEn
                    com.CommandType = CommandType.Text;
                    com = new OleDbCommand("insert into tblJpEn(JpWord,EnMean) values('" + txtWord.Text + "'" + "," +
                                            "'" + txtMean.Text + "')", cn);
                    com.ExecuteNonQuery();

                    //Update
                    ad = new OleDbDataAdapter("SELECT * FROM tblJpEn ORDER BY JpWord", cn);
                    ad.Fill(rs, "tblJpEn");
                    com = new OleDbCommand("SELECT ID,JpWord,EnMean FROM tblJpEn ORDER BY JpWord", cn);
                    reader = com.ExecuteReader();

                    dt = new DataTable("abc");
                    dt.Load(reader);
                    dataGridView.DataSource = null;

                    dataGridView.DataSource = dt;
                    MessageBox.Show("単語を追加された!", "Message", MessageBoxButtons.OK);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }


            }
            else if (cmbJisho.Text == "日本語ーベトナム語")
            {
                try
                {

                    //Insert to tblJpVn
                    com.CommandType = CommandType.Text;
                    com = new OleDbCommand("insert into tblJpVn(JpWord,VnMean) values('" + txtWord.Text + "'" + "," +
                                            "'" + txtMean.Text + "')", cn);
                    com.ExecuteNonQuery();

                    //Update
                    ad = new OleDbDataAdapter("SELECT * FROM tblJpVn ORDER BY JpWord", cn);
                    ad.Fill(rs, "tblJpVn");
                    com = new OleDbCommand("SELECT ID,JpWord,VnMean FROM tblJpVn ORDER BY JpWord", cn);
                    reader = com.ExecuteReader();
                    dt = new DataTable("abc");
                    dt.Load(reader);
                    dataGridView.DataSource = null;

                    dataGridView.DataSource = dt;
                    MessageBox.Show("単語を追加された!", "Message", MessageBoxButtons.OK);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }

            }
            else if (cmbJisho.Text == "ベトナム語ー日本語")
            {
                try
                {

                    //Insert to tblVnJP
                    com.CommandType = CommandType.Text;
                    com = new OleDbCommand("insert into tblVnJp(VnWord,JpMean) values('" + txtWord.Text + "'" + "," +
                                            "'" + txtMean.Text + "')", cn);
                    com.ExecuteNonQuery();

                    //Update
                    ad = new OleDbDataAdapter("SELECT * FROM tblVnJp ORDER BY VnWord", cn);
                    ad.Fill(rs, "tblVnJp");
                    com = new OleDbCommand("SELECT ID,VnWord,JpMean FROM tblVnJp ORDER BY VnWord", cn);
                    reader = com.ExecuteReader();
                    dt = new DataTable("abc");
                    dt.Load(reader);
                    dataGridView.DataSource = null;

                    dataGridView.DataSource = dt;
                    MessageBox.Show("単語を追加された!", "Message", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }


            }
            else
            {

                MessageBox.Show("Please Choose Dictionary");
            }
        }
        #endregion
 
        #region "Delete Button"
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (cmbJisho.Text == "英語－日本語")
            {
                try
                {
                    //Delete from tblEnJP
                    com = new OleDbCommand("Delete From tblEnJp where EnWord = '" + txtWord.Text + "'", cn);
                    com.ExecuteNonQuery();

                    //Update
                    ad = new OleDbDataAdapter("SELECT * FROM tblEnJp ORDER BY EnWord", cn);
                    ad.Fill(rs, "tblEnJp");
                    com = new OleDbCommand("SELECT ID,EnWord,JpMean FROM tblEnJp ORDER BY EnWord", cn);
                    reader = com.ExecuteReader();
                    dt = new DataTable("abc");
                    dt.Load(reader);
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = dt;
                    MessageBox.Show("単語を削除された!", "Message", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }


            }
            else if (cmbJisho.Text == "日本語ー英語")
            {
                try
                {

                    //Delete from tblJpEn
                    com = new OleDbCommand("Delete From tblJpEn where JpWord = '" + txtWord.Text + "'", cn);
                    com.ExecuteNonQuery();

                    //Update
                    ad = new OleDbDataAdapter("SELECT * FROM tblJpEn ORDER BY JpWord", cn);
                    ad.Fill(rs, "tblJpEn");
                    com = new OleDbCommand("SELECT ID,JpWord,EnMean FROM tblJpEn ORDER BY JpWord", cn);
                    reader = com.ExecuteReader();
                    dt = new DataTable("abc");
                    dt.Load(reader);
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = dt;
                    MessageBox.Show("単語を削除された!", "Message", MessageBoxButtons.OK);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }


            }
            else if (cmbJisho.Text == "日本語ーベトナム語")
            {
                try
                {

                    //Delete from tblJpVn
                    com = new OleDbCommand("Delete From tblJpVn where JpWord = '" + txtWord.Text + "'", cn);
                    com.ExecuteNonQuery();

                    //Update
                    ad = new OleDbDataAdapter("SELECT * FROM tblJpVn ORDER BY JpWord", cn);
                    ad.Fill(rs, "tblJpVn");
                    com = new OleDbCommand("SELECT ID,JpWord,VnMean FROM tblJpVn ORDER BY JpWord", cn);
                    reader = com.ExecuteReader();
                    dt = new DataTable("abc");
                    dt.Load(reader);
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = dt;
                    MessageBox.Show("単語を削除された!", "Message", MessageBoxButtons.OK);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }

            }
            else if (cmbJisho.Text == "ベトナム語ー日本語")
            {
                try
                {

                    //Delete from tblVnJp
                    com = new OleDbCommand("Delete From tblVnJp where VnWord = '" + txtWord.Text + "'", cn);
                    com.ExecuteNonQuery();

                    //Update
                    ad = new OleDbDataAdapter("SELECT * FROM tblVnJp ORDER BY VnWord", cn);
                    ad.Fill(rs, "tblVnJp");
                    com = new OleDbCommand("SELECT ID,VnWord,JpMean FROM tblVnJp ORDER BY VnWord", cn);
                    reader = com.ExecuteReader();
                    dt = new DataTable("abc");
                    dt.Load(reader);
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = dt;
                    MessageBox.Show("単語を削除された!", "Message", MessageBoxButtons.OK);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }


            }
            else
            {

                MessageBox.Show("Please Choose Dictionary");
            }
        }
        #endregion
        #region"Load data to textBox"
        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            int item = dataGridView.CurrentCell.RowIndex;
            loadItem(item);
        }

        private void loadItem(int item)
        {
            try
            {
                txtID.Text = dataGridView.Rows[item].Cells[0].Value.ToString().Trim();
                txtWord.Text = dataGridView.Rows[item].Cells[1].Value.ToString();
                txtMean.Text = dataGridView.Rows[item].Cells[2].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }
        #endregion

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMean.Text = "";
            txtWord.Text = "";
            txtID.Text = "";
        }


        private void BtnBack_Click(object sender, EventArgs e)
        {
            frMain frManager = new frMain();
            this.Hide();
            frManager.Show();

        }




    }

}
