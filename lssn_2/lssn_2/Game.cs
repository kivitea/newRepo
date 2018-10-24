using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace lssn_2
{
    class Game
    {
        private static BufferedGraphicsContext context;
        public static BufferedGraphics Buffer;

        public static int Width { get; set; }
        public static int Height { get; set; }

        public static BaseObject[] objs;

        private static Random rnd = new Random();

        /// <summary>
        /// Создание массива объектов. Добавил рандом в количество объектов, начальную позицию и направление/скорость движения.
        /// </summary>
        public static void Load()
        {
            objs = new BaseObject[rnd.Next(2, 5) * 10];

            //Добавил пулю первым объектом - это, конечно, не правильно, но это тольо для демонстрации работы
            objs[0] = new Bullet(new Point(0, 15*rnd.Next(5,35)), new Point(5, 0), new Size(4, 1));
            
            for (int i = 0; i < 6 * objs.Length / 10 + 1; i++)
            {
                objs[1 + i] = new Asteroid(new Point(20 * rnd.Next(1, 30), i * 20), new Point((i % 2 == 0 ? 1 : -1) * 3 * rnd.Next(1, 5), (i % 3 == 0 ? -1 : 1) * 3 * rnd.Next(1, 5)), new Size(10, 10));
            }

            for (int i = 0; i < 4 * objs.Length / 10 - 1; i++)
            {
                objs[1 + 6 * objs.Length / 10 + i] = new Star(new Point(20 * rnd.Next(1, 40), i * 60), new Point(5, 0), new Size(5, 5));
            }
        }

        public static void Init(Form form)
        {
            Graphics g;

            context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();

            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            if (Width > 1000 || Width < 200 || Height > 1000 || Height < 200) throw new ArgumentOutOfRangeException();

            Buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load();

            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += TimerTick;
        }


        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in objs)
            {
                obj.Draw();
                // Решение 3-й задачи
                if (obj is Asteroid && obj.Collision(objs[0]))
                {
                    obj.Reset(800);
                    objs[0].Reset();
                    System.Media.SystemSounds.Hand.Play();
                }

                Buffer.Render();
                
            }
        }

        public static void Update()
        {
            foreach (BaseObject obj in objs) obj.Update();
        }

        private static void TimerTick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

    }
}
