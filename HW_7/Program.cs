using System.Reflection;
using System.Text;

namespace HW_7
{
    internal class Program
    {
        static void Main()
        {
            var test = MakeTestClass(13, "Любой текст", ['a', 'ч', 'ж']);

            string? str = ObjectToString(test!);
            Console.WriteLine("Объект в строку => " + str + "\n");

            var testEmpty = MakeTestClass();
            Console.WriteLine("Пустой объект: => " + ObjectToString(testEmpty!) + "\n");

            testEmpty = StringToObject(str) as TestClass;
            Console.WriteLine("testEmpty присвоен объект test: => " + ObjectToString(testEmpty!) + "\n");
        }
 
        static TestClass? MakeTestClass()
        {
            return Activator.CreateInstance(typeof(TestClass)) as TestClass;
        }
        static TestClass? MakeTestClass(int i)
        {
            return Activator.CreateInstance(typeof(TestClass), i) as TestClass;
        }
        static TestClass? MakeTestClass(int i, string s, char[] c)
        {
            return Activator.CreateInstance(typeof(TestClass), i, s, c) as TestClass;
        }
        static string ObjectToString(object obj)
        {
            StringBuilder sb = new();

            Type type = obj.GetType();

            sb.Append($"{type.AssemblyQualifiedName}:{type.Name}|");

            foreach (PropertyInfo? item in type.GetProperties())
            {
                object? temp = item.GetValue(obj);

                CustomNameAttribute? attribute = Attribute.GetCustomAttribute(item, typeof(CustomNameAttribute)) as CustomNameAttribute;

                sb.Append($"{attribute?.PropertyName ?? item.Name} : {(temp is char[]? new string(temp as char[]) : temp)}|"); 
            }

            return sb.ToString();
        }
        static object? StringToObject(string str)
        {
            string[] pairs = str.TrimEnd('|').Split('|'); 
            string[] names = pairs[0].Split(',');

            object? obj = Activator.CreateInstance(names[1], names[0])?.Unwrap(); 

            if (obj == null || pairs.Length < 2) return obj;

            Type type = obj.GetType();

            for (int i = 1; i < pairs.Length; i++)
            {
                string[] pair = pairs[i].Split(':');
                PropertyInfo? prop = type.GetProperty(pair[0]);

                if (prop == null) 
                {
                    foreach (PropertyInfo item in type.GetProperties())
                    {
                        var attribute = Attribute.GetCustomAttribute(item, typeof(CustomNameAttribute)) as CustomNameAttribute;
                        if (attribute?.PropertyName == pair[0])
                            prop = item;
                    }
                }

                if (prop?.PropertyType == typeof(int)) { prop.SetValue(obj, int.Parse(pair[1])); }
                else if (prop?.PropertyType == typeof(string)) { prop.SetValue(obj, pair[1]); }
                else if (prop?.PropertyType == typeof(char[])) { prop.SetValue(obj, pair[1].ToCharArray()); }
            }

            return obj;
        }
    }
}