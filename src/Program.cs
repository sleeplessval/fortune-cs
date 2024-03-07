using System;
using System.IO;
using System.Security.Cryptography;

//	get resource path from var or default
string resourcePath = Environment.GetEnvironmentVariable("FORTUNE_CS_DIR");
if(resourcePath == "" || !Directory.Exists(resourcePath))
	resourcePath = "/usr/share/fortune-cs/";

//	pull file arg if 1 argument is provided
string file = null;
if(args.Length == 1) {
	file = args[0];
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
//	run merge if more than 1 argument is provided
else if(args.Length > 0) {
	Utilities.Merge(args);
	return 0;
}

//	make sure fortune directory exists
if(!Directory.Exists(resourcePath)) {
	Console.WriteLine("fortune-cs: directory '/usr/share/fortune-cs/' does not exist");
	return 1;
}

//	pull file list
var files = Directory.GetFiles(resourcePath, "*.txt");

//	choose file if no arg provided
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

