namespace PhotogrammetryWin
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            文件ToolStripMenuItem = new ToolStripMenuItem();
            打开后方交会文件ToolStripMenuItem = new ToolStripMenuItem();
            打开相对定向文件ToolStripMenuItem = new ToolStripMenuItem();
            保存运算结果ToolStripMenuItem = new ToolStripMenuItem();
            计算ToolStripMenuItem = new ToolStripMenuItem();
            后方交会ToolStripMenuItem = new ToolStripMenuItem();
            相对定向ToolStripMenuItem = new ToolStripMenuItem();
            groupBox1 = new GroupBox();
            textBoxRead = new TextBox();
            groupBox2 = new GroupBox();
            textBoxResult = new TextBox();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { 文件ToolStripMenuItem, 计算ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(966, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            文件ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 打开后方交会文件ToolStripMenuItem, 打开相对定向文件ToolStripMenuItem, 保存运算结果ToolStripMenuItem });
            文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            文件ToolStripMenuItem.Size = new Size(53, 24);
            文件ToolStripMenuItem.Text = "文件";
            // 
            // 打开后方交会文件ToolStripMenuItem
            // 
            打开后方交会文件ToolStripMenuItem.Name = "打开后方交会文件ToolStripMenuItem";
            打开后方交会文件ToolStripMenuItem.Size = new Size(224, 26);
            打开后方交会文件ToolStripMenuItem.Text = "打开后方交会文件";
            打开后方交会文件ToolStripMenuItem.Click += 打开后方交会文件ToolStripMenuItem_Click;
            // 
            // 打开相对定向文件ToolStripMenuItem
            // 
            打开相对定向文件ToolStripMenuItem.Name = "打开相对定向文件ToolStripMenuItem";
            打开相对定向文件ToolStripMenuItem.Size = new Size(224, 26);
            打开相对定向文件ToolStripMenuItem.Text = "打开相对定向文件";
            打开相对定向文件ToolStripMenuItem.Click += 打开相对定向文件ToolStripMenuItem_Click;
            // 
            // 保存运算结果ToolStripMenuItem
            // 
            保存运算结果ToolStripMenuItem.Name = "保存运算结果ToolStripMenuItem";
            保存运算结果ToolStripMenuItem.Size = new Size(224, 26);
            保存运算结果ToolStripMenuItem.Text = "保存运算结果";
            保存运算结果ToolStripMenuItem.Click += 保存运算结果ToolStripMenuItem_Click;
            // 
            // 计算ToolStripMenuItem
            // 
            计算ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 后方交会ToolStripMenuItem, 相对定向ToolStripMenuItem });
            计算ToolStripMenuItem.Name = "计算ToolStripMenuItem";
            计算ToolStripMenuItem.Size = new Size(53, 24);
            计算ToolStripMenuItem.Text = "计算";
            // 
            // 后方交会ToolStripMenuItem
            // 
            后方交会ToolStripMenuItem.Name = "后方交会ToolStripMenuItem";
            后方交会ToolStripMenuItem.Size = new Size(152, 26);
            后方交会ToolStripMenuItem.Text = "后方交会";
            后方交会ToolStripMenuItem.Click += 后方交会ToolStripMenuItem_Click;
            // 
            // 相对定向ToolStripMenuItem
            // 
            相对定向ToolStripMenuItem.Name = "相对定向ToolStripMenuItem";
            相对定向ToolStripMenuItem.Size = new Size(152, 26);
            相对定向ToolStripMenuItem.Text = "相对定向";
            相对定向ToolStripMenuItem.Click += 相对定向ToolStripMenuItem_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxRead);
            groupBox1.Location = new Point(12, 31);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(942, 300);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "读取数据";
            // 
            // textBoxRead
            // 
            textBoxRead.Location = new Point(6, 26);
            textBoxRead.Multiline = true;
            textBoxRead.Name = "textBoxRead";
            textBoxRead.ScrollBars = ScrollBars.Both;
            textBoxRead.Size = new Size(930, 268);
            textBoxRead.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBoxResult);
            groupBox2.Location = new Point(12, 337);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(942, 300);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "计算结果";
            // 
            // textBoxResult
            // 
            textBoxResult.Location = new Point(6, 26);
            textBoxResult.Multiline = true;
            textBoxResult.Name = "textBoxResult";
            textBoxResult.ScrollBars = ScrollBars.Both;
            textBoxResult.Size = new Size(930, 268);
            textBoxResult.TabIndex = 0;
            // 
            // MainForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(966, 653);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem 文件ToolStripMenuItem;
        private ToolStripMenuItem 打开后方交会文件ToolStripMenuItem;
        private ToolStripMenuItem 打开相对定向文件ToolStripMenuItem;
        private ToolStripMenuItem 保存运算结果ToolStripMenuItem;
        private ToolStripMenuItem 计算ToolStripMenuItem;
        private ToolStripMenuItem 后方交会ToolStripMenuItem;
        private ToolStripMenuItem 相对定向ToolStripMenuItem;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox textBoxRead;
        private TextBox textBoxResult;
    }
}
