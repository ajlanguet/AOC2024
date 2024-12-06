public class AocDayFour
{
    
    public static int SearchDirection(char[,] matrix, int r_val, int c_val, int r_dir, int c_dir)
    {
        char[] characters = ['A', 'S'];

        foreach(char ch in characters)
        {
            if(r_val + r_dir >= 0 && c_val + c_dir >= 0 && r_val + r_dir < matrix.GetLength(0) 
                && c_val + c_dir < matrix.GetLength(1))
            {    
                if(matrix[r_val + r_dir, c_val + c_dir] != ch)
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
            r_val += r_dir;
            c_val += c_dir;
        }
        return 1;
    }
    
    public static int SearchArea(char[,] matrix, int r_val, int c_val)
    {
        int[] search = {-1, 0, 1};
        int total = 0;

        foreach(int r_search in search)
        {
            foreach(int c_search in search)
            {
                if(r_val + r_search >= 0 && c_val + c_search >= 0 && r_val + r_search < matrix.GetLength(0) 
                && c_val + c_search < matrix.GetLength(1))
                {
                    if(matrix[r_val + r_search, c_val + c_search] == 'M')
                    {
                        int new_r_val = r_val + r_search;
                        int new_c_val = c_val + c_search;
                        total += SearchDirection(matrix, new_r_val, new_c_val, r_search, c_search);
                    }
                }
            }
        }
        return total;
    }
    public static int PartOne(string [] lines)
    {
        int rows = lines.Length;
        int cols = lines[0].Length;
        char[,] matrix = new char[rows, cols];
        int total = 0;

        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                matrix[i, j] = lines[i][j];
            }
        }   

        for (int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                
                if(matrix[i,j] == 'X')
                {
                    total += SearchArea(matrix, i, j);
                }    
            }
        }
        return total;
    }

    public static bool AroundA(char[,] matrix, int r_val, int c_val)
    {
        int[] search = {-1, 1};
        int total = 0;
       
        foreach(int r_search in search)
        {
            foreach(int c_search in search)
            {
                if(r_val + r_search >= 0 && c_val + c_search >= 0 && r_val + r_search < matrix.GetLength(0) 
                && c_val + c_search < matrix.GetLength(1))
                {
                    if(matrix[r_val + r_search, c_val + c_search] == 'M')
                    {
                        int new_r_val = r_val + r_search;
                        int new_c_val = c_val + c_search;
                        total += SearchDirection(matrix, new_r_val, new_c_val, r_search * -1, c_search * -1);
                    }
                }
            }
        }
        return total == 2;
    }
    public static int PartTwo(string [] lines)
    {
        int rows = lines.Length;
        int cols = lines[0].Length;
        char[,] matrix = new char[rows, cols];
        int total = 0;

        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                matrix[i, j] = lines[i][j];
            }
        }   

        for (int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                if(matrix[i,j] == 'A')
                {
                    if(AroundA(matrix, i, j)){
                        total += 1;
                    }
                }     
            }
        }
        return total;
    }
}