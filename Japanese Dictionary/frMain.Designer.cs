namespace Japanese_Dictionary
{
    partial class frMain
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
            this.btnOnline = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.終了ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.辞書管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ヘルプToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.バージョンToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpTextList = new System.Windows.Forms.GroupBox();
            this.lstItems = new System.Windows.Forms.ListBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.rtbKekka = new System.Windows.Forms.RichTextBox();
            this.grpjisho = new System.Windows.Forms.GroupBox();
            this.cmbJisho = new System.Windows.Forms.ComboBox();
            this.grpImi = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnManager = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNinki = new System.Windows.Forms.Button();
            this.btnYomu = new System.Windows.Forms.Button();
            this.btnRecent = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.grpTextList.SuspendLayout();
            this.grpSearch.SuspendLayout();
            this.grpjisho.SuspendLayout();
            this.grpImi.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOnline
            // 
            this.btnOnline.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnOnline.Location = new System.Drawing.Point(183, 16);
            this.btnOnline.Name = "btnOnline";
            this.btnOnline.Size = new System.Drawing.Size(175, 25);
            this.btnOnline.TabIndex = 0;
            this.btnOnline.Text = "Online Translate";
            this.btnOnline.UseVisualStyleBackColor = true;
            this.btnOnline.Click += new System.EventHandler(this.btnOnline_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem,
            this.辞書管理ToolStripMenuItem,
            this.ヘルプToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(664, 24);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.終了ToolStripMenuItem});
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ファイルToolStripMenuItem.Text = "ファイル";
            // 
            // 終了ToolStripMenuItem
            // 
            this.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            this.終了ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.終了ToolStripMenuItem.Text = "終了";
            this.終了ToolStripMenuItem.Click += new System.EventHandler(this.終了ToolStripMenuItem_Click);
            // 
            // 辞書管理ToolStripMenuItem
            // 
            this.辞書管理ToolStripMenuItem.Name = "辞書管理ToolStripMenuItem";
            this.辞書管理ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.辞書管理ToolStripMenuItem.Text = "辞書管理";
            this.辞書管理ToolStripMenuItem.Click += new System.EventHandler(this.辞書管理ToolStripMenuItem_Click);
            // 
            // ヘルプToolStripMenuItem
            // 
            this.ヘルプToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.バージョンToolStripMenuItem});
            this.ヘルプToolStripMenuItem.Name = "ヘルプToolStripMenuItem";
            this.ヘルプToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.ヘルプToolStripMenuItem.Text = "ヘルプ";
            // 
            // バージョンToolStripMenuItem
            // 
            this.バージョンToolStripMenuItem.Name = "バージョンToolStripMenuItem";
            this.バージョンToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.バージョンToolStripMenuItem.Text = "バージョン";
            this.バージョンToolStripMenuItem.Click += new System.EventHandler(this.バージョンToolStripMenuItem_Click);
            // 
            // grpTextList
            // 
            this.grpTextList.Controls.Add(this.lstItems);
            this.grpTextList.Location = new System.Drawing.Point(12, 88);
            this.grpTextList.Name = "grpTextList";
            this.grpTextList.Size = new System.Drawing.Size(222, 265);
            this.grpTextList.TabIndex = 26;
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
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtSearch.Location = new System.Drawing.Point(6, 18);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(210, 19);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // grpSearch
            // 
            this.grpSearch.Controls.Add(this.txtSearch);
            this.grpSearch.Location = new System.Drawing.Point(12, 27);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(222, 55);
            this.grpSearch.TabIndex = 27;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "検索";
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
            // grpjisho
            // 
            this.grpjisho.Controls.Add(this.cmbJisho);
            this.grpjisho.Controls.Add(this.btnOnline);
            this.grpjisho.Location = new System.Drawing.Point(290, 27);
            this.grpjisho.Name = "grpjisho";
            this.grpjisho.Size = new System.Drawing.Size(364, 55);
            this.grpjisho.TabIndex = 34;
            this.grpjisho.TabStop = false;
            this.grpjisho.Text = "辞書";
            // 
            // cmbJisho
            // 
            this.cmbJisho.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbJisho.FormattingEnabled = true;
            this.cmbJisho.Items.AddRange(new object[] {
            "日本語ーベトナム語",
            "ベトナム語ー日本語",
            "日本語ー英語",
            "英語－日本語"});
            this.cmbJisho.Location = new System.Drawing.Point(6, 17);
            this.cmbJisho.Name = "cmbJisho";
            this.cmbJisho.Size = new System.Drawing.Size(170, 20);
            this.cmbJisho.TabIndex = 0;
            this.cmbJisho.Text = "辞書を選択してください。。。";
            this.cmbJisho.SelectedIndexChanged += new System.EventHandler(this.cmbJisho_SelectedIndexChanged);
            // 
            // grpImi
            // 
            this.grpImi.Controls.Add(this.rtbKekka);
            this.grpImi.Location = new System.Drawing.Point(286, 88);
            this.grpImi.Name = "grpImi";
            this.grpImi.Size = new System.Drawing.Size(368, 265);
            this.grpImi.TabIndex = 28;
            this.grpImi.TabStop = false;
            this.grpImi.Text = "意味";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(468, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 27);
            this.label1.TabIndex = 37;
            this.label1.Text = "Japanese Dictionary";
            // 
            // btnManager
            // 
            this.btnManager.BackgroundImage = global::Japanese_Dictionary.Properties.Resources.manager;
            this.btnManager.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnManager.Location = new System.Drawing.Point(240, 290);
            this.btnManager.Name = "btnManager";
            this.btnManager.Size = new System.Drawing.Size(40, 40);
            this.btnManager.TabIndex = 36;
            this.btnManager.UseVisualStyleBackColor = true;
            this.btnManager.Click += new System.EventHandler(this.btnManager_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::Japanese_Dictionary.Properties.Resources.save;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.Location = new System.Drawing.Point(240, 198);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(40, 40);
            this.btnSave.TabIndex = 35;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNinki
            // 
            this.btnNinki.BackgroundImage = global::Japanese_Dictionary.Properties.Resources.heart;
            this.btnNinki.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNinki.Location = new System.Drawing.Point(240, 152);
            this.btnNinki.Name = "btnNinki";
            this.btnNinki.Size = new System.Drawing.Size(40, 40);
            this.btnNinki.TabIndex = 32;
            this.btnNinki.UseVisualStyleBackColor = true;
            this.btnNinki.Click += new System.EventHandler(this.btnNinki_Click);
            // 
            // btnYomu
            // 
            this.btnYomu.BackgroundImage = global::Japanese_Dictionary.Properties.Resources.speaker;
            this.btnYomu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnYomu.Location = new System.Drawing.Point(240, 106);
            this.btnYomu.Name = "btnYomu";
            this.btnYomu.Size = new System.Drawing.Size(40, 40);
            this.btnYomu.TabIndex = 30;
            this.btnYomu.UseVisualStyleBackColor = true;
            this.btnYomu.Click += new System.EventHandler(this.btnYomu_Click);
            // 
            // btnRecent
            // 
            this.btnRecent.BackgroundImage = global::Japanese_Dictionary.Properties.Resources.history;
            this.btnRecent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRecent.Location = new System.Drawing.Point(240, 244);
            this.btnRecent.Name = "btnRecent";
            this.btnRecent.Size = new System.Drawing.Size(40, 40);
            this.btnRecent.TabIndex = 38;
            this.btnRecent.UseVisualStyleBackColor = true;
            this.btnRecent.Click += new System.EventHandler(this.btnRecent_Click);
            // 
            // frMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 368);
            this.Controls.Add(this.btnRecent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnManager);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNinki);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.grpTextList);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.grpjisho);
            this.Controls.Add(this.grpImi);
            this.Controls.Add(this.btnYomu);
            this.Name = "frMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Japanese Dictionary";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpTextList.ResumeLayout(false);
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.grpjisho.ResumeLayout(false);
            this.grpImi.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOnline;
        private System.Windows.Forms.Button btnManager;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNinki;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 終了ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 辞書管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ヘルプToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem バージョンToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpTextList;
        private System.Windows.Forms.ListBox lstItems;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.RichTextBox rtbKekka;
        private System.Windows.Forms.GroupBox grpjisho;
        private System.Windows.Forms.ComboBox cmbJisho;
        private System.Windows.Forms.GroupBox grpImi;
        private System.Windows.Forms.Button btnYomu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRecent;
    }
}