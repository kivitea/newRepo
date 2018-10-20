/* Васильев Иван
 * 1. Добавить свои объекты в иерархию объектов, чтобы получился красивый задний фон, похожий на полёт в звёздном пространстве.
 * 2. *Заменить кружочки картинками, используя метод DrawImage.
 * 3. *Разработать собственный класс заставка SplashScreen, аналогичный классу Game в котором создайте собственную иерархию объектов 
 *      и задайте их движение. Предусмотреть кнопки - Начало игры, Рекорды, Выход. Добавить на заставку имя автора.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace lssn_1
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
            form.Text = "ДЗ к 1-му уроку";
            Game.Init(form);

            CreateControls();
            form.Show();

            Application.Run(form);
        }

        /// <summary>
        /// Решение 3-й задачи. Не хватило времени (или вдохновения) сделать полноценный класс, чтобы он как-то заметно отличался, 
        /// поэтому я использовал тот же с добавлением элементов упарвления
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
            info_lbl.Text = "Автор: Васильев Иван";

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
