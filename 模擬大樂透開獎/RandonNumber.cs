using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 模擬大樂透開獎
{
    internal class RandonNumber
    {
        Random random = new Random();
        public List<string> GenerateNumbers(int count)
        {
            var numbers = new List<string>();
            for (int i = 0; i < count; i++)
            {
                numbers.Add(random.Next(1, 50).ToString()); // 生成0-50之間的隨機數並轉換為字符串
            }
            return numbers;
        }
    }
}