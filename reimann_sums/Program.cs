using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reimann_sums
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //}

        public static double rightSum(int start, int stop, int n, Func<double,double> f) {
            double width = (stop - start) / n;
            double sum = 0;

            for (int i = 0; i < n; i++) {
                sum += f(start + (i + 1) * width);
            }

            return width * sum;
        }

        public static double leftSum(int start, int stop, int n, Func<double, double> f) {
            double width = (stop - start) / n;
            double sum = 0;

            for (int i = 0; i < n; i++)
            {
                sum += f(start + (i * width));
            }

            return width * sum;
        }

        public static double midSum(int start, int stop, int n, Func<double, double> f)
        {
            double width = (stop - start) / n;
            double sum = 0;

            for (int i = 0; i < n; i++)
            {
                sum += f(start + ((i + .5) * width));
            }

            return width * sum;
        }

    }
}
