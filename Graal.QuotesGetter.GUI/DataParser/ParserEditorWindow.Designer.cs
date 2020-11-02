namespace Graal.QuotesGetter.GUI.DataParser
{
    partial class ParserEditorWindow
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
            this.Lb_UsedExpressions = new System.Windows.Forms.ListBox();
            this.TW_ExpressionsTree = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.Lb_Expressions = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NUD_SkipRows = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.Tb_InputString = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_SkipRows)).BeginInit();
            this.SuspendLayout();
            // 
            // Lb_UsedExpressions
            // 
            this.Lb_UsedExpressions.FormattingEnabled = true;
            this.Lb_UsedExpressions.Location = new System.Drawing.Point(231, 81);
            this.Lb_UsedExpressions.Name = "Lb_UsedExpressions";
            this.Lb_UsedExpressions.Size = new System.Drawing.Size(382, 303);
            this.Lb_UsedExpressions.TabIndex = 11;
            // 
            // TW_ExpressionsTree
            // 
            this.TW_ExpressionsTree.Location = new System.Drawing.Point(12, 81);
            this.TW_ExpressionsTree.Name = "TW_ExpressionsTree";
            this.TW_ExpressionsTree.Size = new System.Drawing.Size(201, 240);
            this.TW_ExpressionsTree.TabIndex = 10;
            this.TW_ExpressionsTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TW_ExpressionsTree_AfterSelect);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(616, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Выражения";
            // 
            // Lb_Expressions
            // 
            this.Lb_Expressions.FormattingEnabled = true;
            this.Lb_Expressions.Location = new System.Drawing.Point(619, 81);
            this.Lb_Expressions.Name = "Lb_Expressions";
            this.Lb_Expressions.Size = new System.Drawing.Size(370, 160);
            this.Lb_Expressions.TabIndex = 8;
            this.Lb_Expressions.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Lb_Expressions_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Пропуск строк";
            // 
            // NUD_SkipRows
            // 
            this.NUD_SkipRows.Location = new System.Drawing.Point(15, 26);
            this.NUD_SkipRows.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NUD_SkipRows.Name = "NUD_SkipRows";
            this.NUD_SkipRows.Size = new System.Drawing.Size(79, 20);
            this.NUD_SkipRows.TabIndex = 13;
            this.NUD_SkipRows.ValueChanged += new System.EventHandler(this.NUD_SkipRows_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Струтктура парсера";
            // 
            // Tb_InputString
            // 
            this.Tb_InputString.Location = new System.Drawing.Point(231, 25);
            this.Tb_InputString.Name = "Tb_InputString";
            this.Tb_InputString.ReadOnly = true;
            this.Tb_InputString.Size = new System.Drawing.Size(758, 20);
            this.Tb_InputString.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(143, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Входная строка";
            // 
            // ParserEditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Tb_InputString);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NUD_SkipRows);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lb_UsedExpressions);
            this.Controls.Add(this.TW_ExpressionsTree);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Lb_Expressions);
            this.Name = "ParserEditorWindow";
            this.Text = "ParserEditorWindow";
            ((System.ComponentModel.ISupportInitialize)(this.NUD_SkipRows)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Lb_UsedExpressions;
        private System.Windows.Forms.TreeView TW_ExpressionsTree;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox Lb_Expressions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NUD_SkipRows;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Tb_InputString;
        private System.Windows.Forms.Label label4;
    }
}