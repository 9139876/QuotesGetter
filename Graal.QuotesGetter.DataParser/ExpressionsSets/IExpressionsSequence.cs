using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graal.QuotesGetter.DataParser.Expressions;

namespace Graal.QuotesGetter.DataParser.ExpressionsSets
{
    public interface IExpressionsSequence
    {
        void AppendExpression(Expression expression);

        void ExpressionPositionUp(int curPosition);

        void ExpressionPositionDown(int curPosition);

        void RemoveExpression(int position);

        void Clear();

        Expression[] GetAllExpressions();

        string Calculate(string row);

        IExpressionsSequence Clone();
    }
}
