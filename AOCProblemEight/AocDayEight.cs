using System.Runtime.InteropServices.Marshalling;
using System.Runtime.Intrinsics.X86;

public class AocDayEight
{
    public static int PartOne(string[] lines)
    {
        int rows = lines.Length;
        int cols = lines[0].Length;
        char[,] matrix = new char[rows, cols];
        Dictionary<char,List<int[]>> ant = new Dictionary<char, List<int[]>>();
        HashSet<string> count = new HashSet<string>();
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                matrix[i, j] = lines[i][j];
            }
        }   
    
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                if(matrix[i, j] != '.')
                {
                    if(ant.ContainsKey(matrix[i, j]))
                    {
                        ant[matrix[i, j]].Add([i, j]);
                    }
                    else
                    {
                        List<int[]> temp = new List<int[]>();
                        int[] arr = [i, j]; 
                        temp.Add(arr);
                        ant.Add(matrix[i, j], temp);
                    }
                }
            }
        }

        foreach(KeyValuePair<char, List<int[]>> kvp in ant)
        {
            for(int x = 0; x < kvp.Value.Count; x++)
            {
                for(int y = x + 1; y < kvp.Value.Count; y++)
                {
                    int[] first = kvp.Value[x];
                    int[] second = kvp.Value[y];
                    int[] temp = [first[0] - second[0], first[1] - second[1]];
                    int[] first_out = [first[0] + temp[0], first[1] + temp[1]];
                    int[] second_out = [second[0] - temp[0], second[1] - temp[1]];

                    if(!count.Contains(first_out[0].ToString() + ", " +first_out[1].ToString()) && first_out[0] < rows && first_out[1] < cols && first_out[0] >= 0 && first_out[1] >= 0)
                    {
                        count.Add(first_out[0].ToString() + ", " + first_out[1].ToString());
                    }

                    if(!count.Contains(second_out[0].ToString() +  ", " + second_out[1].ToString()) && second_out[0] < rows && second_out[1] < cols && second_out[0] >= 0 && second_out[1] >= 0)
                    {
                        count.Add(second_out[0].ToString() + ", " + second_out[1].ToString());
                    }
                }
            }
        }

        return count.Count;

    }

    public static int PartTwo(string[] lines)
    {
        int rows = lines.Length;
        int cols = lines[0].Length;
        char[,] matrix = new char[rows, cols];
        Dictionary<char,List<int[]>> ant = new Dictionary<char, List<int[]>>();
        HashSet<string> count = new HashSet<string>();
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                matrix[i, j] = lines[i][j];
            }
        }   
    
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                if(matrix[i, j] != '.')
                {
                    if(ant.ContainsKey(matrix[i, j]))
                    {
                        ant[matrix[i, j]].Add([i, j]);
                    }
                    else
                    {
                        List<int[]> temp = new List<int[]>();
                        int[] arr = [i, j]; 
                        temp.Add(arr);
                        ant.Add(matrix[i, j], temp);
                    }
                }
            }
        }

        foreach(KeyValuePair<char, List<int[]>> kvp in ant)
        {
            for(int x = 0; x < kvp.Value.Count; x++)
            {
                for(int y = x + 1; y < kvp.Value.Count; y++)
                {
                    int[] first = kvp.Value[x];
                    int[] second = kvp.Value[y];
                    int[] temp = [first[0] - second[0], first[1] - second[1]];
                    int[] first_out = [first[0],first[1]];
                    int[] second_out = [second[0],second[1]];

                    while(first_out[0] < rows && first_out[1] < cols && first_out[0] >= 0 && first_out[1] >= 0)
                    {
                        count.Add(first_out[0].ToString() + ", " + first_out[1].ToString());
                        first_out = [first_out[0] + temp[0], first_out[1] + temp[1]];
                    }

                    while(second_out[0] < rows && second_out[1] < cols && second_out[0] >= 0 && second_out[1] >= 0)
                    {
                        count.Add(second_out[0].ToString() + ", " + second_out[1].ToString());
                        second_out = [second_out[0] - temp[0], second_out[1] - temp[1]];
                    }
                }
            }
        }

        return count.Count;

    }
}