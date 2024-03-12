using System;
using System.IO;

public static class Globals {
	public const string VERSION = "0.1.0";
	public const string DEFAULT_PATH = "/usr/share/fortune-cs/";
}

public static class Usage {

	public static void HelpText() {
		VersionText();
		Console.WriteLine(@"Valerie Wolfe <sleeplessval@gmail.com>
Shows quotes from a set of files.

usage: fortune-cs [flags] [source]

args:
   [file]                 Manual file selection

flags:
   -h, --help             Shows this help text
   -v, --version          Shows version information
   -l, --list             List files in the fortune directory
   -m, --merge [files...] Output all distinct lines from a set of files");
	}

	public static void ListText(string[] files) {
		foreach(var file in files) {
			var fileName = Path.GetFileNameWithoutExtension(file);
			Console.WriteLine(fileName);
		}
	}

	public static void VersionText() {
		Console.WriteLine("fortune-cs v" + Globals.VERSION);
	}

}

