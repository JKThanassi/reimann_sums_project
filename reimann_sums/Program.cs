﻿using System;
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
            double width = (stop - start) / (double)n;
            double sum = 0;

            for (int i = 0; i < n; i++) {
                sum += f(start + (i + 1) * width);
            }

            return width * sum;
        }

        public static double leftSum(int start, int stop, int n, Func<double, double> f) {
            double width = (stop - start) / (double)n;
            double sum = 0;
    
            for (int i = 0; i < n; i++)
            {
                sum += f(start + (i * width));
            }

            return width * sum;
            
        }

        public static double midSum(int start, int stop, int n, Func<double, double> f)
        {
            double width = (stop - start) / (double)n;
            double sum = 0;

            for (int i = 0; i < n; i++)
            {
                sum += f(start + ((i + .5) * width));
            }

            return width * sum;
        }

        // "l" for left, "m" for midpoint, "r" for right
        public static int convergence_interval(string sum_type, int start, int stop, double cCriteria, Func<double,double> f) {
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

                return counter;
            }
            else if (sum_type.Equals("r", StringComparison.OrdinalIgnoreCase)) {
                do
                {
                    counter++;
                    c = Math.Abs((rightSum(start, stop, (counter + 1), f) - rightSum(start, stop, (counter), f)) / rightSum(start, stop, counter, f));
                    isConverged = cCriteria > c;
                } while (!isConverged);

                return counter;
            }
            else
            {
                Console.WriteLine("Please choose from L, M, or R");
                return -1;
            }
        }

    }
}
