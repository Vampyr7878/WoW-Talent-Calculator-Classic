namespace WoW_Talent_Calculator_Classic
{
    partial class Talents
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Talents));
            this.tabs = new System.Windows.Forms.TabControl();
            this.tab1 = new System.Windows.Forms.TabPage();
            this.tab2 = new System.Windows.Forms.TabPage();
            this.tab3 = new System.Windows.Forms.TabPage();
            this.warrior = new System.Windows.Forms.Button();
            this.paladin = new System.Windows.Forms.Button();
            this.hunter = new System.Windows.Forms.Button();
            this.rogue = new System.Windows.Forms.Button();
            this.priest = new System.Windows.Forms.Button();
            this.shaman = new System.Windows.Forms.Button();
            this.mage = new System.Windows.Forms.Button();
            this.warlock = new System.Windows.Forms.Button();
            this.druid = new System.Windows.Forms.Button();
            this.talent = new System.Windows.Forms.Label();
            this.left = new System.Windows.Forms.Label();
            this.reset = new System.Windows.Forms.Button();
            this.Open = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabs.Controls.Add(this.tab1);
            this.tabs.Controls.Add(this.tab2);
            this.tabs.Controls.Add(this.tab3);
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(260, 358);
            this.tabs.TabIndex = 0;
            // 
            // tab1
            // 
            this.tab1.AutoScroll = true;
            this.tab1.BackColor = System.Drawing.Color.Black;
            this.tab1.ForeColor = System.Drawing.Color.Yellow;
            this.tab1.Location = new System.Drawing.Point(4, 4);
            this.tab1.Name = "tab1";
            this.tab1.Padding = new System.Windows.Forms.Padding(3);
            this.tab1.Size = new System.Drawing.Size(252, 332);
            this.tab1.TabIndex = 0;
            this.tab1.Text = "Specialization";
            // 
            // tab2
            // 
            this.tab2.AutoScroll = true;
            this.tab2.BackColor = System.Drawing.Color.Black;
            this.tab2.ForeColor = System.Drawing.Color.Yellow;
            this.tab2.Location = new System.Drawing.Point(4, 4);
            this.tab2.Name = "tab2";
            this.tab2.Size = new System.Drawing.Size(252, 332);
            this.tab2.TabIndex = 1;
            this.tab2.Text = "Specialization";
            // 
            // tab3
            // 
            this.tab3.AutoScroll = true;
            this.tab3.BackColor = System.Drawing.Color.Black;
            this.tab3.ForeColor = System.Drawing.Color.Yellow;
            this.tab3.Location = new System.Drawing.Point(4, 4);
            this.tab3.Name = "tab3";
            this.tab3.Size = new System.Drawing.Size(252, 332);
            this.tab3.TabIndex = 2;
            this.tab3.Text = "Specialization";
            // 
            // warrior
            // 
            this.warrior.BackColor = System.Drawing.Color.Maroon;
            this.warrior.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.warrior.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(156)))), ((int)(((byte)(110)))));
            this.warrior.Location = new System.Drawing.Point(292, 12);
            this.warrior.Name = "warrior";
            this.warrior.Size = new System.Drawing.Size(100, 23);
            this.warrior.TabIndex = 1;
            this.warrior.Text = "Warrior";
            this.warrior.UseVisualStyleBackColor = false;
            this.warrior.Click += new System.EventHandler(this.button_Click);
            // 
            // paladin
            // 
            this.paladin.BackColor = System.Drawing.Color.Maroon;
            this.paladin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.paladin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(140)))), ((int)(((byte)(186)))));
            this.paladin.Location = new System.Drawing.Point(292, 41);
            this.paladin.Name = "paladin";
            this.paladin.Size = new System.Drawing.Size(100, 23);
            this.paladin.TabIndex = 2;
            this.paladin.Text = "Paladin";
            this.paladin.UseVisualStyleBackColor = false;
            this.paladin.Click += new System.EventHandler(this.button_Click);
            // 
            // hunter
            // 
            this.hunter.BackColor = System.Drawing.Color.Maroon;
            this.hunter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.hunter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(212)))), ((int)(((byte)(115)))));
            this.hunter.Location = new System.Drawing.Point(292, 70);
            this.hunter.Name = "hunter";
            this.hunter.Size = new System.Drawing.Size(100, 23);
            this.hunter.TabIndex = 3;
            this.hunter.Text = "Hunter";
            this.hunter.UseVisualStyleBackColor = false;
            this.hunter.Click += new System.EventHandler(this.button_Click);
            // 
            // rogue
            // 
            this.rogue.BackColor = System.Drawing.Color.Maroon;
            this.rogue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rogue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(105)))));
            this.rogue.Location = new System.Drawing.Point(292, 99);
            this.rogue.Name = "rogue";
            this.rogue.Size = new System.Drawing.Size(100, 23);
            this.rogue.TabIndex = 4;
            this.rogue.Text = "Rogue";
            this.rogue.UseVisualStyleBackColor = false;
            this.rogue.Click += new System.EventHandler(this.button_Click);
            // 
            // priest
            // 
            this.priest.BackColor = System.Drawing.Color.Maroon;
            this.priest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.priest.ForeColor = System.Drawing.Color.White;
            this.priest.Location = new System.Drawing.Point(292, 128);
            this.priest.Name = "priest";
            this.priest.Size = new System.Drawing.Size(100, 23);
            this.priest.TabIndex = 5;
            this.priest.Text = "Priest";
            this.priest.UseVisualStyleBackColor = false;
            this.priest.Click += new System.EventHandler(this.button_Click);
            // 
            // shaman
            // 
            this.shaman.BackColor = System.Drawing.Color.Maroon;
            this.shaman.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.shaman.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(222)))));
            this.shaman.Location = new System.Drawing.Point(292, 157);
            this.shaman.Name = "shaman";
            this.shaman.Size = new System.Drawing.Size(100, 23);
            this.shaman.TabIndex = 6;
            this.shaman.Text = "Shaman";
            this.shaman.UseVisualStyleBackColor = false;
            this.shaman.Click += new System.EventHandler(this.button_Click);
            // 
            // mage
            // 
            this.mage.BackColor = System.Drawing.Color.Maroon;
            this.mage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(204)))), ((int)(((byte)(240)))));
            this.mage.Location = new System.Drawing.Point(292, 186);
            this.mage.Name = "mage";
            this.mage.Size = new System.Drawing.Size(100, 23);
            this.mage.TabIndex = 7;
            this.mage.Text = "Mage";
            this.mage.UseVisualStyleBackColor = false;
            this.mage.Click += new System.EventHandler(this.button_Click);
            // 
            // warlock
            // 
            this.warlock.BackColor = System.Drawing.Color.Maroon;
            this.warlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.warlock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(130)))), ((int)(((byte)(201)))));
            this.warlock.Location = new System.Drawing.Point(292, 215);
            this.warlock.Name = "warlock";
            this.warlock.Size = new System.Drawing.Size(100, 23);
            this.warlock.TabIndex = 8;
            this.warlock.Text = "Warlock";
            this.warlock.UseVisualStyleBackColor = false;
            this.warlock.Click += new System.EventHandler(this.button_Click);
            // 
            // druid
            // 
            this.druid.BackColor = System.Drawing.Color.Maroon;
            this.druid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.druid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(125)))), ((int)(((byte)(10)))));
            this.druid.Location = new System.Drawing.Point(292, 244);
            this.druid.Name = "druid";
            this.druid.Size = new System.Drawing.Size(100, 23);
            this.druid.TabIndex = 9;
            this.druid.Text = "Druid";
            this.druid.UseVisualStyleBackColor = false;
            this.druid.Click += new System.EventHandler(this.button_Click);
            // 
            // talent
            // 
            this.talent.AutoSize = true;
            this.talent.ForeColor = System.Drawing.Color.Yellow;
            this.talent.Location = new System.Drawing.Point(1, 370);
            this.talent.Name = "talent";
            this.talent.Size = new System.Drawing.Size(72, 13);
            this.talent.TabIndex = 10;
            this.talent.Text = "Talent Points:";
            // 
            // left
            // 
            this.left.ForeColor = System.Drawing.Color.Yellow;
            this.left.Location = new System.Drawing.Point(79, 370);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(20, 13);
            this.left.TabIndex = 11;
            this.left.Text = "0";
            this.left.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // reset
            // 
            this.reset.BackColor = System.Drawing.Color.Maroon;
            this.reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.reset.ForeColor = System.Drawing.Color.Yellow;
            this.reset.Location = new System.Drawing.Point(292, 360);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(100, 23);
            this.reset.TabIndex = 12;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = false;
            this.reset.Click += new System.EventHandler(this.button_Click);
            // 
            // Open
            // 
            this.Open.BackColor = System.Drawing.Color.Maroon;
            this.Open.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Open.ForeColor = System.Drawing.Color.Yellow;
            this.Open.Location = new System.Drawing.Point(292, 331);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(100, 23);
            this.Open.TabIndex = 13;
            this.Open.Text = "Open";
            this.Open.UseVisualStyleBackColor = false;
            this.Open.Click += new System.EventHandler(this.button_Click);
            // 
            // save
            // 
            this.save.BackColor = System.Drawing.Color.Maroon;
            this.save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.save.ForeColor = System.Drawing.Color.Yellow;
            this.save.Location = new System.Drawing.Point(292, 302);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(100, 23);
            this.save.TabIndex = 14;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = false;
            this.save.Click += new System.EventHandler(this.button_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "bld";
            this.openFileDialog.Filter = "Talent build files (*.bld)|*.bld";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "bld";
            this.saveFileDialog.Filter = "Talent build files (*.bld)|*.bld";
            // 
            // Talents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(404, 391);
            this.Controls.Add(this.save);
            this.Controls.Add(this.Open);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.left);
            this.Controls.Add(this.talent);
            this.Controls.Add(this.druid);
            this.Controls.Add(this.warlock);
            this.Controls.Add(this.mage);
            this.Controls.Add(this.shaman);
            this.Controls.Add(this.priest);
            this.Controls.Add(this.rogue);
            this.Controls.Add(this.hunter);
            this.Controls.Add(this.paladin);
            this.Controls.Add(this.warrior);
            this.Controls.Add(this.tabs);
            this.ForeColor = System.Drawing.Color.Yellow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Talents";
            this.Text = "Talents";
            this.tabs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tab1;
        private System.Windows.Forms.TabPage tab2;
        private System.Windows.Forms.TabPage tab3;
        private System.Windows.Forms.Button warrior;
        private System.Windows.Forms.Button paladin;
        private System.Windows.Forms.Button hunter;
        private System.Windows.Forms.Button rogue;
        private System.Windows.Forms.Button priest;
        private System.Windows.Forms.Button shaman;
        private System.Windows.Forms.Button mage;
        private System.Windows.Forms.Button warlock;
        private System.Windows.Forms.Button druid;
        private System.Windows.Forms.Label talent;
        private System.Windows.Forms.Label left;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button Open;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;

    }
}

