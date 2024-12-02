
public class AocDayOne
{   
    public static int PartOne(List<int> row1, List<int> row2)
    {
        row1.Sort();
        row2.Sort();

        List<int> dist = new List<int>();

        for(int x = 0; x < row1.Count; x ++)
        {
            dist.Add(Math.Abs(row1[x]-row2[x]));
        }

        return dist.Sum();
    }

    public static int PartTwo(List<int> row1, List<int> row2)
    {
        Dictionary<int, int> row2_store = new Dictionary<int, int>();

        foreach(int num in row2)
        {
            if(row2_store.ContainsKey(num))
            {
                row2_store[num] += 1;
            }
            else
            {   
                row2_store[num] = 1;
            }
        }

        List<int> count = new List<int>();

        foreach(int num in row1)
        {
            if(row2_store.ContainsKey(num))
            {
                count.Add(row2_store[num] * num);
            }
            else
            {
                count.Add(0);
            }
        }

        return count.Sum();
    }

}

