using System;
using System.Linq;
using System.Reflection;

namespace ReflectionDemo
{
    [AttributeUsage(AttributeTargets.Method)]
    public class RunnableAttribute : Attribute
    {
    }

    public class ClassA
    {
        [Runnable]
        public void MethodA()
        {
            Console.WriteLine("MethodA in ClassA executed.");
        }

        public void NonRunnableMethod()
        {
            Console.WriteLine("This method should NOT be executed.");
        }
    }

    public class ClassB
    {
        [Runnable]
        public void MethodB()
        {
            Console.WriteLine("MethodB in ClassB executed.");
        }
    }

    public class ClassC
    {
        [Runnable]
        public void MethodC()
        {
            Console.WriteLine("MethodC in ClassC executed.");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();

            foreach (var type in types)
            {
                var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                                  .Where(m => m.GetCustomAttribute<RunnableAttribute>() != null);

                foreach (var method in methods)
                {
                    Console.WriteLine($"\nExecuting {method.Name} in {type.Name}...");
                    
                    var instance = Activator.CreateInstance(type);
                    method.Invoke(instance, null);
                }
            }
        }
    }
}
