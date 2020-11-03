namespace Graal.QuotesGetter.GUI
{
    partial class QuotesParserWindow
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
            this.Lb_Parsers = new System.Windows.Forms.ListBox();
            this.Btn_AddExpressionsSet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Tb_QuotesSource = new System.Windows.Forms.TextBox();
            this.Btn_CopyExpressionsSet = new System.Windows.Forms.Button();
            this.Btn_RenameExpressionsSet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Lb_Parsers
            // 
            this.Lb_Parsers.FormattingEnabled = true;
            this.Lb_Parsers.Location = new System.Drawing.Point(15, 25);
            this.Lb_Parsers.Name = "Lb_Parsers";
            this.Lb_Parsers.Size = new System.Drawing.Size(341, 121);
            this.Lb_Parsers.TabIndex = 0;
            this.Lb_Parsers.SelectedIndexChanged += new System.EventHandler(this.Lb_Parsers_SelectedIndexChanged);
            // 
            // Btn_AddExpressionsSet
            // 
            this.Btn_AddExpressionsSet.Location = new System.Drawing.Point(362, 25);
            this.Btn_AddExpressionsSet.Name = "Btn_AddExpressionsSet";
            this.Btn_AddExpressionsSet.Size = new System.Drawing.Size(133, 23);
            this.Btn_AddExpressionsSet.TabIndex = 1;
            this.Btn_AddExpressionsSet.Text = "Добавить";
            this.Btn_AddExpressionsSet.UseVisualStyleBackColor = true;
            this.Btn_AddExpressionsSet.Click += new System.EventHandler(this.Btn_AddExpressionsSet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Исходные данные";
            // 
            // Tb_QuotesSource
            // 
            this.Tb_QuotesSource.Location = new System.Drawing.Point(15, 175);
            this.Tb_QuotesSource.Multiline = true;
            this.Tb_QuotesSource.Name = "Tb_QuotesSource";
            this.Tb_QuotesSource.ReadOnly = true;
            this.Tb_QuotesSource.Size = new System.Drawing.Size(480, 121);
            this.Tb_QuotesSource.TabIndex = 5;
            // 
            // Btn_CopyExpressionsSet
            // 
            this.Btn_CopyExpressionsSet.Location = new System.Drawing.Point(362, 54);
            this.Btn_CopyExpressionsSet.Name = "Btn_CopyExpressionsSet";
            this.Btn_CopyExpressionsSet.Size = new System.Drawing.Size(133, 23);
            this.Btn_CopyExpressionsSet.TabIndex = 7;
            this.Btn_CopyExpressionsSet.Text = "Копировать";
            this.Btn_CopyExpressionsSet.UseVisualStyleBackColor = true;
            this.Btn_CopyExpressionsSet.Click += new System.EventHandler(this.Btn_CopyExpressionsSet_Click);
            // 
            // Btn_RenameExpressionsSet
            // 
            this.Btn_RenameExpressionsSet.Location = new System.Drawing.Point(362, 83);
            this.Btn_RenameExpressionsSet.Name = "Btn_RenameExpressionsSet";
            this.Btn_RenameExpressionsSet.Size = new System.Drawing.Size(133, 23);
            this.Btn_RenameExpressionsSet.TabIndex = 8;
            this.Btn_RenameExpressionsSet.Text = "Переименовать";
            this.Btn_RenameExpressionsSet.UseVisualStyleBackColor = true;
            this.Btn_RenameExpressionsSet.Click += new System.EventHandler(this.Btn_RenameExpressionsSet_Click);
            // 
            // QuotesParserWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 306);
            this.Controls.Add(this.Btn_RenameExpressionsSet);
            this.Controls.Add(this.Btn_CopyExpressionsSet);
            this.Controls.Add(this.Tb_QuotesSource);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_AddExpressionsSet);
            this.Controls.Add(this.Lb_Parsers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuotesParserWindow";
            this.Text = "Парсеры котировок";
            this.Load += new System.EventHandler(this.CheckOnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Lb_Parsers;
        private System.Windows.Forms.Button Btn_AddExpressionsSet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Tb_QuotesSource;
        private System.Windows.Forms.Button Btn_CopyExpressionsSet;
        private System.Windows.Forms.Button Btn_RenameExpressionsSet;
    }
}

