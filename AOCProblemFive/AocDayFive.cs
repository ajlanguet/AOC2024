public class AocDayFive
{

    public static bool CheckUpdate(Dictionary<int, List<int>> order_map, int[] upd)
    {
        for(int i = 0; i < upd.Length-1; i++)
        {
            if(order_map.ContainsKey(upd[i]))
            {
                for(int j = i + 1; j < upd.Length; j++)
                {
                    if(!order_map[upd[i]].Contains(upd[j]))
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            
        }
        return true;
    }

    public static int FindMiddle(int[] tr)
    {
        int slow = 0;
        int fast = 0;
        
        while(fast < tr.Length && fast + 1 < tr.Length)
        {
            slow++;
            fast += 2;
        }

        return tr[slow];
    }

    public static int PartOne(List<int[]> order, List<int[]> update)
    {
        Dictionary<int, List<int>> order_map = new Dictionary<int, List<int>>();
        int total = 0;
        List<int[]> truth = new List<int[]>();

        foreach(int[] ord in order)
        {
              if(order_map.ContainsKey(ord[0]))
              { 
                 order_map[ord[0]].Add(ord[1]);
              }
              else
              {
                List<int> new_ord = new List<int>();
                new_ord.Add(ord[1]);
                order_map.Add(ord[0], new_ord);
              }
        }

        foreach(int[] upd in update)
        {
            if(CheckUpdate(order_map, upd))
            {
                truth.Add(upd);
            }
        }

        foreach(int[] tr in truth)
        {
            total += FindMiddle(tr);
        }
     return total; 
    }

    public static int[] OrderTruth(Dictionary<int, List<int>> order_map, int[] tr)
    {
        int swap = 1;
        while(swap != 0)
        {
            swap = 0;
            for(int x = 0; x < tr.Length; x++)
            { 
                int right = x + 1; 
                for(int left = x; left < tr.Length-1; left++)
                {
                    if(order_map.ContainsKey(tr[right]) && order_map[tr[right]].Contains(tr[left]))
                    {   
                        (tr[left], tr[right]) = (tr[right], tr[left]);
                        swap++;
                    }

                    right++;
                }   
            }
    
        }
        return tr; //6237 is incorrect and too high
    }

    public static int PartTwo(List<int[]> order, List<int[]> update)
    {
        Dictionary<int, List<int>> order_map = new Dictionary<int, List<int>>();
        int total = 0;
        List<int[]> truth = new List<int[]>();
        SortedSet<int> nums = new SortedSet<int>();

        foreach(int[] or in order)
        {
            nums.Add(or[0]);
        }
        Console.WriteLine(string.Join(", ", nums));
        Console.WriteLine(nums.Count);

        foreach(int[] ord in order)
        {
              if(order_map.ContainsKey(ord[0]))
              { 
                 order_map[ord[0]].Add(ord[1]);
              }
              else
              {
                List<int> new_ord = new List<int>();
                new_ord.Add(ord[1]);
                order_map.Add(ord[0], new_ord);
              }
        }

        foreach(int[] upd in update)
        {
            if(!CheckUpdate(order_map, upd))
            {
                truth.Add(upd);
            }
        }

        foreach(var kvp in order_map)
        {
            Console.WriteLine($"{kvp.Key}: {string.Join(", ", kvp.Value)}");
        }
        int count = 1;
        foreach(int[] tr in truth)
        {   
            Console.WriteLine($"Unsorted: {count}");
            Console.WriteLine(string.Join(", ", tr));
            OrderTruth(order_map, tr);
            Console.WriteLine($"Sorted: {count}");
            Console.WriteLine(string.Join(", ", tr));
            Console.WriteLine($"Length: {tr.Length}");
            count++;
        }
        foreach(int[] tr in truth)
        {   
            total += FindMiddle(tr);
        }
     return total; 
    }

}