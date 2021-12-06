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


namespace mexanicheskie_chasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const double UH = 2 * Math.PI / 12;     //Угол для часов
        const double UMS = 2 * Math.PI / 60;        //Угол для минут и секунд
        int rs = 180;//Линия стрелки для секунды
        int rm = 140;//Линия стрелки для мин
        int rh = 90;//Линия стрелки для часа
        Graphics gr;
        Pen p_min = new Pen(Color.GreenYellow, 5f);
        Pen p_sec = new Pen(Color.Gray,4f);
        Pen p1 = new Pen(Color.OliveDrab,7f);
        Pen p2 = new Pen(Color.SeaGreen, 7f);
        Pen p3 = new Pen(Color.Green, 7f);  
        SolidBrush br = new SolidBrush(Color.GreenYellow);
        int xc, yc, xs, ys, xm, ym, xh, yh;
        int sec, min,hour;

        private void button1_Click(object sender, EventArgs e)// Будильник
        {
            this.pictureBox1.Load("1.png");
            timer2.Enabled = true;
            button1.Enabled = false;
            button2.Enabled = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {        

            xc = pictureBox1.Width / 2;     //Центр вращения
            yc = pictureBox1.Height / 2;
            gr = pictureBox1.CreateGraphics();//Инструмент
            this.pictureBox1.Load("1.png");
            dateTimePicker1.Value = DateTime.Now;
            timer1.Enabled = true;		//Включить таймер

        }
        private void timer1_Tick(object sender, EventArgs e)//Часы
        {
            sec = DateTime.Now.Second;
             min = DateTime.Now.Minute;
             hour = DateTime.Now.Hour;
            label7.Text = DateTime.Now.ToLongTimeString();   
            pictureBox1.Invalidate();
        }
        private void timer2_Tick(object sender, EventArgs e)//Будилник
        {
           
            DateTime now = DateTime.Now;
            DateTime pik = dateTimePicker1.Value;
            long  elapsedTicks = now.Ticks - pik.Ticks;
            TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
            if (elapsedTicks >= -500000000)
            {
                this.pictureBox1.Load("1.png");
            }
            if (elapsedTicks >= -300000000)
            {
                this.pictureBox1.Load("2.png");
            }
            if (elapsedTicks >= -200000000)
            {
                this.pictureBox1.Load("3.png");
            }
            if (elapsedTicks >= -100000000)//10 сек
            {
                this.pictureBox1.Load("4.png");
            }

            if (elapsedTicks >=0)
            { 
                if (timer2.Enabled)
                {
                    this.pictureBox1.Load("5.png");
                    timer2.Stop();
                    MessageBox.Show("Будильник");
                    button1.Enabled = true;
                    button2.Enabled = false;

                }
                this.pictureBox1.Load("1.png");
            }
        }
        private void po(ref int xs,ref int ys,ref int xm, ref int ym,ref int xh, ref int yh)
        {
            xs = (int)(xc + rs * Math.Sin(UMS * sec));
            ys = (int)(yc - rs * Math.Cos(UMS * sec));
            xm = (int)(xc + rm * Math.Sin(UMS * min));
            ym = (int)(yc - rm * Math.Cos(UMS * min));
            xh = (int)(xc + rh * Math.Sin(UH * hour));
            yh = (int)(yc - rh * Math.Cos(UH * hour));
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Font f = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Regular);
            p1.EndCap = LineCap.ArrowAnchor;
            p2.EndCap = LineCap.ArrowAnchor;
            p3.EndCap = LineCap.ArrowAnchor;

            po(ref  xs, ref  ys, ref  xm, ref  ym, ref  xh, ref  yh);
            gr = e.Graphics;
            gr.DrawLine(p1,xc,yc,xs,ys);//Секундная стрелка  
            gr.DrawLine(p2, xc, yc, xm, ym);//Минутная стрелка    
            gr.DrawLine(p3, xc, yc, xh, yh);//Часовая стрелка
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
           
            string[] s=new string[12];//Числа в кружок
            int j=0;
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
           
            gr.FillEllipse(br, xc-22, 180, 45, 45);//Круг
            
            for (int i = 0; i < 60; i++)//палочки//минуты
            {
                gr.TranslateTransform(xc, yc);
                gr.RotateTransform(6);
                gr.TranslateTransform(-xc, -yc);
                gr.DrawLine(p_sec, 226, 0, xc, 20); 
            }
            for (int i = 0; i < 12; i++)//палочки//минуты
            {
                gr.TranslateTransform(xc, yc);
                gr.RotateTransform(30);
                gr.TranslateTransform(-xc, -yc);
                gr.DrawLine(p_min, 226, 0, xc, 25); 
            }




            //gr.TranslateTransform(xc, yc);
            //gr.RotateTransform(30);
            //gr.TranslateTransform(-xc, -yc);
            //gr.DrawString("1", f, br, xc, yc / 6, sf);
            //gr.TranslateTransform(xc, yc);
            //gr.RotateTransform(30);
            //gr.TranslateTransform(-xc, -yc);
            //gr.DrawString("2", f, br, xc, yc / 6, sf);
            //gr.TranslateTransform(xc, yc);
            //gr.RotateTransform(30);
            //gr.TranslateTransform(-xc, -yc);
            //gr.DrawString("3", f, br, xc, yc / 6, sf);
            //gr.TranslateTransform(xc, yc);
            //gr.RotateTransform(30);
            //gr.TranslateTransform(-xc, -yc);
            //gr.DrawString("4", f, br, xc, yc / 6, sf);
            //gr.TranslateTransform(xc, yc);
            //gr.RotateTransform(30);
            //gr.TranslateTransform(-xc, -yc);
            //gr.DrawString("5", f, br, xc, yc / 6, sf);
            //gr.TranslateTransform(xc, yc);
            //gr.RotateTransform(30);
            //gr.TranslateTransform(-xc, -yc);
            //gr.DrawString("6", f, br, xc, yc / 6, sf);
            //gr.TranslateTransform(xc, yc);
            //gr.RotateTransform(30);
            //gr.TranslateTransform(-xc, -yc);
            //gr.DrawString("7", f, br, xc, yc / 6, sf);
            //gr.TranslateTransform(xc, yc);
            //gr.RotateTransform(30);
            //gr.TranslateTransform(-xc, -yc);
            //gr.DrawString("8", f, br, xc, yc / 6, sf);
            //gr.TranslateTransform(xc, yc);
            //gr.RotateTransform(30);
            //gr.TranslateTransform(-xc, -yc);
            //gr.DrawString("9", f, br, xc, yc / 6, sf);
            //gr.TranslateTransform(xc, yc);
            //gr.RotateTransform(30);
            //gr.TranslateTransform(-xc, -yc);
            //gr.DrawString("10", f, br, xc, yc / 6, sf);
            //gr.TranslateTransform(xc, yc);
            //gr.RotateTransform(30);
            //gr.TranslateTransform(-xc, -yc);
            //gr.DrawString("11", f, br, xc, yc / 6, sf);




        }
    }
}
