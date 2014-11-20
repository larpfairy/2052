using System;
using System.IO;
using System.Collections.Generic;

namespace IntroCS
{
	public class Document:Item
	{
		public string content { get; set;}

		public Document (int id, string Name, int Value, string Content):base(id,Name,Value)
		{
			content = Content;
		}
		public static string GetContent(string keyword)
		{
			var reader = new StreamReader ("DocumentContent.txt");
			string x;
			string y = "";
			while (!reader.EndOfStream) {
				x = reader.ReadLine ();
				if (x == keyword) {
					int i = 0;
					while (i == 0) {
						x = reader.ReadLine ();
						if (x == "~") {
							break;
						}
						y += x;
					}
					break;
				}
			}
			return y;
		}
	}
}

