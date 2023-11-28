using System.Linq.Expressions;
using System.Reflection;

namespace Infrastructure.Objects
{
    public class FakeData<T> 
    {
        private T? Data { get; set; }
        private readonly List<PropertyInfo> IgnoredProperties = new List<PropertyInfo>();
        public FakeData<T> Init()
        {
            GetData getData = new GetData();

            Data = getData.CreateInstance<T>();

            return this;
        }
        public bool ExpectedObject(T other)
        {
            var properties = typeof(T).GetProperties();
            try
            {
                foreach (var prop in properties)
                {
                    if (IgnoredProperties.Contains(prop))
                        continue;

                    var value1 = prop.GetValue(Data);
                    var value2 = prop.GetValue(other);

                    if (!value1?.Equals(value2) ?? value2 != null)
                        throw new Exception($"{prop.Name} should have {value1}, but has {value2}.");
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public FakeData<T> IgnoreProperty(Expression<Func<T, object>> propertyExpression)
        {
            PropertyInfo propertyInfo = GetPropertyInfo(propertyExpression);
            IgnoredProperties.Add(propertyInfo);

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

