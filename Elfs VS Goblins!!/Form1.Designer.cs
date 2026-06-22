namespace Elfs_VS_Goblins__
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.EnemiesMove = new System.Windows.Forms.Timer(this.components);
            this.MoveLeft = new System.Windows.Forms.Timer(this.components);
            this.MoveRight = new System.Windows.Forms.Timer(this.components);
            this.MoveUp = new System.Windows.Forms.Timer(this.components);
            this.MoveDown = new System.Windows.Forms.Timer(this.components);
            this.ElfProjectileMove = new System.Windows.Forms.Timer(this.components);
            this.Nachalo = new System.Windows.Forms.Timer(this.components);
            this.XPbar = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.EnemyCreate = new System.Windows.Forms.Timer(this.components);
            this.EnemyProjectileMove = new System.Windows.Forms.Timer(this.components);
            this.GoblinShoot = new System.Windows.Forms.Timer(this.components);
            this.DemonShoot = new System.Windows.Forms.Timer(this.components);
            this.MagicStaff = new System.Windows.Forms.Timer(this.components);
            this.Hearts1 = new System.Windows.Forms.PictureBox();
            this.Something = new System.Windows.Forms.PictureBox();
            this.ElfPic = new System.Windows.Forms.PictureBox();
            this.Frame = new System.Windows.Forms.PictureBox();
            this.Background = new System.Windows.Forms.PictureBox();
            this.Hearts2 = new System.Windows.Forms.PictureBox();
            this.Hearts3 = new System.Windows.Forms.PictureBox();
            this.Hearts4 = new System.Windows.Forms.PictureBox();
            this.Hearts5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Hearts1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Something)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElfPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Frame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Background)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hearts2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hearts3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hearts4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hearts5)).BeginInit();
            this.SuspendLayout();
            // 
            // EnemiesMove
            // 
            this.EnemiesMove.Enabled = true;
            this.EnemiesMove.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MoveLeft
            // 
            this.MoveLeft.Interval = 5;
            this.MoveLeft.Tick += new System.EventHandler(this.MoveLeft_Tick);
            // 
            // MoveRight
            // 
            this.MoveRight.Interval = 5;
            this.MoveRight.Tick += new System.EventHandler(this.MoveRight_Tick);
            // 
            // MoveUp
            // 
            this.MoveUp.Interval = 5;
            this.MoveUp.Tick += new System.EventHandler(this.MoveUp_Tick);
            // 
            // MoveDown
            // 
            this.MoveDown.Interval = 5;
            this.MoveDown.Tick += new System.EventHandler(this.MoveDown_Tick);
            // 
            // ElfProjectileMove
            // 
            this.ElfProjectileMove.Interval = 20;
            this.ElfProjectileMove.Tick += new System.EventHandler(this.ElfProjectileMove_Tick);
            // 
            // Nachalo
            // 
            this.Nachalo.Enabled = true;
            this.Nachalo.Interval = 5;
            this.Nachalo.Tick += new System.EventHandler(this.Nachalo_Tick);
            // 
            // XPbar
            // 
            this.XPbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(44)))), ((int)(((byte)(9)))));
            this.XPbar.ForeColor = System.Drawing.Color.LawnGreen;
            this.XPbar.Location = new System.Drawing.Point(79, 55);
            this.XPbar.Name = "XPbar";
            this.XPbar.Size = new System.Drawing.Size(411, 37);
            this.XPbar.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(751, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Level: ";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(829, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "0";
            this.label3.Visible = false;
            // 
            // EnemyCreate
            // 
            this.EnemyCreate.Interval = 5000;
            this.EnemyCreate.Tick += new System.EventHandler(this.EnemyCreate_Tick);
            // 
            // EnemyProjectileMove
            // 
            this.EnemyProjectileMove.Interval = 120;
            this.EnemyProjectileMove.Tick += new System.EventHandler(this.EnemyProjectileMove_Tick);
            // 
            // GoblinShoot
            // 
            this.GoblinShoot.Interval = 1500;
            this.GoblinShoot.Tick += new System.EventHandler(this.EnemyShoot_Tick);
            // 
            // DemonShoot
            // 
            this.DemonShoot.Interval = 1500;
            this.DemonShoot.Tick += new System.EventHandler(this.DemonShoot_Tick);
            // 
            // MagicStaff
            // 
            this.MagicStaff.Interval = 5;
            this.MagicStaff.Tick += new System.EventHandler(this.MagicStaff_Tick);
            // 
            // Hearts1
            // 
            this.Hearts1.Location = new System.Drawing.Point(80, 1);
            this.Hearts1.Name = "Hearts1";
            this.Hearts1.Size = new System.Drawing.Size(63, 50);
            this.Hearts1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Hearts1.TabIndex = 3;
            this.Hearts1.TabStop = false;
            // 
            // Something
            // 
            this.Something.Location = new System.Drawing.Point(178, 209);
            this.Something.Name = "Something";
            this.Something.Size = new System.Drawing.Size(521, 504);
            this.Something.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Something.TabIndex = 1;
            this.Something.TabStop = false;
            this.Something.Visible = false;
            // 
            // ElfPic
            // 
            this.ElfPic.Location = new System.Drawing.Point(396, 829);
            this.ElfPic.Name = "ElfPic";
            this.ElfPic.Size = new System.Drawing.Size(50, 70);
            this.ElfPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ElfPic.TabIndex = 0;
            this.ElfPic.TabStop = false;
            // 
            // Frame
            // 
            this.Frame.Location = new System.Drawing.Point(0, 1);
            this.Frame.Name = "Frame";
            this.Frame.Size = new System.Drawing.Size(908, 106);
            this.Frame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Frame.TabIndex = 9;
            this.Frame.TabStop = false;
            // 
            // Background
            // 
            this.Background.Location = new System.Drawing.Point(-14, -6);
            this.Background.Name = "Background";
            this.Background.Size = new System.Drawing.Size(908, 971);
            this.Background.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Background.TabIndex = 8;
            this.Background.TabStop = false;
            // 
            // Hearts2
            // 
            this.Hearts2.Location = new System.Drawing.Point(150, 1);
            this.Hearts2.Name = "Hearts2";
            this.Hearts2.Size = new System.Drawing.Size(63, 50);
            this.Hearts2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Hearts2.TabIndex = 10;
            this.Hearts2.TabStop = false;
            // 
            // Hearts3
            // 
            this.Hearts3.Location = new System.Drawing.Point(221, 1);
            this.Hearts3.Name = "Hearts3";
            this.Hearts3.Size = new System.Drawing.Size(63, 50);
            this.Hearts3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Hearts3.TabIndex = 11;
            this.Hearts3.TabStop = false;
            // 
            // Hearts4
            // 
            this.Hearts4.Location = new System.Drawing.Point(292, 1);
            this.Hearts4.Name = "Hearts4";
            this.Hearts4.Size = new System.Drawing.Size(63, 50);
            this.Hearts4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Hearts4.TabIndex = 12;
            this.Hearts4.TabStop = false;
            // 
            // Hearts5
            // 
            this.Hearts5.Location = new System.Drawing.Point(363, 1);
            this.Hearts5.Name = "Hearts5";
            this.Hearts5.Size = new System.Drawing.Size(63, 50);
            this.Hearts5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Hearts5.TabIndex = 13;
            this.Hearts5.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(130)))));
            this.ClientSize = new System.Drawing.Size(878, 944);
            this.Controls.Add(this.Hearts5);
            this.Controls.Add(this.Hearts4);
            this.Controls.Add(this.Hearts3);
            this.Controls.Add(this.Hearts2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.XPbar);
            this.Controls.Add(this.Hearts1);
            this.Controls.Add(this.Something);
            this.Controls.Add(this.ElfPic);
            this.Controls.Add(this.Frame);
            this.Controls.Add(this.Background);
            this.MaximumSize = new System.Drawing.Size(900, 1000);
            this.MinimumSize = new System.Drawing.Size(900, 1000);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Hearts1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Something)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElfPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Frame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Background)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hearts2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hearts3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hearts4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hearts5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer EnemiesMove;
        private System.Windows.Forms.PictureBox ElfPic;
        private System.Windows.Forms.Timer MoveLeft;
        private System.Windows.Forms.Timer MoveRight;
        private System.Windows.Forms.Timer MoveUp;
        private System.Windows.Forms.Timer MoveDown;
        private System.Windows.Forms.Timer ElfProjectileMove;
        private System.Windows.Forms.PictureBox Something;
        private System.Windows.Forms.Timer Nachalo;
        private System.Windows.Forms.PictureBox Hearts1;
        private System.Windows.Forms.ProgressBar XPbar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer EnemyCreate;
        private System.Windows.Forms.Timer EnemyProjectileMove;
        private System.Windows.Forms.Timer GoblinShoot;
        private System.Windows.Forms.Timer DemonShoot;
        private System.Windows.Forms.Timer MagicStaff;
        private System.Windows.Forms.PictureBox Background;
        private System.Windows.Forms.PictureBox Frame;
        private System.Windows.Forms.PictureBox Hearts2;
        private System.Windows.Forms.PictureBox Hearts3;
        private System.Windows.Forms.PictureBox Hearts4;
        private System.Windows.Forms.PictureBox Hearts5;
    }
}

