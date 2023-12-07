using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
	public class Day4 : Base
	{
		private const string numberMatch = @"\d+";
		public Day4()
		{
			_input = File.ReadAllLines("Inputs/Day4.txt");
		}
		public override int? Q1()
		{
			var allCardsTotal = 0;
			for (var i = 0; i < _input.Count(); i++)
			{
				var cardNumberAndwinningVsNumbers = _input[i].Split(':');
				var winningVsNumbers = cardNumberAndwinningVsNumbers[1].Split("|");
				var winningNumbers = Regex.Matches(winningVsNumbers[0], numberMatch).Select(n => int.Parse(n.Value));
				var numbersIHave = Regex.Matches(winningVsNumbers[1], numberMatch).Select(n => int.Parse(n.Value));

				var cardTotal = 0;

				foreach (var numberIHave in numbersIHave)
				{
					if (winningNumbers.Contains(numberIHave))
					{
						if (cardTotal == 0)
						{
							cardTotal++;
						}
						else
						{
							cardTotal *= 2;
						}
					}
				}
				allCardsTotal += cardTotal;
			}
			return allCardsTotal;
		}
		public override int? Q2()
		{
			var scratchCardCount = 0;
			for (var i = 0; i <= _input.Count() - 1; i++)
			{
				RecursivelyCountCards(i, ref scratchCardCount, 0);
			}
			return scratchCardCount;
		}
		private void RecursivelyCountCards(int cardIndex, ref int totalCardCount, int depth)
		{
			totalCardCount++;

			Dictionary<int, int> cardIndexWinCache = new Dictionary<int, int>();
			int localWinCount = 0;

			if(cardIndexWinCache.ContainsKey(cardIndex))
			{
				localWinCount = cardIndexWinCache[cardIndex];
			}
			else
			{
				var cardNumberAndwinningVsNumbers = _input[cardIndex].Split(':');
				var winningVsNumbers = cardNumberAndwinningVsNumbers[1].Split("|");
				var winningNumbers = Regex.Matches(winningVsNumbers[0], numberMatch).Select(n => int.Parse(n.Value));
				var numbersIHave = Regex.Matches(winningVsNumbers[1], numberMatch).Select(n => int.Parse(n.Value));

				localWinCount = winningNumbers.Count(w => numbersIHave.Contains(w));
			}

			cardIndexWinCache.Add(cardIndex, localWinCount);

			if(depth == 0)
			{
				Console.WriteLine($"Card {cardIndex + 1}: {localWinCount} wins");
			}

			if (localWinCount == 0)
			{
				return;
			}

			for(var i = 1; i <= localWinCount; i++)
			{
				RecursivelyCountCards(i + cardIndex, ref totalCardCount, depth + 1);
			}
		}
	}
}
