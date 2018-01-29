using System;
using System.Linq.Expressions;

namespace Core.Common.Utils
{
    public static class PropertySupport
    {
        public static string ExtractPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            var body = propertyExpression.Body as MemberExpression;
            if (body == null)
            {
                UnaryExpression ubody = (UnaryExpression)propertyExpression.Body;
                body = ubody.Operand as MemberExpression;
            }
            return body?.Member.Name;
        }
    }
}
