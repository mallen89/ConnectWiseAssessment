using System;
using System.Collections.Generic;
using ConnectWiseAssessment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConnectWiseAssessmentUnitTest
{
    [TestClass]
    public class RecordParserTests
    {
        [TestMethod]
        public void GetRecordsCorrectNumberRecordsThree()
        {
            string TestFileAllLines = "(Name)John Doe\r\n(Age)20\r\n(City)Ashtabula, OH\r\n(Flags)NYN\r\n\r\n\r\n(Name)Jane Doe\r\n(Flags)YNY\r\n(City)N Kingsville, OH\r\n\r\n(Name)Sally Jones\r\n(Age)25\r\n(City)Paris\r\n(Flags)YYY\r";

            RecordParser parserTest = new RecordParser();
            
            List<Record> GetRecordsSuccessful =  parserTest.GetRecords(TestFileAllLines);

            Assert.AreEqual(3, GetRecordsSuccessful.Count);
        }

        [TestMethod]
        public void GetRecordsCorrectNumberRecordsZero()
        {
            string TestFileAllLines = "";

            RecordParser parserTest = new RecordParser();

            List<Record> GetRecordsSuccessful = parserTest.GetRecords(TestFileAllLines);

            Assert.AreEqual(0, GetRecordsSuccessful.Count);
        }

        [TestMethod]
        public void GetRecordsCorrectNumberRecordsWithInvalidAgeFormatFirstRecord()
        {
            string TestFileAllLines = "(Name)John Doe\r\n(Age)Twenty\r\n(City)Ashtabula, OH\r\n(Flags)NYN\r\n\r\n\r\n(Name)Jane Doe\r\n(Flags)YNY\r\n(City)N Kingsville, OH\r\n\r\n(Name)Sally Jones\r\n(Age)25\r\n(City)Paris\r\n(Flags)YYY\r";

            RecordParser parserTest = new RecordParser();

            List<Record> GetRecordsSuccessful = parserTest.GetRecords(TestFileAllLines);

            Assert.AreEqual(2, GetRecordsSuccessful.Count);
        }

        [TestMethod]
        public void GetRecordsCorrectNumberRecordsWithInvalidAgeFormatFirstAndThirdRecord()
        {
            string TestFileAllLines = "(Name)John Doe\r\n(Age)Twenty\r\n(City)Ashtabula, OH\r\n(Flags)NYN\r\n\r\n\r\n(Name)Jane Doe\r\n(Flags)YNY\r\n(City)N Kingsville, OH\r\n\r\n(Name)Sally Jones\r\n(Age)TwentyFive\r\n(City)Paris\r\n(Flags)YYY\r";

            RecordParser parserTest = new RecordParser();

            List<Record> GetRecordsSuccessful = parserTest.GetRecords(TestFileAllLines);

            Assert.AreEqual(1, GetRecordsSuccessful.Count);
        }


    }
}
