namespace AdventOfCode2023
{
	public class Day2 : Base
	{
		private string[] _input = File.ReadAllLines("Inputs/Day2.txt");
		private Dictionary<string, int> _bagTotals = new Dictionary<string, int>
		{
			{ "red", 12 },
			{ "green", 13 },
			{ "blue", 14 },
		};
		public Day2()
		{
			_input = File.ReadAllLines("Inputs/Day2.txt");
		}
		public override int? Q1()
		{
			var sumOfViableGameIds = 0;
			foreach (var line in _input)
			{
				var gameViable = true;
				var gameByReference = line.Split(':');
				var gameId = int.Parse(gameByReference[0].Replace("Game ", ""));
				var gameSets = gameByReference[1].Split(";");
				foreach (var gameSet in gameSets)
				{
					var colourTotals = gameSet.Split(",").Select(s => new { k = s.Trim().Split(" ")[1].ToString(), v = int.Parse(s.Trim().Split(" ")[0]) }).ToDictionary(k => k.k, v => v.v);
					foreach (var bagTotal in _bagTotals)
					{
						colourTotals.TryGetValue(bagTotal.Key, out int count);
						if (count > bagTotal.Value)
						{
							gameViable = false;
							//Console.WriteLine($"Game {gameId} not viable. There are {bagTotal.Value} {bagTotal.Key} cubes in the bag but you are trying to take out {count} {bagTotal.Key} cubes.");
						}
					}
				}
				if (gameViable)
				{
					sumOfViableGameIds += gameId;
				}
			}
			return sumOfViableGameIds;
		}
		public override int? Q2()
		{
			var sumOfPowers = 0;
			foreach (var line in _input)
			{
				var power = 0;
				var gameByReference = line.Split(':');
				var gameId = int.Parse(gameByReference[0].Replace("Game ", ""));
				var gameSets = gameByReference[1].Split(";");
				Dictionary<string, int> minimumBag = new Dictionary<string, int>
				{
					{ "red", 0 },
					{ "green", 0 },
					{ "blue", 0 },
				};
				foreach (var gameSet in gameSets)
				{
					var colourTotals = gameSet.Split(",").Select(s => new { k = s.Trim().Split(" ")[1].ToString(), v = int.Parse(s.Trim().Split(" ")[0]) }).ToDictionary(k => k.k, v => v.v);
					foreach (var colourTotal in colourTotals)
					{
						minimumBag.TryGetValue(colourTotal.Key, out int countInBag);
						if (colourTotal.Value > countInBag)
						{
							minimumBag[colourTotal.Key] = colourTotal.Value;
						}
					}
				}
				power = minimumBag["red"] * minimumBag["green"] * minimumBag["blue"];
				sumOfPowers += power;
			}
			return sumOfPowers;
		}
	}
}
