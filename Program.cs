﻿using System;
using System.Globalization;

class Program
{
    public static void Main()
    {
        Console.WriteLine("Введите массив!");
        while (true)
        {
            string inputArrStr = Console.ReadLine() ?? string.Empty;
            var inputArr = new List<string>(inputArrStr.Split(' '));
            var outputArr = CocoJambo(inputArr);
            outputArr.ForEach(Console.WriteLine);
        }
    }

    public static List<long> CocoJambo(List<string> inputArr)
    {
        var outputArr = new List<long>();
        foreach (var num in inputArr)
        {
            if (IsInt(num) && !IsNegative(num))
            {
                long res = Fact(long.Parse(num));
                outputArr.Add(res);
            }

            else if (IsDouble(num) && num.IndexOf(',') > 0)
            {
                long res = Round(double.Parse(num));
                outputArr.Add(res);
            }

            else
            {
                outputArr.Add(long.Parse(num));
            }
        }
        return outputArr;
    }
    public static bool IsInt(string input)
    {
        return int.TryParse(input, out var number);
    }

    public static bool IsDouble(string input)
    {
        return double.TryParse(input, out var number);
    }

    public static bool IsNegative(string number)
    {
        bool answer = number[0] == '-';
        return answer;
    }
    
    public static long Fact(long n)
    {
        if (n == 0)
            return 1;
        else
            return n * Fact(n - 1);
    }

    public static int FindNumberOfDigits(double number)
    {
        string strNumber = number.ToString();
        int index = strNumber.IndexOf(",");

        int length = 0;
        if (index > -1)
        {
            length = strNumber.Substring(index).Length - 1;
        }
        return length;
    }
    public static int Round(double number)
    {
        number = Math.Abs(number);
        double val = Math.Round(number - (int)number, 2) * 100;
        return (int)val;
    }
}
