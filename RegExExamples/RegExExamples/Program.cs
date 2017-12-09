using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegExExamples
{
    class Program
    {
        

        static void Main(string[] args)
        {
            string example1 = @"bla-bla 050-555-77-22, 067-123-43-34";
            Regex regex = new Regex("\\d{3}-\\d{3}-\\d{2}-\\d{2}");
            var matches = regex.Matches(example1);
            var groups = regex.GetGroupNames();

            string example2 = "абсолютная хрень. Абсолютно без всякого смысла. Бла-блаабс";
            matches = Regex.Matches(example2, "абс");
            matches = Regex.Matches(example2, "(А|а)бс");
            matches = Regex.Matches(example2, "\\S*абс");
            matches = Regex.Matches(example2, "абс\\S*");
            matches = Regex.Matches(example2, "\\b(А|а)бс\\S*");

            string example3 =
@"<p><b>Википедия</b> — свободная энциклопедия, в которой <i>каждый</i> может изменить или дополнить любую статью</p>";
            matches = Regex.Matches(example3, "<.*>"); // жадный
            matches = Regex.Matches(example3, "<.*?>"); // Не жадный

            string example4 = "To beer or not to bear";
            matches = Regex.Matches(example4, "b(ee|ea)r");

            string example5 = "quartal quota qwerty query";
            matches = Regex.Matches(example5, @"[^\s]*q(?=werty)[^\s]*");

            string pattern = @"(\b(\w+?)[,:;]?\s?)+[?.!]";
            string input = "This is one sentence. This is a second sentence.";

            Match match = Regex.Match(input, pattern);
            Console.WriteLine("Match: " + match.Value);
            int groupCtr = 0;
            foreach (Group group in match.Groups)
            {
                groupCtr++;
                Console.WriteLine("   Group {0}: '{1}'", groupCtr, group.Value);
                int captureCtr = 0;
                foreach (Capture capture in group.Captures)
                {
                    captureCtr++;
                    Console.WriteLine("      Capture {0}: '{1}'", captureCtr, capture.Value);
                }
            }
        }
    }
}
