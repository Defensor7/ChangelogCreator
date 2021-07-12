using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangelogCreator
{
    public partial class Main : Form
    {
        private string _selectedPath;
        public Main()
        {
            InitializeComponent();
        }

        private void buttonPathDialog_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog() { };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _selectedPath = dialog.SelectedPath;
                textBoxPath.Text = dialog.SelectedPath;
            }
        }

        private async void buttonFind_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(_selectedPath))
                {
                    MessageBox.Show("Необходимо выбрать существующую директорию с конфигурацией!");
                    return;
                }

                if (string.IsNullOrEmpty(textBoxToFind.Text))
                {
                    MessageBox.Show("Необходимо заполнить строку поиска!");
                    return;
                }

                buttonFind.Enabled = false;
                buttonPathDialog.Enabled = false;
                textBoxResult.Clear();
                var toFind = textBoxToFind.Text;

                var finder = new Finder(_selectedPath, toFind);
                finder.LinesAdded += Finder_LinesAdded;
                finder.ProgressChanged += Finder_ProgressChanged;
                await Task.Run(finder.FindChanges);
                buttonFind.Enabled = true;
                buttonPathDialog.Enabled = true;
                if (textBoxResult.Text.Length == 0)
                {
                    textBoxResult.AppendText("Ничего не найдено");
                }
                else
                {
                    textBoxResult.AppendText($"Сформировано автоматически {DateTime.Now:dd.MM.yyyy HH:mm:ss}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        private void Finder_ProgressChanged(object sender, int e)
        {
            Invoke(new Action(() =>
            {
                progressBar.Value = e;
            }));
        }

        private void Finder_LinesAdded(object sender, (string text, Color color) e)
        {
            Invoke(new Action(() =>
            {
                textBoxResult.AppendText(e.text, e.color);
            }));
        }
    }

    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
