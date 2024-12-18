using System;
using System.Data;

public class PermutationCounter
{
    public int[] permvals { get; set; }

    public PermutationCounter(int size)
    {
        permvals = new int[size];
    }
    
    public void BinaryIncrement()
    {
        bool carry = true;
        for(int x = 0; x < permvals.Length; x++)
        {
            if (carry)
            {
                permvals[x] += 1;
                if(permvals[x] == 2)
                {
                    permvals[x] = 0;
                    carry = true;
                }
                else 
                {
                    carry = false;
                    break;
                }
            }
        }
    }

    public void TernaryIncrement()
    {
        bool carry = true;
        for(int x = 0; x < permvals.Length; x++)
        {
            if(carry)
            {
                permvals[x] += 1;
                if(permvals[x] == 3)
                {
                    permvals[x] = 0;
                    carry = true;
                }
                else
                {
                    carry = false;
                    break;
                }
            }
        }
    }
}

public class AocDaySeven
{
    public static long PartOne(List<long> keys, List<long[]> vals)
    {
        List<long> truth = new List<long>();
        for(int pos = 0; pos < keys.Count; pos++)
        {
            long target = keys[pos];
            int size = vals[pos].Length - 1;
            int baseNumber = 2;

            PermutationCounter count = new PermutationCounter(size);

            for(int perm = 0; perm < Math.Pow(baseNumber, size); perm++)
            {
                long running_total = vals[pos][0];

                for(int bit = 0; bit < count.permvals.Length; bit++)
                {
                    if(count.permvals[bit] == 0)
                    {
                        running_total += vals[pos][bit+1];
                    }
                    else if(count.permvals[bit] == 1)
                    {
                        running_total *= vals[pos][bit+1];
                    }
                }

                if(target == running_total)
                {
                    truth.Add(keys[pos]);
                    break;
                }
                count.BinaryIncrement();
            }
        }

        return truth.Sum();
    }

     public static long PartTwo(List<long> keys, List<long[]> vals)
    {
        List<long> truth = new List<long>();
        for(int pos = 0; pos < keys.Count; pos++)
        {
            long target = keys[pos];
            int size = vals[pos].Length - 1;
            int baseNumber = 3;

            PermutationCounter count = new PermutationCounter(size);

            for(int perm = 0; perm < Math.Pow(baseNumber, size); perm++)
            {
                long running_total = vals[pos][0];
                for(int bit = 0; bit < count.permvals.Length; bit++)
                {
                    if(count.permvals[bit] == 0)
                    {
                        running_total += vals[pos][bit+1];
                    }
                    else if(count.permvals[bit] == 1)
                    {
                        running_total *= vals[pos][bit+1];
                    }
                    else if(count.permvals[bit] == 2)
                    {
                       
                        running_total = Int64.Parse(running_total.ToString() + vals[pos][bit+1].ToString());
                    }
                }

                if(target == running_total)
                {
                    truth.Add(keys[pos]);
                    break;
                }

                count.TernaryIncrement();
                
            }
        }

        return truth.Sum();
    }
}