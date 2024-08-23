using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 模擬大樂透開獎
{
    public partial class Form1 : Form
    {
        // 1. 前後端不夠分離 前端只應該負責渲染 不應該負責邏輯判斷
        // 2. selectNumbers 應該要存Button 物件
        private List<LotteryButton> selectedNumbers = new List<LotteryButton>();
        ParameterControll parameterControl = new ParameterControll();
        public Form1()
        {
            InitializeComponent();

        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i=1;i<=49;i++)
            {
                LotteryButton button = new LotteryButton();
                button.Text = i.ToString();
                button.Click += Button_Click;
                flowLayoutPanel1.Controls.Add(button);
            }
        }
        private void Button_Click(object sender, EventArgs e)
        {
            if (sender is LotteryButton clickedButton)
            {
                parameterControl.ToggleButtonSelection(clickedButton);
                UpdateDisplay();
            }
            
        }


        private void Return_Click(object sender, EventArgs e)
        {
            if (selectedNumbers.Count > 0)
            {
                parameterControl.remove();
                UpdateDisplay();
                
            }
        }

        private void computer_Click(object sender, EventArgs e)
        {
            parameterControl.ComputerPick();
            UpdateDisplay();
        }
        private List<LotteryButton> FindButtonsByNumbers(List<string> numbers)
        {
            return flowLayoutPanel1.Controls.OfType<LotteryButton>()
                .Where(btn => numbers.Contains(btn.Text))
                .ToList();
        }
        private void ClearAllSelections()
        {
            foreach (Button btn in selectedNumbers)
            {
                btn.BackColor = SystemColors.Control;
            }
            selectedNumbers.Clear();
        }

        public void HighlightSelectedNumbers(List<LotteryButton> buttons)
        {
            foreach (LotteryButton btn in buttons)
            {
                btn.BackColor = Color.Yellow;
            }
        }

        private void UpdateDisplay()
        {
            ClearAllSelections();
            List<string> selectedButtonTexts = parameterControl.GetSelectedButtons();
            selectedNumbers = FindButtonsByNumbers(selectedButtonTexts);
            HighlightSelectedNumbers(selectedNumbers);

            textBox1.Text = string.Join(", ", selectedButtonTexts);
        }
        private void PrizeButton_Click(object sender, EventArgs e)
        {
            (List<string> prizenumber,string prize) = parameterControl.Lottery_draw();
            if (prizenumber != null)
            {
                textBox2.Text = string.Join(", ", prizenumber);

            }

            textBox4.Text = prize;
        }


    }
}
