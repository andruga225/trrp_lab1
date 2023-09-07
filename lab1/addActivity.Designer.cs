namespace lab1
{
    partial class ActivityForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbSportType = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbElapsedTime = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbStartDate = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbDistance = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Название тренировки";
            // 
            // tbName
            // 
            this.tbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbName.Location = new System.Drawing.Point(3, 19);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(277, 23);
            this.tbName.TabIndex = 0;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbSportType);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(283, 52);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Тип активности";
            // 
            // cbSportType
            // 
            this.cbSportType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSportType.FormattingEnabled = true;
            this.cbSportType.Location = new System.Drawing.Point(3, 19);
            this.cbSportType.Name = "cbSportType";
            this.cbSportType.Size = new System.Drawing.Size(277, 23);
            this.cbSportType.TabIndex = 0;
            this.cbSportType.SelectedIndexChanged += new System.EventHandler(this.cbSportType_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbElapsedTime);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 106);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(283, 51);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Длительность";
            // 
            // tbElapsedTime
            // 
            this.tbElapsedTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbElapsedTime.Location = new System.Drawing.Point(3, 19);
            this.tbElapsedTime.Name = "tbElapsedTime";
            this.tbElapsedTime.Size = new System.Drawing.Size(277, 23);
            this.tbElapsedTime.TabIndex = 0;
            this.tbElapsedTime.TextChanged += new System.EventHandler(this.tbElapsedTime_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbStartDate);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 157);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(283, 60);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Дата тренировки";
            // 
            // tbStartDate
            // 
            this.tbStartDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbStartDate.Location = new System.Drawing.Point(3, 19);
            this.tbStartDate.Name = "tbStartDate";
            this.tbStartDate.Size = new System.Drawing.Size(277, 23);
            this.tbStartDate.TabIndex = 0;
            this.tbStartDate.TextChanged += new System.EventHandler(this.tbStartDate_TextChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tbDistance);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(0, 217);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(283, 55);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Дистанция";
            // 
            // tbDistance
            // 
            this.tbDistance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDistance.Location = new System.Drawing.Point(3, 19);
            this.tbDistance.Name = "tbDistance";
            this.tbDistance.Size = new System.Drawing.Size(277, 23);
            this.tbDistance.TabIndex = 0;
            this.tbDistance.TextChanged += new System.EventHandler(this.tbDistance_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSave.Location = new System.Drawing.Point(0, 350);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(283, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ActivityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 373);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ActivityForm";
            this.Text = "Activity";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private TextBox tbName;
        private GroupBox groupBox2;
        private ComboBox cbSportType;
        private GroupBox groupBox3;
        private TextBox tbElapsedTime;
        private GroupBox groupBox4;
        private TextBox tbStartDate;
        private GroupBox groupBox5;
        private TextBox tbDistance;
        private Button btnSave;
    }
}