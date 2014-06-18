using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Playground.PDMS
{
    [TestFixture]
    class Migrate
    {
        public const string idRegex = @"id: \{" + guidRegex + @"\}";

        public const string parentRegex = @"parent: \{" + guidRegex + @"\}";
        public const string pathLineStartingMath = "path: /sitecore/content/";

        public const string guidRegex = @"[0-9|A-F|-]{36}";

        public StringDictionary GuidMap = new StringDictionary();

        public const string ttPathPrefix = "Trafalgar/";
        public const string ivPathPrefix = "Insight/";

        /// <summary>
        /// Modify existing file by changing ID of item to a totally new one.
        /// If modified ID is referenced as a parent ID be sure to update it also.
        /// Modify item path to include brand item.
        /// </summary>
        /// <remarks>Created to migrate item tree structures from two different sitecore instanced into a new one.
        ///          These sitecore instances might have same ID's somewhere, so create a new ID instead of using original ones.
        /// </remarks>
        [Test]
        public void ParseFiles()
        {
            var filePaths = GetFilesInDirecotryRecursive().ToList();
            foreach (var filePath in filePaths)
            {
                var lines = File.ReadLines(filePath).ToList();

                for(int i=0;i < lines.Count; i ++)
                {
                    var line = lines[i];
                    Console.WriteLine(line);

                    // Parse ID
                    if (Regex.IsMatch(line, idRegex))
                    {
                        var idGuid = Regex.Match(line, guidRegex).Value;

                        var newIdGuid = Guid.NewGuid().ToString().ToUpper();

                        GuidMap.Add(idGuid, newIdGuid);
                        lines[i] = line.Replace(idGuid, newIdGuid);
                    } // parse parent ID
                    else if (Regex.IsMatch(line, parentRegex))
                    {
                        var parentGuid = Regex.Match(line, guidRegex).Value;

                        if (GuidMap.ContainsKey(parentGuid))
                        {
                            var newGuid = GuidMap[parentGuid];
                            lines[i] = line.Replace(parentGuid, newGuid);
                        }
                    } // parse item Path
                    else if (line.StartsWith(pathLineStartingMath))
                    {
                        lines[i] = line.Replace(pathLineStartingMath, pathLineStartingMath + ttPathPrefix);
                    }
                    Console.WriteLine(lines[i]);

                }

                // Overwrite existing file with updated data.
                File.WriteAllText(filePath, string.Join("\n", lines));
            }
        }

        /// <summary>
        /// In width iteration.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetFilesInDirecotryRecursive()
        {
            const string path = @"C:\worek\serialization";
            return Directory.EnumerateFiles(
                path, "*.*", SearchOption.AllDirectories);
        }
    }
}
