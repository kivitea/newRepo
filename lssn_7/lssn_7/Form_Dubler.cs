// Решение 1-й задачи

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
    public partial class Form_Dubler : Form
    {
        static Dubler currGame;
        
        public Form_Dubler()
        {
            InitializeComponent();
            StartNewGame();
        }

        /// <summary>
        /// Старт новой игры
        /// </summary>
        private void StartNewGame()
        {
            currGame = new Dubler();
            ChangeDesc();
            lbl_Answer.Text = $"Цель: {currGame.Answer}";
        }

        /// <summary>
        /// обновление состояния (текущий ход, значение)
        /// </summary>
        private void ChangeDesc()
        {
            lbl_Round.Text = $"Текущий ход: {currGame.RoundNum}";
            lbl_CurrentNum.Text = $"Текущее значение: {currGame.CurrentValue}";
        }

        /// <summary>
        /// Проверка текущего значения
        /// </summary>
        private void checckResult()
        {
            if (currGame.CurrentValue == currGame.Answer) MessageBox.Show($"Вы победили! Количество ходов: {currGame.RoundNum}");
            else if (currGame.CurrentValue > currGame.Answer) MessageBox.Show("Вы проиграли");
        }

        private void Cancell_button_Click(object sender, EventArgs e)
        {
            currGame.Cancell();
            ChangeDesc();
        }

        private void Sum_button_Click(object sender, EventArgs e)
        {
            currGame.Sum();
            ChangeDesc();
            checckResult();
        }

        private void Mult_button_Click(object sender, EventArgs e)
        {
            currGame.Mult();
            ChangeDesc();
            checckResult();
        }

        private void NewGame_button_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }
    }
}
