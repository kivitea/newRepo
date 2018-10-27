using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lssn_3
{
    class HealPack : Asteroid
    {

        /// <summary>
        /// Конструктор. Аптечки имеют отрицательную "мошность"
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public HealPack(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = - 30;
        }

        /// <summary>
        /// бновление отображения
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.Red, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// Обновление состояния. Аптечки двигаются по горизонтали
        /// </summary>
        public override void Update()
        {
            Pos.X += Dir.X;
            Pos.Y += Dir.Y;
            if (Pos.X < 0 || (Pos.X > Game.Width && Dir.X > 0)) Pos.X = 800;
        }

    }
}
