using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 模擬大樂透開獎
{
    internal class Awards
    {



        public int CountMatchingNumbers(List<string> list1, List<string> list2, string SpecialList)
        {

            int prizeNumber =  list1.Intersect(list2).Count();
            int specialNumber = int.Parse(SpecialList);
            bool sp = specialNumber > 0;
            int prize = calculatePrize(prizeNumber, sp);
        
            return prize;
        }


        private int calculatePrize(int matchedNumbers, bool secondAreaMatched)
        {
            switch (matchedNumbers)
            {
                case 6:
                    if (secondAreaMatched)
                    {
                        return 15072350;  // 頭獎,本期無人中獎
                    }
                    else
                    {
                        return 1862874;  // 貳獎,本期無人中獎
                    }
                case 5:
                    if (secondAreaMatched)
                    {
                        return 1800000;  // 參獎
                    }
                    else
                    {
                        return 1240000;   // 肆獎
                    }
                case 4:
                    if (secondAreaMatched)
                    {
                        return 1428000;    // 伍獎
                    }
                    else
                    {
                        return 1502400;     // 陸獎
                    }
                case 3:
                    if (secondAreaMatched)
                    {
                        return 1317200;     // 柒獎
                    }
                    else
                    {
                        return 3241600;     // 玖獎
                    }
                case 2:
                    if (secondAreaMatched)
                    {
                        return 2070900;     // 捌獎
                    }
                    else
                    {
                        return 3429200;       // 未中獎
                    }
                case 1:
                    if (secondAreaMatched)
                    {
                        return 100;     // 普獎
                    }
                    else
                    {
                        return 0;       // 未中獎
                    }
                default:
                    return 0;           // 未中獎
            }
        }
    }
}
