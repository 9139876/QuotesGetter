using Graal.Library.Common;
using Graal.Library.Common.Quotes;
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
        IExpressionsSequence curExpressionsSequence;

        readonly ExpressionsSet parser;

        readonly string parserName;

        readonly string[] input;

        readonly List<Button> expressionsButtons;

        readonly Action<string, ExpressionsSet> getParser;

        public ParserEditorWindow(ExpressionsSet _parser, string _parserName, string[] _input, Action<string, ExpressionsSet> _getParser)
        {
            input = _input;
            parser = _parser;
            parserName = _parserName;
            getParser = _getParser;

            InitializeComponent();

            expressionsButtons = new List<Button>() { Btn_UpExpression, Btn_DownExpression, Btn_RemoveExpression };
            SetExpressionsButtonsVisible(false);

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

            Lb_UsedExpressions.Visible = false;
            Lb_Expressions.Visible = false;
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

        void SetExpressionsButtonsVisible(bool visible) => expressionsButtons.ForEach(b => b.Visible = visible);

        private void Lb_Expressions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Btn_SaveParser.Visible = false;
            new CreateExpressionWindow(Description.ValueFromDescription<ExpressionType>(Lb_Expressions.SelectedItem.ToString()), expr => curExpressionsSequence.AppendExpression(expr)).ShowDialog();
            RefreshExpressionsSequence();
        }

        private void TW_ExpressionsTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Lb_UsedExpressions.Items.Clear();
            SetExpressionsButtonsVisible(false);

            if (TW_ExpressionsTree.SelectedNode == null
                || TW_ExpressionsTree.SelectedNode.Parent == null
                || TW_ExpressionsTree.SelectedNode.Text == "Дата")
            {
                Lb_UsedExpressions.Visible = false;
                Lb_Expressions.Visible = false;
                return;
            }

            Lb_UsedExpressions.Visible = true;
            Lb_Expressions.Visible = true;

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
            Btn_SaveParser.Visible = false;
            parser.RowSkipCount = (int)NUD_SkipRows.Value;
            RefreshInput();
        }

        private void Lb_UsedExpressions_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetExpressionsButtonsVisible(Lb_UsedExpressions.SelectedItem != null);
        }

        private void Btn_RemoveExpression_Click(object sender, EventArgs e)
        {
            Btn_SaveParser.Visible = false;
            curExpressionsSequence.RemoveExpression(Lb_UsedExpressions.SelectedIndex);
            RefreshExpressionsSequence();
        }

        private void Btn_UpExpression_Click(object sender, EventArgs e)
        {
            Btn_SaveParser.Visible = false;
            curExpressionsSequence.ExpressionPositionUp(Lb_UsedExpressions.SelectedIndex);
            RefreshExpressionsSequence();
        }

        private void Btn_DownExpression_Click(object sender, EventArgs e)
        {
            Btn_SaveParser.Visible = false;
            curExpressionsSequence.ExpressionPositionDown(Lb_UsedExpressions.SelectedIndex);
            RefreshExpressionsSequence();
        }

        private void Btn_TryCalc_Click(object sender, EventArgs e)
        {
            if (TW_ExpressionsTree.SelectedNode == null)
                return;

            try
            {
                string res = string.Empty;

                if (TW_ExpressionsTree.SelectedNode.Parent == null)
                {
                    if (parser.TryParse(Tb_InputString.Text, out Quote quote, out res))
                    {
                        res = quote.ToString();
                        Btn_SaveParser.Visible = true;
                    }
                    else
                        Btn_SaveParser.Visible = false;
                }
                else if (TW_ExpressionsTree.SelectedNode.Text == "Дата")
                {
                    if (parser.DateExpressionsSet.TryParse(Tb_InputString.Text, out DateTime dt, out res))
                        res = dt.ToString();
                }
                else
                {
                    res = curExpressionsSequence.Calculate(Tb_InputString.Text);
                }

                Tb_ParseResult.Text = res;
            }
            catch (Exception ex)
            {
                Tb_ParseResult.Text = ex.Message;
            }
        }

        private void Btn_SaveParser_Click(object sender, EventArgs e)
        {
            getParser(parserName, parser);
            Close();
        }
    }
}
