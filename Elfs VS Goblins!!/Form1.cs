using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elfs_VS_Goblins__
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        ElfProjectile[] Magiya;
        int CoolDown = 0;
        PictureBox[]Surca = new PictureBox[5];

        bool stoped = false;
        bool over = false;

        PictureBox Wizard = new PictureBox();
        PictureBox Bow = new PictureBox();
        PictureBox Staff = new PictureBox();
        Elf Igrach = new Elf();

        int SceneBreak = 0;
        int level = -2;
        bool LevelEnded = false;

        PictureBox WizardTalk = new PictureBox();
        System.Windows.Forms.Label WizardSpeak = new System.Windows.Forms.Label();
        int speak = 0;

        List<Enemy> Chudovishta = new List<Enemy>();
        List<Tank> Tankove = new List<Tank>();
        List<Goblin> Goblini = new List<Goblin>();
        List <Demon> Demoni  = new List<Demon>();
        List<Apple> Yabulki = new List<Apple>();
        List<Tank> TankoveDeathLine = new List<Tank>();

        List <GoblinProjectile> Kamuni = new List<GoblinProjectile>();
        List <DemonProjectile> Ogun = new List<DemonProjectile>();

        PictureBox Pravila = new PictureBox(); //obyasnyavat kakvo pravyat chudovishtata
                                               //mozhe be magyosnikut go kazva

        int XPlevel1 = 30; // vremenna st-st // kolko?
        int XPlevel2 = 60; // vremenno
        int XPlevel3;

        Point Default = new Point(250, 500);
        Point A  =new Point(50,10);
        Point B = new Point(150,10);
        Point C = new Point(250,10);
        Point D = new Point(350,10);
        Point E = new Point(450,10);
        public class ElfProjectile// tryabva otdelen za magiya i za streli ; magiyata mazhe da bie poveche?
        {
            public int speed = 10;
            public PictureBox Pic;
            protected int x = 6;
            protected int y = 15;
            public ElfProjectile()
            {
                Pic = new PictureBox();
                Pic.Size = new Size(x, y);
                Pic.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        public class GoblinProjectile
        {
            public int speed = 10;
            public PictureBox Pic;
            private int x = 10;
            private int y = 10;
            public GoblinProjectile()
            {
                Pic = new PictureBox();
                Pic.Size = new Size(x, y);
                Pic.BackColor = Color.Gray;
            }
        }
        public class DemonProjectile
        {
            public int speed = 20;
            public PictureBox Pic;
            private int x = 10;
            private int y = 10;
            public DemonProjectile()
            {
                Pic = new PictureBox();
                Pic.Size = new Size(x, y);
                Pic.BackColor = Color.Red;
            }
        }
        public class Apple
        {
            public int Speed;
            private int x;
            private int y;
            public PictureBox Pic;
            public Apple(int a, int b)
            {
                x = 80;
                y = 80;
                Speed = 2;
                Pic = new PictureBox();
                Pic.Location = new Point(a, b);
                Pic.Size = new Size(x, y);
                Pic.SizeMode = PictureBoxSizeMode.StretchImage;
                Pic.Image = Image.FromFile("sprites/apple-export.gif");
            }
        }
        public class Enemy
        {
            public int Speed;
            public int MaxHealth;
            public int Health;
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
            public Goblin(int a, int b) : base(a, b)
            {
                x = 80;
                y = 80;
                MaxHealth = 4;
                Health = 4;
                Speed = 2;
                XP = 5;
                Pic = new PictureBox();
                Pic.Location = new Point(a, b);
                Pic.Size = new Size(x, y);
                Pic.SizeMode = PictureBoxSizeMode.StretchImage;
                Pic.Image = Image.FromFile("PlaceHolders/Goblin.png"); 
            }
        }
        public class Tank : Enemy
        {
            public int DeathLine;
            public Tank(int a, int b) : base(a, b)
            {
                
                x = 100;
                y = 100;
                MaxHealth = 10;
                Health = 10;
                Speed = 1;
                XP = 15;
                DeathLine  = 200;
                Pic = new PictureBox();
                Pic.Location = new Point(a, b);
                Pic.Size = new Size(x, y);
                Pic.SizeMode = PictureBoxSizeMode.StretchImage;
                Pic.Image = Image.FromFile("PlaceHolders/Tank.png");
                
            }
        }
        public class Demon : Enemy
        {
            public Demon(int a, int b) : base(a, b)
            {
                x = 60;
                y = 60;
                MaxHealth = 2;
                Health = 2;
                Speed = 3;
                XP = 2;
                Pic = new PictureBox();
                Pic.Location = new Point(a, b);
                Pic.Size = new Size(x, y);
                Pic.SizeMode = PictureBoxSizeMode.StretchImage;
                Pic.Image = Image.FromFile("PlaceHolders/Demon.png");
            }
        }
        public class Elf
        {
            public int MaxHealth = 5;
            public int Health = 5;
            public PictureBox Pic;
            public int speed = 4;
            public int ShootingSpeed;
            public int XP;
        }
        

        public Form1()
        {
            InitializeComponent();

            BackgroundAndHearts();

            
            ElfPic.Image = Image.FromFile("sprites/melf-static2.gif");
            Igrach.Pic = ElfPic;
            Igrach.Pic.Size = new Size(50, 70);
            Igrach.XP = 0;
            
            Bow.Location = new Point(250,300);
            Bow.Size = new Size(70,70);
            Bow.SizeMode = PictureBoxSizeMode.StretchImage;
            Bow.Image = Image.FromFile("sprites/bow.gif");
            this.Controls.Add(Bow);
            Bow.BringToFront();

            Wizard.Location = new Point(340, 220);
            Wizard.Size = new Size(60, 135);
            Wizard.SizeMode = PictureBoxSizeMode.StretchImage;
            Wizard.Image = Image.FromFile("sprites/the wiz.gif");
            this.Controls.Add(Wizard);
            Wizard.BringToFront();

            this.Controls.Add(WizardTalk);
            WizardTalk.Visible = false;
            WizardTalk.Parent = Background;
            WizardTalk.BackColor = Color.Transparent;
        }
        private void BackgroundAndHearts()
        {
            Surca[0] = Hearts1;
            Surca[1] = Hearts2;
            Surca[2] = Hearts3;
            Surca[3] = Hearts4;
            Surca[4] = Hearts5;
            for (int i = 0;i <5; i++)
            {
                Surca[i].BackColor = Color.Transparent;
                Surca[i].Parent = Frame;
                Surca[i].Image = Image.FromFile("sprites/Heart.png");
                Surca[i].Visible = true;
                Surca[i].BringToFront();
            }

            Frame.BackColor = Color.Transparent;
            Frame.Parent = Background;
            Frame.Image = Image.FromFile("sprites/Frame.png");
            Background.Image = Image.FromFile("sprites/Level1.png");
        }
        private void Napred(PictureBox p)
        {
            p.BringToFront();
            Frame.BringToFront();
            for (int i = 0; i < 5; i++)
            {
                Surca[i].BringToFront();
            }
            
        }
        private void Nachalo_Tick(object sender, EventArgs e)
        {
            if (Igrach.Pic.Bounds.IntersectsWith(Bow.Bounds)&&level ==-2)
            {
                Bow.Dispose();
                Igrach.Pic.Image = Image.FromFile("sprites/melf-bow2.gif");
                stoped = true;

                WizardTalk.Size = new Size(570, 200);
                WizardTalk.Location = new Point(20, 400);
                WizardTalk.SizeMode = PictureBoxSizeMode.StretchImage;
                WizardTalk.Image = Image.FromFile("sprites/wizard1.png");
                WizardTalk.BringToFront();
                WizardTalk.Visible = true;

                level++;
            }
            if ((Igrach.Pic.Top <= 50)&&level==-1)
            {
                Igrach.Pic.Location = Default;
                GameStart();
                level++;
            }
        }

        private void timer1_Tick(object sender, EventArgs e) //enemies and apples move
        {
            for (int i = Chudovishta.Count - 1; i >= 0; i--)
            {
                Chudovishta[i].Pic.Top += Chudovishta[i].Speed;

                if (Chudovishta[i].Pic.Top >= this.Height)
                {
                    Chudovishta[i].Pic.Dispose();
                    Chudovishta.RemoveAt(i);
                    CheckIfLevelEnded();
                }
            }
            for (int i = TankoveDeathLine.Count - 1; i >= 0; i--)
            {
                if (TankoveDeathLine[i].Pic.Top >= 400)
                {
                    Igrach.Health--;
                    if (Igrach.Health <= 0)
                        over = true;
                    HeartUpdate();
                    TankoveDeathLine.RemoveAt(i);
                }
            }
            for (int i = Yabulki.Count - 1; i >= 0; i--)
            {
                Yabulki[i].Pic.Top += Yabulki[i].Speed;
                if (Yabulki[i].Pic.Top >= this.Height)
                {
                    Yabulki[i].Pic.Dispose();
                    Yabulki.RemoveAt(i);
                    CheckIfLevelEnded();
                }
            }
        }

        private void MoveDown_Tick(object sender, EventArgs e)
        {
            if (Igrach.Pic.Top < 540)
            {
                Igrach.Pic.Top += Igrach.speed;
            }
        }

        private void MoveUp_Tick(object sender, EventArgs e)
        {
            if (Igrach.Pic.Top > 0)
            {
                Igrach.Pic.Top -= Igrach.speed;
            }
        }

        private void MoveRight_Tick(object sender, EventArgs e)
        {
            if (Igrach.Pic.Right < 520)
            {
                Igrach.Pic.Left += Igrach.speed;
            }
        }

        private void MoveLeft_Tick(object sender, EventArgs e)
        {
            if (Igrach.Pic.Left > 50)
            {
                Igrach.Pic.Left -= Igrach.speed;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Down | e.KeyCode == Keys.S) && !stoped && !over)
            {
                MoveDown.Start();
            }
            if ((e.KeyCode == Keys.Up | e.KeyCode == Keys.W) && !stoped && !over)
            {
                MoveUp.Start();
            }
            if ((e.KeyCode == Keys.Left | e.KeyCode == Keys.A) && !stoped&&!over)
            {
                MoveLeft.Start();
            }
            if ((e.KeyCode == Keys.Right | e.KeyCode == Keys.D) && !stoped&&!over)
            {
                MoveRight.Start();
            }
            if (e.KeyCode == Keys.P && !over&&!stoped&&level>=0)
            {
                GameStop();
            }
            if (e.KeyCode == Keys.C && !over&&stoped&&level>=0)
            {
                GameContinue();
            }
            if(e.KeyCode == Keys.Space && !over&&stoped)
            {
                if (WizardTalk.Visible)
                {
                    speak++;
                    if (speak == 1)
                    {
                        WizardTalk.Image = Image.FromFile("sprites/wizard2.png");
                    }
                    else if(speak ==2)
                    {
                        WizardTalk.Image = Image.FromFile("sprites/wizard3.png");
                    }
                    else if (speak == 3)
                    {
                        WizardTalk.Image = Image.FromFile("sprites/wizard4.png");
                    }
                    else if (speak == 4)
                    {
                        WizardTalk.Visible = false;
                        Wizard.Dispose();
                        stoped = false;
                    }
                }
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
                if (Magiya[i].Pic.Top > 0)
                {
                    Magiya[i].Pic.Visible = true;
                    Magiya[i].Pic.Top -= Magiya[i].speed;
                }
                else
                {
                    Magiya[i].Pic.Visible = false;
                    int a = rand.Next(0,3);
                    switch(a)
                    {
                        case 0:
                            Magiya[i].Pic.Image = Image.FromFile("sprites/arrow1.png");
                            break;
                        case 1:
                            Magiya[i].Pic.Image = Image.FromFile("sprites/arrow2.png");
                            break;
                        case 2:
                            Magiya[i].Pic.Image = Image.FromFile("sprites/arrow3.png");
                            break;
                    }
                    Magiya[i].Pic.Location = new Point(Igrach.Pic.Location.X + 20, Igrach.Pic.Location.Y + 45 - i * 10);
                }
            }
            Collisions();
            StaffScene();
            CoolDown++;
            if(CoolDown>10)
                CollisionsElf();
            if (over)
            {
                GameOver();
            }
        }

        private void EnemyProjectileMove_Tick(object sender, EventArgs e)
        {
            for (int i = Kamuni.Count - 1; i >= 0; i--)
            {
                Kamuni[i].Pic.Top += Kamuni[i].speed;

                if (Kamuni[i].Pic.Top >= this.Height)
                {
                    Kamuni[i].Pic.Dispose();
                    Kamuni.RemoveAt(i);
                }
            }
            for (int i = Ogun.Count - 1; i >= 0; i--)
            {
                Ogun[i].Pic.Top += Ogun[i].speed;

                if (Ogun[i].Pic.Top >= this.Height)
                {
                    Ogun[i].Pic.Dispose();
                    Ogun.RemoveAt(i);
                }
            }
        }
        private void EnemyShoot_Tick(object sender, EventArgs e) //GoblinShoot
        {
            if (Goblini.Count > 0)
            {
                int j = rand.Next(0, Goblini.Count);
                var x = new GoblinProjectile();
                x.Pic.Location = new Point(Goblini[j].Pic.Location.X + 20, Goblini[j].Pic.Location.Y + 80);
                this.Controls.Add(x.Pic);
                Napred(x.Pic);
                Kamuni.Add(x);
            }
        }
        private void DemonShoot_Tick(object sender, EventArgs e)
        {
            if (Demoni.Count > 0)
            {
                int k = rand.Next(0, Demoni.Count);
                var x = new DemonProjectile();
                x.Pic.Location = new Point(Demoni[k].Pic.Location.X + 35, Demoni[k].Pic.Location.Y + 80);
                this.Controls.Add(x.Pic);
                Napred(x.Pic);
                Ogun.Add(x);
            }
        }

        private void Collisions()
        {
            for (int j = 0; j < Magiya.Length; j++)
            {
                for (int i = Goblini.Count - 1; i >= 0; i--)
                {
                    Goblin g = Goblini[i];
                    if (Magiya[j].Pic.Visible && Magiya[j].Pic.Bounds.IntersectsWith(g.Pic.Bounds))
                    {
                        g.Health--;
                        Magiya[j].Pic.Visible = false;
                        Magiya[j].Pic.Location = new Point(Igrach.Pic.Location.X + 25, Igrach.Pic.Location.Y + 45 - j * 10);
                        if (g.Health == 0)
                        {
                            Igrach.XP += g.XP;
                            XPUpdate();
                            g.Pic.Dispose();
                            Goblini.RemoveAt(i);
                            Chudovishta.Remove(g);
                            CheckIfLevelEnded();
                        }
                    }
                }
                for (int i = Demoni.Count - 1; i >= 0; i--)
                {
                    Demon d = Demoni[i];
                    if (Magiya[j].Pic.Visible && Magiya[j].Pic.Bounds.IntersectsWith(d.Pic.Bounds))
                    {
                        d.Health--;
                        Magiya[j].Pic.Visible = false;
                        Magiya[j].Pic.Location = new Point(Igrach.Pic.Location.X + 25, Igrach.Pic.Location.Y + 45 - j * 10);
                        if (d.Health == 0)
                        {
                            Igrach.XP += d.XP;
                            XPUpdate();
                            d.Pic.Dispose();
                            Demoni.RemoveAt(i);
                            Chudovishta.Remove(d);
                            CheckIfLevelEnded();
                        }
                    }
                }
                for (int i = Tankove.Count - 1; i >= 0; i--)
                {
                    Tank t = Tankove[i];
                    if (Magiya[j].Pic.Visible && Magiya[j].Pic.Bounds.IntersectsWith(t.Pic.Bounds))
                    {
                        t.Health--;
                        Magiya[j].Pic.Visible = false;
                        Magiya[j].Pic.Location = new Point(Igrach.Pic.Location.X + 25, Igrach.Pic.Location.Y + 45 - j * 10);
                        if (t.Health == 0)
                        {
                            Igrach.XP += t.XP;
                            XPUpdate();
                            t.Pic.Dispose();
                            Tankove.RemoveAt(i);
                            Chudovishta.Remove(t);
                            CheckIfLevelEnded();
                        }
                    }
                }
            }

            for (int i = Yabulki.Count - 1; i >= 0; i--)
            {
                if (Yabulki[i].Pic.Bounds.IntersectsWith(Igrach.Pic.Bounds))
                {
                    if (Igrach.Health < Igrach.MaxHealth)
                    {
                        Igrach.Health++;
                        HeartUpdate();
                    }
                    Yabulki[i].Pic.Dispose();
                    Yabulki.RemoveAt(i);
                    CheckIfLevelEnded();
                }
            }
        }
        private void CollisionsElf()
        {
            for (int i = Chudovishta.Count - 1; i >= 0; i--)
            {
                Enemy ch = Chudovishta[i];
                if (Igrach.Pic.Bounds.IntersectsWith(ch.Pic.Bounds))
                {
                    Igrach.Health--;
                    HeartUpdate();
                    CoolDown = 0;
                    Igrach.Pic.Location = Default;
                    if (Igrach.Health == 0)
                    {
                        over = true;
                    }
                }
            }
            for (int i = Kamuni.Count - 1; i >= 0; i--)
            {
                GoblinProjectile k = Kamuni[i];
                if (Igrach.Pic.Bounds.IntersectsWith(k.Pic.Bounds))
                {
                    Igrach.Health--;
                    HeartUpdate();
                    CoolDown = 0;
                    Igrach.Pic.Location = Default;
                    if (Igrach.Health == 0)
                    {
                        over = true;
                    }
                }
            }
            for (int i = Ogun.Count - 1; i >= 0; i--)
            {
                DemonProjectile o = Ogun[i];
                if (Igrach.Pic.Bounds.IntersectsWith(o.Pic.Bounds))
                {
                    Igrach.Health--;
                    HeartUpdate();
                    CoolDown = 0;
                    Igrach.Pic.Location = Default;
                    if (Igrach.Health == 0)
                    {
                        over = true;
                    }
                }
            }
        }
        private void GameStart()
        {
            EnemiesMove.Start();
            ElfProjectileMove.Start();
            Nachalo.Stop();
            EnemyCreate.Start();
            GoblinShoot.Start();
            DemonShoot.Start();
            EnemyProjectileMove.Start();

            stoped  = false;
            level++;
            label2.Visible = true;
            label3.Text = level.ToString();
            label3.Visible = true;

            Magiya = new ElfProjectile[3];
            for (int i = 0; i < 3; i++)
            {
                Magiya[i] = new ElfProjectile();
                this.Controls.Add(Magiya[i].Pic);
                Magiya[i].Pic.BringToFront();
                int a = rand.Next(0, 3);
                switch (a)
                {
                    case 0:
                        Magiya[i].Pic.Image = Image.FromFile("sprites/arrow1.png");
                        break;
                    case 1:
                        Magiya[i].Pic.Image = Image.FromFile("sprites/arrow2.png");
                        break;
                    case 2:
                        Magiya[i].Pic.Image = Image.FromFile("sprites/arrow3.png");
                        break;
                }
            }

        }
        private void EnemyCreate_Tick(object sender, EventArgs e)
        {
            if (level == 1)
            {
                for (int i = 0; i < 5; i++)
                {
                    switch (i)
                    {
                        case 0:
                            Type1(A);
                            break;
                        case 1:
                            Type1(B);
                            break;
                        case 2:
                            Type1(C);
                            break;
                        case 3:
                            Type1(D);
                            break;
                        case 4:
                            Type1(E);
                            break;
                    }
                }
            }
            else if (level == 2)
            {
                for (int i = 0; i < 5; i++)
                {
                    switch (i)
                    {
                        case 0:
                            Type2(A);
                            break;
                        case 1:
                            Type2(B);
                            break;
                        case 2:
                            Type2(C);
                            break;
                        case 3:
                            Type2(D);
                            break;
                        case 4:
                            Type2(E);
                            break;
                    }
                }
            }
            else if (level == 3)
            {

            }
        }
        private void Type1(Point P) //nivo 1
        {
            int a = rand.Next(0,9); 
            switch (a)
            {
                // 0 i 1 prazni
                case 2:
                case 3:
                case 4:
                    var g = new Goblin(P.X, P.Y);
                    this.Controls.Add(g.Pic);
                    g.Pic.Image = Image.FromFile("PlaceHolders/Goblin.png");
                    Napred(g.Pic);
                    Chudovishta.Add(g);
                    Goblini.Add(g);
                    break;
                case 5:
                    var t = new Tank(P.X, P.Y);
                    this.Controls.Add(t.Pic);
                    Napred(t.Pic);
                    Chudovishta.Add(t);
                    Tankove.Add(t);
                    TankoveDeathLine.Add(t);
                    break;
                case 6: 
                case 7:
                    var d = new Demon(P.X, P.Y);
                    this.Controls.Add(d.Pic);
                    Napred(d.Pic);
                    Chudovishta.Add(d);
                    Demoni.Add(d);
                    break;
                case 8:
                    var ap = new Apple(P.X, P.Y);
                    this.Controls.Add(ap.Pic);
                    Napred(ap.Pic);
                    Yabulki.Add(ap);
                    break;
            }
        }
        private void Type2(Point P) // nivo 2
        {
            int a = rand.Next(0, 10); // mozhe da se promeni ratio-to
            switch (a)
            {
                // 0  prazni
                case 1:
                case 2:
                case 3:
                case 4:
                    var g = new Goblin(P.X, P.Y);
                    g.Pic.Image = Image.FromFile("sprites/foxy.gif");
                    Chudovishta.Add(g);
                    Goblini.Add(g);
                    this.Controls.Add(g.Pic);
                    Napred(g.Pic);
                    break;
                case 5:
                    var t = new Tank(P.X, P.Y);
                    // kartinka
                    Chudovishta.Add(t);
                    Tankove.Add(t);
                    TankoveDeathLine.Add(t);
                    this.Controls.Add(t.Pic);
                    Napred(t.Pic);
                    break;
                case 6:
                case 7:
                case 8:
                    var d = new Demon(P.X, P.Y);
                    // kartinka
                    Chudovishta.Add(d);
                    Demoni.Add(d);
                    this.Controls.Add(d.Pic);
                    Napred(d.Pic);
                    break;
                case 9:
                    var ap = new Apple(P.X, P.Y);
                    // kartinka
                    Yabulki.Add(ap);
                    this.Controls.Add(ap.Pic);
                    Napred(ap.Pic);
                    break;
            }
        }
        private void Type3 (Point P) // v momenta e sushtoto kato 2 i ne e izpolzvano
        {
            int a = rand.Next(0, 10); // mozhe da se promeni ratio-to
            switch (a)
            {
                // 0  prazni
                case 1:
                case 2:
                case 3:
                case 4:
                    var g = new Goblin(P.X, P.Y);
                    g.Pic.Image = Image.FromFile("sprites/foxy.gif");
                    Chudovishta.Add(g);
                    Goblini.Add(g);
                    this.Controls.Add(g.Pic);
                    Napred(g.Pic);
                    break;
                case 5:
                    var t = new Tank(P.X, P.Y);
                    // kartinka
                    Chudovishta.Add(t);
                    Tankove.Add(t);
                    TankoveDeathLine.Add(t);
                    this.Controls.Add(t.Pic);
                    Napred(t.Pic);
                    break;
                case 6:
                case 7:
                case 8:
                    var d = new Demon(P.X, P.Y);
                    // kartinka
                    Chudovishta.Add(d);
                    Demoni.Add(d);
                    this.Controls.Add(d.Pic);
                    Napred(d.Pic);
                    break;
                case 9:
                    var ap = new Apple(P.X, P.Y);
                    // kartinka
                    Yabulki.Add(ap);
                    this.Controls.Add(ap.Pic);
                    Napred(ap.Pic);
                    break;
            }
        }
        private void GameStop()
        {
            EnemiesMove.Stop();
            ElfProjectileMove.Stop();
            EnemyCreate.Stop();
            GoblinShoot.Stop();
            DemonShoot.Stop();
            EnemyProjectileMove.Stop();
            stoped = true;
            Something.BringToFront();
            //location
            Something.Size = new Size(411,207);
            Something.Image = Image.FromFile("PlaceHolders/Paused.png");
            Something.Visible = true;
        }
        private void GameContinue()
        {
            EnemiesMove.Start();
            ElfProjectileMove.Start();
            EnemyCreate.Start();
            GoblinShoot.Start();
            DemonShoot.Start();
            EnemyProjectileMove.Start();

            stoped = false;
            Something.Visible = false;
        }
        private void GameOver()
        {
            EnemiesMove.Stop();
            ElfProjectileMove.Stop();
            EnemyCreate.Stop();
            GoblinShoot.Stop();
            DemonShoot.Stop();
            EnemyProjectileMove.Stop();
            stoped = true;

            Something.BringToFront();
            //location
            Something.Size = new Size(330,445);
            Something.Image = Image.FromFile("PlaceHolders/GameOver.png");
            Something.Visible = true;
        }
        private void HeartUpdate()
        {
            switch (Igrach.Health)
            {
                case 5:
                    Hearts1.Visible = true;
                    Hearts2.Visible = true;
                    Hearts3.Visible = true;
                    Hearts4.Visible = true;
                    Hearts5.Visible = true;
                    break;
                case 4:
                    Hearts1.Visible = true;
                    Hearts2.Visible = true;
                    Hearts3.Visible = true;
                    Hearts4.Visible = true;
                    Hearts5.Visible = false;
                    break;
                case 3:
                    Hearts1.Visible = true;
                    Hearts2.Visible = true;
                    Hearts3.Visible = true;
                    Hearts4.Visible = false;
                    Hearts5.Visible = false;
                    break;
                case 2:
                    Hearts1.Visible = true;
                    Hearts2.Visible = true;
                    Hearts3.Visible = false;
                    Hearts4.Visible = false;
                    Hearts5.Visible = false;
                    break;
                case 1:
                    Hearts1.Visible = true;
                    Hearts2.Visible = false;
                    Hearts3.Visible = false;
                    Hearts4.Visible = false;
                    Hearts5.Visible = false;
                    break;
                case 0:
                    Hearts1.Visible = false;
                    Hearts2.Visible = false;
                    Hearts3.Visible = false;
                    Hearts4.Visible = false;
                    Hearts5.Visible = false;
                    break;
            }
        }
        private void XPUpdate()
        {
            if(level==1)
            {
                if(Igrach.XP<XPlevel1)
                    XPbar.Value = (Igrach.XP*100) / XPlevel1;
                else
                {
                    XPbar.Value = 100;
                    EndOfLevel();
                }
            }
            else if(level==2)
            {
                if (Igrach.XP < XPlevel2)
                    XPbar.Value = (Igrach.XP *100)/ XPlevel2;
                else
                {
                    XPbar.Value = 100;
                    EndOfLevel();
                    
                }
            }
            else if(level ==3)
            {
                if (Igrach.XP < XPlevel3)
                    XPbar.Value = (Igrach.XP * 100) / XPlevel3;
                else
                {
                    //EndofLevel();
                    //kartinka / cvyat
                }
            }
        }
        private void EndOfLevel()
        {
            EnemyCreate.Stop();
            LevelEnded = true;
            if(level==2&&SceneBreak==0)
            {
                SceneBreak = 1;
            }
        }
        private void StaffScene()
        {
            if (Chudovishta.Count == 0 && Yabulki.Count == 0&&SceneBreak==1)
            {
                ElfProjectileMove.Stop();
                for (int i = 0;i<Magiya.Length;i++)
                {
                    Magiya[i].Pic.Dispose();
                }
                MagicStaff.Start();
                Staff.Location = new Point(200, 100);
                Staff.Size = new Size(70, 70);
                Staff.SizeMode = PictureBoxSizeMode.StretchImage;
                Staff.Image = Image.FromFile("sprites/wand.gif");
                this.Controls.Add(Staff);
                Staff.BringToFront();
            }
        }
        private void MagicStaff_Tick(object sender, EventArgs e)
        {

            if (Igrach.Pic.Bounds.IntersectsWith(Staff.Bounds))
            {
                Staff.Dispose();
                Igrach.Pic.Image = Image.FromFile("sprites/melf-wand2.gif");
                SceneBreak++;
            }
            if (Igrach.Pic.Top <= -30 && SceneBreak == 2)
            {
                SceneBreak = 0;
                Igrach.Pic.Location = Default;
                ElfProjectileMove.Start();
                CheckIfLevelEnded();
            }
            
        }
        private void CheckIfLevelEnded()
        {
            if (LevelEnded &&Chudovishta.Count == 0 &&Yabulki.Count == 0&&SceneBreak==0)
            {
                MagicStaff.Stop();
                StartOfLevel();
            }
        }
        private void StartOfLevel()
        {
            EnemyCreate.Start();
            LevelEnded = false;
            Igrach.XP = 0;
            level++;
            label3.Text = level.ToString();
            XPbar.Value = 0;
            if(level==2)
            {
                // + bg image
                BackColor = Color.PaleTurquoise;
            }
            else if(level==3)
            {
                
            }
        }

        private void GameWon()
        {
            EnemiesMove.Stop();
            ElfProjectileMove.Stop();
            EnemyCreate.Stop();
            GoblinShoot.Stop();
            DemonShoot.Stop();
            EnemyProjectileMove.Stop();
            stoped = true;

            Something.BringToFront();
            //location
            Something.Size = new Size(450, 330);
            Something.Image = Image.FromFile("PlaceHolders/YouWon.png");
            Something.Visible = true;
        }

        
    }
}
