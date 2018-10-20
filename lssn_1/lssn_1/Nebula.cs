using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lssn_1
{
    /// <summary>
    /// Решение 1-й и 2-й задачи
    /// </summary>
    class Nebula: BaseObject
    {
        Image img;
        public Nebula(Point pos, Point dir, Size size) : base(pos, dir, size) { chImage(); }

        /// <summary>
        /// Выбор картинки из папки
        /// </summary>
        private void chImage()
        {
            switch (rnd.Next(1,6) % 6)
            {
                case 1: img = Image.FromFile("neb_1.jpg"); break;
                case 2: img = Image.FromFile("neb_2.jpg"); break;
                case 3: img = Image.FromFile("neb_3.jpg"); break;
                case 4: img = Image.FromFile("neb_4.jpg"); break;
                case 5: img = Image.FromFile("neb_5.jpg"); break;
            }
        }
        
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// Перемещение объекта. При уходе за край экрана, позиция и картинка определяется заново
        /// </summary>
        public override void Update()
        {
            Pos.X -= Dir.X;
            if (Pos.X < 0)
            {
                Pos.X = Game.Width + Size.Width;
                Pos.Y = rnd.Next(1, 11) * 50;

                chImage();
            }
        }

    }
    
}
