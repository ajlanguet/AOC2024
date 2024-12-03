using System.Text.RegularExpressions;

public class AocDayThree
{
    public static int PartOne(string[] lines)
    {
        int total_sum = 0;

        string pattern = @"mul\((\d+),(\d+)\)";

        foreach(string line in lines){
            
            MatchCollection matches = Regex.Matches(line, pattern);
        
            foreach(Match match in matches)
            {
        
                int first_num = int.Parse(match.Groups[1].Value);
                int second_num = int.Parse(match.Groups[2].Value);
                        
                total_sum += first_num * second_num;
            }
        }

        return total_sum;
    }

    public static int PartTwo(string[] lines)
    {
        int total_sum = 0;

        string pattern = @"(mul|do|don't)\((\d*)?,?(\d*)?\)";
        bool adding = true;

        foreach(string line in lines){
            
            MatchCollection matches = Regex.Matches(line, pattern);
        
            foreach(Match match in matches)
            {
                string state = match.Groups[1].Value;
                if(match.Groups[1].Value == "don't")
                {
                    adding = false;
                }
                if(match.Groups[1].Value == "do")
                {
                    adding = true;
                }
                if(adding)
                {   
                    if(match.Groups[1].Value == "mul")
                    {
                    int first_num = int.Parse(match.Groups[2].Value);
                    int second_num = int.Parse(match.Groups[3].Value);
                    total_sum += first_num * second_num;
                    }
                }
            }
        }

        return total_sum;
    }
}