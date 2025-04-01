
namespace task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int n))
            {
                Console.WriteLine("Error! Invalid input.");
                return;
            }
            int fact = 1;

            if (n < 0)
            {
                Console.WriteLine("Error! Given number is negative.");
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                fact = fact * i;
            }
            Console.WriteLine(fact);
        }
    }
}