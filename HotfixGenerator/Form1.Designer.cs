
namespace HotfixGenerator
{
    partial class Form1
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
            this.listFiles = new System.Windows.Forms.ListView();
            this.txtFileToProcess = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddFiles = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnProcess = new System.Windows.Forms.Button();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkRemoveTemp = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listFiles
            // 
            this.listFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listFiles.FullRowSelect = true;
            this.listFiles.GridLines = true;
            this.listFiles.HideSelection = false;
            this.listFiles.Location = new System.Drawing.Point(12, 169);
            this.listFiles.Name = "listFiles";
            this.listFiles.Size = new System.Drawing.Size(500, 197);
            this.listFiles.TabIndex = 0;
            this.listFiles.UseCompatibleStateImageBehavior = false;
            this.listFiles.View = System.Windows.Forms.View.Details;
            this.listFiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listFiles_MouseClick);
            // 
            // txtFileToProcess
            // 
            this.txtFileToProcess.Location = new System.Drawing.Point(113, 108);
            this.txtFileToProcess.Name = "txtFileToProcess";
            this.txtFileToProcess.Size = new System.Drawing.Size(251, 22);
            this.txtFileToProcess.TabIndex = 1;
            this.txtFileToProcess.DoubleClick += new System.EventHandler(this.txtFileToProcess_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "File to Proces:";
            // 
            // btnAddFiles
            // 
            this.btnAddFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFiles.Location = new System.Drawing.Point(370, 101);
            this.btnAddFiles.Name = "btnAddFiles";
            this.btnAddFiles.Size = new System.Drawing.Size(127, 29);
            this.btnAddFiles.TabIndex = 4;
            this.btnAddFiles.Text = "Add File(s)";
            this.btnAddFiles.UseVisualStyleBackColor = true;
            this.btnAddFiles.Click += new System.EventHandler(this.btnAddFiles_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Output Folder:";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(116, 29);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(246, 22);
            this.txtOutput.TabIndex = 6;
            this.txtOutput.Text = "c:\\Hotfix";
            this.txtOutput.DoubleClick += new System.EventHandler(this.txtOutput_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Filename:";
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(116, 66);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(215, 22);
            this.txtFilename.TabIndex = 8;
            this.txtFilename.Text = "Hotfix.zip";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Filename";
            this.columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Folder";
            this.columnHeader2.Width = 100;
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Location = new System.Drawing.Point(408, 34);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(89, 54);
            this.btnProcess.TabIndex = 9;
            this.btnProcess.Text = "Build Zip";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "fullPath";
            this.columnHeader3.Width = 0;
            // 
            // checkRemoveTemp
            // 
            this.checkRemoveTemp.AutoSize = true;
            this.checkRemoveTemp.Checked = true;
            this.checkRemoveTemp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkRemoveTemp.Location = new System.Drawing.Point(14, 142);
            this.checkRemoveTemp.Name = "checkRemoveTemp";
            this.checkRemoveTemp.Size = new System.Drawing.Size(188, 21);
            this.checkRemoveTemp.TabIndex = 10;
            this.checkRemoveTemp.Text = "Remove Temp After Zip?";
            this.checkRemoveTemp.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 377);
            this.Controls.Add(this.checkRemoveTemp);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddFiles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFileToProcess);
            this.Controls.Add(this.listFiles);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listFiles;
        private System.Windows.Forms.TextBox txtFileToProcess;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddFiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.CheckBox checkRemoveTemp;
    }
}

