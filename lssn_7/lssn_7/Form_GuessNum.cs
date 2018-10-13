// Решение 2-й задачи

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lssn_7
{
    public partial class Form_GuessNum : Form
    {
        GuessGame currGame;

        public Form_GuessNum()
        {
            InitializeComponent();
            StartNewGame();
        }

        private void StartNewGame()
        {
            currGame = new GuessGame();
            changeHead();
        }

        private void changeHead()
        {
            lbl_RoundNum.Text = $"Сделано ходов: {currGame.RoundNum}";
            lbl_Hint.Text = $"Подсказка: {currGame.MinValue} < x < {currGame.MaxValue}";
        }

        private void NewGame_button_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void Answer_button_Click(object sender, EventArgs e)
        {
            int currentAnswer = Convert.ToInt32(AnswerBox.Text);
            int result = currGame.checkValue(currentAnswer);

            if (result == 0) MessageBox.Show($"Вы победили! Сделано ходов: {currGame.RoundNum}");
            else if (result == 1) MessageBox.Show("Слишком много");
            else MessageBox.Show("Слишком мало");

            changeHead();
        }
    }
}
