using System;
using System.Collections.Generic;
using System.IO;

public static class Utilities {


	///	<summary>
	///		Checks if a given flag is set in `args`.
	///	</summary>
	public static bool HasFlags(string[] args, params string[] flags) {
		foreach(string flag in flags)
			//	using `Array.IndexOf` since including Linq for `array.Contains` increases binary size
			if(Array.IndexOf(args, flag) != -1)
				return true;
		return false;
	}

	public static void Merge(params string[] files) {
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

