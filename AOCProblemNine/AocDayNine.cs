using System.ComponentModel;
using System.Diagnostics.Tracing;

public class AocDayNine
{
    public static long PartOneBad(string line)
    {
        int right = line.Length - 1;
        int maxid = line.Length / 2;
        int left = 0;
        int minid = 0;
        List<int> numbers = new List<int>();
        int num_count = 0;

        while(left < right)
        {
            if(left % 2 != 0)
            {
                int back_count = 0;
                while(back_count < int.Parse(line[left].ToString()))
                {
      //              Console.WriteLine(int.Parse(line[right].ToString()));
                    numbers.Add(maxid);
                    back_count++;
                    num_count++;
      //              Console.WriteLine($"num_count: {num_count}");
                    if(num_count == int.Parse(line[right].ToString()))
                    {
            //            Console.WriteLine("hits");
                        num_count = 0;
                        maxid--;
                        right-=2;
                    } 
         //           Console.WriteLine($"this is maxid: {maxid}");
                }
                
            }
            else
            {
                for(int front = 0; front < int.Parse(line[left].ToString()); front++)
                {
                    numbers.Add(minid);
                }
                minid++;
            }
            left++;
        }

  //      Console.WriteLine($"final num count: {num_count}");

        int final_count = int.Parse(line[right].ToString()) - num_count;

        for(int final = 0; final < final_count; final++)
        {
            numbers.Add(maxid);
        }

        Console.WriteLine(string.Join(", ", numbers));

        long check_sum = 0;

        for(int check = 0; check < numbers.Count; check++)
        {
            check_sum += (long)check * numbers[check];
        }

// 6398608069280
// 6399665440598
        return check_sum;
    }

    public static long PartOne(string line)
    {
        List<long> numbers = new List<long>();
        int index = 0;

        for(int pos = 0; pos < line.Length; pos++)
        {
            if(pos % 2 == 0)
            {
                for(int num = 0; num < int.Parse(line[pos].ToString()); num++)
                {
                    numbers.Add(index);
                }
                index++;
            }
            else
            {
                for(int dot = 0; dot < int.Parse(line[pos].ToString()); dot++)
                {
                    numbers.Add(-1);
                }
            }
        }
        
        int right = numbers.Count - 1;
        int left = 0;

 //       Console.WriteLine(string.Join(", ", numbers));

        while(left < right)
        {
            if(numbers[left] == -1 && numbers[right] != -1)
            {
                (numbers[right], numbers[left]) = (numbers[left], numbers[right]);
            }
            else if(numbers[left] != -1)
            {
                left++;
            }
            else if(numbers[right] == -1)
            {
                right--;
            }
        }

    //    Console.WriteLine(string.Join(", ", numbers));

        long check_sum = 0;


        for(int check = 0; check < numbers.Count; check++)
        {
            if(numbers[check] == -1)
            {
                break;
            }
            check_sum += check * numbers[check];
        }

        return check_sum;
    }

     public static long PartTwo(string line)
    {
        List<long> numbers = new List<long>();
        int index = 0;

        for(int pos = 0; pos < line.Length; pos++)
        {
            if(pos % 2 == 0)
            {
                for(int num = 0; num < int.Parse(line[pos].ToString()); num++)
                {
                    numbers.Add(index);
                }
                index++;
            }
            else
            {
                for(int dot = 0; dot < int.Parse(line[pos].ToString()); dot++)
                {
                    numbers.Add(-1);
                }
            }
        }
        
        SortedSet<long> indexes_set = new SortedSet<long>();

        foreach(long ind in numbers)
        {
            if(ind == -1)
            {
                continue;
            }
            indexes_set.Add(ind);
        }

        List<long> indexes = new List<long>(indexes_set);

  //      Console.WriteLine(string.Join(", ", indexes));

        indexes.Reverse();

 //       Console.WriteLine(string.Join(", ", indexes));
 //       Console.WriteLine(string.Join(", ", numbers));

        foreach(long ind in indexes)
        {
            int file_count = numbers.Count(x => x == ind); 
        //    Console.WriteLine(file_count);

            for(int trav = 0; trav < numbers.Count; trav++)
            {
                if(numbers[trav] == -1)
                {
                //    Console.WriteLine(trav);
                    int count = 0;
                    int spos = trav;
                    while(numbers[spos] == -1)
                    {
                        count++;
                        spos++;
                    }

                //    Console.WriteLine($"Count: {count}");

                    if(count >= file_count)
                    {
                        int right = numbers.IndexOf(ind);
                        for(int x = 0; x < file_count; x++)
                        {
                            (numbers[right], numbers[trav]) = (numbers[trav], numbers[right]);
                            trav++;
                            right++;
                        }
                        break;
                    }
                 //   Console.WriteLine(string.Join(", ", numbers));
                
                }

                if(numbers[trav] == ind)
                {
                    break;
                }
            }  
        
            
        }

    //    Console.WriteLine(string.Join(", ", numbers));

        long check_sum = 0;
        for(int check = 0; check < numbers.Count; check++)
        {
            if(numbers[check] == -1)
            {
                continue;
            }
            check_sum += check * numbers[check];
        }

        return check_sum;
    }
}