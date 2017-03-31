using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WordCountApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //  check that file was passed
                if (args.Length == 0)
                {
                    return;
                }

                //  check that file exists
                var filePath = args[0];
                if (!File.Exists(filePath))
                {
                    return;
                }

                //  open stream
                using (var fileStream = File.OpenRead(filePath))
                using (var reader = new WordStreamReader(fileStream))
                {
                    //  read stream analyze words
                    reader.Read();

                    if (reader.MaxCharFrequencyWord != null)
                    {
                        Console.WriteLine(reader.MaxCharFrequencyWord);
                    }
                }
            }
            catch
            {  
                // ignore              
            }
        }
    }
}
