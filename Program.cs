using System;
using System.Linq;
using System.Collections.Generic;

namespace Assignment1_Spring2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1 : Enter the number of rows for the traingle:");
            int n = Convert.ToInt32(Console.ReadLine());
            printTriangle(n);
            Console.WriteLine();

            //Question 2:
            Console.WriteLine("Q2 : Enter the number of terms in the Pell Series:");
            int n2 = Convert.ToInt32(Console.ReadLine());
            printPellSeries(n2);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Q3 : Enter the number to check if squareSums exist:");
            int n3 = Convert.ToInt32(Console.ReadLine());
            bool flag = squareSums(n3);
            if (flag)
            {
                Console.WriteLine("Yes, the number can be expressed as a sum of squares of 2 integers");
            }
            else
            {
                Console.WriteLine("No, the number cannot be expressed as a sum of squares of 2 integers");
            }

            //Question 4:
            int[] arrnew = { 3, 1, 4, 1, 5 };
            int[] arr = arrnew.Distinct().ToArray();
            Console.WriteLine("Q4: Enter the absolute difference to check");
            int k = Convert.ToInt32(Console.ReadLine());
            int n4 = DiffPairs(arr, k);
            Console.WriteLine("There exists {0} pairs with the given difference", n4);

            //Question 5:
            List<string> emails = new List<string>();
            emails.Add("dis.email + bull@usf.com");
            emails.Add("dis.e.mail+bob.cathy@usf.com");
            emails.Add("disemail+david@us.f.com");
            emails.Add("disemail+david@usf.com");
            int ans5 = UniqueEmails(emails);
            Console.WriteLine("Q5");
            Console.WriteLine("The number of unique emails is " + ans5);

            //Question 6
            string[,] paths = new string[,] { { "London", "New York" }, { "New York", "Tampa" },
                                        { "Delhi", "London" } };
            string destination = Destcity(paths);
            Console.WriteLine("Q6");
            Console.WriteLine("Destination city is " + destination);


        }

        /// ///////////////Method section////////////////////

        //1st Answer

        private static void printTriangle(int n)
        {
            try
            {
                int i = 0, j = 0, a = 1, space, k = n;
                space = k - 1;
                for (i = 1; i <= k; i++)
                {
                    for (j = 1; j <= space; j++)
                    {
                        Console.Write(" ");
                    }
                    for (j = 1; j < a * 2; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine("");
                    if (i < k)
                    {
                        space--;
                        a++;
                    }
                    else
                    {
                        space++;
                        a--;

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        //2nd Answer

        private static void printPellSeries(int n2)
        {
            try
            {
                int i = 0;
                int NextPennNo = 0;
                int FirstNo = 0;
                int SecondNo = 1;
                Console.Write(FirstNo);
                Console.Write(SecondNo);
                for (i = 3; i <= n2; i++)
                {
                    NextPennNo = 2 * SecondNo + FirstNo;
                    Console.Write(NextPennNo);
                    FirstNo = SecondNo;
                    SecondNo = NextPennNo;
                }
                Console.WriteLine();
            }
            catch (Exception)
            {

                throw;
            }

        }

        //3rd Answer

        private static bool squareSums(int n3)
        {
            try
            {
                {
                    for (long i = 1; i * i <= n3; i++)
                        for (long j = 1; j * j <= n3; j++)
                            if (i * i + j * j == n3)
                            {
                                //Console.Write(i + "^2 + "+ j + "^2");
                                return true;
                            }
                    return false;
                }

                return false;

            }
            catch (Exception)
            {

                throw;
            }
        }

        //4th Answer
        private static int DiffPairs(int[] arr, int k)
        {
            try
            {
                int arrLength = arr.Length;
                /*Console.WriteLine(arrLength); //To check if array removing duplicate values
                for ( int ncount = 0; ncount < arrLength; ncount++)
                {
                    Console.WriteLine(arr[ncount]);
                }
                Console.WriteLine();*/
                int count = 0;
                int diff = 0;
                for (int i = 0; i < arrLength - 1; i++)   //Taking first element of array and comparing with others
                {
                    for (int n = i + 1; n < arrLength; n++)
                    {
                        if (arr[i] > arr[n])
                        {
                            diff = arr[i] - arr[n];
                        }
                        else if
                            (arr[i] < arr[n])
                        {
                            diff = arr[n] - arr[i];
                        }
                        if (diff == k && diff != 0)
                        {
                            Console.WriteLine(arr[i]);
                            Console.WriteLine(arr[n]);
                            count++;
                        }

                    }
                }
                return count;
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }

        //5th Answer

        private static int UniqueEmails(List<string> emails)
        {
            try
            {
                int count = 0;
                int Listlength = emails.Count;
                List<string> emailsNew = new List<string>();
                for (int i = 0; i < Listlength; i++)
                {
                    string ListItem = emails[i];
                    string ListItem1 = ListItem.Split('@')[0]; // To split email id before @
                    string ListItem3 = ListItem1.Split('+')[0]; // To get string before +

                    string ListItem2 = ListItem.Split('@')[1]; // To split email id after @
                    string[] string_array = ListItem3.Split(" ");
                    ListItem3 = ListItem3.Replace(".", "");
                    ListItem = ListItem3 + "@" + ListItem2; //Merging the email id
                                                            //Console.WriteLine("The final string: '{0}'", ListItem);
                    emailsNew.Add(ListItem); // Adding elements to new List called "emailsNew"
                }
                List<string> uniqueList = emailsNew.Distinct().ToList();
                count = uniqueList.Count;
                return count;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        //6th Answer
        private static string Destcity(string[,] paths)
        {
            try
            {
                int length = paths.GetLength(0);
                string destination = paths[0, 1];
                for (int i = 1; i < length; i++)
                {
                    if (destination == paths[i, 0])
                    {
                        destination = paths[i, 1];
                        i = 0;
                    }

                }
                return destination;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

    }
}
