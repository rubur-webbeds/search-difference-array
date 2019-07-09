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
            // var set = new int[] { 6, 3, 5, 2, 4 };
            var resultSet = new List<dynamic>();
            var diffsDict = new Dictionary<int, List<int>>();
            int diff = 2;
            int subResult, sumResult;
            int ite = 0;

            for (int i = 0; i < set.Length; i++)
            {
                for (int j = 0; j < set.Length; j++)
                {
                    ite++;
                    subResult = set[i] - set[j];
                    if (subResult == diff)
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
                    subResult = set[i] - set[j];
                    if (Math.Abs(subResult) == diff)
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
                if(diffsDict.TryGetValue(set[k], out List<int> idxs))
                {
                    foreach(var idx in idxs)
                    {
                        resultSet.Add(new { A = set[k], B = set[idx] });
                    }
                    continue;
                }

                subResult = set[k] - diff;
                sumResult = set[k] + diff;

                if(diffsDict.ContainsKey(subResult)){
                    diffsDict[subResult].Add(k);
                }
                else
                {
                    diffsDict.Add(subResult, new List<int> { k });
                }

                if (diffsDict.ContainsKey(sumResult))
                {
                    diffsDict[sumResult].Add(k);
                }
                else
                {
                    diffsDict.Add(sumResult, new List<int> { k });
                }
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
