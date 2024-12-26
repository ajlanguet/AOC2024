public class AocDayTen
{
    private static HashSet<string> visited = new HashSet<string>();
    private static bool part = true;

    public static int[,] MatrixCreation(string[] lines, int rows, int cols)
    {
        int[,] matrix = new int[rows,cols];
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                matrix[i, j] = int.Parse(lines[i][j].ToString());
            }
        }
        return matrix;
    }

    public static int FindPath(int[,] matrix, int rows, int cols, int row, int col)
    {
        int paths = 0;
        //up, right, down, left
        int[][] directions = [[0,-1], [1,0], [0,1], [-1,0]];

        if(matrix[row, col] == 9 && !visited.Contains($"{row},{col}"))
        {
            if(part)
            {
                visited.Add($"{row},{col}");
            }
           
           return 1;
        }

        foreach(int[] dir in directions)
        {
           // Console.WriteLine(string.Join(", ", dir));
            if(row + dir[0] >= 0 && col + dir[1] >= 0 && row + dir[0] < rows && col + dir[1] < cols)
            {
                if(matrix[row + dir[0], col + dir[1]] == matrix[row, col] + 1)
                {
                    paths += FindPath(matrix, rows, cols, row + dir[0], col + dir[1]);
                }
            }
        }
        return paths;
    }

    public static int PartOne(string[] lines)
    {
        int rows = lines.Length;
        int cols = lines[0].Length;
        int[,] matrix = MatrixCreation(lines, rows, cols);
        int total = 0;
       
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                if(matrix[i,j] == 0)
                {
                    visited = new HashSet<string>(); // don't really need this
                    total+= FindPath(matrix, rows, cols, i, j);
                }
            }
            
        }
        return total;
    }

    public static int PartTwo(string[] lines)
    {
        part = false;
        int rows = lines.Length;
        int cols = lines[0].Length;
        int[,] matrix = MatrixCreation(lines, rows, cols);
        int total = 0;
       
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                if(matrix[i,j] == 0)
                {
                    visited = new HashSet<string>();
                    total+= FindPath(matrix, rows, cols, i, j);
                }
            }
            
        }
        return total;
    }
}