using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace lssn_1
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
            objs = new BaseObject[rnd.Next(2,5)*10];

            for (int i = 0; i < objs.Length / 10; i++)
            {
                objs[i] = new Nebula(new Point(20 * rnd.Next(1, 30), (i + 1) * 150), new Point(5, 0), new Size(50, 50));
            }

            for (int i = 0; i < 6*objs.Length/10; i++)
            {
                objs[objs.Length / 10 + i] = new BaseObject(new Point(20 * rnd.Next(1, 30), i * 20), new Point((i % 2 == 0 ? 1 : -1) * 3 * rnd.Next(1, 5), (i % 3 == 0 ? -1 : 1) * 3 * rnd.Next(1, 5)), new Size(10, 10));
            }

            for (int i = 0; i < 3* objs.Length / 10; i++)
            {
                objs[7 * objs.Length / 10 + i] = new Star(new Point(20 * rnd.Next(1, 40), i * 60), new Point(5, 0), new Size(5, 5));
            }
        }

       public static void Init(Form form)
        {
            Graphics g;

            context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();

            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

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
