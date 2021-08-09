using System;
using System.Collections.Generic;

namespace RoundTable
{
    class ChipsOnTable
    {
        static void Main(string[] args)
        {
            while (true)
            {
                List<int> chips = PlaceChips();
                PrintAllItems(chips);

                int sum = GetItemsSum(chips);
                while ((float)sum % (float)chips.Count != 0)
                {
                    Console.WriteLine("The number of players' chips is different.");
                    Console.WriteLine("Please use the same number of chips for each player\n\n");
                    chips = PlaceChips();
                    PrintAllItems(chips);

                    sum = GetItemsSum(chips);
                }

                chips = Balance(chips, sum);
            }
        }

        private static List<int> Balance(List<int> myArray, int sum)
        {
            int step = 0;
            int smallerNumber;
            int leftNeighbour, rightNeighbour;
            int average = sum / myArray.Count;

            while (isBalance(myArray, average) == false)
            {
                smallerNumber = FindSmallerNumber(myArray);
                leftNeighbour = smallerNumber;
                rightNeighbour = smallerNumber;
                while (myArray[smallerNumber] < average)
                {                    
                    leftNeighbour--;
                    rightNeighbour++;                    

                    if (leftNeighbour == -1)
                    {
                        leftNeighbour = myArray.Count - 1;
                    }
                    if (rightNeighbour == myArray.Count)
                    {
                        rightNeighbour = 0;
                    }

                    if (myArray[rightNeighbour] > average)
                    {
                        myArray[rightNeighbour] = myArray[rightNeighbour] - 1;
                        if (rightNeighbour - 1 == - 1)
                        {
                            myArray[myArray.Count - 1] = myArray[myArray.Count - 1] + 1;
                        }
                        else {
                            myArray[rightNeighbour - 1] = myArray[rightNeighbour - 1] + 1;
                        }
                        step++;
                        break;
                    }
                    if (myArray[leftNeighbour] > average)
                    {
                        myArray[leftNeighbour] = myArray[leftNeighbour] - 1;
                        if (leftNeighbour + 1 == myArray.Count)
                        {
                            myArray[0] = myArray[0] + 1;
                        }
                        else {
                            myArray[leftNeighbour + 1] = myArray[leftNeighbour + 1] + 1;
                        }
                        step++;
                        break;
                    }

                    if (leftNeighbour - 1 == rightNeighbour)
                    {
                        break;
                    }
                }
            }

            PrintAllItems(myArray);
            Console.WriteLine("Moves it took: " + Convert.ToString(step) + "\n\n");

            return myArray;
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

        private static int FindSmallerNumber(List<int> myArray)
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
            return smallerNumber;
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

        private static int GetItemsSum(List<int> myArray)
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
