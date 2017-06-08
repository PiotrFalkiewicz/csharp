using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C://Users//Kasia//Documents//visual studio 2015//Projects//ConsoleApplication2//ConsoleApplication2//folder";
            string[] files = Directory.GetFiles(@path);
            Parallel.ForEach(files, file =>
            {

                using (StreamReader reader = File.OpenText(file))
                {
                    int count = 0;

                    while (!reader.EndOfStream)
                    {
                        String line = reader.ReadToEnd();
                        count = line.Count(c => c == 'a');
                        WriteLine(file+" "+Thread.CurrentThread.GetHashCode() + " " + count + "");
                    }
                }
            });
            ReadLine();
        }
    }
}
