using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elfs_VS_Goblins__
{
    public partial class Form1 : Form
    {
        Random rand;
        Enemy []Chudovishta;
        ElfProjectile[] Magiya;
        public class ElfProjectile
        {
            public int speed = 10;
            public PictureBox Pic;
            protected int x= 6;
            protected int y = 15;
            public ElfProjectile()
            {
                Pic = new PictureBox();
                Pic.Size = new Size(x,y);
                Pic.BackColor = Color.Purple;
            }
        }
        public class Enemy
        {
            public int Speed ;
            public int Health ;
            public PictureBox Pic;
            protected int x;
            protected int y;
            public int XP;
            public Enemy(int a, int b)
            {
                Pic = new PictureBox();
                Pic.Location = new Point(a, b);
                Pic.Size = new Size(x, y);
            }
        }
        public class Goblin : Enemy
        {
            public Goblin(int a, int b) : base(a,b) 
            {
                x = 80;
                y = 80;
                Health = 2;
                Speed = 2;
                Pic = new PictureBox();
                Pic.Location = new Point(a, b);
                Pic.Size = new Size(x, y);
                Pic.Image = Image.FromFile("sprites/apple-export.gif"); //vremenno
            }
        }
        public class Tank : Enemy 
        { 
            public Tank(int a, int b):base(a,b)
            {
                /*
                x = ;
                y = ;
                Health = ;
                Speed = ;
                Pic = new PictureBox();
                Pic.Location = new Point(a, b);
                Pic.Size = new Size(x, y);
                Pic.Image = Image.FromFile("sprites/----");
                */
            }
        }
        public class Demon : Enemy
        {
            public Demon(int a, int b) : base(a, b)
            {
                /*
                x = ;
                y = ;
                Health = ;
                Speed = ;
                Pic = new PictureBox();
                Pic.Location = new Point(a, b);
                Pic.Size = new Size(x, y);
                Pic.Image = Image.FromFile("sprites/----");
                */
            }
        }
        public class Elf
        {
            public int Health = 1;
            public PictureBox Pic;
            public int speed = 4;
            public int ShootingSpeed;
        }
        Elf Igrach = new Elf();

        public Form1()
        {
            InitializeComponent();
            rand = new Random();
            Chudovishta = new Enemy[1];

            EnemiesMove.Start();
            Goblin test = new Goblin(rand.Next(20, 450), 10);
            this.Controls.Add(test.Pic);
            Chudovishta[0] =test;

            Igrach.Pic = ElfPic;
            Magiya = new ElfProjectile[3];
            for(int i = 0; i<3;i++)
            {
                Magiya[i] = new ElfProjectile();
                this.Controls.Add(Magiya[i].Pic);
                Magiya[i].Pic.BringToFront();
            }
        }

        private void timer1_Tick(object sender, EventArgs e) //enemies move
        {
            foreach(var a in Chudovishta)
            {
                a.Pic.Top += a.Speed;
                if(a.Pic.Top>=this.Height)
                {
                    a.Pic.Dispose();
                }
            }
        }

        private void MoveDown_Tick(object sender, EventArgs e)
        {
            if(Igrach.Pic.Top<300)
            {
                Igrach.Pic.Top += Igrach.speed;
            }
        }

        private void MoveUp_Tick(object sender, EventArgs e)
        {
            if (Igrach.Pic.Top > -45)
            {
                Igrach.Pic.Top -= Igrach.speed;
            }
        }

        private void MoveRight_Tick(object sender, EventArgs e)
        {
            if (Igrach.Pic.Right < 535)
            {
                Igrach.Pic.Left += Igrach.speed;
            }
        }

        private void MoveLeft_Tick(object sender, EventArgs e)
        {
            if (Igrach.Pic.Left > -15)
            {
                Igrach.Pic.Left -= Igrach.speed;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Down|e.KeyCode==Keys.S)
            {
                MoveDown.Start();
            }
            if (e.KeyCode == Keys.Up | e.KeyCode == Keys.W)
            {
                MoveUp.Start();
            }
            if (e.KeyCode == Keys.Left | e.KeyCode == Keys.A)
            {
                MoveLeft.Start();
            }
            if (e.KeyCode == Keys.Right | e.KeyCode == Keys.D)
            {
                MoveRight.Start();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down | e.KeyCode == Keys.S)
            {
                MoveDown.Stop();
            }
            if (e.KeyCode == Keys.Up | e.KeyCode == Keys.W)
            {
                MoveUp.Stop();
            }
            if (e.KeyCode == Keys.Left | e.KeyCode == Keys.A)
            {
                MoveLeft.Stop();
            }
            if (e.KeyCode == Keys.Right | e.KeyCode == Keys.D)
            {
                MoveRight.Stop();
            }
        }

        private void ElfProjectileMove_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Magiya.Length; i++)
            {
                if(Magiya[i].Pic.Top>0)
                {
                    Magiya[i].Pic.Visible = true;
                    Magiya[i].Pic.Top -= Magiya[i].speed;

                    Collisions();
                    if(!Igrach.Pic.Visible)
                    {
                        GameStop();
                    }
                }
                else
                {
                    Magiya[i].Pic.Visible = false;
                    Magiya[i].Pic.Location = new Point(Igrach.Pic.Location.X+60, Igrach.Pic.Location.Y +70-i*15);
                }
            }
        }
        private void Collisions()
        {
            for(int i = 0;i<Chudovishta.Length;i++)
            {
                for(int j = 0; j<Magiya.Length;j++)
                {
                    if (Magiya[j].Pic.Bounds.IntersectsWith(Chudovishta[i].Pic.Bounds))
                    {
                        Chudovishta[i].Pic.Location = new Point(50, -100);
                    }
                }
                if (Igrach.Pic.Bounds.IntersectsWith(Chudovishta[i].Pic.Bounds))
                {
                    Igrach.Pic.Visible = false;
                }
            }
        }
        private void GameStop()
        {
            EnemiesMove.Stop();
            ElfProjectileMove.Stop();
        }
    }
}
