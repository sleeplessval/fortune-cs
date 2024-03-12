using System;
using System.IO;
using System.Security.Cryptography;

//	handle help flag
if(Utilities.HasFlags(args, "-h", "--help")) {
	Usage.HelpText();
	return 0;
}

//	handle version flag
if(Utilities.HasFlags(args, "-v", "--version")) {
	Usage.VersionText();
	return 0;
}

//	collect nonflag args for merge or file selection
var arguments = Utilities.CollectArgs(args);

//	handle merge flag
if(Utilities.HasFlags(args, "-m", "--merge")) {
	Utilities.Merge(arguments);
	return 0;
}

//	get resource path from var or default
string resourcePath = Environment.GetEnvironmentVariable("FORTUNE_CS_DIR");
if(resourcePath == "" || !Directory.Exists(resourcePath))
	resourcePath = Globals.DEFAULT_PATH;

//	pull file arg if provided
string file = null;
if(arguments.Count == 1) {
	file = arguments[0];
	//	if the file doens't exist, see if it's in `resourcePath`
	if(!File.Exists(file)) {
		if(!file.EndsWith(".txt"))
			file = file + ".txt";
		file = resourcePath + file;
		if(!File.Exists(file)) {
			//	don't try to read a file that doesn't exist
			Console.WriteLine($"fortune-cs: no file '{file}' found.");
			return 2;
		}
	}
}

//	make sure fortune directory exists
if(!Directory.Exists(resourcePath)) {
	Console.WriteLine($"fortune-cs: directory '${resourcePath}' does not exist");
	return 1;
}

//	pull file list
var files = Directory.GetFiles(resourcePath, "*.txt");

//	handle list flag
if(Utilities.HasFlags(args, "-l", "--list")) {
	Usage.ListText(files);
	return 0;
}

//	choose file if not provided
if(file == null)
	file = files[RandomNumberGenerator.GetInt32(files.Length)];
//	read the file and choose a line
var lines = File.ReadAllLines(file);
var line = lines[RandomNumberGenerator.GetInt32(lines.Length)];

//	process line breaks
line = line.Replace("\\n", "\n");

//	write the fortune
Console.WriteLine(line);

return 0;

