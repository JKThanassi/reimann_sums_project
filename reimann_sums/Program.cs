using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reimann_sums
{
    class Program
    {

        public static double rightSum(double start, double stop, int n, Func<double,double> f) {
            double width = (stop - start) / n;
            double sum = 0;

            for (int i = 0; i < n; i++) {
                sum += f(start + (i + 1) * width);
            }

            return width * sum;
        }

        public static double leftSum(double start, double stop, int n, Func<double, double> f) {
            double width = (stop - start) / n;
            double sum = 0;
    
            for (int i = 0; i < n; i++)
            {
                sum += f(start + (i * width));
            }

            return width * sum;
            
        }

        public static double midSum(double start, double stop, int n, Func<double, double> f)
        {
            double width = (stop - start) / n;
            double sum = 0;

            for (int i = 0; i < n; i++)
            {
                sum += f(start + ((i + .5) * width));
            }

            return width * sum;
        }

        public static double trapezoidalSum(double start, double stop, int n, Func<double, double> f) {
            return (leftSum(start, stop, n, f) + rightSum(start, stop, n, f)) / 2;
        }

        // "l" for left, "m" for midpoint, "r" for right
        public static int convergence_interval(string sum_type, double start, double stop, double cCriteria, Func<double,double> f) {
            bool isConverged;
            int counter=0; //set as 0 so I can increment the counter at the start of each loop so I dont get count + 1 as my convergence result
            double c;
            if (sum_type.Equals("l", StringComparison.OrdinalIgnoreCase))
            {
                do
                {
                    counter++; 
                    c = Math.Abs((leftSum(start, stop, (counter + 1), f) - leftSum(start, stop, counter, f)) / leftSum(start, stop, counter, f));
                    isConverged = cCriteria >= c;
                } while (!isConverged);

                Console.WriteLine("area: " + leftSum(start, stop, counter, f));
                return counter;
            }
            else if (sum_type.Equals("m", StringComparison.OrdinalIgnoreCase))
            {
                do
                {
                    counter++;
                    c = Math.Abs((midSum(start, stop, (counter + 1), f) - midSum(start, stop, (counter), f)) / midSum(start, stop, counter, f));
                    isConverged = cCriteria > c;
                } while (!isConverged);

                Console.WriteLine("Area:" + midSum(start, stop, counter, f));
                return counter;
            }
            else if (sum_type.Equals("r", StringComparison.OrdinalIgnoreCase)) {
                do
                {
                    counter++;
                    c = Math.Abs((rightSum(start, stop, (counter + 1), f) - rightSum(start, stop, (counter), f)) / rightSum(start, stop, counter, f));
                    isConverged = cCriteria > c;
                } while (!isConverged);

                Console.WriteLine("area: " + rightSum(start, stop, counter, f));
                return counter;
            }
            else if (sum_type.Equals("t", StringComparison.OrdinalIgnoreCase))
            {
                do
                {
                    counter++;
                    c = Math.Abs((trapezoidalSum(start, stop, (counter + 1), f) - trapezoidalSum(start, stop, (counter), f)) / trapezoidalSum(start, stop, counter, f));
                    isConverged = cCriteria > c;
                } while (!isConverged);

                Console.WriteLine("area: " + trapezoidalSum(start, stop, counter, f));
                return counter;
            }
            else
            {
                Console.WriteLine("Please choose from L, M, R, or T");
                return -1;
            }
        }

    }
}
