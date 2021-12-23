using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWiseAssessment
{
    public class Record
    {
        public string Name { get; set; }
        public int? Age { get; set; }
        
        public string City { get; set; }
        public string State { get; set; }
        public bool IsStudent { get; set; }
        public bool IsFemale { get; set; }
        public bool IsEmployee { get; set; }

        public override string ToString()
        {
            string printedString = Name + "[";

            if(Age != null)
            {
                printedString += Age + ", ";
            }

            if(IsFemale)
            {
                printedString += "Female]\n";
            }
            else
            {
                printedString += "Male]\n";
            }

            printedString += "City : " + City + "\n";
            
            if(State != null)
            {
                printedString += "State : " + State + "\n"; 
            }
            else
            {
                printedString += "State : N/A\n";
            }

            if(IsStudent)
            {
                printedString += "Student : Yes\n";
            }
            else
            {
                printedString += "Student : No\n";
            }

            if(IsEmployee)
            {
                printedString += "Employee : Yes\n";
            }
            else
            {
                printedString += "Employee : No\n";
            }

            return printedString;
        }
    }
}
