using System;

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

}

