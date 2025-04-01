using System.Collections.Generic;
using System;

namespace collectionsdemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> task = new List<string>();
            task.Add("Task 1: Learn C#");
            task.Add("Task 2: Practice coding");
            task.Add("Task 3: Build a project");
            task.Add("Task 4: Review concepts");

            Console.WriteLine("Printing task By using String Manipulations");
            foreach (string item in task)
            {
                Console.WriteLine(item.ToUpper());
            }

            task[1] = "Task 2: Practice coding with examples";
            Console.WriteLine("After updating Task 2:");
            foreach (string item in task)
            {
                Console.WriteLine(item);
            }

            task.Remove("Task 2: Practice coding with examples");

            Console.WriteLine("After removing Task 2:");
            foreach (string item in task)
            {
                Console.WriteLine(item);
            }
        }
    }
}