using System.Windows.Forms;

namespace UniversalServiceInstaller
{
    partial class main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.Installed = new System.Windows.Forms.Label();
            this.Uninstalled = new System.Windows.Forms.Label();
            this.rights = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.label1.Location = new System.Drawing.Point(12, -7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Discord Presence Installer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 49);
            this.button1.TabIndex = 1;
            this.button1.Text = "Install";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(238, 95);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 49);
            this.button2.TabIndex = 2;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(325, 161);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(38, 13);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Tag = "";
            this.linkLabel1.Text = "Github";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Installed
            // 
            this.Installed.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.Installed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Installed.Location = new System.Drawing.Point(10, 33);
            this.Installed.Name = "Installed";
            this.Installed.Size = new System.Drawing.Size(346, 32);
            this.Installed.TabIndex = 4;
            this.Installed.Text = "Service Installed";
            this.Installed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Installed.Visible = false;
            // 
            // Uninstalled
            // 
            this.Uninstalled.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.Uninstalled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Uninstalled.Location = new System.Drawing.Point(10, 65);
            this.Uninstalled.Name = "Uninstalled";
            this.Uninstalled.Size = new System.Drawing.Size(346, 31);
            this.Uninstalled.TabIndex = 5;
            this.Uninstalled.Text = "Service not installed";
            this.Uninstalled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rights
            // 
            this.rights.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.rights.ForeColor = System.Drawing.Color.Red;
            this.rights.Location = new System.Drawing.Point(14, 147);
            this.rights.Name = "rights";
            this.rights.Size = new System.Drawing.Size(272, 25);
            this.rights.TabIndex = 6;
            this.rights.Text = "Restart with admin rights!";
            this.rights.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rights.Visible = false;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(375, 176);
            this.Controls.Add(this.rights);
            this.Controls.Add(this.Uninstalled);
            this.Controls.Add(this.Installed);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "main";
            this.Text = "Discord presence installer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private LinkLabel linkLabel1;
        private Label Installed;
        private Label Uninstalled;
        private Label rights;
    }
}