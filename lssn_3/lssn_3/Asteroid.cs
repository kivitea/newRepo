using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lssn_3
{
    class Asteroid : BaseObject
    {

        public int Power { get; set; }

        /// <summary>
        /// Конструктор. Power - "мощность" объекта
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 10;
        }

        /// <summary>
        /// Обновление отображения
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// Обновление состояния объекта
        /// </summary>
        public override void Update()
        {
            Pos.X += Dir.X;
            Pos.Y += Dir.Y;
            if (Pos.X < 0 || (Pos.X > Game.Width && Dir.X > 0) ) Dir.X = -Dir.X; // Придвижении вправо поворачиваем только с положительной скоростью
                                                                                 // для обработки столкновений
            if (Pos.Y < 0 || Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }

    }
}
