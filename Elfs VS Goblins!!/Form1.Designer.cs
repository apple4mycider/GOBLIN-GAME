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
            this.label1 = new System.Windows.Forms.Label();
            this.XPbar = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.EnemyCreate = new System.Windows.Forms.Timer(this.components);
            this.Hearts = new System.Windows.Forms.PictureBox();
            this.Controls1 = new System.Windows.Forms.PictureBox();
            this.Something = new System.Windows.Forms.PictureBox();
            this.ElfPic = new System.Windows.Forms.PictureBox();
            this.EnemyProjectileMove = new System.Windows.Forms.Timer(this.components);
            this.GoblinShoot = new System.Windows.Forms.Timer(this.components);
            this.DemonShoot = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Hearts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Controls1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Something)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElfPic)).BeginInit();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "XP: ";
            this.label1.Visible = false;
            // 
            // XPbar
            // 
            this.XPbar.Location = new System.Drawing.Point(57, 73);
            this.XPbar.Name = "XPbar";
            this.XPbar.Size = new System.Drawing.Size(150, 20);
            this.XPbar.TabIndex = 5;
            this.XPbar.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(645, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Level: ";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(706, 8);
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
            // Hearts
            // 
            this.Hearts.Image = global::Elfs_VS_Goblins__.Properties.Resources._5heart;
            this.Hearts.Location = new System.Drawing.Point(12, 12);
            this.Hearts.Name = "Hearts";
            this.Hearts.Size = new System.Drawing.Size(206, 50);
            this.Hearts.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Hearts.TabIndex = 3;
            this.Hearts.TabStop = false;
            this.Hearts.Visible = false;
            // 
            // Controls1
            // 
            this.Controls1.Location = new System.Drawing.Point(115, 73);
            this.Controls1.Name = "Controls1";
            this.Controls1.Size = new System.Drawing.Size(521, 504);
            this.Controls1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Controls1.TabIndex = 2;
            this.Controls1.TabStop = false;
            this.Controls1.Visible = false;
            // 
            // Something
            // 
            this.Something.Location = new System.Drawing.Point(115, 73);
            this.Something.Name = "Something";
            this.Something.Size = new System.Drawing.Size(521, 504);
            this.Something.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Something.TabIndex = 1;
            this.Something.TabStop = false;
            this.Something.Visible = false;
            // 
            // ElfPic
            // 
            this.ElfPic.Image = global::Elfs_VS_Goblins__.Properties.Resources.melf_wand;
            this.ElfPic.Location = new System.Drawing.Point(301, 622);
            this.ElfPic.Name = "ElfPic";
            this.ElfPic.Size = new System.Drawing.Size(150, 210);
            this.ElfPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ElfPic.TabIndex = 0;
            this.ElfPic.TabStop = false;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(778, 844);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.XPbar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Hearts);
            this.Controls.Add(this.Controls1);
            this.Controls.Add(this.Something);
            this.Controls.Add(this.ElfPic);
            this.MaximumSize = new System.Drawing.Size(800, 900);
            this.MinimumSize = new System.Drawing.Size(800, 900);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Hearts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Controls1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Something)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElfPic)).EndInit();
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
        private System.Windows.Forms.PictureBox Controls1;
        private System.Windows.Forms.Timer Nachalo;
        private System.Windows.Forms.PictureBox Hearts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar XPbar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer EnemyCreate;
        private System.Windows.Forms.Timer EnemyProjectileMove;
        private System.Windows.Forms.Timer GoblinShoot;
        private System.Windows.Forms.Timer DemonShoot;
    }
}

