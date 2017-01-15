using System;
using System.Text;
using System.Collections.Generic;

namespace Raffle
{
	class ReadFromFile
	{
		static void Example()
		{
			System.Console.WriteLine("Enter path to file:");
			//string path = @"C:\Users\Public\TestFolder\WriteLines2.txt";
			string path = ReadInput();
			WriteLine(ReadAll(path));
			WriteLines(ReadLines(path));
			// Keep the console window open in debug mode.
			//System.Console.WriteLine("Press any key to exit.");
			//System.Console.ReadKey();
		}

		public static string ReadInput()
		{
			// Read the file as one string.
			string path = System.Console.ReadLine();
			return path;
		}

		public static string ReadAll(string path)
		{
			// Read the file as one string.
			string text = System.IO.File.ReadAllText(path);
			return text;
		}

		public static void WriteLine(string text)
		{
			// Display the file contents to the console. Variable text is a string.
			System.Console.WriteLine("Contents of input = {0}", text);
		}

		public static List<string> ReadLines(string path)
		{
			// Example #2
			// Read each line of the file into a string array. Each element
			// of the array is one line of the file.
			if (System.IO.File.Exists(path))
			{
				List<string> lines = new List<string>(System.IO.File.ReadAllLines(path));
				return lines;
			} else {
				throw new ArgumentException(String.Format("Input file not found at path {0}", path), "path"); 
			}
		}

		public static void WriteLines(List<string> text)
		{
			int i = 0;
			// Display the file contents by using a foreach loop.
			//System.Console.WriteLine("Contents of input = ");
			foreach (string line in text)
			{
				i++;
				// Use a tab to indent each line of the file.
				System.Console.WriteLine("\t" + line);
			}
		}

		public static string Repeat(string value, int count)
		{
			return new StringBuilder(value.Length * count).Insert(0, value, count).ToString();
		}
	}
}