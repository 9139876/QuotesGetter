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
            this.Btn_RenameExpressionsSet = new System.Windows.Forms.Button();
            this.Btn_CopyExpressionsSet = new System.Windows.Forms.Button();
            this.Btn_DeleteExpressionsSet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Lb_Parsers
            // 
            this.Lb_Parsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lb_Parsers.FormattingEnabled = true;
            this.Lb_Parsers.Location = new System.Drawing.Point(15, 25);
            this.Lb_Parsers.Name = "Lb_Parsers";
            this.Lb_Parsers.Size = new System.Drawing.Size(341, 121);
            this.Lb_Parsers.TabIndex = 0;
            this.Lb_Parsers.SelectedIndexChanged += new System.EventHandler(this.Lb_Parsers_SelectedIndexChanged);
            this.Lb_Parsers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Lb_Parsers_MouseDoubleClick);
            // 
            // Btn_AddExpressionsSet
            // 
            this.Btn_AddExpressionsSet.Location = new System.Drawing.Point(15, 152);
            this.Btn_AddExpressionsSet.Name = "Btn_AddExpressionsSet";
            this.Btn_AddExpressionsSet.Size = new System.Drawing.Size(75, 23);
            this.Btn_AddExpressionsSet.TabIndex = 1;
            this.Btn_AddExpressionsSet.Text = "Добавить";
            this.Btn_AddExpressionsSet.UseVisualStyleBackColor = true;
            this.Btn_AddExpressionsSet.Click += new System.EventHandler(this.Btn_AddExpressionsSet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Парсеры";
            // 
            // Tb_QuotesSource
            // 
            this.Tb_QuotesSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Tb_QuotesSource.Location = new System.Drawing.Point(478, 25);
            this.Tb_QuotesSource.Multiline = true;
            this.Tb_QuotesSource.Name = "Tb_QuotesSource";
            this.Tb_QuotesSource.ReadOnly = true;
            this.Tb_QuotesSource.Size = new System.Drawing.Size(540, 121);
            this.Tb_QuotesSource.TabIndex = 5;
            // 
            // Btn_RenameExpressionsSet
            // 
            this.Btn_RenameExpressionsSet.Location = new System.Drawing.Point(96, 152);
            this.Btn_RenameExpressionsSet.Name = "Btn_RenameExpressionsSet";
            this.Btn_RenameExpressionsSet.Size = new System.Drawing.Size(98, 23);
            this.Btn_RenameExpressionsSet.TabIndex = 6;
            this.Btn_RenameExpressionsSet.Text = "Переименовать";
            this.Btn_RenameExpressionsSet.UseVisualStyleBackColor = true;
            // 
            // Btn_CopyExpressionsSet
            // 
            this.Btn_CopyExpressionsSet.Location = new System.Drawing.Point(200, 152);
            this.Btn_CopyExpressionsSet.Name = "Btn_CopyExpressionsSet";
            this.Btn_CopyExpressionsSet.Size = new System.Drawing.Size(75, 23);
            this.Btn_CopyExpressionsSet.TabIndex = 7;
            this.Btn_CopyExpressionsSet.Text = "Копировать";
            this.Btn_CopyExpressionsSet.UseVisualStyleBackColor = true;
            // 
            // Btn_DeleteExpressionsSet
            // 
            this.Btn_DeleteExpressionsSet.Location = new System.Drawing.Point(281, 152);
            this.Btn_DeleteExpressionsSet.Name = "Btn_DeleteExpressionsSet";
            this.Btn_DeleteExpressionsSet.Size = new System.Drawing.Size(75, 23);
            this.Btn_DeleteExpressionsSet.TabIndex = 8;
            this.Btn_DeleteExpressionsSet.Text = "Удалить";
            this.Btn_DeleteExpressionsSet.UseVisualStyleBackColor = true;
            // 
            // QuotesParserWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 646);
            this.Controls.Add(this.Btn_DeleteExpressionsSet);
            this.Controls.Add(this.Btn_CopyExpressionsSet);
            this.Controls.Add(this.Btn_RenameExpressionsSet);
            this.Controls.Add(this.Tb_QuotesSource);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_AddExpressionsSet);
            this.Controls.Add(this.Lb_Parsers);
            this.Name = "QuotesParserWindow";
            this.Text = "Парсер котировок";
            this.Load += new System.EventHandler(this.CheckOnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Lb_Parsers;
        private System.Windows.Forms.Button Btn_AddExpressionsSet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Tb_QuotesSource;
        private System.Windows.Forms.Button Btn_RenameExpressionsSet;
        private System.Windows.Forms.Button Btn_CopyExpressionsSet;
        private System.Windows.Forms.Button Btn_DeleteExpressionsSet;
    }
}

