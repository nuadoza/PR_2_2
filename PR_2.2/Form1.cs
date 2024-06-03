using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace PR._2_РОМА
/// <summary>
/// Метод для проверки количество букв введенные в строку
/// </summary>
{
    public partial class Form1 : Form
    {
        ErrorProvider errorProvider = new ErrorProvider();
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Метод для проверки строки, на числа
        /// </summary>   
        public bool Checknumbers(string input)
        {
            foreach (char c in input) //проверка на нечисла
            {
                if (!Char.IsDigit(c))
                {
                    return false; 
                }
            }
            string result = "";
            foreach (char c in input) // 
            {
                if (Char.IsDigit(c))
                {
                    result += c;
                }
            }
            int f = Convert.ToInt32(result); // результат конвертируется в числа
            if (f != 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Метод удаления цифр
        /// </summary>  
        static string RemoveDigits(string input)
        {
            string result = "";
            foreach (char c in input)
            {
                if (!Char.IsDigit(c))
                {
                    result += c;
                }
            }
            return result;
        }    
        private async void calculation_button_1_Click(object sender, EventArgs e)
        {
            string inputString = InputTextBox.Text;
            if (String.IsNullOrWhiteSpace(inputString))
            {
                errorProvider.SetError(InputTextBox, "Ошибка: введите строку!");
                await Task.Delay(2000);
                errorProvider.SetError(InputTextBox, "");
            }
            else if (Checknumbers(inputString))
            {
                errorProvider.SetError(InputTextBox, "Ошибка: введите строку!");
                await Task.Delay(2000);
                errorProvider.SetError(InputTextBox, "");
            }
            else
            {
                inputString = RemoveDigits(InputTextBox.Text.Replace(" ", ""));
                Dictionary<char, int> charCountDictionary = new Dictionary<char, int>();
                foreach (char c in inputString)
                {
                    if (charCountDictionary.ContainsKey(c))
                    {
                        charCountDictionary[c]++;
                    }
                    else
                    {
                        charCountDictionary[c] = 1;
                    }
                }
                ResultTextBox.Text = "Словарь из строки: \r \n";
                foreach (KeyValuePair<char, int> kvp in charCountDictionary)
                {
                    ResultTextBox.Text += $"{kvp.Key}: {kvp.Value}, ";
                }
                ResultTextBox.Text = ResultTextBox.Text.TrimEnd(',', ' ') + ".";
            }

        }
        private void close_1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void clear_Click(object sender, EventArgs e)
        {
            InputTextBox.Clear();
            ResultTextBox.Clear();
        }
        private void close_2_Click(object sender, EventArgs e)
        {
            close_1_Click(sender, e);
        }
        private void aboutTheProgram_Click(object sender, EventArgs e)
        {
            Form2 newF = new Form2();
            newF.Show();
        }
        private void calculation_button_2_Click(object sender, EventArgs e)
        {
            calculation_button_1_Click(sender, e);
        }
    }
}