using System;
using System.IO;

namespace ConnectWiseAssessment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string AllText = File.ReadAllText(Environment.CurrentDirectory + "/" + "SampleInputFile.txt");

            RecordParser parser = new RecordParser();

            foreach(Record record in parser.GetRecords(AllText))
            {
                Console.WriteLine(record.ToString());
            }

            Console.ReadLine();
        }
    }
}
