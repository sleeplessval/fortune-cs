using System;
using System.IO;
using System.Security.Cryptography;

//	handle help and version flags
if(Utilities.HasFlags(args, "-h", "--help")) {
	Usage.HelpText();
	return 0;
}
if(Utilities.HasFlags(args, "-v", "--version")) {
	Usage.VersionText();
	return 0;
}

//	make sure fortune directory exists
var resourcePath = Globals.DEFAULT_PATH;
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

//	choose a file and line
var file = files[RandomNumberGenerator.GetInt32(files.Length)];
var lines = File.ReadAllLines(file);
var line = lines[RandomNumberGenerator.GetInt32(lines.Length)];

//	process escape codes
line = line.Replace("\\n", "\n");

//	write
Console.WriteLine(line);

return 0;

