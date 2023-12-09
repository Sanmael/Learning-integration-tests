using System.Linq.Expressions;
using System.Reflection;

namespace Infrastructure.Objects
{
    public class FakeData<T>
    {
        private T? Data { get;}
        private List<PropertyInfo> _ignoredProperties = new List<PropertyInfo>();

        public FakeData(string cenario)
        {
            Data = GetData.CreateInstanceResponse<T>(cenario);
        }

        public bool ExpectedObject(T other)
        {
            try
            {
                ProcessComparison(Data!, other!);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ProcessComparison(object compare, object toCompare)
        {
            if (compare == null || toCompare == null)
                throw new Exception("Objects should both be null or not null.");

            var properties = compare.GetType().GetProperties();

            foreach (var prop in properties)
            {
                if (_ignoredProperties.Contains(prop) || prop.Name == "Method")
                    continue;

                var value1 = prop.GetValue(compare)!;
                var value2 = prop.GetValue(toCompare)!;

                if (prop.PropertyType.IsClass && prop.PropertyType != typeof(string))
                    ProcessComparison(value1, value2);

                else if (!Equals(value1, value2))
                    throw new Exception($"{prop.Name} should have {value1}, but has {value2}.");
            }
        }

        public FakeData<T> IgnoreProperty(Expression<Func<T, object>> propertyExpression)
        {
            PropertyInfo propertyInfo = GetPropertyInfo(propertyExpression);
            _ignoredProperties.Add(propertyInfo);

            return this;
        }
        private PropertyInfo GetPropertyInfo(Expression<Func<T, object>> propertyExpression)
        {
            MemberExpression? memberExpression = propertyExpression.Body as MemberExpression;

            if (memberExpression == null)
                if (propertyExpression.Body is UnaryExpression unaryExpression)
                    memberExpression = unaryExpression.Operand as MemberExpression;

            if (memberExpression == null)
                throw new ArgumentException("Invalid property expression", nameof(propertyExpression));

            PropertyInfo? propertyInfo = memberExpression.Member as PropertyInfo;

            if (propertyInfo == null)
                throw new ArgumentException("Expression does not represent a property", nameof(propertyExpression));

            return propertyInfo;
        }
    }
}

