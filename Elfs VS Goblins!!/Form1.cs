using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
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

        bool stoped = false;
        bool over = false;

        PictureBox Bow = new PictureBox();
        Elf Igrach = new Elf();

        int level = -2;
        bool LevelEnded = false;

        PictureBox Wizard = new PictureBox();
        Label WizardSpeak = new Label();
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

        Point A  =new Point(20,10);
        Point B = new Point(120,10);
        Point C = new Point(220,10);
        Point D = new Point(320,10);
        Point E = new Point(420,10);
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
                Pic.BackColor = Color.Purple; // tuk shte sa strelite
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

            ElfPic.Image = Image.FromFile("sprites/melf-static.gif");
            Igrach.Pic = ElfPic;
            Igrach.XP = 0;
            
            Bow.Location = new Point(200,100);
            Bow.Size = new Size(70,70);
            Bow.SizeMode = PictureBoxSizeMode.StretchImage;
            Bow.Image = Image.FromFile("sprites/bow.gif");
            this.Controls.Add(Bow);

            this.Controls.Add(Wizard);
            this.Controls.Add(WizardSpeak);
        }
        private void Nachalo_Tick(object sender, EventArgs e)
        {
            if (Igrach.Pic.Bounds.IntersectsWith(Bow.Bounds)&&level ==-2)
            {
                Bow.Dispose();
                Igrach.Pic.Image = Image.FromFile("sprites/melf-bow.gif");
                stoped = true;

                Wizard.Size = new Size(500, 200);
                Wizard.Location = new Point(0, 350);
                Wizard.SizeMode = PictureBoxSizeMode.StretchImage;
                Wizard.Image = Image.FromFile("PlaceHolders/Wizard.png");
                Wizard.BringToFront();
                Wizard.Visible = true;

                WizardSpeak.Text = "Bla bla bla bla \n Take this bow";
                WizardSpeak.Location = new Point(50, 450);
                WizardSpeak.AutoSize = true;
                WizardSpeak.Font = new Font("Arial", 15);
                WizardSpeak.BringToFront();
                WizardSpeak.Visible = true;

                level++;
            }
            if ((Igrach.Pic.Top <= -30))
            {
                Igrach.Pic.Location = new Point(200, 450);
                Controls1.Image = Image.FromFile("PlaceHolders/Controls.png");
                Controls1.Visible = true;
                Controls1.BringToFront();
                stoped = true;
                level++;
            }
            if ((!Controls1.Visible)&&speak==2&&level==0)
                GameStart();
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
            if (Igrach.Pic.Top < 450)
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
            if (e.KeyCode == Keys.Z && !over)
            {
                Controls1.Visible = false;
            }
            if(e.KeyCode == Keys.Space && !over&&stoped)
            {
                speak++;
                if(speak==1)
                {
                    WizardSpeak.Text = "Save the forest\nGood luck!";
                }
                else if(speak==2)
                {
                    WizardSpeak.Visible =false;
                    Wizard.Visible = false;
                    stoped = false;
                }

                // tuk tryabva da se dobavi i picture box koito obyasnyava kak se dvizhat chudovishtata i kak atakuvat
                // s Pravila i oshte if - ove 

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
                    Magiya[i].Pic.Location = new Point(Igrach.Pic.Location.X + 60, Igrach.Pic.Location.Y + 70 - i * 15);
                }
            }
            Collisions();
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
                x.Pic.Location = new Point(Goblini[j].Pic.Location.X + 35, Goblini[j].Pic.Location.Y + 80);
                this.Controls.Add(x.Pic);
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
                        Magiya[j].Pic.Location = new Point(Igrach.Pic.Location.X + 60, Igrach.Pic.Location.Y + 70 - j * 15);
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
                        Magiya[j].Pic.Location = new Point(Igrach.Pic.Location.X + 60, Igrach.Pic.Location.Y + 70 - j * 15);
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
                        Magiya[j].Pic.Location = new Point(Igrach.Pic.Location.X + 60, Igrach.Pic.Location.Y + 70 - j * 15);
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
                    Igrach.Pic.Location = new Point(200, 450);
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
                    Igrach.Pic.Location = new Point(200, 450);
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
                    Igrach.Pic.Location = new Point(200, 450);
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
            Hearts.Visible = true;
            label1.Visible = true;
            XPbar.Visible = true;

            Magiya = new ElfProjectile[3];
            for (int i = 0; i < 3; i++)
            {
                Magiya[i] = new ElfProjectile();
                this.Controls.Add(Magiya[i].Pic);
                Magiya[i].Pic.BringToFront();
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
                    Chudovishta.Add(g);
                    Goblini.Add(g);
                    break;
                case 5:
                    var t = new Tank(P.X, P.Y);
                    this.Controls.Add(t.Pic);
                    Chudovishta.Add(t);
                    Tankove.Add(t);
                    TankoveDeathLine.Add(t);
                    break;
                case 6: 
                case 7:
                    var d = new Demon(P.X, P.Y);
                    this.Controls.Add(d.Pic);
                    Chudovishta.Add(d);
                    Demoni.Add(d);
                    break;
                case 8:
                    var ap = new Apple(P.X, P.Y);
                    this.Controls.Add(ap.Pic);
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
                    this.Controls.Add(g.Pic);
                    Chudovishta.Add(g);
                    Goblini.Add(g);
                    break;
                case 5:
                    var t = new Tank(P.X, P.Y);
                    this.Controls.Add(t.Pic);
                    Chudovishta.Add(t);
                    Tankove.Add(t);
                    TankoveDeathLine.Add(t);
                    break;
                case 6:
                case 7:
                case 8:
                    var d = new Demon(P.X, P.Y);
                    this.Controls.Add(d.Pic);
                    Chudovishta.Add(d);
                    Demoni.Add(d);
                    break;
                case 9:
                    var ap = new Apple(P.X, P.Y);
                    this.Controls.Add(ap.Pic);
                    Yabulki.Add(ap);
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
                    Hearts.Image = Image.FromFile("PlaceHolders/5heart.png");
                    break;
                case 4:
                    Hearts.Image = Image.FromFile("PlaceHolders/4heart.png");
                    break;
                case 3:
                    Hearts.Image = Image.FromFile("PlaceHolders/3heart.png");
                    break;
                case 2:
                    Hearts.Image = Image.FromFile("PlaceHolders/2heart.png");
                    break;
                case 1:
                    Hearts.Image = Image.FromFile("PlaceHolders/1heart.png");
                    break;
                case 0:
                    Hearts.Image = Image.FromFile("PlaceHolders/0heart.png");
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
                    GameWon(); //vremenno 
                    //EndofLevel();
                    //kartinka/cvyat 
                    
                }
            }
            else if(level ==3)
            {
                if (Igrach.XP < XPlevel2)
                    XPbar.Value = (Igrach.XP * 100) / XPlevel2;
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
        }
        private void CheckIfLevelEnded()
        {
            if (LevelEnded &&Chudovishta.Count == 0 &&Yabulki.Count == 0)
            {
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
                BackColor = Color.PaleTurquoise;
            }
            else if(level==3)
            {
                // bla bla
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
