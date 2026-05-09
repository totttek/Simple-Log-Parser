using System;

class LogParser
{
	const string RED = "\x1b[31m";
	const string YELLOW = "\x1b[33m";
	const string GREEN = "\x1b[32m";
	const string RESET = "\x1b[0m";
	static int Main(string[] args)
	{
		if (args.Length == 0)
		{
			Console.WriteLine($"{RED}No Path Provided!!!{RESET}");
			return (1); // Argument Error
		}

		string path = args[0];

		if (!File.Exists(path))
		{
			Console.WriteLine($"{RED}Invalid Path!!!{RESET}");
			return (1); // Argument Error
		}

		List<string> logErrors = new List<string>();
		List<string> logWarnings = new List<string>();
		int totalLines = 0;

		foreach (string line in File.ReadLines(path))
		{
			totalLines++;
			string lower = line.ToLower();
			if (lower.Contains("error:") || lower.Contains("[error]"))
				logErrors.Add($"line {totalLines}: {line}");
			if (lower.Contains("warning:") || lower.Contains("[warning]"))
				logWarnings.Add($"line {totalLines}: {line}");
		}

		string directory = Path.GetDirectoryName(path) ?? ".";
		File.WriteAllLines(Path.Combine(directory,"errors.txt"), logErrors);
		File.WriteAllLines(Path.Combine(directory,"warnings.txt"), logWarnings);

		Console.WriteLine($"{GREEN}Logs Parsed succesfully!\nTotal lines: {totalLines} {RESET}");
		Console.WriteLine($"{RED}Errors Found: {logErrors.Count()} {RESET}");
		Console.WriteLine($"{YELLOW}Warnings Found: {logWarnings.Count()} {RESET}");

		if (logErrors.Count() > 0) return 2; // Errors detected
		if (logWarnings.Count() > 0) return 3; // Warnings deteced

		return (0);
	}
}
