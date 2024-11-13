using crossplatformMK1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crossplatformMK1Tests
{
    public class WriteToFileTest
    {
        private string path;
        private WriteToFile writeToFile;
        public WriteToFileTest()
        {
            var baseDir = AppContext.BaseDirectory;
            this.path = Path.Combine(baseDir, "output.txt");
            writeToFile = new WriteToFile(new List<char>() { 'A', 'E', 'N', 'R', 'S', 'W' }, path);
        }

        [Fact]
        public void WriteToFileWriteCorrectPath()
        {
            writeToFile.Write();
            var srteamReader = new StreamReader(path);
            string? actual = srteamReader.ReadLine();

            string expect = "Answer: AENRSW";

            Assert.Equal(actual, expect);
        }
    }
}
