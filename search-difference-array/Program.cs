using System;
using System.Collections.Generic;
using System.Dynamic;

namespace search_difference_array
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Start();
        }

        private void Start()
        {
            var set = new int[] { 12, 9, 7, 5, 3, 2, 1 };
            var resultSet = new List<dynamic>();
            var diffsDict = new Dictionary<int, int>();
            int diff = 2;
            int result;
            int ite = 0;

            for (int i = 0; i < set.Length; i++)
            {
                for (int j = 0; j < set.Length; j++)
                {
                    ite++;
                    result = set[i] - set[j];
                    if (result == diff)
                    {
                        resultSet.Add(new { A = set[i], B = set[j] });
                    }
                }
            }

            PrintResults(new { Iterations = ite, ResultSet = resultSet });
            ite = 0;
            resultSet.Clear();

            for (int i = 0; i < set.Length; i++)
            {
                for(int j = i; j < set.Length; j++)
                {
                    ite++;
                    result = set[i] - set[j];
                    if (Math.Abs(result) == diff)
                    {
                        resultSet.Add(new { A = set[i], B = set[j] });
                    }
                }
            }

            PrintResults(new { Iterations = ite, ResultSet = resultSet });
            ite = 0;
            resultSet.Clear();

            for(int k = 0; k < set.Length; k++)
            {
                ite++;
                if(diffsDict.TryGetValue(set[k], out int idx))
                {
                    resultSet.Add(new { A = set[k], B = set[idx] });
                    continue;
                }

                result = set[k] - diff;
                diffsDict.Add(result, k);
            }

            PrintResults(new { Iterations = ite, ResultSet = resultSet });
        }

        private void PrintResults(dynamic obj)
        {
            Console.WriteLine(obj.Iterations);
            foreach (var pair in obj.ResultSet)
            {
                Console.WriteLine(pair);
            }
        }
    }
}
