using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.Codility.MyExam
{
    [TestClass]
    public class MyExam
    {
        [TestMethod]
        public void Test()
        {
            var s = @"
UserName:admin;
Password:""super%^&*333password;
DNSName:SomeName;

TimeToLive:4;
ClusterSize:2;
PortNumber:2222;

IsEnabled:true;
EnsureTransaction:false;
PersistentStorage:false;
                ";
            var dyn = Parse(s);
            Console.WriteLine(dyn.TimeToLive);
            //Console.WriteLine(dyn.Foo);
        }

        //support for different operating systems
        private readonly string[] _validEndLineSeparators = new[] {"\r\n", "\r", "\n"};
        private const string ValidKeyPattern = @"^[a-zA-Z][a-zA-Z0-9]*$";

        public dynamic Parse(string configuration)
        {

            if (string.IsNullOrEmpty(configuration))
                throw new ArgumentException("Configuration can't be empty.");

            var lines = configuration.Split(
                _validEndLineSeparators, 
                StringSplitOptions.None
            );

            var parsedConfig = new Dictionary<string,dynamic>();

            foreach (var line in lines)
            {
                var configLine = line.Trim();
                if(string.IsNullOrEmpty(configLine)) 
                    continue;

                var keyValuePair = configLine.Split(':');

                ValidateConfigLine(keyValuePair, configLine);

                BuildParsedConfig(keyValuePair, parsedConfig, line);
            }

            return ToObject(parsedConfig);
        }

        private static void ValidateConfigLine(string[] keyValuePair, string configLine)
        {
            if (keyValuePair.Length != 2)
            {
                if (configLine.Trim().StartsWith(':'))
                    throw new EmptyKeyException();

                throw new ArgumentException();
            }
        }

        private static void BuildParsedConfig(string[] keyValuePair, Dictionary<string, dynamic> parsedConfig, string line)
        {
            var key = keyValuePair[0].Trim();
            var value = keyValuePair[1].Trim();

            ValidateKeyValuePairs(parsedConfig, line, key, value);

            value = value.Remove(value.Length - 1);
            int parsedInt;
            bool parsedBool;
            if (int.TryParse(value, out parsedInt))
            {
                parsedConfig.Add(key, parsedInt);
            }
            else if (bool.TryParse(value, out parsedBool))
            {
                parsedConfig.Add(key, parsedBool);
            }
            else
            {
                parsedConfig.Add(key, value);
            }
        }

        private static void ValidateKeyValuePairs(Dictionary<string, dynamic> parsedConfig, string line, string key, string value)
        {
            if (parsedConfig.ContainsKey(key))
            {
                throw new DuplicatedKeyException();
            }

            if (value.LastIndexOf(';') != value.Length - 1)
            {
                throw new ArgumentException($"Each config line should end with a semicolon. Following line doesn't {line}");
            }

            if(string.IsNullOrEmpty(key))
                throw new EmptyKeyException();

            if (!Regex.IsMatch(key, ValidKeyPattern))
                throw new InvalidKeyException();
            
        }

        public dynamic ToObject(Dictionary<string, dynamic> parsedConfig)
        {
            var eo = new ExpandoObject();
            var eoColl = (ICollection<KeyValuePair<string, object>>)eo;

            foreach (var kvp in parsedConfig)
            {
                eoColl.Add(kvp);
            }

            return eo;
        }

    }

    public class InvalidKeyException : Exception
    {
        public InvalidKeyException() : base() { }
    }

    public class DuplicatedKeyException : Exception
    {
        public DuplicatedKeyException() : base() { }
    }

    public class EmptyKeyException : Exception
    {
        public EmptyKeyException() : base(){}
    }
}
