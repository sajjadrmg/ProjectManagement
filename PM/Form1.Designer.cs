namespace PM
{
    partial class Form1
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
            projectToolStripMenuItem = new ToolStripMenuItem();
            newProjectToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            reportToolStripMenuItem = new ToolStripMenuItem();
            finishDayToolStripMenuItem = new ToolStripMenuItem();
            mounthlyReportToolStripMenuItem = new ToolStripMenuItem();
            settingToolStripMenuItem = new ToolStripMenuItem();
            groupBox1 = new GroupBox();
            treeViewProject = new TreeView();
            textBoxCodePath = new TextBox();
            gbToDO = new GroupBox();
            checkedListBoxToDo = new CheckedListBox();
            btnAddUpdateToDo = new Button();
            textBoxToDoInput = new TextBox();
            gbAI = new GroupBox();
            textBox4 = new TextBox();
            button2 = new Button();
            textBox3 = new TextBox();
            panel1 = new Panel();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            gbToDO.SuspendLayout();
            gbAI.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { projectToolStripMenuItem, reportToolStripMenuItem, settingToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1165, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // projectToolStripMenuItem
            // 
            projectToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newProjectToolStripMenuItem, loadToolStripMenuItem });
            projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            projectToolStripMenuItem.Size = new Size(82, 29);
            projectToolStripMenuItem.Text = "Project";
            // 
            // newProjectToolStripMenuItem
            // 
            newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            newProjectToolStripMenuItem.Size = new Size(153, 34);
            newProjectToolStripMenuItem.Text = "New";
            newProjectToolStripMenuItem.Click += newProjectToolStripMenuItem_Click;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(153, 34);
            loadToolStripMenuItem.Text = "Load";
            // 
            // reportToolStripMenuItem
            // 
            reportToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { finishDayToolStripMenuItem, mounthlyReportToolStripMenuItem });
            reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            reportToolStripMenuItem.Size = new Size(81, 29);
            reportToolStripMenuItem.Text = "Report";
            // 
            // finishDayToolStripMenuItem
            // 
            finishDayToolStripMenuItem.Name = "finishDayToolStripMenuItem";
            finishDayToolStripMenuItem.Size = new Size(270, 34);
            finishDayToolStripMenuItem.Text = "FinishDay";
            finishDayToolStripMenuItem.Click += finishDayToolStripMenuItem_Click;
            // 
            // mounthlyReportToolStripMenuItem
            // 
            mounthlyReportToolStripMenuItem.Name = "mounthlyReportToolStripMenuItem";
            mounthlyReportToolStripMenuItem.Size = new Size(270, 34);
            mounthlyReportToolStripMenuItem.Text = "Mounthly Report";
            // 
            // settingToolStripMenuItem
            // 
            settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            settingToolStripMenuItem.Size = new Size(84, 29);
            settingToolStripMenuItem.Text = "Setting";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(treeViewProject);
            groupBox1.Controls.Add(textBoxCodePath);
            groupBox1.Dock = DockStyle.Left;
            groupBox1.Location = new Point(0, 33);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(300, 469);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "ProjectExplorer";
            // 
            // treeViewProject
            // 
            treeViewProject.Dock = DockStyle.Fill;
            treeViewProject.Location = new Point(3, 27);
            treeViewProject.Name = "treeViewProject";
            treeViewProject.Size = new Size(294, 408);
            treeViewProject.TabIndex = 2;
            treeViewProject.NodeMouseDoubleClick += treeViewProject_NodeMouseDoubleClick;
            // 
            // textBoxCodePath
            // 
            textBoxCodePath.Dock = DockStyle.Bottom;
            textBoxCodePath.Location = new Point(3, 435);
            textBoxCodePath.Name = "textBoxCodePath";
            textBoxCodePath.Size = new Size(294, 31);
            textBoxCodePath.TabIndex = 1;
            // 
            // gbToDO
            // 
            gbToDO.Controls.Add(checkedListBoxToDo);
            gbToDO.Controls.Add(btnAddUpdateToDo);
            gbToDO.Controls.Add(textBoxToDoInput);
            gbToDO.Dock = DockStyle.Left;
            gbToDO.Location = new Point(300, 33);
            gbToDO.Name = "gbToDO";
            gbToDO.Size = new Size(300, 469);
            gbToDO.TabIndex = 2;
            gbToDO.TabStop = false;
            gbToDO.Text = "ToDolist";
            // 
            // checkedListBoxToDo
            // 
            checkedListBoxToDo.Dock = DockStyle.Fill;
            checkedListBoxToDo.FormattingEnabled = true;
            checkedListBoxToDo.Location = new Point(3, 178);
            checkedListBoxToDo.Name = "checkedListBoxToDo";
            checkedListBoxToDo.ScrollAlwaysVisible = true;
            checkedListBoxToDo.Size = new Size(294, 288);
            checkedListBoxToDo.TabIndex = 3;
            // 
            // btnAddUpdateToDo
            // 
            btnAddUpdateToDo.Dock = DockStyle.Top;
            btnAddUpdateToDo.Location = new Point(3, 144);
            btnAddUpdateToDo.Name = "btnAddUpdateToDo";
            btnAddUpdateToDo.Size = new Size(294, 34);
            btnAddUpdateToDo.TabIndex = 2;
            btnAddUpdateToDo.Text = "Add/Edit";
            btnAddUpdateToDo.UseVisualStyleBackColor = true;
            btnAddUpdateToDo.Click += btnAddUpdateToDo_Click;
            // 
            // textBoxToDoInput
            // 
            textBoxToDoInput.Dock = DockStyle.Top;
            textBoxToDoInput.Location = new Point(3, 27);
            textBoxToDoInput.Multiline = true;
            textBoxToDoInput.Name = "textBoxToDoInput";
            textBoxToDoInput.Size = new Size(294, 117);
            textBoxToDoInput.TabIndex = 1;
            // 
            // gbAI
            // 
            gbAI.Controls.Add(textBox4);
            gbAI.Controls.Add(button2);
            gbAI.Controls.Add(textBox3);
            gbAI.Dock = DockStyle.Left;
            gbAI.Location = new Point(600, 33);
            gbAI.Name = "gbAI";
            gbAI.Size = new Size(300, 469);
            gbAI.TabIndex = 3;
            gbAI.TabStop = false;
            gbAI.Text = "Ai_Assitant";
            // 
            // textBox4
            // 
            textBox4.Dock = DockStyle.Fill;
            textBox4.Location = new Point(3, 178);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(294, 288);
            textBox4.TabIndex = 2;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Top;
            button2.Location = new Point(3, 144);
            button2.Name = "button2";
            button2.Size = new Size(294, 34);
            button2.TabIndex = 1;
            button2.Text = "OK";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            textBox3.Dock = DockStyle.Top;
            textBox3.Location = new Point(3, 27);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(294, 117);
            textBox3.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Location = new Point(906, 243);
            panel1.Name = "panel1";
            panel1.Size = new Size(335, 169);
            panel1.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1165, 502);
            Controls.Add(panel1);
            Controls.Add(gbAI);
            Controls.Add(gbToDO);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "ProjectManagment";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            gbToDO.ResumeLayout(false);
            gbToDO.PerformLayout();
            gbAI.ResumeLayout(false);
            gbAI.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem projectToolStripMenuItem;
        private ToolStripMenuItem reportToolStripMenuItem;
        private ToolStripMenuItem settingToolStripMenuItem;
        private ToolStripMenuItem newProjectToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem finishDayToolStripMenuItem;
        private ToolStripMenuItem mounthlyReportToolStripMenuItem;
        private GroupBox groupBox1;
        private GroupBox gbToDO;
        private CheckedListBox checkedListBoxToDo;
        private Button btnAddUpdateToDo;
        private TextBox textBoxToDoInput;
        private TextBox textBoxCodePath;
        private TreeView treeViewProject;
        private GroupBox gbAI;
        private Button button2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Panel panel1;
    }
}
