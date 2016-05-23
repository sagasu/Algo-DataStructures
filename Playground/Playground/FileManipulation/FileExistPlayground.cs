using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Playground.FileManipulation
{
    [TestFixture]
    public class FileExistPlayground
    {
        [Test]
        public void FileExist() {
            Assert.True(File.Exists(@"F:\worek2\github\playground\README.md"));
        }

        [Test]
        public void FileExist2()
        {
            var uri = new UriBuilder(@"file:///F:\worek2\github\playground\README.md");
            var path = uri.Path;
            Assert.True(File.Exists(path));
        }
    }
}
