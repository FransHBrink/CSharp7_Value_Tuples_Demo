using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp7_Value_Tuples_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Problem: We have an array of intiger values and want a method to return both the min and max values of that array.
            //We could use Linq, however this would mean we'd need to evaluate int[] values twice with drawback of possible performance blunder.
            //Tuples existed back in 2005, but cumbersome to use.

            //Arrays: Same type e.g. int[]
            //Dictionary: Key Value Pair, key and it's value/What if you had two objects/Don't neccesarily correspond.

            int[] values = { 4, 5, -3, 10, 1 };

            MinMaxValuesEvaluatedTwice(values);

            MinMaxTuplesOld2005(values);

            MinMaxSyntax1(values);

            MinMaxSyntax2(values);

            Console.ReadLine();
        }

        /// <summary>
        /// evaluation/run over sequence first
        /// evaluation/run over sequence second time
        /// </summary>
        /// <param name="values"></param>
        private static void MinMaxValuesEvaluatedTwice(int[] values)
        {
            int min = values.Min();
            int max = values.Max();
        }

        /// <summary>
        /// Reference Tuple.Item1/.Item2
        /// </summary>
        /// <param name="values"></param>
        private static void MinMaxTuplesOld2005(int[] values)
        {
            var minMaxOld = MinMaxOld(values);
            Console.WriteLine($"MinOld: {minMaxOld.Item1}");
            Console.WriteLine($"MaxOld: {minMaxOld.Item2}");
        }

        /// <summary>
        /// Tuples syntax 1
        /// </summary>
        /// <param name="values"></param>
        private static void MinMaxSyntax1(int[] values)
        {
            var (minimumValue, maximumValue) = MinMax(values);
            Console.WriteLine($"Min: {minimumValue}");
            Console.WriteLine($"Max: {maximumValue}");
        }

        /// <summary>
        /// Tuples syntax 2
        /// </summary>
        /// <param name="values"></param>
        private static void MinMaxSyntax2(int[] values)
        {
            var minMax = MinMax(values);
            Console.WriteLine($"Min: {minMax.minimumValue}");
            Console.WriteLine($"Max: {minMax.maximumValue}");
        }

        static (int minimumValue, int maximumValue) MinMax(IEnumerable<int> values)
        {
            using (var iterator = values.GetEnumerator())
            {
                if (!iterator.MoveNext())
                {
                    throw new ArgumentException();
                }
                int tmpMin = iterator.Current;
                int tmpMax = iterator.Current;
                while (iterator.MoveNext())
                {
                    tmpMin = Math.Min(tmpMin, iterator.Current);
                    tmpMax = Math.Max(tmpMax, iterator.Current);
                }
                return (tmpMin, tmpMax);
            }
        }

        static Tuple<int, int> MinMaxOld(IEnumerable<int> values)
        {
            using (var iterator = values.GetEnumerator())
            {
                if (!iterator.MoveNext())
                {
                    throw new ArgumentException();
                }
                int tmpMin = iterator.Current;
                int tmpMax = iterator.Current;
                while (iterator.MoveNext())
                {
                    tmpMin = Math.Min(tmpMin, iterator.Current);
                    tmpMax = Math.Max(tmpMax, iterator.Current);
                }
                return new Tuple<int, int>(tmpMin, tmpMax);
            }
        }
    }
}
