using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM
{
    public static class Prompt
    {
        /// <summary>
        /// نمایش دیالوگ دریافت نام پروژه با بررسی تکراری بودن در مسیر مشخص شده.
        /// </summary>
        /// <param name="text">متن توضیح بالای TextBox</param>
        /// <param name="caption">عنوان فرم</param>
        /// <param name="baseDir">مسیر پایه برای بررسی وجود نام پروژه</param>
        /// <param name="year">سال جاری به عنوان زیرپوشه (مثلاً "2025")</param>
        /// <returns>نام پروژه معتبر یا رشته خالی اگر کنسل شد</returns>
        public static string ShowDialog(string text, string caption, string baseDir, string year)
        {
            string result = "";

            using (Form prompt = new Form())
            {
                prompt.Width = 400;
                prompt.Height = 160;
                prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                prompt.Text = caption;
                prompt.StartPosition = FormStartPosition.CenterScreen;
                prompt.MaximizeBox = false;
                prompt.MinimizeBox = false;
                prompt.ShowIcon = false;
                prompt.ShowInTaskbar = false;

                Label textLabel = new Label() { Left = 10, Top = 10, Text = text, AutoSize = true };
                TextBox textBox = new TextBox() { Left = 10, Top = 35, Width = 360 };

                Button confirmation = new Button() { Text = "OK", Left = 290, Width = 80, Top = 70 };
                Button cancel = new Button() { Text = "Cancel", Left = 200, Width = 80, Top = 70, DialogResult = DialogResult.Cancel };

                confirmation.Click += (sender, e) =>
                {
                    string enteredName = textBox.Text.Trim();
                    if (string.IsNullOrEmpty(enteredName))
                    {
                        MessageBox.Show("لطفاً نام پروژه را وارد کنید.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string fullPath = Path.Combine(baseDir, year, enteredName);
                    if (Directory.Exists(fullPath))
                    {
                        MessageBox.Show("نام پروژه تکراری است! لطفاً نام دیگری وارد کنید.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    result = enteredName;
                    prompt.DialogResult = DialogResult.OK;
                    prompt.Close();
                };

                confirmation.DialogResult = DialogResult.None;

                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(cancel);

                prompt.AcceptButton = confirmation;
                prompt.CancelButton = cancel;

                var dialogResult = prompt.ShowDialog();

                if (dialogResult != DialogResult.OK)
                    result = "";  // اگر Cancel شد یا بسته شد، مقدار خالی برگردد
            }

            return result;
        }
    }
}
