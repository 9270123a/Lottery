using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 模擬大樂透開獎
{
    internal class ParameterControll
    {
        List<string> normalWinningNumber;
        string specialWinningNumber;
        private List<string> selectedButtons = new List<string>();
        Awards awards = new Awards();
        RandonNumber randonNumber = new RandonNumber();


        public ParameterControll() {

            Generate_winingnumber();
        }

  
        private void Generate_winingnumber()
        {
            HashSet<string> normalWiningNumber = new HashSet<string>();
            while (normalWiningNumber.Count < 8)
            {
                string newnumber = randonNumber.GenerateNumbers(1)[0];
                normalWiningNumber.Add(newnumber);
            }
            string lastElement = normalWiningNumber.Last();
            normalWiningNumber.Remove(lastElement);

            normalWinningNumber = normalWiningNumber.ToList();
            specialWinningNumber = lastElement;



        }
        public void remove()
        {
            string lastElement = selectedButtons.Last();
            selectedButtons.Remove(lastElement);
        }
        public void ComputerPick()
        {
                while (selectedButtons.Count < 6)
                {
                    string newNumber = randonNumber.GenerateNumbers(1)[0];
                    // 如果生成的數字不在已選擇的數字中,則添加
                    if (!selectedButtons.Contains(newNumber))
                    {
                        selectedButtons.Add(newNumber);
                    }
                }
            
        }


        public (List<string>, string) Lottery_draw()
        {
            List<string> prizeNumber = null;
            int prize = 0;
            if (selectedButtons.Count != 6)
            {

                MessageBox.Show("請先選擇六個");

            }
            else
            {
                prizeNumber = normalWinningNumber;
                if (prizeNumber.Count == 6)
                {
                    prizeNumber.Add(specialWinningNumber);
                    prize = awards.CountMatchingNumbers(selectedButtons, normalWinningNumber, specialWinningNumber);
                }

               
            }

            return (prizeNumber, prize.ToString());
        }


        public void ToggleButtonSelection(LotteryButton button)
        {
            string buttonText = button.Text;

            if (selectedButtons.Contains(buttonText))
            {
                selectedButtons.Remove(buttonText);
                button.BackColor = SystemColors.Control;
            }
            else if (selectedButtons.Count < 6)
            {
                selectedButtons.Add(buttonText);
                button.BackColor = Color.Yellow;
            }
            else
            {
                MessageBox.Show("您已經選擇了 6 個號碼，不能再選了！");
            }

        }


        public List<string> GetSelectedButtons()
        {
            return selectedButtons;
        }

    }
}
