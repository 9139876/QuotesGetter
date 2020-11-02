using Graal.Library.Common;
using Graal.Library.Storage.Common;
using Graal.QuotesGetter.DataParser.Expressions;
using Graal.QuotesGetter.DataParser.ExpressionsSets;
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
    public partial class ParserEditorWindow : Form
    {
        //StorageManager storageManager;

        ExpressionsSet parser;

        IExpressionsSequence curExpressionsSequence;

        readonly string[] input;

        public ParserEditorWindow(ExpressionsSet _parser, string parserName, string[] _input)
        {
            input = _input;
            parser = _parser;

            InitializeComponent();

            Initial(parserName);
        }

        void Initial(string parserName)
        {
            this.Text = $"Редактирование парсера '{parserName}'";

            NUD_SkipRows.Value = parser.RowSkipCount;

            RefreshInput();

            Lb_Expressions.Items.AddRange(Description.GetAllDescptions<ExpressionType>());

            TW_ExpressionsTree.Nodes.Clear();

            var root = new TreeNode(parserName);

            var dateNode = new TreeNode("Дата");
            dateNode.Nodes.AddRange(parser.DateExpressionsSet.GetAllPropertiesNames().Select(n => new TreeNode(n)).ToArray());
            root.Nodes.Add(dateNode);

            root.Nodes.AddRange(parser.GetAllPropertiesNames().Select(n => new TreeNode(n)).ToArray());

            TW_ExpressionsTree.Nodes.Add(root);
        }

        void RefreshInput()
        {
            Tb_InputString.Text = input.Length > NUD_SkipRows.Value ? input[(int)NUD_SkipRows.Value] : string.Empty;
        }

        void RefreshExpressionsSequence()
        {
            Lb_UsedExpressions.Items.Clear();
            Lb_UsedExpressions.Items.AddRange(curExpressionsSequence.GetAllExpressions().Select(expr => expr.Name).ToArray());
        }

        private void Lb_Expressions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new CreateExpressionWindow(Description.ValueFromDescription<ExpressionType>(Lb_Expressions.SelectedItem.ToString()), expr => curExpressionsSequence.AppendExpression(expr)).ShowDialog();
            RefreshExpressionsSequence();
        }

        private void TW_ExpressionsTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Lb_UsedExpressions.Items.Clear();

            if (TW_ExpressionsTree.SelectedNode == null
                || TW_ExpressionsTree.SelectedNode.Parent == null
                || TW_ExpressionsTree.SelectedNode.Text == "Дата")
            {
                Lb_UsedExpressions.Visible = false;
                return;
            }

            Lb_UsedExpressions.Visible = true;

            if (parser.GetAllPropertiesNames().Contains(TW_ExpressionsTree.SelectedNode.Text))
            {
                curExpressionsSequence = parser.GetSequence(TW_ExpressionsTree.SelectedNode.Text);
            }
            else if (TW_ExpressionsTree.SelectedNode.Parent.Text == "Дата" && parser.DateExpressionsSet.GetAllPropertiesNames().Contains(TW_ExpressionsTree.SelectedNode.Text))
            {
                curExpressionsSequence = parser.DateExpressionsSet.GetSequence(TW_ExpressionsTree.SelectedNode.Text);
            }

            RefreshExpressionsSequence();
        }

        private void NUD_SkipRows_ValueChanged(object sender, EventArgs e)
        {
            RefreshInput();
        }
    }
}
