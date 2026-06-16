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
            this.ElfPic = new System.Windows.Forms.PictureBox();
            this.MoveLeft = new System.Windows.Forms.Timer(this.components);
            this.MoveRight = new System.Windows.Forms.Timer(this.components);
            this.MoveUp = new System.Windows.Forms.Timer(this.components);
            this.MoveDown = new System.Windows.Forms.Timer(this.components);
            this.ElfProjectileMove = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ElfPic)).BeginInit();
            this.SuspendLayout();
            // 
            // EnemiesMove
            // 
            this.EnemiesMove.Enabled = true;
            this.EnemiesMove.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ElfPic
            // 
            this.ElfPic.Image = global::Elfs_VS_Goblins__.Properties.Resources.melf_wand;
            this.ElfPic.Location = new System.Drawing.Point(303, 443);
            this.ElfPic.Name = "ElfPic";
            this.ElfPic.Size = new System.Drawing.Size(150, 210);
            this.ElfPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ElfPic.TabIndex = 0;
            this.ElfPic.TabStop = false;
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
            this.ElfProjectileMove.Enabled = true;
            this.ElfProjectileMove.Interval = 20;
            this.ElfProjectileMove.Tick += new System.EventHandler(this.ElfProjectileMove_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 644);
            this.Controls.Add(this.ElfPic);
            this.MaximumSize = new System.Drawing.Size(800, 700);
            this.MinimumSize = new System.Drawing.Size(800, 700);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.ElfPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer EnemiesMove;
        private System.Windows.Forms.PictureBox ElfPic;
        private System.Windows.Forms.Timer MoveLeft;
        private System.Windows.Forms.Timer MoveRight;
        private System.Windows.Forms.Timer MoveUp;
        private System.Windows.Forms.Timer MoveDown;
        private System.Windows.Forms.Timer ElfProjectileMove;
    }
}

