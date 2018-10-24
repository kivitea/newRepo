/* Иван Васильев
 * 2. Переделать виртуальный метод Update в BaseObject в абстрактный и реализовать его в наследниках.
 * 3. Сделать так, чтобы при столкновениях пули с астероидом они регенерировались в разных концах экрана.
 * 4. Сделать проверку на задание размера экрана в классе Game. Если высота или ширина (Width, Height) больше 1000 
 *      или принимает отрицательное значение, выбросить исключение ArgumentOutOfRangeException().
 * 5. *Создать собственное исключение GameObjectException, которое появляется при попытке создать объект с неправильными характеристиками 
 * (например, отрицательные размеры, слишком большая скорость или позиция).
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace lssn_2
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
            form.Width = 1200;
            form.Height = 800;
            form.Text = "ДЗ к 2-му уроку";

            // Решение 4-й задачи
            try
            {
                Game.Init(form);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Заданы не верные параметры экрана");
                form.Width = 800;
                form.Height = 600;
                Game.Init(form);
            }

            CreateControls();
            form.Show();

            Application.Run(form);
        }

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
