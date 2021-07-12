
namespace ChangelogCreator
{
    partial class Main
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
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxPath = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelPath = new System.Windows.Forms.FlowLayoutPanel();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.buttonPathDialog = new System.Windows.Forms.Button();
            this.textBoxToFind = new System.Windows.Forms.TextBox();
            this.buttonFind = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.textBoxResult = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanelMain.SuspendLayout();
            this.groupBoxPath.SuspendLayout();
            this.flowLayoutPanelPath.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.groupBoxPath, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.progressBar, 0, 2);
            this.tableLayoutPanelMain.Controls.Add(this.textBoxResult, 0, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1574, 1129);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // groupBoxPath
            // 
            this.groupBoxPath.Controls.Add(this.flowLayoutPanelPath);
            this.groupBoxPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxPath.Location = new System.Drawing.Point(3, 3);
            this.groupBoxPath.Name = "groupBoxPath";
            this.groupBoxPath.Size = new System.Drawing.Size(1568, 144);
            this.groupBoxPath.TabIndex = 0;
            this.groupBoxPath.TabStop = false;
            this.groupBoxPath.Text = "Конфигурация";
            // 
            // flowLayoutPanelPath
            // 
            this.flowLayoutPanelPath.Controls.Add(this.textBoxPath);
            this.flowLayoutPanelPath.Controls.Add(this.buttonPathDialog);
            this.flowLayoutPanelPath.Controls.Add(this.textBoxToFind);
            this.flowLayoutPanelPath.Controls.Add(this.buttonFind);
            this.flowLayoutPanelPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelPath.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanelPath.Name = "flowLayoutPanelPath";
            this.flowLayoutPanelPath.Size = new System.Drawing.Size(1562, 125);
            this.flowLayoutPanelPath.TabIndex = 0;
            // 
            // textBoxPath
            // 
            this.textBoxPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPath.Location = new System.Drawing.Point(3, 3);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.ReadOnly = true;
            this.textBoxPath.Size = new System.Drawing.Size(996, 44);
            this.textBoxPath.TabIndex = 0;
            // 
            // buttonPathDialog
            // 
            this.buttonPathDialog.Location = new System.Drawing.Point(1005, 3);
            this.buttonPathDialog.Name = "buttonPathDialog";
            this.buttonPathDialog.Size = new System.Drawing.Size(150, 44);
            this.buttonPathDialog.TabIndex = 1;
            this.buttonPathDialog.Text = "Открыть";
            this.buttonPathDialog.UseVisualStyleBackColor = true;
            this.buttonPathDialog.Click += new System.EventHandler(this.buttonPathDialog_Click);
            // 
            // textBoxToFind
            // 
            this.textBoxToFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxToFind.Location = new System.Drawing.Point(3, 53);
            this.textBoxToFind.MaxLength = 128;
            this.textBoxToFind.Name = "textBoxToFind";
            this.textBoxToFind.Size = new System.Drawing.Size(996, 44);
            this.textBoxToFind.TabIndex = 2;
            // 
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(1005, 53);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(150, 44);
            this.buttonFind.TabIndex = 3;
            this.buttonFind.Text = "Найти";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(3, 1092);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1568, 34);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 2;
            // 
            // textBoxResult
            // 
            this.textBoxResult.BackColor = System.Drawing.Color.White;
            this.textBoxResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxResult.Location = new System.Drawing.Point(3, 153);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.ReadOnly = true;
            this.textBoxResult.Size = new System.Drawing.Size(1568, 933);
            this.textBoxResult.TabIndex = 3;
            this.textBoxResult.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1574, 1129);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Формирование Changelog";
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.groupBoxPath.ResumeLayout(false);
            this.flowLayoutPanelPath.ResumeLayout(false);
            this.flowLayoutPanelPath.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.GroupBox groupBoxPath;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPath;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button buttonPathDialog;
        private System.Windows.Forms.TextBox textBoxToFind;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.RichTextBox textBoxResult;
    }
}

