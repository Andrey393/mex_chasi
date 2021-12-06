using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Media;


namespace mexanicheskie_chasi
{
    public partial class Form1 : Form
    {
        private SoundPlayer player;
        public Form1()
        {
            InitializeComponent();
            player = new SoundPlayer();
            player.Stream = Properties.Resources.signal_elektronnyih_chasov_budilnik_33058;

        }
        const double UH = 2 * Math.PI / 12;     //Угол для часов
        const double UMS = 2 * Math.PI / 60;        //Угол для минут и секунд
        int rs = 180;//Линия стрелки для секунды
        int rm = 140;//Линия стрелки для мин
        int rh = 90;//Линия стрелки для часа

        Graphics gr;
        Pen p_min = new Pen(Color.GreenYellow, 5f);
        Pen p_sec = new Pen(Color.Gray, 4f);
        Pen p1 = new Pen(Color.OliveDrab, 7f);
        Pen p2 = new Pen(Color.SeaGreen, 7f);
        Pen p3 = new Pen(Color.Green, 7f);
        SolidBrush br = new SolidBrush(Color.GreenYellow);
        int xc, yc, xs, ys, xm, ym, xh, yh, xs2, ys2;
        int sec, min, hour;
        double ang2 = 0, dangle = 2 * Math.PI /640;//0.53125 0,101225 0.53515 //0.10703,cek///0,10475
        int bol = 0;


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)//Формат datepicter
        {
            Data_pic.CustomFormat = "dd.MM.yyyy hh:mm:ss";
        }
        private void button1_Click(object sender, EventArgs e)//Пуск Будильник
        {
            this.Chasi_box.Load("1.png");
            timer2.Enabled = true;
            Pust_but.Enabled = false;
            Stop_but.Enabled = true;
            Data_pic.Enabled = false;

            
        }
        private void button2_Click(object sender, EventArgs e)//Стоп будильника
        {
            timer2.Enabled = false;
            Pust_but.Enabled = true;
            Stop_but.Enabled = false;
            Data_pic.Enabled = true;
        }
        private void Form1_Load(object sender, EventArgs e)//Координаты
        {        

            xc = Chasi_box.Width / 2;     //Центр вращения
            yc = Chasi_box.Height / 2;
            gr = Chasi_box.CreateGraphics();//Инструмент
            this.Chasi_box.Load("1.png");
            Data_pic.Value = DateTime.Now;
            timer1.Enabled = true;		//Включить таймер
            

        }
        private void timer1_Tick(object sender, EventArgs e)//Часы
        {
            if (bol<=1)
            {
                ang2 = sec*0.10644;
                bol++;
            }
            ang2 +=dangle;
             sec = DateTime.Now.Second;
             min = DateTime.Now.Minute;
             hour = DateTime.Now.Hour;
            label7.Text = DateTime.Now.ToString();
           
            Chasi_box.Invalidate();
        }
        private void timer2_Tick(object sender, EventArgs e)//Будилник
        {
           
            DateTime now = DateTime.Now;
            DateTime pik = Data_pic.Value;
            long  elapsedTicks = now.Ticks - pik.Ticks;
            TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
            if (elapsedTicks >= -500000000)
            {
                this.Chasi_box.Load("1.png");
            }
            if (elapsedTicks >= -300000000)
            {
                this.Chasi_box.Load("2.png");
            }
            if (elapsedTicks >= -200000000)
            {
                this.Chasi_box.Load("3.png");
            }
            if (elapsedTicks >= -100000000)//10 сек
            {
                this.Chasi_box.Load("4.png");
            }
            if (elapsedTicks >=0)
            { 
                if (timer2.Enabled)
                {
                    this.Chasi_box.Load("5.png");
                    timer2.Stop();
                    
                    player.PlayLooping();

                    MessageBox.Show("Время вышло");
                    player.Stop();
                    Pust_but.Enabled = true;
                    Stop_but.Enabled = false;
                    Data_pic.Enabled = true;

                }
                this.Chasi_box.Load("1.png");
            }
        }

        //Формулы вращения
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            xs2 = (int)(xc + rs * Math.Sin(ang2));
            ys2 = (int)(yc - rs * Math.Cos(ang2));
            xs = (int)(xc + rs * Math.Sin(UMS * sec));
            ys = (int)(yc - rs * Math.Cos(UMS * sec));
            xm = (int)(xc + rm * Math.Sin(UMS * min));
            ym = (int)(yc - rm * Math.Cos(UMS * min));
            xh = (int)(xc + rh * Math.Sin(UH * hour));
            yh = (int)(yc - rh * Math.Cos(UH * hour));

            Font f = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Regular);
            p1.EndCap = LineCap.ArrowAnchor;
            p2.EndCap = LineCap.ArrowAnchor;
            p3.EndCap = LineCap.ArrowAnchor;
 
            gr = e.Graphics;

            if (check_Plav.Checked)//Переключатель плавных движений(//Секундная стрелка )
            {
                gr.DrawLine(p1, xc, yc, xs2, ys2);
            }
            else
            {
                gr.DrawLine(p1, xc, yc, xs, ys);
            }
            
            gr.DrawLine(p2, xc, yc, xm, ym);//Минутная стрелка    
            gr.DrawLine(p3, xc, yc, xh, yh);//Часовая стрелка

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            string[] s = new string[12];//Числа в кружок
            int j = 0;
            for (int i = 0; i < s.Length; i++)
            {
                j++;
                s[i] = j.ToString();
            }

            for (int i = 0; i < 12; i++)//Рисование чисел
            {
                gr.TranslateTransform(xc, yc);
                gr.RotateTransform(30);
                gr.TranslateTransform(-xc, -yc);
                gr.DrawString(s[i], f, br, xc, yc / 6, sf);
            }

            gr.FillEllipse(br, xc - 22, 180, 45, 45);//Круг

            for (int i = 0; i < 60; i++)//палочки//секунд
            {
                gr.TranslateTransform(xc, yc);
                gr.RotateTransform(6);
                gr.TranslateTransform(-xc, -yc);
                gr.DrawLine(p_sec, 226, 0, xc, 20);
            }
            for (int i = 0; i < 12; i++)//палочки минут
            {
                gr.TranslateTransform(xc, yc);
                gr.RotateTransform(30);
                gr.TranslateTransform(-xc, -yc);
                gr.DrawLine(p_min, 225, 0, xc, 25);
            }


        }
    }
}
