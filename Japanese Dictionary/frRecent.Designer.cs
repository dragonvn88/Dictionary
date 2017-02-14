namespace Japanese_Dictionary
{
    partial class frRecent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpTextList = new System.Windows.Forms.GroupBox();
            this.lstItems = new System.Windows.Forms.ListBox();
            this.grpImi = new System.Windows.Forms.GroupBox();
            this.rtbKekka = new System.Windows.Forms.RichTextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.grpTextList.SuspendLayout();
            this.grpImi.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpTextList
            // 
            this.grpTextList.Controls.Add(this.lstItems);
            this.grpTextList.Location = new System.Drawing.Point(11, 12);
            this.grpTextList.Name = "grpTextList";
            this.grpTextList.Size = new System.Drawing.Size(222, 265);
            this.grpTextList.TabIndex = 39;
            this.grpTextList.TabStop = false;
            this.grpTextList.Text = "単語リスト";
            // 
            // lstItems
            // 
            this.lstItems.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lstItems.FormattingEnabled = true;
            this.lstItems.ItemHeight = 15;
            this.lstItems.Location = new System.Drawing.Point(6, 18);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(210, 229);
            this.lstItems.TabIndex = 0;
            this.lstItems.SelectedIndexChanged += new System.EventHandler(this.lstItems_SelectedIndexChanged);
            // 
            // grpImi
            // 
            this.grpImi.Controls.Add(this.rtbKekka);
            this.grpImi.Location = new System.Drawing.Point(239, 12);
            this.grpImi.Name = "grpImi";
            this.grpImi.Size = new System.Drawing.Size(368, 265);
            this.grpImi.TabIndex = 40;
            this.grpImi.TabStop = false;
            this.grpImi.Text = "意味";
            // 
            // rtbKekka
            // 
            this.rtbKekka.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rtbKekka.Location = new System.Drawing.Point(6, 18);
            this.rtbKekka.Name = "rtbKekka";
            this.rtbKekka.Size = new System.Drawing.Size(356, 232);
            this.rtbKekka.TabIndex = 5;
            this.rtbKekka.Text = "";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(532, 286);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 41;
            this.btnBack.Text = "戻り";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(451, 286);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 42;
            this.btnClear.Text = "クリア";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frRecent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 321);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.grpTextList);
            this.Controls.Add(this.grpImi);
            this.Name = "frRecent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "最近の検索単語";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frRecent_FormClosed);
            this.Load += new System.EventHandler(this.frRecent_Load);
            this.grpTextList.ResumeLayout(false);
            this.grpImi.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpTextList;
        private System.Windows.Forms.ListBox lstItems;
        private System.Windows.Forms.GroupBox grpImi;
        private System.Windows.Forms.RichTextBox rtbKekka;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnClear;



    }
}