using System;
using System.Collections.Generic;
using System.IO;

class Result
{
    public static List<string> romanizer(List<int> numbers) {
        List<string> result = new List<string>();

        foreach (var num in numbers) {
            if (num >= 1 && num <= 1000) {
                string romanNumeral = ConvertToRoman(num);
                result.Add(romanNumeral);
            }
            else {
                result.Add("Invalid input: " + num);
            }
        }

        return result;
    }

    public static string ConvertToRoman(int num) {
        if (num < 1 || num > 1000) {
            return "Invalid input: " + num;
        }

        string[] thousands = { "", "M", "MM", "MMM" };
        string[] hundreds = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        string[] tens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        string[] units = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

        int thousandsDigit = num / 1000;
        int hundredsDigit = (num % 1000) / 100;
        int tensDigit = (num % 100) / 10;
        int unitsDigit = num % 10;

        return thousands[thousandsDigit] + hundreds[hundredsDigit] + tens[tensDigit] + units[unitsDigit];
    }
}

class Solution
{
    public static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int numbersCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> numbers = new List<int>();

        for (int i = 0; i < numbersCount; i++) {
            int numbersItem = Convert.ToInt32(Console.ReadLine().Trim());
            numbers.Add(numbersItem);
        }

        List<string> result = Result.romanizer(numbers);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
