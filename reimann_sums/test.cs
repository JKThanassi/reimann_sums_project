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
            string input;
            string sub1;
            string sub2;
            while (true)
            {
                Console.WriteLine("Please enter what you would like to do:");
                Console.WriteLine("1 and the type for riemann sum results ex. 1r for a right handed riemann sum");
                Console.WriteLine("2 and the type for convergence: ex. 2m for solving the convergence of a midpoint riemann sum");
                Console.WriteLine("enter q to quit");
                input = Console.ReadLine();
                sub1 = input.Substring(0, 1);
                sub2 = input.Substring(1, 1);
                if (input.Equals("q", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                else if (sub1.Equals("1"))
                {
                    if (sub2.Equals("m", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("enter the start point: ");
                        int start = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter stop point: ");
                        int stop = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter the number of intervals you would like to sum over: ");
                        int n = Convert.ToInt32(Console.ReadLine());
                        if ((stop > start) && n > 0)
                        {
                            Console.WriteLine("Riemann sum mid: " + Program.midSum(start, stop, n, testFunc));
                        }
                        else
                        {
                            Console.WriteLine("Stop must be greater than start and n must be greater than zero");
                        }

                    }
                    else if (sub2.Equals("r", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("enter the start point: ");
                        int start = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter stop point: ");
                        int stop = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter the number of intervals you would like to sum over: ");
                        int n = Convert.ToInt32(Console.ReadLine());
                        if ((stop > start) && n > 0)
                        {
                            Console.WriteLine("Riemann sum right: " + Program.rightSum(start, stop, n, testFunc));
                        }
                        else
                        {
                            Console.WriteLine("Stop must be greater than start and n must be greater than zero");
                        }
                    }
                    else if (sub2.Equals("l", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("enter the start point: ");
                        int start = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter stop point: ");
                        int stop = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter the number of intervals you would like to sum over: ");
                        int n = Convert.ToInt32(Console.ReadLine());
                        if ((stop > start) && n > 0)
                        {
                            Console.WriteLine("Riemann sum left: " + Program.leftSum(start, stop, n, testFunc));
                        }
                        else
                        {
                            Console.WriteLine("Stop must be greater than start and n must be greater than zero");
                        }
                    }
                    else
                    {
                        Console.WriteLine("please input n,m, or r for the second character");
                    }
                }
                else if (sub1.Equals("2"))
                {
                    if (sub2.Equals("m", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("enter the start point: ");
                        int start = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter stop point: ");
                        int stop = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter the Convergence criteria: ");
                        double cCriteria = Convert.ToDouble(Console.ReadLine());
                        if ((stop > start) && cCriteria > 0)
                        {
                            Console.WriteLine("Midpt convergence: " + Program.convergence_interval("m", start, stop, cCriteria, testFunc));
                        }
                        else
                        {
                            Console.WriteLine("Stop must be greater than start and cCriteria must be less than zero");
                        }

                    }
                    else if (sub2.Equals("l", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("enter the start point: ");
                        int start = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter stop point: ");
                        int stop = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter the Convergence criteria: ");
                        double cCriteria = Convert.ToDouble(Console.ReadLine());
                        if ((stop > start) && cCriteria > 0)
                        {
                            Console.WriteLine("Left convergence: " + Program.convergence_interval("l", start, stop, cCriteria, testFunc));
                        }
                        else
                        {
                            Console.WriteLine("Stop must be greater than start and cCriteria must be less than zero");
                        }

                    }
                    else if (sub2.Equals("r", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("enter the start point: ");
                        int start = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter stop point: ");
                        int stop = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter the Convergence criteria: ");
                        double cCriteria = Convert.ToDouble(Console.ReadLine());
                        if ((stop > start) && (cCriteria > 0))
                        {
                            Console.WriteLine("Right convergence: " + Program.convergence_interval("R", start, stop, cCriteria, testFunc));
                        }
                        else
                        {
                            Console.WriteLine("Stop must be greater than start and cCriteria must be less than zero");
                        }

                    }
                    else
                    {
                        Console.WriteLine("please input n,m, or r for the second character");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter 1 or 2 as the first character");
                }
            }
            

            //Console.WriteLine("Left handed sum: " + Program.leftSum(0,3,4,testFunc));
            //Console.WriteLine();
            //Console.WriteLine("midpt sum: " + Program.midSum(0, 3, 4, testFunc));
            //Console.WriteLine();
            //Console.WriteLine("right handed sum: " + Program.rightSum(0, 3, 4, testFunc));
            //Console.WriteLine();
            //Console.WriteLine("convergence: " + Program.convergence_interval("m", 0, 3, .001, testFunc));
            //Console.ReadLine();

        }

        public static double testFunc(double x) {
            return Math.Pow(x, 2) + 4 * x + 3;
        }
    }
}
