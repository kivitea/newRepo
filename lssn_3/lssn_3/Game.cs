using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace lssn_3
{
    class Game
    {
        private static BufferedGraphicsContext context;
        public static BufferedGraphics Buffer;

        public static int Width { get; set; }
        public static int Height { get; set; }

        public static BaseObject[] objs;

        private static Ship ship;
        private static List<Bullet> list_bullets = new List<Bullet>();
        private static int Score = 0;

        private static Timer timer = new Timer { Interval = 100 };
        private static Random rnd = new Random();

        /// <summary>
        /// Создание массива объектов. Добавил рандом в количество объектов, начальную позицию и направление/скорость движения.
        /// </summary>
        public static void Load(bool SplashScreen = false)
        {
            if (!SplashScreen) ship = new Ship(new Point(10, 300), new Point(5, 5), new Size(20, 20));

            objs = new BaseObject[rnd.Next(2, 5) * 10];

            for (int i = 0; i < objs.Length / 10; i++)
            {
                objs[i] = new HealPack(new Point(800, 20 * rnd.Next(1, 30)), new Point(-3 * rnd.Next(1, 5), 0), new Size(10, 10));
            }

            for (int i = 0; i < 5 * objs.Length / 10; i++)
            {
                objs[objs.Length / 10 + i] = new Asteroid(new Point(20 * rnd.Next(1, 30), i * 20), new Point((i % 2 == 0 ? 1 : -1) * 3 * rnd.Next(1, 5), (i % 3 == 0 ? -1 : 1) * 3 * rnd.Next(1, 5)), new Size(10, 10));
            }

            for (int i = 0; i < 4 * objs.Length / 10; i++)
            {
                objs[6 * objs.Length / 10 + i] = new Star(new Point(20 * rnd.Next(1, 40), i * 60), new Point(5, 0), new Size(5, 5));
            }
        }

        /// <summary>
        /// Инициализация. Добавил признак SlashScreen чтобы в меню не работали кнопки управления
        /// </summary>
        /// <param name="form"></param>
        /// <param name="SplashScreen"> признак для фона меню</param>
        public static void Init(Form form, bool SplashScreen = false)
        {
            Graphics g;

            context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();

            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            if (Width > 1000 || Width < 200 || Height > 1000 || Height < 200) throw new ArgumentOutOfRangeException();

            form.KeyDown += form_KeyDown;

            Buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load(SplashScreen);

            timer.Start();
            timer.Tick += TimerTick;

            if (SplashScreen) Ship.MessageDie += Finish;
        }

        /// <summary>
        /// Завершение игры
        /// </summary>
        public static void Finish()
        {
            timer.Stop();
            Buffer.Graphics.DrawString("The End   |   Score: {Score}", SystemFonts.DefaultFont, Brushes.White, 380, 300);
            Buffer.Render();
        }

        /// <summary>
        /// Обновление отображения по таймеру
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);

            for (int i = 0; i < list_bullets.Count; i++)
            {
                list_bullets[i].Draw();
            }

            if (ship != null)
            {
                ship.Draw();
                Buffer.Graphics.DrawString($"Energy: {ship.Energy}", SystemFonts.DefaultFont, Brushes.White, 0, 0);
                Buffer.Graphics.DrawString($"Score: {Score}", SystemFonts.DefaultFont, Brushes.White, 700, 0);
                Buffer.Graphics.DrawString("\"Up/Down\" - движение вверх/вниз       |     \"Space\" - стельба", SystemFonts.DefaultFont, Brushes.White, 220, 540);
            }

            foreach (BaseObject obj in objs)
            {
                obj.Draw();
                Buffer.Render();
            }
        }

        /// <summary>
        /// Обновление состояния объектов
        /// </summary>
        public static void Update()
        {
            for (int i = 0; i < list_bullets.Count; i++)
            {
                list_bullets[i].Update();
                if (list_bullets[i].Pos_x > 800) list_bullets.RemoveAt(i--);
            }

            for (int i = 0; i < objs.Length; i++)
            {
                if (objs[i] is Asteroid)
                {
                    if (!(objs[i] is HealPack))
                    {
                        for (int j = 0; j < list_bullets.Count; j++)
                        {
                            if (objs[i].Collision(list_bullets[j]))
                            {
                                System.Media.SystemSounds.Hand.Play();
                                objs[i].Reset(800);
                                list_bullets.Remove(list_bullets[j]);
                                Score += 5;
                            }

                        }
                    }

                    if (ship != null && objs[i].Collision(ship))
                    {
                        ship.EnergyLow((objs[i] as Asteroid).Power);
                        objs[i].Reset(800);

                        System.Media.SystemSounds.Asterisk.Play();

                        if (ship.Energy <= 0) ship?.Die();
                    }

                }

                objs[i].Update();
            }
        }

        /// <summary>
        /// Обработка события таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void TimerTick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        /// <summary>
        /// Обработка нажатия кнопок управления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void form_KeyDown(object sender, KeyEventArgs e)
        {
            if (ship == null) return;
            if (e.KeyCode == Keys.Space) list_bullets.Add(new Bullet(new Point(10, ship.Pos_y + 10), new Point(15, 0), new Size(5, 1)));
            if (e.KeyCode == Keys.Up) ship.Up();
            if (e.KeyCode == Keys.Down) ship.Down();
        }

    }
}
