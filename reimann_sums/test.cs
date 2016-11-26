using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reimann_sums
{
    class test_sums
    {
        static void Main(String[] args) {
            Console.WriteLine("Left handed sum: " + Program.leftSum(0,3,4,testFunc));
            Console.WriteLine();
            Console.WriteLine("midpt sum: " + Program.midSum(0, 3, 4, testFunc));
            Console.WriteLine();
            Console.WriteLine("right handed sum: " + Program.rightSum(0, 3, 4, testFunc));
            Console.WriteLine();
            Console.WriteLine("convergence: " + Program.convergence_interval("r", 0, 3, .001, testFunc));
            Console.ReadLine();

        }

        public static double testFunc(double x) {
            return Math.Pow(x, 2) + 4 * x + 3;
        }
    }
}
