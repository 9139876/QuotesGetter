using Graal.QuotesGetter.GUI.DataParser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Graal.QuotesGetter.DataParser.Expressions;

namespace Graal.QuotesGetter.GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new CreateExpressionWindow((Expression ex) => { }).ShowDialog();
        }
    }
}
