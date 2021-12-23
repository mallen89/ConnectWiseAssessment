using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWiseAssessment
{
    public class RecordParser
    {
        private string NameDelimiter = "(Name)";
        private string AgeDelimiter = "(Age)";
        private string CityDelimiter = "(City)";
        private string FlagsDelimiter = "(Flags)";

        public RecordParser()
        {

        }

        public List<Record> GetRecords(string FileLines)
        {
            List<Record> records = new List<Record>();

            foreach(List<string> RecordStrings in ParseStringIntoSeperateLists(FileLines))
            {
                Record tempRecord = ParseRecordFromString(RecordStrings);

                if(tempRecord != null)
                {
                    records.Add(tempRecord);
                }
            }

            return records;
        }

        private List<List<string>> ParseStringIntoSeperateLists(string FileLines)
        {
            List<List<string>> parsedStringsIntoSeperateLists = new List<List<string>>();
            List<string> parsedStringIntoRecord = new List<string>();

            List<string> AllLines = FileLines.Split(new string[] { "\n" }, StringSplitOptions.None).ToList();
            AllLines.Add("\r");

            foreach(string line in AllLines)
            {
                if(!line.Equals("\r"))
                {
                    parsedStringIntoRecord.Add(line.Replace("\r", ""));
                }
                else
                {
                    if (parsedStringIntoRecord.Count >= 3)
                    {
                        parsedStringsIntoSeperateLists.Add(parsedStringIntoRecord);
                        parsedStringIntoRecord = new List<string>();
                    }
                }
            }

            return parsedStringsIntoSeperateLists;
        }

        private Record ParseRecordFromString(List<string> LinesOfARecord)
        {
            Record record = new Record();

            foreach (string line in LinesOfARecord)
            {
                if(line.Contains(NameDelimiter))
                {
                    try
                    {
                        record.Name = line.Split(new string[] { NameDelimiter }, StringSplitOptions.None)[1];
                    }
                    catch(Exception exception)
                    {
                        Console.WriteLine("Invalid data, unable to process.");
                        record = null;
                        break;
                    }
                }

                if (line.Contains(AgeDelimiter))
                {
                    try
                    {
                        record.Age = Convert.ToInt32(line.Split(new string[] { AgeDelimiter }, StringSplitOptions.None)[1]);
                    }
                    catch(Exception exception)
                    {
                        Console.WriteLine("Invalid data, unable to process.");
                        record = null;
                        break;
                    }
                }

                if (line.Contains(CityDelimiter))
                {
                    try
                    {
                        string cityString = line.Split(new string[] { CityDelimiter }, StringSplitOptions.None)[1];

                        if(cityString.Contains(','))
                        {
                            record.City = cityString.Split(',')[0];
                            record.State = cityString.Split(',')[1].Replace(" ", "");
                        }
                        else
                        {
                            record.City = cityString.Split(',')[0];
                        }
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine("Invalid data, unable to process.");
                        record = null;
                        break;
                    }
                }

                if (line.Contains(FlagsDelimiter))
                {
                    try
                    {
                        string flagString = line.Split(new string[] { FlagsDelimiter }, StringSplitOptions.None)[1];
                        record.IsFemale = (flagString.ElementAt(0) == ('Y'));
                        record.IsStudent = (flagString.ElementAt(1) == ('Y'));
                        record.IsEmployee = (flagString.ElementAt(2) == ('Y'));
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine("Invalid data, unable to process.");
                        record = null;
                        break;
                    }
                }
            }

            return record;
        }
    }
}
