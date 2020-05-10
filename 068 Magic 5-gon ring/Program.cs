using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _068_Magic_5_gon_ring
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://projecteuler.net/problem=68
            //Consider the following "magic" 3-gon ring, filled with the numbers 1 to 6, and each line adding to nine.

            //Working clockwise, and starting from the group of three with the numerically lowest external node (4,3,2 in this example), 
            //each solution can be described uniquely. For example, the above solution can be described by the set: 4,3,2; 6,2,1; 5,1,3.

            //It is possible to complete the ring with four different totals: 9, 10, 11, and 12. There are eight solutions in total.
            //Total	Solution Set
            //9	4,2,3; 5,3,1; 6,1,2
            //9	4,3,2; 6,2,1; 5,1,3
            //10	2,3,5; 4,5,1; 6,1,3
            //10	2,5,3; 6,3,1; 4,1,5
            //11	1,4,6; 3,6,2; 5,2,4
            //11	1,6,4; 5,4,2; 3,2,6
            //12	1,5,6; 2,6,4; 3,4,5
            //12	1,6,5; 3,5,4; 2,4,6

            //By concatenating each group it is possible to form 9-digit strings; the maximum string for a 3-gon ring is 432621513.

            //Using the numbers 1 to 10, and depending on arrangements, it is possible to form 16- and 17-digit strings. 
            //What is the maximum 16-digit string for a "magic" 5-gon ring?

            var testring = new Magic3gonRing(new[] {4,6,5,3,2,1});
            Console.WriteLine(testring.IsMagic());

            var possibleNumbers = MathFunctions.PermutationsOf(new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10});
            Console.WriteLine("{0} perms to test", possibleNumbers.Count);

            List<Magic5gonRing> magicRings = new List<Magic5gonRing>();
            foreach (List<int> numbers in possibleNumbers)
            {
                var ring = new Magic5gonRing(numbers.ToArray());
                if (ring.IsMagicAndUnique())
                {
                    magicRings.Add(ring);
                }
            }

            List<string> ringStrings = new List<string>();
            foreach (Magic5gonRing magicRing in magicRings)
            {
                ringStrings.Add(magicRing.ToString());
            }

            Console.WriteLine(ringStrings.Max());

            Console.Read();
        }

        class Magic3gonRing
        {
            public int[] Numbers { get; set; }
            public int[][] SolutionSet { get; set; }

            public Magic3gonRing(int[] numbers)
            {
                if (numbers.Length != 6)
                {
                    throw new InvalidOperationException("set must contain 6 elements");
                }

                Numbers = numbers;
                SolutionSet = GetSolutionSet();
            }

            int[][] GetSolutionSet()
            {
                var set = new int[3][];
                set[0] = new[] {Numbers[0], Numbers[3], Numbers[4]};
                set[1] = new[] {Numbers[1], Numbers[4], Numbers[5]};
                set[2] = new[] {Numbers[2], Numbers[5], Numbers[3]};
                return set;
            }

            public bool IsMagic()
            {
                int magicNum = SolutionSet[0].Sum();
                return SolutionSet.All(x => x.Sum() == magicNum);
            }

            public bool IsLowestUnique()
            {
                int startInt = Numbers[0];
                return SolutionSet.All(row => row[0] >= startInt);
            }

            public bool IsMagicAndUnique()
            {
                return IsMagic() && IsLowestUnique();
            }

            public override string ToString()
            {
                string s = "";
                foreach (int[] row in SolutionSet)
                {
                    foreach (int n in row)
                    {
                        s += n;
                    }
                }
                return s;
            }
        }

        class Magic5gonRing
        {
            public int[] Numbers { get; set; }
            public int[][] SolutionSet { get; set; }

            public Magic5gonRing(int[] numbers)
            {
                if (numbers.Length != 10)
                {
                    throw new InvalidOperationException("set must contain 10 elements");
                }

                Numbers = numbers;
                SolutionSet = GetSolutionSet();
            }

            int[][] GetSolutionSet()
            {
                var set = new int[5][];
                set[0] = new[] { Numbers[0], Numbers[5], Numbers[6]};
                set[1] = new[] { Numbers[1], Numbers[6], Numbers[7] };
                set[2] = new[] { Numbers[2], Numbers[7], Numbers[8] };
                set[3] = new[] { Numbers[3], Numbers[8], Numbers[9] };
                set[4] = new[] { Numbers[4], Numbers[9], Numbers[5] };
                return set;
            }

            public bool IsMagic()
            {
                int magicNum = SolutionSet[0].Sum();
                return SolutionSet.All(x => x.Sum() == magicNum);
            }

            public bool IsLowestUnique()
            {
                int startInt = Numbers[0];
                return SolutionSet.All(row => row[0] >= startInt);
            }

            public bool IsMagicAndUnique()
            {
                return IsMagic() && IsLowestUnique();
            }

            public override string ToString()
            {
                string s = "";
                foreach (int[] row in SolutionSet)
                {
                    foreach (int n in row)
                    {
                        s += n;
                    }
                }
                return s;
            }
        }
    }
}
