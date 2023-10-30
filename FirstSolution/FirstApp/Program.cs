namespace FirstApp
{
    internal class Program
    {
        static void AddTwoNumbers()
        {
            int num1, num2,sum;
            Console.WriteLine("Enter two number to add them");
            num1 = Convert.ToInt32(Console.ReadLine());
            num2 = Convert.ToInt32(Console.ReadLine());
            sum=num1 + num2;
            Console.WriteLine($"the sum of {num1} and {num2} is {sum}");
        }
        static void BiggerNumber()
        {
            int num1, num2;
            Console.WriteLine("Enter two numbers to find the bigger number");
            num1 = Convert.ToInt32(Console.ReadLine());
            num2 = Convert.ToInt32(Console.ReadLine());
            if (num1 > num2)
            {
                Console.WriteLine($"The Bigger number is {num1}");
            }
            else
            {
                Console.WriteLine($"The Bigger number is {num2}");
            }
        }

        static void EvenNum()
        {
            int num1;
            Console.WriteLine("Enter a number to find if it's odd or even");
            num1 = Convert.ToInt32(Console.ReadLine());
            if (num1 % 2 == 0)
            {
                Console.WriteLine($"The Number {num1} is even");
            }
            else
            {
                Console.WriteLine($"The Number {num1} is odd");
            }
        }

        static void PrimeNum()
        {
            int num1,flag=0;
            Console.WriteLine("Enter a to find out if it's a prime number or not");
            num1 = Convert.ToInt32(Console.ReadLine());

            if (num1 == 0 || num1 == 1)
            {
                flag = 1;
            }
            for(int i=2;i<=num1/2; i++)
            {
                if (num1 % i == 0)
                {
                    flag = 1;
                    break;
                }
            }
            if(flag == 0)
            {
                Console.WriteLine($"{num1} is a prime number");
            }
            else
            {
                Console.WriteLine($"{num1} is not a prime number");
            }
        }

        static void SquareNum()
        {
            int num1,ans;
            Console.WriteLine("Enter a number to find it's square");
            num1 = Convert.ToInt32(Console.ReadLine());
            ans = num1 * num1;
            Console.WriteLine($"The square of the enter number is {ans}");
        }

        static void AverageNum()
        {
            int[] arr=new int[10];
            float sum = 0;
            float avg = 0;
            Console.WriteLine("Enter 10 Numbers");
            for(int i = 0; i < 10; i++)
            {
                arr[i]=Convert.ToInt32(Console.ReadLine());
                sum += arr[i];
                
            }
            avg = sum % 10;
            Console.WriteLine($"The Average of the enetered numberss is {avg}");

        }
        static void Main(string[] args)
        {
            //AddTwoNumbers();
            //BiggerNumber();
            //EvenNum();
            //PrimeNum();
            //SquareNum();
            AverageNum();
        }
    }
}