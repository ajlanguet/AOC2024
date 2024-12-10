using System.Collections;
public class AocDaySix
{
    public static int[] curr = [0,0];
    public static int[] up = [-1,0];
    public static int[] right = [0,1];
    public static int[] left = [0,-1];
    public static int[] down = [1,0];
    public static int[][] directions = [up,right,down,left];
    public static int PartOne(string[] lines)
    {
        int rows = lines.Length;
        int cols = lines[0].Length;
        char[,] matrix = new char[rows, cols];

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
                if(matrix[i, j] == '^')
                {
                    curr = [i, j];
                }
            }
        } 
        int direction = 0;
        HashSet<int[]> total = new HashSet<int[]>(new ArrayComparer());
        total.Add(curr);

        while(curr[0] >= 0 && curr[1] >= 0 && curr[0] < rows && curr[1] < cols)
        {  
            if(matrix[curr[0], curr[1]] == '#')
            {
                total.Remove(curr);
                curr = [curr[0] - directions[direction][0], curr[1] - directions[direction][1]];
                if(direction == directions.Length - 1)
                {
                    direction = 0;
                }
                else{
                    direction++;
                }
            }
            matrix[curr[0], curr[1]] = 'X';

            if(!total.Contains(curr))
            {
                total.Add(curr);
            }
            curr = [curr[0] + directions[direction][0], curr[1] + directions[direction][1]];
        }

        return total.Count;
    }


    public static int PartTwo(string[] lines)
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

        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                if(matrix[i, j] == '^')
                {
                    curr = [i, j];
                }
            }
        } 
        int direction = 0;
        int[] tempCurr = new int[2];

        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j ++)
            {
                char temp = matrix[i,j];
                if(temp == '#')
                {
                    continue;
                }

                matrix[i,j] = '#';
                direction = 0;
                if(IsCycle(curr, direction, rows, cols, matrix))
                {
                    total++;
                }
                matrix[i, j] = temp;

            }
        }
        

        return total;
    }

    private static bool IsCycle(int[] curr, int direction, int rows, int cols, char[,] matrix)
    {
        HashSet<(int[], int[])> seenOb = new HashSet<(int[], int[])>(new TupleArrayComparer());

        while(curr[0] >= 0 && curr[1] >= 0 && curr[0] < rows && curr[1] < cols)
        {
            if(matrix[curr[0], curr[1]] == '#')
            {
                if(seenOb.Contains((curr, directions[direction])))
                {
                    return true;
                }
                else
                {
                    seenOb.Add((curr, directions[direction]));
                }
                
                curr = [curr[0] - directions[direction][0], curr[1] - directions[direction][1]];
                
                if(direction == directions.Length - 1)
                {
                    direction = 0;
                }
                else{
                    direction++;
                }
            }  
            curr = [curr[0] + directions[direction][0], curr[1] + directions[direction][1]];
        }
        return false;
    }
}

class ArrayComparer : IEqualityComparer<int[]>
{
    public bool Equals(int[] x, int[] y)
    {
        // Compare arrays element by element
        return x != null && y != null && x.SequenceEqual(y);
    }

    public int GetHashCode(int[] obj)
    {
        // Combine hash codes of all elements
        if (obj == null) return 0;
        return obj.Aggregate(0, (hash, item) => hash ^ item.GetHashCode());
    }
}

class TupleArrayComparer : IEqualityComparer<(int[], int[])>
{
    public bool Equals((int[], int[]) x, (int[], int[]) y)
    {
        return StructuralComparisons.StructuralEqualityComparer.Equals(x.Item1, y.Item1) &&
               StructuralComparisons.StructuralEqualityComparer.Equals(x.Item2, y.Item2);
    }

    public int GetHashCode((int[], int[]) obj)
    {
        int hash1 = StructuralComparisons.StructuralEqualityComparer.GetHashCode(obj.Item1);
        int hash2 = StructuralComparisons.StructuralEqualityComparer.GetHashCode(obj.Item2);
        return hash1 ^ hash2;
    }
}

