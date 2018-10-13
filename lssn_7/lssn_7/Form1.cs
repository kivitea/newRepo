/*Иван Васильев
 * 1.   а) Добавить в программу «Удвоитель» подсчёт количества отданных команд удвоителю. 
 *      б) Добавить меню и команду «Играть». При нажатии появляется сообщение, какое число должен получить игрок. 
 *          Игрок должен получить это число за минимальное количество ходов. 
 *      в) *Добавить кнопку «Отменить», которая отменяет последние ходы. Используйте обобщенный класс Stack. 
 *      
 *      Вся логика игры должна быть реализована в классе с удвоителем. 
 *
 * 2.   Используя Windows Forms, разработать игру «Угадай число». Компьютер загадывает число от 1 до 100, а человек пытается его угадать 
 *          за минимальное число попыток. Компьютер говорит, больше или меньше загаданное число введенного.  
 *      a) Для ввода данных от человека используется элемент TextBox; 
 *      б) **Реализовать отдельную форму c TextBox для ввода числа. - не стал делать, т.к. сделал отдельные формы для каждой игры (в одной программе)
 */

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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GuessNum_button_Click(object sender, EventArgs e)
        {
            Form_GuessNum exam = new Form_GuessNum();
            exam.ShowDialog();
        }

        private void NewGame_button_Click(object sender, EventArgs e)
        {
            Form_Dubler exam = new Form_Dubler();
            exam.ShowDialog();
        }
    }
}
