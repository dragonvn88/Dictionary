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
    public partial class frLogin : Form
    {
        
        private OleDbConnection cn;
        //private OleDbDataReader reader;
        //private OleDbCommand com;
        private DataSet rs;
        //private OleDbDataAdapter ad;
        private DataTable dt;


        public frLogin()
        {

            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frMain frLogin = new frMain();
            this.Hide();
            frLogin.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MyConnect();
            dt = new DataTable();
            //get ID password
            string sql = "Select * from tblLogin where ID='" + txtID.Text + "' AND Password='" + txtPw.Text + "'";
            OleDbDataAdapter da = new OleDbDataAdapter(sql, cn);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                this.Hide();
                new frManager().Show();
            }
            else
            {
                MessageBox.Show("正しくユーザー/パスワードを入力してください。");
            }
            
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

    }
}
