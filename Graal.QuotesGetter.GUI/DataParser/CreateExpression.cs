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
    public partial class CreateExpression : Form
    {
        public CreateExpression()
        {
            InitializeComponent();

            Cmb_ExpressionType.Items.AddRange(Enum.GetValues(typeof(ExpressionType)).Cast<string>().ToArray());
        }

        private void Cmb_ExpressionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tb_Parameters.Text = string.Empty;
        }

        private void Btn_Create_Click(object sender, EventArgs e)
        {

        }
    }
}
