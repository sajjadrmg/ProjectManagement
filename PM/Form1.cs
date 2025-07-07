using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PM
{
    public partial class Form1 : Form
    {
        private string basePath = @"D:\MyProject";  // مسیر اصلی پروژه‌ها
        private string currentProjectPath = "";     // مسیر پروژه جاری
        private string currentToDoPath = "";        // مسیر ToDo فایل پروژه جاری

        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;
            treeViewProject.NodeMouseDoubleClick += treeViewProject_NodeMouseDoubleClick;
            btnAddUpdateToDo.Click += btnAddUpdateToDo_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gbToDO.Enabled = false;
            gbAI.Enabled = false;

            if (!Directory.Exists(basePath))
                Directory.CreateDirectory(basePath);

            LoadProjectsMenu();
        }

        private void LoadProjectsMenu()
        {
            projectToolStripMenuItem.DropDownItems.Clear();

            // گزینه پروژه جدید
            var newItem = new ToolStripMenuItem("New");
            newItem.Click += newProjectToolStripMenuItem_Click;
            projectToolStripMenuItem.DropDownItems.Add(newItem);

            if (!Directory.Exists(basePath))
                return;

            // پوشه‌های سال
            var years = Directory.GetDirectories(basePath)
                .Select(Path.GetFileName)
                .OrderByDescending(y => y);

            foreach (var year in years)
            {
                var yearItem = new ToolStripMenuItem(year);
                string yearPath = Path.Combine(basePath, year);

                var projects = Directory.GetDirectories(yearPath)
                    .Select(Path.GetFileName)
                    .OrderBy(p => p);

                foreach (var project in projects)
                {
                    var projectItem = new ToolStripMenuItem(project);
                    projectItem.Tag = Path.Combine(yearPath, project);
                    projectItem.Click += ProjectItem_Click;
                    yearItem.DropDownItems.Add(projectItem);
                }
                projectToolStripMenuItem.DropDownItems.Add(yearItem);
            }
        }

        private void ProjectItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem item && item.Tag is string path)
            {
                if (!string.IsNullOrEmpty(currentToDoPath) && File.Exists(currentToDoPath))
                {
                    //string reportPath1 = Path.Combine(currentProjectPath, "Report", "report.json");
                   // SaveExitTime(reportPath1);
                    SaveToDoList();
                }
                string reportPath1 = Path.Combine(currentProjectPath, "Report", "report.json");
                SaveExitTime(reportPath1);
                currentProjectPath = path;
                currentToDoPath = Path.Combine(path, "ToDoList", "tasks.json");
              
                gbToDO.Enabled = true;
                gbAI.Enabled = true;

                LoadProjectTree(currentProjectPath);
                LoadToDoList();

                textBoxCodePath.Text = Path.Combine(currentProjectPath, "Code");
                string reportPath = Path.Combine(currentProjectPath, "Report", "report.json");
                SaveEntryTime(reportPath);
                MessageBox.Show($"پروژه {item.Text} باز شد.");
            }
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentToDoPath) && File.Exists(currentToDoPath))
            {
                SaveToDoList();
            }
            string year = DateTime.Now.Year.ToString();

            string projectName = Prompt.ShowDialog("نام پروژه را وارد کنید:", "پروژه جدید", basePath, year);

            if (string.IsNullOrWhiteSpace(projectName))
                return;

            string projectPath = Path.Combine(basePath, year, projectName);

            if (Directory.Exists(projectPath))
            {
                MessageBox.Show("این پروژه قبلا ساخته شده است. نام دیگری انتخاب کنید.");
                return;
            }

            Directory.CreateDirectory(projectPath);

            foreach (var folder in new[] { "Code", "Document", "ToDoList", "Ai", "Export", "Report" })
                Directory.CreateDirectory(Path.Combine(projectPath, folder));

            CreateWord(Path.Combine(projectPath, "Document", $"{projectName}_Document.docx"));

            SaveEntryTime(Path.Combine(projectPath, "Report", "report.json"));

            currentProjectPath = projectPath;
            currentToDoPath = Path.Combine(projectPath, "ToDoList", "tasks.json");

            gbToDO.Enabled = true;
            gbAI.Enabled = true;

            LoadProjectTree(projectPath);
            LoadToDoList();

            textBoxCodePath.Text = Path.Combine(projectPath, "Code");

            LoadProjectsMenu();

        }

        private void LoadProjectTree(string path)
        {
            treeViewProject.Nodes.Clear();

            if (!Directory.Exists(path))
                return;

            var rootDir = new DirectoryInfo(path);
            TreeNode rootNode = CreateDirectoryNode(rootDir);
            treeViewProject.Nodes.Add(rootNode);
            treeViewProject.ExpandAll();
        }

        private TreeNode CreateDirectoryNode(DirectoryInfo dir)
        {
            TreeNode node = new TreeNode(dir.Name) { Tag = dir.FullName };

            foreach (var subDir in dir.GetDirectories())
                node.Nodes.Add(CreateDirectoryNode(subDir));

            foreach (var file in dir.GetFiles())
                node.Nodes.Add(new TreeNode(file.Name) { Tag = file.FullName });

            return node;
        }

        private void treeViewProject_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag == null) return;

            string path = e.Node.Tag.ToString();

            if (Directory.Exists(path))
                return; // فولدر را باز نکن

            string ext = Path.GetExtension(path).ToLower();

            if (ext == ".docx")
            {
                EnsureDateInWord(path);
                Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
            }
            else
            {
                Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
            }
        }

        private void EnsureDateInWord(string filePath)
        {
            var pc = new System.Globalization.PersianCalendar();
            DateTime now = DateTime.Now;
            string todayShamsi = $"{pc.GetYear(now)}/{pc.GetMonth(now):00}/{pc.GetDayOfMonth(now):00}";

            using (WordprocessingDocument doc = WordprocessingDocument.Open(filePath, true))
            {
                var body = doc.MainDocumentPart.Document.Body;

                if (body.InnerText.Contains(todayShamsi))
                    return;

                var para = new Paragraph(new Run(new Text(todayShamsi)))
                {
                    ParagraphProperties = new ParagraphProperties(
                        new Justification() { Val = JustificationValues.Right }
                    )
                };

                body.Append(para);  // <-- درج در انتهای سند

                doc.MainDocumentPart.Document.Save();
            }
        }

        private void LoadToDoList()
        {
            checkedListBoxToDo.Items.Clear();

            if (!File.Exists(currentToDoPath))
                return;

            var items = JsonConvert.DeserializeObject<List<ToDoItem>>(File.ReadAllText(currentToDoPath));
            foreach (var item in items)
            {
                int idx = checkedListBoxToDo.Items.Add(item.Title);
                checkedListBoxToDo.SetItemChecked(idx, item.Done);
            }
        }

        private void SaveToDoList()
        {
            var items = new List<ToDoItem>();

            for (int i = 0; i < checkedListBoxToDo.Items.Count; i++)
            {
                items.Add(new ToDoItem
                {
                    Title = checkedListBoxToDo.Items[i].ToString(),
                    Done = checkedListBoxToDo.GetItemChecked(i)
                });
            }

            File.WriteAllText(currentToDoPath, JsonConvert.SerializeObject(items, Formatting.Indented));
        }

        private void btnAddUpdateToDo_Click(object sender, EventArgs e)
        {
            string todoText = textBoxToDoInput.Text.Trim();

            if (string.IsNullOrEmpty(todoText))
            {
                checkedListBoxToDo.ClearSelected();
                return;
            }
            int selectedIndex = checkedListBoxToDo.SelectedIndex;

            if (selectedIndex >= 0)
            {
                bool isChecked = checkedListBoxToDo.GetItemChecked(selectedIndex);
                checkedListBoxToDo.Items[selectedIndex] = todoText;
                checkedListBoxToDo.SetItemChecked(selectedIndex, isChecked);
            }
            else
            {
                checkedListBoxToDo.Items.Add(todoText, false);
            }

            textBoxToDoInput.Clear();
            SaveToDoList();
            checkedListBoxToDo.ClearSelected();
        }

        private void SaveEntryTime(string reportPath)
        {

            string today = DateTime.Now.ToString("yyyy-MM-dd");
            string now = DateTime.Now.ToString("HH:mm");

            var report = File.Exists(reportPath)
                ? JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(File.ReadAllText(reportPath))
                : new Dictionary<string, List<Dictionary<string, string>>>();

            if (!report.ContainsKey(today))
                report[today] = new List<Dictionary<string, string>>();

            report[today].Add(new Dictionary<string, string> { { "Entry", now }, { "Exit", "" } });

            File.WriteAllText(reportPath, JsonConvert.SerializeObject(report, Formatting.Indented));
        }

        private void CreateWord(string path)
        {
            using (var doc = WordprocessingDocument.Create(path, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
            {
                var main = doc.AddMainDocumentPart();
                main.Document = new Document(new Body(
                    new Paragraph(new Run(new Text("شروع پروژه")))
                ));
            }
        }

        private void finishDayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentToDoPath))
            {
                MessageBox.Show("پروژه‌ای انتخاب نشده است.", "هشدار");
                return;
            }

            string projectPath = Path.GetDirectoryName(Path.GetDirectoryName(currentToDoPath)); // به پوشه اصلی پروژه برگرد
            string reportPath = Path.Combine(projectPath, "Report", "report.json");

            SaveExitTime(reportPath);
        }

        private void SaveExitTime(string reportPath)
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            string now = DateTime.Now.ToString("HH:mm");

            if (!File.Exists(reportPath))
            {
                MessageBox.Show("فایل گزارش یافت نشد.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var report = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(File.ReadAllText(reportPath));

            if (!report.ContainsKey(today) || report[today].Count == 0)
            {
                MessageBox.Show("هیچ ورود ثبت نشده است.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // آخرین رکورد بدون خروج را پیدا کن
            var lastSession = report[today].LastOrDefault(x => x.ContainsKey("Exit") && string.IsNullOrEmpty(x["Exit"]));
            if (lastSession != null)
            {
                lastSession["Exit"] = now;
                File.WriteAllText(reportPath, JsonConvert.SerializeObject(report, Formatting.Indented));
                MessageBox.Show("ساعت خروج ثبت شد.", "ثبت موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("همه ورودها قبلاً خروج ثبت کرده‌اند.", "اطلاع", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }
}

