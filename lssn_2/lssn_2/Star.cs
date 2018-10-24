using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lssn_2
{
    class Star : BaseObject
    {
        Pen pen;

        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            chPen();
        }

        /// <summary>
        /// Выбор цвета при создании
        /// </summary>
        private void chPen()
        {
            switch (rnd.Next(1, 5) % 5)
            {
                case 1: pen = Pens.Red; break;
                case 2: pen = Pens.Yellow; break;
                case 3: pen = Pens.Green; break;
                case 4: pen = Pens.Blue; break;
            }
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawLine(pen, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(pen, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
        }

        /// <summary>
        /// Перемещение объекта. При уходе за край экрана, позиция и цвет определяются заново
        /// </summary>
        public override void Update()
        {
            Pos.X -= Dir.X;
            if (Pos.X < 0)
            {
                Pos.X = Game.Width + Size.Width;
                Pos.Y = rnd.Next(1, 9) * 60;

                chPen();
            }
        }
    }
}