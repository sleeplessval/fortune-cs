using System;
using System.Collections.Generic;
using System.IO;

public static class Utilities {

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

