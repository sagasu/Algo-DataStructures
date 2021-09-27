using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Unique_Email_Addresses
{
    class Unique_Email_Addresses
    {
        public int NumUniqueEmails(string[] emails)
        {
            var emailSet = new HashSet<string>();

            foreach (var email in emails)
            {
                var locAndDom = email.Split('@');
                locAndDom[0] = locAndDom[0].Split('+')[0];                  
                locAndDom[0] = locAndDom[0].Replace(".", "");               
                emailSet.Add(String.Concat(locAndDom[0] + "@", locAndDom[1]));
            }

            return emailSet.Count;
        }
    }
}
