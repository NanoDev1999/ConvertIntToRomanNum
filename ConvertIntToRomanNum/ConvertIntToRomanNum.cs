using System;
using System.Collections.Generic;
using System.IO;

class Result
{
    public static List<string> romanizer(List<int> numbers) {
        List<string> result = new List<string>();

        for (int i = 0; i < numbers.Count; i++) {
            int num = numbers[i];
            if (num >= 1 && num <= 1000) {  // constraint 1 <= numbers[i] <= 1000 which is num
                string romanNumeral = ConvertIntToRomanNumerals(num);
                result.Add(romanNumeral);

                if(result.Count == 1000 || result.Count == 0) {    // constraint 1 <= n <= 1000 where n is the number of elements in numbers
                    break;
                }
            }
            else {
                result.Add("Invalid input: " + num);
            }
        }

        return result;
    }

    public static string ConvertIntToRomanNumerals(int num) {

        int[] arabicValues = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        string[] romanNumerals = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

        string resultString = "";

        int i = 0;
        while (num != 0) {
            if (num >= arabicValues[i]) {
                num -= arabicValues[i];
                resultString += romanNumerals[i];
            }
            else{
                i++;
            }
        }

        return resultString;

        // old code
        // Dictionary< string, int > romanNumerals = new Dictionary< string, int >() {
        //     { "I", 1}, 
        //     { "IV", 4}, 
        //     { "V", 5}, 
        //     { "IX", 9}, 
        //     { "X", 10}, 
        //     { "XL", 40}, 
        //     { "L", 50}, 
        //     { "XC", 90}, 
        //     { "C", 100}, 
        //     { "CD", 400}, 
        //     { "D", 500}, 
        //     { "CM", 900}, 
        //     { "M", 1000}
        // };

        // int addedValues = 0;
        // string arabicNumAsString = num.ToString();

        // for (int i = 0; i < arabicNumAsString.Length; i++) {
        //     char currentRomanChar = arabicNumAsString[i];
        //     romanNumerals.TryGetValue(currentRomanChar, out int foundNum);
        //     if (i + 1 < s.Length && romanNumerals[arabicNumAsString[i + 1]] > romanNumerals[currentRomanChar])
        //     {
        //         addedValues -= foundNum;
        //     }
        //     else
        //     {
        //         addedValues += foundNum;
        //     }
        // }

  
        // string[] thousands = { "", "M", "MM", "MMM" };
        // string[] hundreds = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        // string[] tens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        // string[] units = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

        // int thousandsDigit = num / 1000;
        // int hundredsDigit = (num % 1000) / 100;
        // int tensDigit = (num % 100) / 10;
        // int unitsDigit = num % 10;

        // return thousands[thousandsDigit] + hundreds[hundredsDigit] + tens[tensDigit] + units[unitsDigit];
    }
}

class Solution
{
    public static void Main(string[] args) {
        string fileName = @"C:\Temp\ConvertIntToRomanNumResult.txt";
        TextWriter textWriter = new StreamWriter(fileName);

        int numCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> numbers = new List<int>();

        for (int i = 0; i < numCount; i++) {
            int numbersItem = Convert.ToInt32(Console.ReadLine().Trim());
            numbers.Add(numbersItem);
        }

        List<string> result = Result.romanizer(numbers);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
