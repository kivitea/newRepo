using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lssn_2
{
    abstract class BaseObject : ICollision
    {

        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        protected static Random rnd = new Random();

        /// <summary>
        /// Конструктор. Добавил исключения (по 5-й задаче) - исключения отрабатывают, но обработку исключений 
        ///         я пока не доделал (при создании объектов в классе Game)
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

        public abstract void Draw();
        
        /// <summary>
        /// Решение 2-й задачи. В основном функция Update и так была переопределена, так что просто перенес исходный код в класс Asteroid
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

        public bool Collision(ICollision o) => o.Rect.IntersectsWith(Rect);

    }
}
