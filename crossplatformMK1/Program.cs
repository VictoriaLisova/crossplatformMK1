using crossplatformMK1;
using System;
using System.IO;
internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string read_path = Path.Combine(projectDirectory, "input.txt");
            var read_file = new ReadFile(read_path);
            read_file.Read();

            if (read_file.Words_maze_count >= 1 && read_file.Words_maze_count <= 10
                && read_file.Words_find_count >= 0 && read_file.Words_find_count <= 100)
            {
                var maze = new Maze(read_file);
                maze.CreateMaze();
                Logic logic = new Logic(maze, read_file.Known_words);

                string write_path = Path.Combine(projectDirectory, "output.txt");
                logic.ShowResult(0, 0, 0, write_path);
            }
            else
            {
                Console.WriteLine("N shoud be between 1 and 10; M should be between 0 and 100");
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
