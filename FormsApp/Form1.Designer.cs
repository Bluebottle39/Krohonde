﻿namespace FormsApp
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
            this.ant0 = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.ant1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ant0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ant1)).BeginInit();
            this.SuspendLayout();
            // 
            // ant0
            // 
            this.ant0.Image = global::FormsApp.Properties.Resources.CFermièreEst;
            this.ant0.Location = new System.Drawing.Point(346, 165);
            this.ant0.Name = "ant0";
            this.ant0.Size = new System.Drawing.Size(16, 16);
            this.ant0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ant0.TabIndex = 0;
            this.ant0.TabStop = false;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // ant1
            // 
            this.ant1.Image = global::FormsApp.Properties.Resources.COuvrièreNord;
            this.ant1.Location = new System.Drawing.Point(424, 288);
            this.ant1.Name = "ant1";
            this.ant1.Size = new System.Drawing.Size(16, 16);
            this.ant1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ant1.TabIndex = 1;
            this.ant1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ant1);
            this.Controls.Add(this.ant0);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ant0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ant1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ant0;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox ant1;
    }
}

