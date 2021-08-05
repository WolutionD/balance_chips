using System;
using System.Collections.Generic;

namespace BalanceChips
{
    class TableWithChips
    {
        static void Main(string[] args)
        {
            var chips = PlaceChips();            
            PrintAllItems(chips);

            int sum = GetSum(chips);
            while ((float)sum % (float)chips.Count != 0)
            {
                Console.WriteLine("The number of players' chips is different.");
                Console.WriteLine("Please use the same number of chips for each player\n\n");
                chips = PlaceChips();
                PrintAllItems(chips);

                sum = GetSum(chips);
            }

            int average = sum / chips.Count;
            int[] smaller = new int[2];
            int[] largest = new int[2];
            int step = 0;
            int multiplier = 1;
            int neighbour;
            int straightDistance;
            int backDistance;
            while (isBalance(chips, average) == false)
            {
                smaller = FindSmaller(chips);
                largest = FindLargest(chips);
                while (largest[0] > average)
                {
                    // [1, 5, 9, 10, 5]
                    //start new function
                    if (largest[1] > smaller[1]) 
                    { 
                        straightDistance = largest[1] - smaller[1];
                        
                        backDistance = 0;
                        int counter = largest[1] + 1;
                        while (true)
                        {
                            if (counter == chips.Count)
                            {
                                counter = 0;
                            }
                            backDistance++;
                            if (counter == smaller[1])
                            {
                                break;
                            }
                            counter++;
                        }
                    }
                    else
                    {
                        straightDistance = smaller[1] - largest[1];
                    }
                    //end new function

                    for (int counter = 0; counter < chips.Count; counter++)
                    {
                        backDistance = 0;
                    }
                    
                        
                    
                    neighbour = largest[1] + multiplier;
                    if (neighbour == chips.Count)
                    {
                        neighbour = 0;
                    }
                    /* есть ли между ними слишком большое число?
                     *      тогда еспользовать его как наибольшее
                     * есть ли между ними число не в равновесии?
                     *      тогда сначала увеличить его
                     * увеличить наименьшее число
                     */
                    while (true)
                    {
                        step = step + 1 * multiplier;
                        break;
                    }                    
                }                
            }            
        }

        private static bool isBalance(List<int> myArray, int average)
        {
            bool balance = true;
            foreach(int number in myArray)
            {
                if (number != average)
                {
                    balance = false;
                    break;
                }
            }
            return balance;
        }

        private static int[] FindLargest(List<int> myArray)
        {
            int largest = 0;
            int largestNumber = 0;
            for (int counter = 0; counter < myArray.Count; counter++)
            {
                if (myArray[counter] > largest)
                {
                    largest = myArray[counter];
                    largestNumber = counter;
                }
            }
            int[] target = { largest, largestNumber };
            return target;
        }

        private static int[] FindSmaller(List<int> myArray)
        {
            int smaller = 10000;
            int smallerNumber = 0;
            for (int counter = 0; counter < myArray.Count; counter++)
            {
                if (myArray[counter] < smaller)
                {
                    smaller = myArray[counter];
                    smallerNumber = counter;
                }
            }
            int[] target = { smaller, smallerNumber };
            return target;
        }

        private static List<int> PlaceChips()
        {
            var chips = new List<int>();
            string chip = "";
            while (chips.Count == 0)
            {
                Console.WriteLine("Enter the chip number: ");
                chip = Console.ReadLine();
                if (Int32.TryParse(chip, out int number))
                {
                    chips.Add(number);
                }
                else
                {
                    Console.WriteLine("Pleace, enter a natural number, no letters.");
                }
            }
            Console.WriteLine("(Enter a blank line to complete input)");
            while (chip != "")
            {
                Console.WriteLine("Enter the number of the next chip: ");
                chip = Console.ReadLine();
                if (Int32.TryParse(chip, out int number))
                {
                    chips.Add(number);
                }
                else
                {
                    Console.WriteLine("Pleace, enter a natural number, no letters.");
                }                               
            }
            return chips;            
        }

        private static int GetSum(List<int> myArray)
        {
            int sum = 0;
            for (int counter = 0; counter <= myArray.Count - 1; counter++)
            {
                sum = sum + myArray[counter];
            }
            return sum;

        }

        private static void PrintAllItems(List<int> myArray)
        {
            string print = "";
            for (int counter = 0; counter < myArray.Count; counter++)
            {
                int number = myArray[counter];
                print = print + Convert.ToString(number) + ", ";
                
            }
            print = print.Remove(print.Length - 2);
            Console.WriteLine("Chips on table: ");
            Console.WriteLine(print + "\n");
        }
    }
}
