using System.Collections.Generic;

namespace Common
{
    public class WriterWrapper
    {
        public static void WriteLinesToFile(IEnumerable<string> lines)
        {
            using (var file = new System.IO.StreamWriter("WriteLines2.txt"))
            {
                foreach (string line in lines)
                {
                    // If the line doesn't contain the word 'Second', write the line to the file.
                    if (!line.Contains("Second"))
                    {
                        file.WriteLine(line);
                    }
                }
            } // file is disposed here
        }
    }
}
