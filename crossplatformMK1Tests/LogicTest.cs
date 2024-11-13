using crossplatformMK1;

namespace crossplatformMK1Tests
{
    public class LogicTest
    { 
        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] { "input.txt", new List<char>() { 'A', 'E', 'N', 'R', 'S', 'W' } };
            yield return new object[] { "input_2.txt", new List<char> { 'A', 'B', 'C', 'Q', 'Q', 'W' } };
        }
        [Theory]
        [MemberData(nameof(GetData))]
        public void Lab1_Logic_ReturnResult(string file_path, List<char> expected)
        {
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string read_path = Path.Combine(projectDirectory, file_path);
            var read_file = new ReadFile(read_path);
            read_file.Read();
            var maze = new Maze(read_file);
            maze.CreateMaze();
            var logic = new Logic(maze, read_file.Known_words);
            Assert.Equal(logic.GetResult(0, 0, 0), expected);
        }
    }
}