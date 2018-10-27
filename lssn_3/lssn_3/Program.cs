/* Иван Васильев
 * 1. Добавить космический корабль, как описано в уроке. 
 * 2. Доработать игру «Астероиды»: 
 *      a. Добавить ведение журнала в консоль с помощью делегатов; 
 *      b. * добавить это и в файл. 
 * 3. Разработать аптечки, которые добавляют энергию. 
 * 4. Добавить подсчет очков за сбитые астероиды. 
 * 5. * Добавить в пример ​ Lesson3​​ обобщенный делегат.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace lssn_3
{
    static class Program
    {
        static Form form;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            form = new Form();
            form.Width = 800;
            form.Height = 600;
            form.Text = "ДЗ к 3-му уроку";

            try
            {
                Game.Init(form, true);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Заданы не верные параметры экрана");
                form.Width = 800;
                form.Height = 600;
                Game.Init(form, true);
            }

            CreateControls();
            form.Show();

            Application.Run(form);
        }

        /// <summary>
        /// Создание элементов управления
        /// </summary>
        static void CreateControls()
        {
            Button newGame_btn = new Button();
            newGame_btn.Left = 300;
            newGame_btn.Top = 150;
            newGame_btn.Width = 200;
            newGame_btn.Height = 50;
            newGame_btn.BackColor = Color.Black;
            newGame_btn.ForeColor = Color.White;
            newGame_btn.Text = "Новая игра";
            newGame_btn.Click += new EventHandler(NewGame_Click);

            form.Controls.Add(newGame_btn);

            Button record_btn = new Button();
            record_btn.Left = 300;
            record_btn.Top = 250;
            record_btn.Width = 200;
            record_btn.Height = 50;
            record_btn.BackColor = Color.Black;
            record_btn.ForeColor = Color.White;
            record_btn.Text = "Рекорды";

            form.Controls.Add(record_btn);

            Button exit_btn = new Button();
            exit_btn.Left = 300;
            exit_btn.Top = 350;
            exit_btn.Width = 200;
            exit_btn.Height = 50;
            exit_btn.BackColor = Color.Black;
            exit_btn.ForeColor = Color.White;
            exit_btn.Text = "Выход";

            form.Controls.Add(exit_btn);

            Label info_lbl = new Label();
            info_lbl.Top = 500;
            info_lbl.Left = 50;
            info_lbl.Width = 200;
            info_lbl.Height = 50;
            info_lbl.BackColor = Color.Black;
            info_lbl.ForeColor = Color.White;
            info_lbl.Text = "Автор: Иван Васильев";

            form.Controls.Add(info_lbl);
        }

        /// <summary>
        /// Очистка экрана. Новая игра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void NewGame_Click(object sender, System.EventArgs e)
        {
            form.Controls.Clear();
            Game.Init(form);
        }
    }
}
