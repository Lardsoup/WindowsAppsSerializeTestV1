using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsAppsSerializeTest
{
    public class Person
    {
        public string CprNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public Person()
        {
        }

        public Person(string cprNo, string firstName, string lastName, string address)
        {
            CprNo = cprNo;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }

        public override string ToString()
        {
            return string.Format("CprNo: {0}, FirstName: {1}, LastName: {2}, Address: {3}", CprNo, FirstName, LastName, Address);
        }
    }
}
