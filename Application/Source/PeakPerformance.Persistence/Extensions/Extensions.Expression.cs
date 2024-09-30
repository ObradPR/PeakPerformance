using System.Linq.Expressions;

namespace PeakPerformance.Persistence.Extensions;

public static partial class Extensions
{
    private static bool TryParsePath(Expression expression, out string path)
    {
        path = null;
        var withoutConvert = expression.RemoveConvert();

        if (withoutConvert is MemberExpression memberExpression)
        {
            var thisPart = memberExpression.Member.Name;
            //if (!TryParsePath(memberExpression.Expression, out var parentPart))
            //	return false;

            TryParsePath(memberExpression.Expression, out var parentPart);
            path = parentPart == null ? thisPart : $"{parentPart}.{thisPart}";

            return true;
        }
        else if (withoutConvert is MethodCallExpression callExpression)
        {
            if (callExpression.Method.Name == "Select" && callExpression.Arguments.Count == 2)
            {
                if (!TryParsePath(callExpression.Arguments[0], out var parentPart))
                    return false;

                if (parentPart != null)
                {
                    if (callExpression.Arguments[1] is LambdaExpression subExpression)
                    {
                        if (!TryParsePath(subExpression.Body, out var thisPart))
                            return false;

                        if (thisPart != null)
                        {
                            path = $"{parentPart}.{thisPart}";
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        return false;
    }

    private static Expression RemoveConvert(this Expression expression)
    {
        while (expression.NodeType == ExpressionType.Convert || expression.NodeType == ExpressionType.ConvertChecked)
            expression = ((UnaryExpression)expression).Operand;
        return expression;
    }
}