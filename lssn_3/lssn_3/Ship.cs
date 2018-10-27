using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lssn_3
{
    class Ship : BaseObject
    {
        private int energy = 100;
        public int Energy => energy;
        public static event Message MessageDie;

        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size) { }

        /// <summary>
        /// Уменьшение энергии
        /// </summary>
        /// <param name="n"></param>
        public void EnergyLow(int n)
        {
            energy -= n;
            if (energy > 100) energy = 100;
        }

        /// <summary>
        /// Обновление отображения
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.Wheat, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// Обновление объекта при столкновении. Для корабля не используется
        /// </summary>
        public override void Update() { }

        /// <summary>
        /// Движение вверх
        /// </summary>
        public void Up()
        {
            if (Pos.Y > 0) Pos.Y -= Dir.Y;
        }

        /// <summary>
        /// Движение вниз
        /// </summary>
        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y += Dir.Y;
        }
        
        /// <summary>
        /// Разрушение корабля
        /// </summary>
        public void Die()
        {
            MessageDie?.Invoke();
        }
    }
}
