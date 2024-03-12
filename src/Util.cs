using System;
using System.Collections.Generic;
using System.IO;

public static class Utilities {

	///	<summary>
	///		returns a `List` of all non-flag arguments
	///	</summary>
	public static List<string> CollectArgs(string[] args) {
		var output = new List<string>();
		foreach(string arg in args)
			if(!arg.StartsWith("-"))
				output.Add(arg);
		return output;
	}

	///	<summary>
	///		checks if a given flag is set in `args`
	///	</summary>
	public static bool HasFlags(string[] args, params string[] flags) {
		foreach(string flag in flags)
			//	using `Array.IndexOf` since including Linq for `array.Contains` increases binary size
			if(Array.IndexOf(args, flag) != -1)
				return true;
		return false;
	}

	///	<summary>
	///		outputs all unique lines from all files in `args` to stdout
	///	</summary>
	public static void Merge(string[] args) {
		var files = CollectArgs(args);
		//	hashset to prevent duplicates
		var members = new HashSet<string>();
		//	iterate over all paths given
		foreach(var file in files) {
			//	skip nonexistent files gracefully
			if(!File.Exists(file))
				continue;
			//	iterate over lines
			var lines = File.ReadAllLines(file);
			foreach(var line in lines) {
				//	prevent duplicates
				if(members.Contains(line))
					continue;
				members.Add(line);
				//	emit to stdout
				Console.WriteLine(line);
			}
		}
	}

}

