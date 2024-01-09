using System;
using System.Text;

class PasswordGeneratorMichelle
{
    public string ComputePassword(string fullName)
    {
        if (string.IsNullOrEmpty(fullName))
        {
            throw new ArgumentException("Full name cannot be null or empty.Enter a name:");
        }

        int eliminatedLettersCount = 0;

        StringBuilder password = new StringBuilder();

        //the rules the program apllies to generate the password
        foreach (char c in fullName)
        {
            if (c == 'a' || c == 'e' || c == 't' || c == 'A' || c == 'E' || c == 'T')
            {
                eliminatedLettersCount++;
            }
            else if (c == ' ')
            {
                password.Append("S&#38;?");
            }
            else if (IsVowel(c))
            {
                password.Append($"{c}{c}");
            }
            else
            {
                password.Append(c);
            }
        }

        // Adding the count of eliminated letters to the end of the password
        password.Append(eliminatedLettersCount);

        return password.ToString();
    }

    //checkking if a character is a vowel
    private bool IsVowel(char c)
    {
        return "aeiouAEIOU".IndexOf(c) >= 0;
    }
}

class Program
{
    static void Main()
    {
        PasswordGeneratorMichelle passwordGenerator = new PasswordGeneratorMichelle();

        // Promting the user to enter how many items they would like to create
        Console.Write("Enter the number of items to create: ");
        if (!int.TryParse(Console.ReadLine(), out int itemCount) || itemCount <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive number.");
            return;
        }

        // Creating passwords for each full name the user enters
        for (int i = 1; i <= itemCount; i++)
        {
            Console.Write($"Enter full name #{i}: ");
            string fullName = Console.ReadLine();

            try
            {
                // Computing and displaying the password for each full name
                string password = passwordGenerator.ComputePassword(fullName);
                Console.WriteLine($"Generated password for {fullName}: {password}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
