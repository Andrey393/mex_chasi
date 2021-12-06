namespace mexanicheskie_chasi
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.Chasi_box = new System.Windows.Forms.PictureBox();
            this.Pust_but = new System.Windows.Forms.Button();
            this.Stop_but = new System.Windows.Forms.Button();
            this.check_Plav = new System.Windows.Forms.CheckBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.Data_pic = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.Chasi_box)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 80;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Image = global::mexanicheskie_chasi.Properties.Resources.WEf88OtAWrQ;
            this.label7.Location = new System.Drawing.Point(96, 426);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(224, 31);
            this.label7.TabIndex = 3;
            this.label7.Text = "Текущее время";
            // 
            // Chasi_box
            // 
            this.Chasi_box.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Chasi_box.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Chasi_box.Location = new System.Drawing.Point(11, 15);
            this.Chasi_box.Name = "Chasi_box";
            this.Chasi_box.Size = new System.Drawing.Size(450, 408);
            this.Chasi_box.TabIndex = 0;
            this.Chasi_box.TabStop = false;
            this.Chasi_box.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // Pust_but
            // 
            this.Pust_but.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Pust_but.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Pust_but.BackgroundImage")));
            this.Pust_but.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Pust_but.Location = new System.Drawing.Point(34, 501);
            this.Pust_but.Name = "Pust_but";
            this.Pust_but.Size = new System.Drawing.Size(175, 42);
            this.Pust_but.TabIndex = 11;
            this.Pust_but.Text = "Включить";
            this.Pust_but.UseVisualStyleBackColor = false;
            this.Pust_but.Click += new System.EventHandler(this.button1_Click);
            // 
            // Stop_but
            // 
            this.Stop_but.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Stop_but.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Stop_but.BackgroundImage")));
            this.Stop_but.Enabled = false;
            this.Stop_but.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Stop_but.Location = new System.Drawing.Point(261, 501);
            this.Stop_but.Name = "Stop_but";
            this.Stop_but.Size = new System.Drawing.Size(175, 41);
            this.Stop_but.TabIndex = 12;
            this.Stop_but.Text = "Выключить";
            this.Stop_but.UseVisualStyleBackColor = false;
            this.Stop_but.Click += new System.EventHandler(this.button2_Click);
            // 
            // check_Plav
            // 
            this.check_Plav.AutoSize = true;
            this.check_Plav.BackgroundImage = global::mexanicheskie_chasi.Properties.Resources._11_29_21_191118;
            this.check_Plav.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.check_Plav.Location = new System.Drawing.Point(144, 549);
            this.check_Plav.Name = "check_Plav";
            this.check_Plav.Size = new System.Drawing.Size(176, 22);
            this.check_Plav.TabIndex = 13;
            this.check_Plav.Text = "Плавное движение";
            this.check_Plav.UseVisualStyleBackColor = true;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Data_pic
            // 
            this.Data_pic.CalendarMonthBackground = System.Drawing.Color.YellowGreen;
            this.Data_pic.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Data_pic.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Data_pic.Location = new System.Drawing.Point(110, 460);
            this.Data_pic.Name = "Data_pic";
            this.Data_pic.Size = new System.Drawing.Size(256, 31);
            this.Data_pic.TabIndex = 17;
            this.Data_pic.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackgroundImage = global::mexanicheskie_chasi.Properties.Resources.WEf88OtAWrQ;
            this.ClientSize = new System.Drawing.Size(472, 585);
            this.Controls.Add(this.Data_pic);
            this.Controls.Add(this.check_Plav);
            this.Controls.Add(this.Stop_but);
            this.Controls.Add(this.Pust_but);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Chasi_box);
            this.Name = "Form1";
            this.Text = "Часы ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Chasi_box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Chasi_box;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Pust_but;
        private System.Windows.Forms.Button Stop_but;
        private System.Windows.Forms.CheckBox check_Plav;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.DateTimePicker Data_pic;
    }
}

