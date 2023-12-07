using System.Reflection;
using System.Runtime.CompilerServices;

namespace AdventOfCode2023
{
	public class Day1 : Base
	{
		public Day1()
		{
			_input = File.ReadAllLines("Inputs/Day1.txt");
		}
		public override int? Q1()
		{
			var total = 0;

			foreach (var line in _input)
			{
				var numbers = line.Where(c => char.IsDigit(c));
				var firstNumber = numbers.FirstOrDefault();
				var lastNumber = numbers.LastOrDefault();
				var concatenated = firstNumber.ToString() + lastNumber.ToString();
				int.TryParse(concatenated, out int calibrationValue);
				total += calibrationValue;
			}
			return total;
		}
		public override int? Q2()
		{
			var total = 0;
			foreach (var line in _input)
			{
				var firstNumber = GetFirstNumber(line);
				var lastNumber = GetLastNumber(line);
				var concatenated = firstNumber.ToString() + lastNumber.ToString();
				int.TryParse(concatenated, out int calibrationValue);
				total += calibrationValue;
			}
			return total;
		}
		public string GetFirstNumber(string line)
		{
			var indexOfFirstIntNumber = line.IndexOfAny(line.Where(c => char.IsDigit(c)).ToArray());
			var firstStringNumber = "";
			var indexOfFirstStringNumber = 10000;
			foreach (var stringNum in Reference.numberStringLookup.Keys)
			{
				var index = line.IndexOf(stringNum);
				if (index < indexOfFirstStringNumber && index > -1)
				{
					indexOfFirstStringNumber = index;
					firstStringNumber = stringNum;
				}
			}

			if (indexOfFirstIntNumber < indexOfFirstStringNumber && indexOfFirstIntNumber > -1)
			{
				return line.Substring(indexOfFirstIntNumber, 1);
			}
			else
			{
				return Reference.numberStringLookup[firstStringNumber].ToString();
			}
		}
		public string GetLastNumber(string line)
		{
			var indexOfLastIntNumber = line.LastIndexOfAny(line.Where(c => char.IsDigit(c)).ToArray());
			var lastStringNumber = "";
			var indexOfLastStringNumber = -10000;
			foreach (var stringNum in Reference.numberStringLookup.Keys)
			{
				var index = line.LastIndexOf(stringNum);
				if (index > indexOfLastStringNumber && index > -1)
				{
					indexOfLastStringNumber = index;
					lastStringNumber = stringNum;
				}
			}

			if (indexOfLastIntNumber > indexOfLastStringNumber && indexOfLastIntNumber > -1)
			{
				return line.Substring(indexOfLastIntNumber, 1);
			}
			else
			{
				return Reference.numberStringLookup[lastStringNumber].ToString();
			}
		}
	}
}
