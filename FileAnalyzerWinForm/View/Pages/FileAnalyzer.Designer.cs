namespace FileAnalyzerWinForm.View.Pages
{
    partial class FileAnalyzer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxFileType = new System.Windows.Forms.ComboBox();
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.buttonAnalysis = new System.Windows.Forms.Button();
            this.richTextBoxAnalysisResult = new System.Windows.Forms.RichTextBox();
            this.progressBarLoading = new System.Windows.Forms.ProgressBar();
            this.buttonExcelExport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select File Type";
            // 
            // comboBoxFileType
            // 
            this.comboBoxFileType.FormattingEnabled = true;
            this.comboBoxFileType.Location = new System.Drawing.Point(138, 18);
            this.comboBoxFileType.Name = "comboBoxFileType";
            this.comboBoxFileType.Size = new System.Drawing.Size(163, 21);
            this.comboBoxFileType.TabIndex = 1;
            // 
            // buttonSelectFile
            // 
            this.buttonSelectFile.Location = new System.Drawing.Point(316, 18);
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.buttonSelectFile.Size = new System.Drawing.Size(95, 21);
            this.buttonSelectFile.TabIndex = 2;
            this.buttonSelectFile.Text = "Select File";
            this.buttonSelectFile.UseVisualStyleBackColor = true;
            this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
            // 
            // buttonAnalysis
            // 
            this.buttonAnalysis.Location = new System.Drawing.Point(417, 18);
            this.buttonAnalysis.Name = "buttonAnalysis";
            this.buttonAnalysis.Size = new System.Drawing.Size(95, 21);
            this.buttonAnalysis.TabIndex = 3;
            this.buttonAnalysis.Text = "Analyze";
            this.buttonAnalysis.UseVisualStyleBackColor = true;
            this.buttonAnalysis.Click += new System.EventHandler(this.buttonAnalysis_Click);
            // 
            // richTextBoxAnalysisResult
            // 
            this.richTextBoxAnalysisResult.Location = new System.Drawing.Point(7, 59);
            this.richTextBoxAnalysisResult.Name = "richTextBoxAnalysisResult";
            this.richTextBoxAnalysisResult.Size = new System.Drawing.Size(505, 185);
            this.richTextBoxAnalysisResult.TabIndex = 4;
            this.richTextBoxAnalysisResult.Text = "";
            // 
            // progressBarLoading
            // 
            this.progressBarLoading.Location = new System.Drawing.Point(0, 386);
            this.progressBarLoading.Name = "progressBarLoading";
            this.progressBarLoading.Size = new System.Drawing.Size(531, 23);
            this.progressBarLoading.TabIndex = 5;
            // 
            // buttonExcelExport
            // 
            this.buttonExcelExport.Location = new System.Drawing.Point(417, 261);
            this.buttonExcelExport.Name = "buttonExcelExport";
            this.buttonExcelExport.Size = new System.Drawing.Size(95, 21);
            this.buttonExcelExport.TabIndex = 6;
            this.buttonExcelExport.Text = "Export Excel";
            this.buttonExcelExport.UseVisualStyleBackColor = true;
            this.buttonExcelExport.Click += new System.EventHandler(this.buttonExcelExport_Click);
            // 
            // FileAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonExcelExport);
            this.Controls.Add(this.progressBarLoading);
            this.Controls.Add(this.richTextBoxAnalysisResult);
            this.Controls.Add(this.buttonAnalysis);
            this.Controls.Add(this.buttonSelectFile);
            this.Controls.Add(this.comboBoxFileType);
            this.Controls.Add(this.label1);
            this.Name = "FileAnalyzer";
            this.Size = new System.Drawing.Size(531, 412);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxFileType;
        private System.Windows.Forms.Button buttonSelectFile;
        private System.Windows.Forms.Button buttonAnalysis;
        private System.Windows.Forms.RichTextBox richTextBoxAnalysisResult;
        private System.Windows.Forms.ProgressBar progressBarLoading;
        private System.Windows.Forms.Button buttonExcelExport;
    }
}
