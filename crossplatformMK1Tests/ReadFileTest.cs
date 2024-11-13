using crossplatformMK1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crossplatformMK1Tests
{
    public class ReadFileTests
    {
        private ReadFile GeInstance(string file_name)
        {
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string read_path = Path.Combine(projectDirectory, file_name);
            var read_file = new ReadFile(read_path);
            return read_file;
        }
        [Fact]
        public void Lab1_ReadFile_ReturnWordsMazeCount()
        {
            ReadFile read_file = GeInstance("input.txt");
            read_file.Read();
            int expected = 5;
            Assert.Equal(read_file.Words_maze_count, expected);
        }

        [Fact]
        public void Lab1_ReadFile_ReturnKnownWordsCount()
        {
            ReadFile read_file = GeInstance("input.txt");
            read_file.Read();
            int expected = 3;
            Assert.Equal(read_file.Words_find_count, expected);
        }

        public static IEnumerable<object[]> GetWordsMaze()
        {
            yield return new object[] { "input.txt", new List<string>() { "POLTE", "RWYMS", "OAIPT", "BDANR", "LEMES" } };
            yield return new object[] { "input_2.txt", new List<string>() { "ISQ", "ABC", "IQW" } };
        }

        [Theory]
        [MemberData(nameof(GetWordsMaze))]
        public void Lab1_ReadFile_ReturnWordMaze(string file_path, List<string> expected)
        {
            ReadFile read_file = GeInstance(file_path);
            read_file.Read();
            Assert.Equal(read_file.Maze_words, expected);
        }

        public static IEnumerable<object[]> GetWordsToFind()
        {
            yield return new object[] { "input.txt", new List<string>() { "OLYMPIAD", "PROBLEM", "TEST" } };
            yield return new object[] { "input_2.txt", new List<string>() { "I", "IS" } };
        }

        [Theory]
        [MemberData(nameof(GetWordsToFind))]
        public void Lab1_ReadFile_ReturnKnownListOfWords(string file, List<string> expected)
        {
            ReadFile read_file = GeInstance(file);
            read_file.Read();
            Assert.Equal(read_file.Known_words, expected);
        }
        [Fact]
        public void Lab1_ReadFile_ReturnFileNotFoundExeption()
        {
            ReadFile read_file = GeInstance("input_1.txt");
            var excpected = new FieldAccessException().Message;
            try
            {
                read_file.Read();
            }
            catch (Exception ex)
            {
                Assert.IsType<FileNotFoundException>(ex);
                Assert.Equal(ex.Message, excpected);
            }
        }
    }
}
