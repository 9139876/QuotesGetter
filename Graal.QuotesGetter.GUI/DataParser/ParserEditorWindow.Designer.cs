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
            this.Btn_TryCalc = new System.Windows.Forms.Button();
            this.Btn_UpExpression = new System.Windows.Forms.Button();
            this.Btn_DownExpression = new System.Windows.Forms.Button();
            this.Btn_RemoveExpression = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Tb_ParseResult = new System.Windows.Forms.TextBox();
            this.Btn_SaveParser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_SkipRows)).BeginInit();
            this.SuspendLayout();
            // 
            // Lb_UsedExpressions
            // 
            this.Lb_UsedExpressions.FormattingEnabled = true;
            this.Lb_UsedExpressions.Location = new System.Drawing.Point(231, 81);
            this.Lb_UsedExpressions.Name = "Lb_UsedExpressions";
            this.Lb_UsedExpressions.Size = new System.Drawing.Size(382, 186);
            this.Lb_UsedExpressions.TabIndex = 11;
            this.Lb_UsedExpressions.SelectedIndexChanged += new System.EventHandler(this.Lb_UsedExpressions_SelectedIndexChanged);
            // 
            // TW_ExpressionsTree
            // 
            this.TW_ExpressionsTree.HideSelection = false;
            this.TW_ExpressionsTree.Location = new System.Drawing.Point(12, 81);
            this.TW_ExpressionsTree.Name = "TW_ExpressionsTree";
            this.TW_ExpressionsTree.Size = new System.Drawing.Size(201, 186);
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
            this.Lb_Expressions.Size = new System.Drawing.Size(370, 186);
            this.Lb_Expressions.TabIndex = 11;
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
            // Btn_TryCalc
            // 
            this.Btn_TryCalc.Location = new System.Drawing.Point(12, 273);
            this.Btn_TryCalc.Name = "Btn_TryCalc";
            this.Btn_TryCalc.Size = new System.Drawing.Size(201, 23);
            this.Btn_TryCalc.TabIndex = 17;
            this.Btn_TryCalc.Text = "Проверить";
            this.Btn_TryCalc.UseVisualStyleBackColor = true;
            this.Btn_TryCalc.Click += new System.EventHandler(this.Btn_TryCalc_Click);
            // 
            // Btn_UpExpression
            // 
            this.Btn_UpExpression.Location = new System.Drawing.Point(231, 273);
            this.Btn_UpExpression.Name = "Btn_UpExpression";
            this.Btn_UpExpression.Size = new System.Drawing.Size(65, 23);
            this.Btn_UpExpression.TabIndex = 18;
            this.Btn_UpExpression.Text = "Вверх";
            this.Btn_UpExpression.UseVisualStyleBackColor = true;
            this.Btn_UpExpression.Click += new System.EventHandler(this.Btn_UpExpression_Click);
            // 
            // Btn_DownExpression
            // 
            this.Btn_DownExpression.Location = new System.Drawing.Point(302, 273);
            this.Btn_DownExpression.Name = "Btn_DownExpression";
            this.Btn_DownExpression.Size = new System.Drawing.Size(65, 23);
            this.Btn_DownExpression.TabIndex = 19;
            this.Btn_DownExpression.Text = "Вниз";
            this.Btn_DownExpression.UseVisualStyleBackColor = true;
            this.Btn_DownExpression.Click += new System.EventHandler(this.Btn_DownExpression_Click);
            // 
            // Btn_RemoveExpression
            // 
            this.Btn_RemoveExpression.Location = new System.Drawing.Point(373, 273);
            this.Btn_RemoveExpression.Name = "Btn_RemoveExpression";
            this.Btn_RemoveExpression.Size = new System.Drawing.Size(65, 23);
            this.Btn_RemoveExpression.TabIndex = 20;
            this.Btn_RemoveExpression.Text = "Удалить";
            this.Btn_RemoveExpression.UseVisualStyleBackColor = true;
            this.Btn_RemoveExpression.Click += new System.EventHandler(this.Btn_RemoveExpression_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 299);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Результат";
            // 
            // Tb_ParseResult
            // 
            this.Tb_ParseResult.Location = new System.Drawing.Point(12, 318);
            this.Tb_ParseResult.Multiline = true;
            this.Tb_ParseResult.Name = "Tb_ParseResult";
            this.Tb_ParseResult.ReadOnly = true;
            this.Tb_ParseResult.Size = new System.Drawing.Size(977, 120);
            this.Tb_ParseResult.TabIndex = 21;
            // 
            // Btn_SaveParser
            // 
            this.Btn_SaveParser.Location = new System.Drawing.Point(12, 444);
            this.Btn_SaveParser.Name = "Btn_SaveParser";
            this.Btn_SaveParser.Size = new System.Drawing.Size(201, 23);
            this.Btn_SaveParser.TabIndex = 23;
            this.Btn_SaveParser.Text = "Сохранить";
            this.Btn_SaveParser.UseVisualStyleBackColor = true;
            this.Btn_SaveParser.Click += new System.EventHandler(this.Btn_SaveParser_Click);
            // 
            // ParserEditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 476);
            this.Controls.Add(this.Btn_SaveParser);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Tb_ParseResult);
            this.Controls.Add(this.Btn_RemoveExpression);
            this.Controls.Add(this.Btn_DownExpression);
            this.Controls.Add(this.Btn_UpExpression);
            this.Controls.Add(this.Btn_TryCalc);
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
        private System.Windows.Forms.Button Btn_TryCalc;
        private System.Windows.Forms.Button Btn_UpExpression;
        private System.Windows.Forms.Button Btn_DownExpression;
        private System.Windows.Forms.Button Btn_RemoveExpression;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Tb_ParseResult;
        private System.Windows.Forms.Button Btn_SaveParser;
    }
}