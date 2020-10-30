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
            this.button1 = new System.Windows.Forms.Button();
            this.Lb_Expressions = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Lb_Parsers
            // 
            this.Lb_Parsers.FormattingEnabled = true;
            this.Lb_Parsers.Location = new System.Drawing.Point(15, 25);
            this.Lb_Parsers.Name = "Lb_Parsers";
            this.Lb_Parsers.Size = new System.Drawing.Size(200, 342);
            this.Lb_Parsers.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(713, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Lb_Expressions
            // 
            this.Lb_Expressions.FormattingEnabled = true;
            this.Lb_Expressions.Location = new System.Drawing.Point(588, 25);
            this.Lb_Expressions.Name = "Lb_Expressions";
            this.Lb_Expressions.Size = new System.Drawing.Size(200, 160);
            this.Lb_Expressions.TabIndex = 2;
            this.Lb_Expressions.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Lb_Expressions_MouseDoubleClick);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(585, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Выражения";
            // 
            // QuotesParserWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lb_Expressions);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Lb_Parsers);
            this.Name = "QuotesParserWindow";
            this.Text = "Парсер котировок";
            this.Load += new System.EventHandler(this.CheckOnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Lb_Parsers;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox Lb_Expressions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

