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
            this.Cmb_ExpressionType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Tb_Parameters = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_Create = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Cmb_ExpressionType
            // 
            this.Cmb_ExpressionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_ExpressionType.FormattingEnabled = true;
            this.Cmb_ExpressionType.Location = new System.Drawing.Point(96, 12);
            this.Cmb_ExpressionType.Name = "Cmb_ExpressionType";
            this.Cmb_ExpressionType.Size = new System.Drawing.Size(208, 21);
            this.Cmb_ExpressionType.TabIndex = 0;
            this.Cmb_ExpressionType.SelectedIndexChanged += new System.EventHandler(this.Cmb_ExpressionType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Тип выражения";
            // 
            // Tb_Parameters
            // 
            this.Tb_Parameters.Location = new System.Drawing.Point(96, 40);
            this.Tb_Parameters.Name = "Tb_Parameters";
            this.Tb_Parameters.Size = new System.Drawing.Size(208, 20);
            this.Tb_Parameters.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Параметры";
            // 
            // Btn_Create
            // 
            this.Btn_Create.Location = new System.Drawing.Point(229, 66);
            this.Btn_Create.Name = "Btn_Create";
            this.Btn_Create.Size = new System.Drawing.Size(75, 23);
            this.Btn_Create.TabIndex = 4;
            this.Btn_Create.Text = "Создать";
            this.Btn_Create.UseVisualStyleBackColor = true;
            this.Btn_Create.Click += new System.EventHandler(this.Btn_Create_Click);
            // 
            // CreateExpressionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 97);
            this.Controls.Add(this.Btn_Create);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Tb_Parameters);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cmb_ExpressionType);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateExpressionWindow";
            this.Text = "Создание выражения";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Cmb_ExpressionType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Tb_Parameters;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_Create;
    }
}