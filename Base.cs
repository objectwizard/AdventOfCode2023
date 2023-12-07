using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
	public class Base
	{
		public string[] _input = new string[0];
		public void Run()
		{
			var className = this.GetType().Name;
			if (_input.Length == 0)
			{	
				Console.WriteLine($"{className}: Please update Inputs/{className}.txt with the day's input");
				return;
			}
			var q1answer = Q1();
			if (q1answer != null)
			{
				Console.WriteLine($"{className}: Answer = {q1answer}");
			}
			var q2answer = Q2();
			if (q2answer != null)
			{
				Console.WriteLine($"{className}: Answer = {q2answer}");
			}
		}
		public virtual int? Q1(){
			return null;
		}
		public virtual int? Q2(){
			return null;
		}
	}
}
