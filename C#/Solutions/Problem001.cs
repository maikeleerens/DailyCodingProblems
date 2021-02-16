using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    /// <summary>
    /// This problem was recently asked by Google.
    /// 
    /// Given a list of numbers and a number k, return whether any two numbers from the list add up to k.
    /// 
    /// For example, given[10, 15, 3, 7] and k of 17, return true since 10 + 7 is 17.
    /// 
    /// Bonus: Can you do this in one pass?
    /// </summary>
    public static class Problem001
    {
        public static bool Solution(IReadOnlyCollection<int> numberList, int k)
        {
            return numberList.Select(number => k - number).Where(numberList.Contains).Any();
        }
    }
}
