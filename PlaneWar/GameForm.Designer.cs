namespace PlaneWar
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.lName = new System.Windows.Forms.Label();
            this.tName = new System.Windows.Forms.TextBox();
            this.beginGame = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.msg = new System.Windows.Forms.Label();
            this.rank = new System.Windows.Forms.Label();
            this.rank_button = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // axWindowsMediaPlayer1
            // 
            resources.ApplyResources(this.axWindowsMediaPlayer1, "axWindowsMediaPlayer1");
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            // 
            // lName
            // 
            resources.ApplyResources(this.lName, "lName");
            this.lName.BackColor = System.Drawing.SystemColors.Menu;
            this.lName.Name = "lName";
            // 
            // tName
            // 
            resources.ApplyResources(this.tName, "tName");
            this.tName.Name = "tName";
            // 
            // beginGame
            // 
            resources.ApplyResources(this.beginGame, "beginGame");
            this.beginGame.Name = "beginGame";
            this.beginGame.UseVisualStyleBackColor = true;
            this.beginGame.Click += new System.EventHandler(this.beginGame_Click);
            // 
            // title
            // 
            resources.ApplyResources(this.title, "title");
            this.title.BackColor = System.Drawing.SystemColors.Menu;
            this.title.Name = "title";
            // 
            // msg
            // 
            resources.ApplyResources(this.msg, "msg");
            this.msg.Name = "msg";
            // 
            // rank
            // 
            resources.ApplyResources(this.rank, "rank");
            this.rank.Name = "rank";
            // 
            // rank_button
            // 
            resources.ApplyResources(this.rank_button, "rank_button");
            this.rank_button.Name = "rank_button";
            this.rank_button.UseVisualStyleBackColor = true;
            this.rank_button.Click += new System.EventHandler(this.rank_button_Click);
            // 
            // back
            // 
            resources.ApplyResources(this.back, "back");
            this.back.Name = "back";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // GameForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.back);
            this.Controls.Add(this.rank_button);
            this.Controls.Add(this.rank);
            this.Controls.Add(this.msg);
            this.Controls.Add(this.title);
            this.Controls.Add(this.beginGame);
            this.Controls.Add(this.tName);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Cursor = System.Windows.Forms.Cursors.No;
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.HelpButton = true;
            this.KeyPreview = true;
            this.Name = "GameForm";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Game_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GameForm_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Game_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.TextBox tName;
        private System.Windows.Forms.Button beginGame;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label msg;
        private System.Windows.Forms.Label rank;
        private System.Windows.Forms.Button rank_button;
        private System.Windows.Forms.Button back;
    }
}

