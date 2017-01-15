using System;
using System.Collections.Generic;

namespace Raffle
{
	class Raffle
	{
		private static readonly Random random = new Random();

		static string _path;
		public string path
		{
			get { return _path; }
			set { _path = value; }
		}

		static string _plebsPath;
		public string plebsPath
		{
			get { return _plebsPath; }
			set { _plebsPath = value; }
		}

		static string _subsPath;
		public string subsPath
		{
			get { return _subsPath; }
			set { _subsPath = value; }
		}

		static List<string> _subs;
		public List<string> subs
		{
			get { return _subs; }
			set { _subs = value; }
		}

		static List<string> _plebs;
		public List<string> plebs
		{
			get { return _plebs; }
			set { _plebs = value; }
		}

		public int _subLuck;
		public int subLuck
		{
			get { return _subLuck; }
			set { _subLuck = value; }
		}
		public int _numWinners;
		public int numWinners
		{
			get { return (_numWinners<=numEntrants) ? _numWinners : numEntrants; }
			set { _numWinners = value; }
		}
		public int numSubs
		{
			get { return subs.Count; }
		}
		public int numPlebs
		{
			get { return plebs.Count; }
		}
		public int numEntrants
		{
			get { return numPlebs + numSubs; }
		}
		public int numEntries
		{
			get { return numPlebs + numSubEntries; }
		}
		public int numSubEntries
		{
			get { return (1 + subLuck) * numSubs; }
		}
		static List<string> winners = new List<string>();

		public List<string> DrawWinners(int numWinners)
		{
			for (int inc = 0; inc < numWinners; inc++)
			{
				int n = random.Next(0, numEntries);
				if (n < (1 + subLuck) * numSubs)
				{
					//pick a sub
					int i = random.Next(0, numSubs - 1);
					winners.Add(_subs[i]);
					_subs.RemoveAt(i);
				} else {
					//pick a pleb
					int i = random.Next(0, numPlebs - 1);
					winners.Add(_plebs[i]);
					_plebs.RemoveAt(i);
				}
			}
			return winners;
		}
	}

	class Entry
	{
		public static void Main(string[] args)
		{
			if (args.Length > 0)
			{
				Raffle raffle = new Raffle();
				Dictionary<string, string> dict = Arguments.Parse(args);
				if (dict.ContainsKey("plebs"))
				{
					raffle.plebsPath = dict["plebs"].ToString() ;
				} else {
					raffle.plebsPath = "plebs.txt";
				}
				if (dict.ContainsKey("subs"))
				{
					raffle.subsPath = dict["subs"].ToString();
				} else {
					raffle.subsPath = "subs.txt";
				}
				if (dict.ContainsKey("subluck"))
				{
					//Console.WriteLine(dict["subluck"]);
					bool parsed = Int32.TryParse(dict["subluck"], out raffle._subLuck);
				} else {
					throw new ArgumentNullException("raffle.subLuck", "No subluck argument supplied");
				}
				if (dict.ContainsKey("winners"))
				{
					bool parsed = Int32.TryParse(dict["winners"], out raffle._numWinners);
				} else {
					throw new ArgumentNullException("raffle.numWinners", "No winners argument supplied");
				}
				//raffle.path = @"C:\Users\Public\Documents\";
				raffle.path = @"";
				try
				{
					raffle.subs = ReadFromFile.ReadLines(raffle.path + raffle.subsPath);
					raffle.plebs = ReadFromFile.ReadLines(raffle.path + raffle.plebsPath);
				}
				catch (System.IO.FileNotFoundException)
				{
					Console.WriteLine("Failed to find one of the input files, ensure the subs and plebs paramemters are correct and try again.");
				}
				List<string> winners = raffle.DrawWinners(raffle.numWinners);
				Console.WriteLine("Winners:");
				ReadFromFile.WriteLines(winners);
			} else {
				System.Console.WriteLine("Usage: raffle [param1=value1] [param2=value2] ...");
				System.Console.WriteLine("Params: int subluck, int winners, string subs, string plebs.");
				System.Console.WriteLine("Subluck of 0 makes subs equally likely to win, 1 makes them twice as likely.");
				System.Console.WriteLine("Subs and plebs should point to text files containing names on separate lines, default is plebs.txt and subs.txt.");
			}
		}
	}
}