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
        readonly Action<Expression> returnExpression;

        readonly ExpressionType expressionType;

        public CreateExpressionWindow(ExpressionType _expressionType, Action<Expression> _returnExpression)
        {
            returnExpression = _returnExpression;
            expressionType = _expressionType;

            InitializeComponent();

            Lbl_Hint.Text = Expression.GetExpressionHint(expressionType);

            if (Lbl_Hint.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).Length > 1)
                Lbl_Hint.Location = new Point(Lbl_Hint.Location.X, Lbl_Hint.Location.Y - 15);
        }

        private void Btn_Create_Click(object sender, EventArgs e)
        {
            string[] parameters = Tb_Parameters.Text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                var expr = Expression.GetExpression(expressionType, parameters);

                //MessageBox.Show($"Выражение '{expr.Name}' успешно создано");

                returnExpression(expr);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка создания выражения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
