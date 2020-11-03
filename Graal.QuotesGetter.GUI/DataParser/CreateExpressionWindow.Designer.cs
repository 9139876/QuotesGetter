namespace Graal.QuotesGetter.GUI.DataParser
{
    partial class CreateExpressionWindow
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
            this.Tb_Parameters = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_Create = new System.Windows.Forms.Button();
            this.Lbl_Hint = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Tb_Parameters
            // 
            this.Tb_Parameters.Location = new System.Drawing.Point(82, 50);
            this.Tb_Parameters.Name = "Tb_Parameters";
            this.Tb_Parameters.Size = new System.Drawing.Size(220, 20);
            this.Tb_Parameters.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Параметры";
            // 
            // Btn_Create
            // 
            this.Btn_Create.Location = new System.Drawing.Point(227, 76);
            this.Btn_Create.Name = "Btn_Create";
            this.Btn_Create.Size = new System.Drawing.Size(75, 23);
            this.Btn_Create.TabIndex = 4;
            this.Btn_Create.Text = "Создать";
            this.Btn_Create.UseVisualStyleBackColor = true;
            this.Btn_Create.Click += new System.EventHandler(this.Btn_Create_Click);
            // 
            // Lbl_Hint
            // 
            this.Lbl_Hint.AutoSize = true;
            this.Lbl_Hint.Location = new System.Drawing.Point(79, 33);
            this.Lbl_Hint.Name = "Lbl_Hint";
            this.Lbl_Hint.Size = new System.Drawing.Size(26, 13);
            this.Lbl_Hint.TabIndex = 5;
            this.Lbl_Hint.Text = "Hint";
            // 
            // CreateExpressionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 111);
            this.Controls.Add(this.Lbl_Hint);
            this.Controls.Add(this.Btn_Create);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Tb_Parameters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateExpressionWindow";
            this.Text = "Создание выражения";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Tb_Parameters;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_Create;
        private System.Windows.Forms.Label Lbl_Hint;
    }
}