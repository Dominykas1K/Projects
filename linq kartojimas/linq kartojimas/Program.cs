using System.Runtime.CompilerServices;

namespace linq_kartojimas
{
    public static class Program
    {
        public delegate void MyDelegate(string text);
        //static void PrintText(string message) => Console.WriteLine(message);
        static void Main(string[] args)
        {
            //MyDelegate myDelegate = x => Console.WriteLine(x);
            //myDelegate("hello");

            //Action<string> printText = x => Console.WriteLine(x);
            //printText("hello");

            //Action<string,int> printTextTwice = (x,y) => Console.WriteLine($"{x} {y}");
            //printTextTwice("first", 3);


            //Func<int, int, int> sumFunc = (x, y) => x * y;

            //var resultSumFunc = sumFunc(3, 4);

            //Console.WriteLine(resultSumFunc);

            //Func<int, int> addToSum = (x) => x + sumFunc(3, 4);
            //Console.WriteLine(addToSum(3));


            //string[] strings = ["text1", "text1", "text1", "text1", "text1", "text1",];
            //PrintCollectionWithMagic(strings, x => $"{x} **************");

            //var numbers = GetNumbers();
            //foreach (var number in numbers)
            //{
            //    Console.WriteLine(number);
            //}


            var numbers = new List<int> { 12, 25, 43, 57, 87, 102 };

            var evenNumbers = numbers.MyWhere(x => x >= 40);
            var x = numbers.Select(x => x.ToString());

            foreach (var number in x)
            {
                Console.WriteLine(number);
            }

        }

        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }











        public static IEnumerable<int> GetNumbers()
        {
            for (int i = 0; i <= 10; i++)
            {
                yield return i;
            }
        }

        public static void PrintCollectionWithMagic(IEnumerable<string> source, Func<string,string> magic)
        {
            foreach (var item in source)
            {
                Console.WriteLine(magic(item));
            }
        }


        
    }
}
