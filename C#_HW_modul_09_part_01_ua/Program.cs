namespace C__HW_modul_09_part_01_ua
{
    internal class Program
    {
        delegate bool NumberPredicate(int number);
        static List<int> FilterArray(int[] array, NumberPredicate predicate)
        {
            return array.Where(number => predicate(number)).ToList();
        }
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 13, 17, 21, 34, 55, 89 };

            Console.WriteLine("Enter choice: ");

            int choice = int.Parse(Console.ReadLine()); 

            switch (choice)
            {
                case 1:

                    NumberPredicate isEven = IsEven;
                    NumberPredicate isOdd = IsOdd;
                    NumberPredicate isPrime = IsPrime;
                    NumberPredicate isFibonacci = IsFibonacci;


                    var evenNumbers = FilterArray(array, isEven);
                    var oddNumbers = FilterArray(array, isOdd);
                    var primeNumbers = FilterArray(array, isPrime);
                    var fibonacciNumbers = FilterArray(array, isFibonacci);

                    Console.WriteLine("Even Numbers: " + string.Join(", ", evenNumbers));
                    Console.WriteLine("Odd Numbers: " + string.Join(", ", oddNumbers));
                    Console.WriteLine("Prime Numbers: " + string.Join(", ", primeNumbers));
                    Console.WriteLine("Fibonacci Numbers: " + string.Join(", ", fibonacciNumbers));
                    break;
            }

            static bool IsEven(int number) => number % 2 == 0;

            static bool IsOdd(int number) => number % 2 != 0;

            static bool IsPrime(int number)
            {
                if (number < 2) return false;
                for (int i = 2; i <= Math.Sqrt(number); i++)
                    if (number % i == 0) return false;
                return true;
            }

            static bool IsFibonacci(int number)
            {
                if (number < 0) return false;
                int a = 0, b = 1;
                while (a < number)
                {
                    int temp = a;
                    a = b;
                    b = temp + b;
                }
                return a == number;
            }
        }
    }
}
