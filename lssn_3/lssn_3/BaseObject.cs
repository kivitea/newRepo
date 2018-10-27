using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lssn_3
{
    abstract class BaseObject : ICollision
    {
        public delegate void Message();

        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        /// <summary>
        /// Свойства-координаты. Чтобы стрелять из корабля
        /// </summary>
        public int Pos_x { get { return Pos.X; } }
        public int Pos_y { get { return Pos.Y; } }

        protected static Random rnd = new Random();

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;

            if (Size.Height > 20 || Size.Width > 20)
            {
                GameObjectException newException = new GameObjectException();
                newException.WrongSize = true;
                throw newException;
            }

            if (Math.Sqrt(Math.Pow(Dir.X, 2) + Math.Pow(Dir.Y, 2)) > 30)
            {
                GameObjectException newException = new GameObjectException();
                newException.WrongSpeed = true;
                throw newException;
            }
        }

        /// <summary>
        /// Обновление отображения
        /// </summary>
        public abstract void Draw();

        /// <summary>
        /// Обновление состояния объекта
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// Обновление объекта при столкновении
        /// </summary>
        /// <param name="newPos"></param>
        public virtual void Reset(int newPos = 1)
        {
            Pos.X = newPos;
        }

        public Rectangle Rect => new Rectangle(Pos, Size);

        /// <summary>
        /// Обработка столкновения объектов
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public bool Collision(ICollision o) => o.Rect.IntersectsWith(Rect);

    }
}
