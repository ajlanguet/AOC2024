using System.Runtime.InteropServices;

public class AocDayEleven
{
    public static long PartOne(string line)
    {
        string[] inital = line.Split(" ");
        List<string> stones = inital.ToList();
        List<string> new_stones = new List<string>();
      
        for(int blinks = 0; blinks < 25; blinks++)
        {
            for(int s = 0; s < stones.Count; s++)
            {
                if(stones[s] == "0")
                {
                    new_stones.Add("1");
                }
                else if (stones[s].ToString().Length % 2 == 0)
                {
                    new_stones.Add(stones[s].ToString().Substring(0, stones[s].ToString().Length / 2));
                    
                    if(stones[s].ToString().Substring(stones[s].ToString().Length / 2, stones[s].ToString().Length / 2).Count(zero => zero == '0') 
                        == stones[s].ToString().Length / 2)
                    {
                        new_stones.Add("0");
                    }
                    else
                    {
                        new_stones.Add(long.Parse(stones[s].Substring(stones[s].ToString().Length / 2, stones[s].ToString().Length / 2)).ToString());
                    }
                }
                else
                {
                    long mul_stone = 2024 * long.Parse(stones[s]);
                    new_stones.Add(mul_stone.ToString());
                }
            }

            stones = new_stones;
            new_stones = new List<string>();
        }

        return stones.Count;
    }

    public static long PartTwo(string line)
    {
        string[] inital = line.Split(" ");
        Dictionary<string, long> stones = new Dictionary<string, long>();
        foreach(string init in inital)
        {
            if(stones.ContainsKey(init))
            {
                stones[init] += 1;
            }
            else 
            {
                stones[init] = 1;
            }
        }
      
        for(int blinks = 0; blinks < 75; blinks++)
        {
            Dictionary<string, long> new_stones = new Dictionary<string, long>();
            foreach(KeyValuePair<string, long> kvp in stones)
            {
                if(kvp.Key == "0")
                {
                    if(!new_stones.ContainsKey("1"))
                    {
                        new_stones.Add("1", 0);
                    }
                    new_stones["1"] += kvp.Value;
                }
                else if (kvp.Key.ToString().Length % 2 == 0)
                {
                    string first_half = long.Parse(kvp.Key.ToString().Substring(0, kvp.Key.ToString().Length / 2)).ToString();    
                    string second_half = long.Parse(kvp.Key.Substring(kvp.Key.ToString().Length / 2, kvp.Key.ToString().Length / 2)).ToString();
                    
                    if(!new_stones.ContainsKey(first_half))
                    {
                        new_stones.Add(first_half, 0);
                    }
                    if(!new_stones.ContainsKey(second_half))
                    {
                        new_stones.Add(second_half, 0);
                    }
                    
                    new_stones[first_half] +=  kvp.Value;
                    new_stones[second_half] += kvp.Value;
                
                }
                else
                {
                    long mul_stone = 2024 * long.Parse(kvp.Key);
                    if(!new_stones.ContainsKey(mul_stone.ToString()))
                    {
                        new_stones.Add(mul_stone.ToString(), 0);
                    }
                    new_stones[mul_stone.ToString()] += kvp.Value;
                }
            }
            stones = new_stones;
        }

        return stones.Values.Sum();
    }
    public static int PartTwob(string line) // brute force does not work
    {
        string[] inital = line.Split(" ");
        List<string> stones = inital.ToList();
        List<string> new_stones = new List<string>();
      
        for(int blinks = 0; blinks < 75; blinks++)
        {
            for(int s = 0; s < stones.Count; s++)
            {
                if(stones[s] == "0")
                {
                    new_stones.Add("1");
                }
                else if (stones[s].ToString().Length % 2 == 0)
                {
                    new_stones.Add(stones[s].ToString().Substring(0, stones[s].ToString().Length / 2));
                    
                    if(stones[s].ToString().Substring(stones[s].ToString().Length / 2, stones[s].ToString().Length / 2).Count(zero => zero == '0') 
                        == stones[s].ToString().Length / 2)
                    {
                        new_stones.Add("0");
                    }
                    else
                    {
                        new_stones.Add(long.Parse(stones[s].Substring(stones[s].ToString().Length / 2, stones[s].ToString().Length / 2)).ToString());
                    }
                }
                else
                {
                    long mul_stone = 2024 * long.Parse(stones[s]);
                    new_stones.Add(mul_stone.ToString());
                }
            }

            stones = new_stones;
            new_stones = new List<string>();
        }

        return stones.Count;
    }
}