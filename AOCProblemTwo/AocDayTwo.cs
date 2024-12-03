public class AocDayTwo 
{
    public static bool IsSafe(List<int> level) 
    {
        if(level.Count < 2)
        {
            return true;
        }

        int start = level[1] - level[0];

        if(start == 0 || Math.Abs(start) > 3)
        {
            return false;
        }

        int ind = start / Math.Abs(start);

        for(int x = 1; x < level.Count-1; x++)
        {
            int next = level[x+1] - level[x];

            if(next == 0 || Math.Abs(next) > 3)
            {
                return false;
            }

            int incOrDec = next / Math.Abs(next);

            if(ind != incOrDec)
            {
                return false;
            }
        }
        return true;

    }
  
    public static int PartOne(List<int[]> levels)
    {
        int safe = 0;
        foreach(int[] level in levels)
        {
            List<int> newLevel = level.ToList();
            if(IsSafe(newLevel))
            {
                safe++;
            }
        }   
        return safe;
    }

    public static int PartTwo(List<int[]> levels)
    {
        int safe = 0;
        foreach(int[] level in levels)
        {
            List<int> newLevel = level.ToList();
            if(IsSafe(newLevel))
            {
                safe++;
            }
            else
            {
                for(int x = 0; x < level.Length; x++)
                {
                    List<int> removeLevel = level.ToList();
                    removeLevel.RemoveAt(x);
                    if(IsSafe(removeLevel))
                    {
                        safe++;
                        break;
                    }
                }
            }
        }   
        return safe;
        
    }
}