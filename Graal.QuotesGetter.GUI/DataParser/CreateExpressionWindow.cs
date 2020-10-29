using Graal.Library.Common;
using Graal.QuotesGetter.DataParser.Expressions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graal.QuotesGetter.GUI.DataParser
{
    public partial class CreateExpressionWindow : Form
    {
        Action<Expression> returnExpression;

        public CreateExpressionWindow(Action<Expression> _returnExpression)
        {
            returnExpression = _returnExpression;

            InitializeComponent();

            Cmb_ExpressionType.Items.AddRange(Description.GetAllDescptions<ExpressionType>());
        }

        private void Cmb_ExpressionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tb_Parameters.Text = string.Empty;
        }

        private void Btn_Create_Click(object sender, EventArgs e)
        {
            if (Cmb_ExpressionType.SelectedItem == null)
            {
                MessageBox.Show("Не выбран тип создаваемого выражения");
                return;
            }

            ExpressionType type = Description.ValueFromDescription<ExpressionType>(Cmb_ExpressionType.SelectedItem.ToString());

            string[] parameters = Tb_Parameters.Text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                returnExpression(Expression.GetExpression(type, parameters));
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка создания выражения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
