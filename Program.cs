using System;

// Create a class for the dice simulator
class DiceSimulator
{
    // Create a method for the main program
    static void Main()
    {
        // Welcome the user and prompt them to enter how many times they want to roll the dice. Save that number to a variable.
        Console.WriteLine("Welcome to the dice throwing simulator!");
        Console.Write("How many dice rolls would you like to simulate? ");
        int numberOfRolls = int.Parse(Console.ReadLine());

        // Create an instance of the DiceRoller class (down below)
        DiceRoller diceRoller = new DiceRoller();

        // Get the array containing the results
        int[] results = diceRoller.SimulateRolls(numberOfRolls);

        // Print the histogram
        PrintHistogram(results, numberOfRolls);

        // Indicate that the program has ended
        Console.WriteLine("Thank you for using the dice throwing simulator. Goodbye!");
    }

    // Create method that prints the histogram
    static void PrintHistogram(int[] results, int totalRolls)
    {
        // Display header for the dice rolling simulation results
        Console.WriteLine("DICE ROLLING SIMULATION RESULTS");

        // Provide information about the representation of '*' in the histogram
        Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");

        // Display the total number of rolls in the simulation
        Console.WriteLine($"Total number of rolls = {totalRolls}.");

        // Iterate through possible sums of two dice (from 2 to 12) to print the histogram
        for (int i = 2; i <= 12; i++)
        {
            // Calculate the percentage of occurrences for the current sum
            int percentage = results[i] * 100 / totalRolls;

            // Print the histogram bar for the current sum, using '*' characters
            Console.WriteLine($"{i}: {new string('*', percentage)}");
        }
    }
}

class DiceRoller
{
    // Private field to generate random numbers for dice rolls
    private Random random = new Random();

    // Simulates rolling two six-sided dice a specified number of times
    // and returns an array representing the count of occurrences for each possible sum.
    public int[] SimulateRolls(int numberOfRolls)
    {
        // Initialize an array to store the count of occurrences for each possible sum (2 to 12)
        int[] results = new int[13];

        // Iterate through the specified number of rolls
        for (int i = 0; i < numberOfRolls; i++)
        {
            // Generate random numbers for the rolls of two six-sided dice
            int dice1 = random.Next(1, 7);
            int dice2 = random.Next(1, 7);

            // Calculate the sum of the two dice rolls
            int sum = dice1 + dice2;

            // Increment the count for the current sum in the results array
            results[sum]++;
        }

        // Return the array containing the results of the simulated dice rolls
        return results;
    }
}

