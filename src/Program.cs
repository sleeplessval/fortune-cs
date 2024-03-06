using System;
using System.IO;
using System.Security.Cryptography;

var resourcePath = "/usr/share/fortune-cs/";
if(!Directory.Exists(resourcePath)) {
	Console.WriteLine("fortune-cs: directory '/usr/share/fortune-cs/' does not exist");
	return 1;
}

var files = Directory.GetFiles(resourcePath, "*.txt");

var prng = RandomNumberGenerator.Create();

var file = files[RandomNumberGenerator.GetInt32(files.Length)];
var lines = File.ReadAllLines(file);
var line = lines[RandomNumberGenerator.GetInt32(lines.Length)];

prng.Dispose();

Console.WriteLine(line);

return 0;

