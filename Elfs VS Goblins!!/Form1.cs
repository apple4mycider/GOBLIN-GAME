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
        List <Enemy> Chudovishta;
        public class Enemy
        {
            public int Speed ;
            public int Health ;
            public PictureBox picture;
            public int x;
            public int y;
            public int XP;
            public Enemy(int a, int b)
            {
                picture = new PictureBox();
                picture.Location = new Point(a, b);
                picture.Size = new Size(x, y);
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
                picture = new PictureBox();
                picture.Location = new Point(a, b);
                picture.Size = new Size(x, y);
                picture.Image = Image.FromFile("sprites/apple-export.gif"); 

            }
        }
        
        public class Elf
        {
            public int Health = 1;
            public PictureBox Pic;
            public int ShootingSpeed;
        }

        public Form1()
        {
            InitializeComponent();
            rand = new Random();
            Chudovishta = new List <Enemy>();
            timer1.Start();
            Goblin test = new Goblin(rand.Next(20, 450), 10);
            this.Controls.Add(test.picture);
            Chudovishta.Add(test);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach(var a in Chudovishta)
            {
                a.picture.Top += a.Speed;
                if(a.picture.Top>=this.Height)
                {
                    a.picture.Dispose();
                }
            }
        }
    }
}
