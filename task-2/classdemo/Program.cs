namespace classdemo
{
    class Person{
        public string? name ;
        public int? age;

        public void Introduce(){

            Console.WriteLine($"Hello, my name is {name} and I am {age} years old.");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.name = "John";
            person.age = 30;
            person.Introduce();
            person.name = "Jane";
            person.age = 25;
            person.Introduce();
        }
    }
}