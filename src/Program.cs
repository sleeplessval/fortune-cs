using System;
using System.IO;
using System.Security.Cryptography;

//	use merge function if given multiple arguments
if(args.Length > 0) {
	Utilities.Merge(args);
	return 0;
}

//	make sure fortune directory exists
var resourcePath = "/usr/share/fortune-cs/";
if(!Directory.Exists(resourcePath)) {
	Console.WriteLine("fortune-cs: directory '/usr/share/fortune-cs/' does not exist");
	return 1;
}

//	pull file list
var files = Directory.GetFiles(resourcePath, "*.txt");

//	choose a file and line
var file = files[RandomNumberGenerator.GetInt32(files.Length)];
var lines = File.ReadAllLines(file);
var line = lines[RandomNumberGenerator.GetInt32(lines.Length)];

//	process escape codes
line = line.Replace("\\n", "\n");

//	write
Console.WriteLine(line);

return 0;

