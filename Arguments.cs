using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Raffle
{
	class Arguments
	{
		public static Dictionary<string, string> Parse(string[] args)
		{
			Dictionary<string, string> dict = new Dictionary<string, string>();
			foreach (string str in args)
			{
				string[] pair = KeyPair(str);
				dict.Add(pair[0], pair[1]);
			}
			return dict;
		}

		static string[] KeyPair(string arg)
		{
			string pattern = @"([a-z]+)=([a-z0-9]+)";
			//string input = "subluck=2";
			string input = arg;
			Match match = Regex.Match(input, pattern);
			if (match.Success)
			{
				if (match.Groups.Count == 3)
				{
					string key = match.Groups[1].Value;
					string value = match.Groups[2].Value;
					return new string[] { key, value };
				} else {
					throw new System.ArgumentException("Match detected but wrong number of captures returned");
				}
			}
			else
			{
				throw new System.ArgumentException("Invalid argument: no match found");
			}
		}
	}
}