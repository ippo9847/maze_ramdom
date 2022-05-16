using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using InoueLab;


namespace template
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// PictureBoxにはりつける画像
        /// </summary>
        Bitmap bmp;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            //pictureBoxに，bmpをはりつける
            pictureBox1.Image = bmp;
            textBox1.Text = "25";
            textBox2.Text = "25";

            comboBox1.SelectedIndex = 0;

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        /// <summary>
        /// 棒倒し法
        /// </summary>
        Random rnd = new Random();
        Boolean make = true;
        private void CutDown()
        {
            bool colorMode = false;
            make = true;

            //画面を白または黒で塗りつぶす


            colorMode = !colorMode;


            while (make)
            {

                {
                    /*
                    for (int x = 0; x <= 19; x++)　//外壁
                    {
                        for (int y = 0; y < pictureBox1.Height; y++)
                        {
                            bmp.SetPixel(x, y, Color.Black);
                        }
                    }

                    for (int x = 400; x <= 419; x++)
                    {
                        for (int y = 0; y < pictureBox1.Height; y++)
                        {
                            bmp.SetPixel(x, y, Color.Black);
                        }
                    }

                    for (int y = 0; y <= 19; y++)
                    {
                        for (int x = 0; x < pictureBox1.Width; x++)
                        {
                            bmp.SetPixel(x, y, Color.Black);
                        }
                    }

                    for (int y = 400; y <= 419; y++)
                    {
                        for (int x = 0; x < pictureBox1.Width; x++)
                        {
                            bmp.SetPixel(x, y, Color.Black);
                        }
                    }　//　外壁end

                    int ax = 20;
                    int ay = 20;
                    int fx;
                    int fy;
                    int rs;

                    for (int x = 20; x <= 399; x++)
                    {
                        for (int y = 20; y <= 399; y++)
                        {
                            fx = x / 20;
                            fy = y / 20;
                            if (fx % 2 == 0 && fy % 2 == 0)
                            {
                                bmp.SetPixel(x, y, Color.Black);
                            }

                            if (x % (ax * 2) == 0 && y % (ay * 2) == 0)
                            {
                                if (x == 40)
                                {


                                    rs = rnd.Next(1, 5);
                                    switch (rs)
                                    {
                                        case 1:
                                            for (int ix = (fx - 1) * ax; ix < fx * ax; ix++)
                                            {
                                                for (int iy = fy * ay; iy < (fy + 1) * ay; iy++)
                                                {
                                                    bmp.SetPixel(ix, iy, Color.Black);
                                                }
                                            }
                                            break;

                                        case 2:
                                            for (int ix = fx * ax; ix < (fx + 1) * ax; ix++)
                                            {
                                                for (int iy = (fy + 1) * ay; iy < (fy + 2) * ay; iy++)
                                                {
                                                    bmp.SetPixel(ix, iy, Color.Black);
                                                }
                                            }
                                            break;

                                        case 3:
                                            for (int ix = (fx + 1) * ax; ix < (fx + 2) * ax; ix++)
                                            {
                                                for (int iy = fy * ay; iy < (fy + 1) * ay; iy++)
                                                {
                                                    bmp.SetPixel(ix, iy, Color.Black);
                                                }
                                            }
                                            break;

                                        case 4:
                                            for (int ix = fx * ax; ix < (fx + 1) * ax; ix++)
                                            {
                                                for (int iy = (fy - 1) * ay; iy < fy * ay; iy++)
                                                {
                                                    bmp.SetPixel(ix, iy, Color.Black);
                                                }
                                            }
                                            break;
                                    }
                                }

                                if (fx != 2 && fx % 2 == 0)
                                {
                                    rs = rnd.Next(1, 4);
                                    switch (rs)
                                    {
                                        case 1:
                                            for (int ix = (fx - 1) * ax; ix < fx * ax; ix++)
                                            {
                                                for (int iy = fy * ay; iy < (fy + 1) * ay; iy++)
                                                {
                                                    bmp.SetPixel(ix, iy, Color.Black);
                                                }
                                            }
                                            break;

                                        case 2:
                                            for (int ix = fx * ax; ix < (fx + 1) * ax; ix++)
                                            {
                                                for (int iy = (fy + 1) * ay; iy < (fy + 2) * ay; iy++)
                                                {
                                                    bmp.SetPixel(ix, iy, Color.Black);
                                                }
                                            }
                                            break;

                                        case 3:
                                            for (int ix = (fx + 1) * ax; ix < (fx + 2) * ax; ix++)
                                            {
                                                for (int iy = fy * ay; iy < (fy + 1) * ay; iy++)
                                                {
                                                    bmp.SetPixel(ix, iy, Color.Black);
                                                }
                                            }
                                            break;
                                    }
                                }
                            }
                        }
                    }
                    */
                }

                int dir = 0;
                int[,] colorcode = new int[21, 21];

                for (int i = 0; i <= 20; i++)//全通路を通路にする
                {
                    for (int j = 0; j <= 20; j++)
                    {
                        colorcode[i, j] = 1;
                    } //0は壁(黒)　1は通路(白)
                }//全通路終わり


                for (int i = 0; i <= 20; i++)//偶数と端をを壁にする
                {
                    for (int j = 0; j <= 20; j++)
                    {
                        if (i % 2 == 0 && j % 2 == 0) colorcode[i, j] = 0;
                        else if (i == 0 || i == 20 || j == 0 || j == 20) colorcode[i, j] = 0;                                                
                    } //0は壁(黒)　1は通路(白)
                }//偶数端壁終わり


                for (int i = 0; i <= 20; i++)
                {
                    for (int j = 0; j <= 20; j++)
                    {
                        if (i == 0 || i == 20 || j == 0 || j == 20) continue;
                        if (i == 2 && j % 2 == 0) 
                        {
                            dir = rnd.Next(1, 5);

                            switch (dir)
                            {
                                case 1:
                                    colorcode[i - 1, j] = 0;
                                    break;
                                case 2:
                                    colorcode[i, j + 1] = 0;
                                    break;
                                case 3:
                                    colorcode[i + 1, j] = 0;
                                    break;
                                case 4:
                                    colorcode[i, j - 1] = 0;
                                    break;
                            }
                        }
                        else if(i % 2 == 0 && j % 2 == 0) 
                        {
                            dir = rnd.Next(1, 4);

                            switch (dir)
                            {
                                case 1:
                                    colorcode[i - 1, j] = 0;
                                    break;
                                case 2:
                                    colorcode[i, j + 1] = 0;
                                    break;
                                case 3:
                                    colorcode[i + 1, j] = 0;
                                    break;
                            }

                        }

                    } 
                }



                for (int i = 0; i <= 20; i++)//色塗り
                {
                    for (int j = 0; j <= 20; j++)
                    {
                        for (int y = 20 * j; y < 20 * (j + 1); y++)
                        {
                            for (int x = 20 * i; x < 20 * (i + 1); x++)
                            {
                                if (colorcode[i, j] == 0)
                                {
                                    bmp.SetPixel(x, y, Color.Black);
                                }
                                if (colorcode[i, j] == 1)
                                {
                                    bmp.SetPixel(x, y, Color.White);
                                }
                            }
                        }
                    }
                }//色塗り終わり

                //探索はじめ
                int[,] search = new int[21, 21];
                //int sdir = 1;//進む向き
                int bdir = 1;//向いてる向き
                int schx = 1;
                int schy = 1;
                int bschx = 1;
                int bschy = 1;
                int dschx = 1;
                int dschy = 1;
                int maxrangex = 19;
                int minrangex = 1;
                int maxrangey = 19;
                int minrangey = 1;
                Boolean rpct = false;
                //探索q    b

                for (int i = 0; i <= 20; i++)
                {
                    for (int j = 0; j <= 20; j++)
                    {
                        search[i, j] = 0;
                    }
                }

                while (bschx != 19 || bschy != 19)
                {

                    search[bschx, bschy] = 1;//ひとつ前の現在地


                    switch (bdir)
                    {
                        case 1:
                            for (int i = 1; i <= 4; i++)
                            {
                                switch (i)
                                {
                                    case 1:
                                        schx = bschx;
                                        schy = bschy + 1; //方向判定
                                        if (schy >= maxrangey) break;
                                        if (colorcode[schx, schy] == 0) break;
                                        schx = bschx;
                                        schy = bschy + 2;
                                        search[schx, schy] = 1;
                                        search[bschx, bschy] = 0;
                                        bdir = 2;
                                        rpct = true;
                                        break;//処理を中断してswitch文から抜けだす。
                                    case 2:
                                        schx = bschx - 1;
                                        schy = bschy;
                                        if (schx <= minrangex) break;
                                        if (colorcode[schx, schy] == 0) break;
                                        schx = bschx - 2;
                                        schy = bschy;
                                        search[schx, schy] = 1;
                                        search[bschx, bschy] = 0;
                                        bdir = 1;
                                        rpct = true;
                                        break;//処理を中断してswitch文から抜けだす。
                                    case 3:
                                        schx = bschx;
                                        schy = bschy - 1;
                                        if (schy <= minrangey) break;
                                        if (colorcode[schx, schy] == 0) break;
                                        schx = bschx;
                                        schy = bschy - 2;
                                        search[schx, schy] = 1;
                                        search[bschx, bschy] = 0;
                                        bdir = 4;
                                        rpct = true;
                                        break;//処理を中断してswitch文から抜けだす。
                                    case 4:
                                        schx = bschx + 1;
                                        schy = bschy;
                                        if (schx >= maxrangex) break;
                                        if (colorcode[schx, schy] == 0) break;
                                        schx = bschx + 2;
                                        schy = bschy;
                                        search[schx, schy] = 1;
                                        search[bschx, bschy] = 0;
                                        bdir = 3;
                                        rpct = true;
                                        break;
                                }
                                if (rpct) break;
                            }//処理を中断してswitch文から抜けだす。
                            break;

                        case 2:
                            for (int i = 1; i <= 4; i++)
                            {
                                switch (i)
                                {
                                    case 1:
                                        schx = bschx + 1;
                                        schy = bschy;
                                        if (schx >= maxrangex) break;
                                        if (colorcode[schx, schy] == 0) break;
                                        schx = bschx + 2;
                                        schy = bschy;
                                        search[schx, schy] = 1;
                                        search[bschx, bschy] = 0;
                                        bdir = 3;
                                        rpct = true;
                                        break;
                                    case 2:
                                        schx = bschx;
                                        schy = bschy + 1; //方向判定
                                        if (schy >= maxrangey) break;
                                        if (colorcode[schx, schy] == 0) break;
                                        schx = bschx;
                                        schy = bschy + 2;
                                        search[schx, schy] = 1;
                                        search[bschx, bschy] = 0;
                                        bdir = 2;
                                        rpct = true;
                                        break;//処理を中断してswitch文から抜けだす。
                                    case 3:
                                        schx = bschx - 1;
                                        schy = bschy;
                                        if (schx <= minrangex) break;
                                        if (colorcode[schx, schy] == 0) break;
                                        schx = bschx - 2;
                                        schy = bschy;
                                        search[schx, schy] = 1;
                                        search[bschx, bschy] = 0;
                                        bdir = 1;
                                        rpct = true;
                                        break;//処理を中断してswitch文から抜けだす。
                                    case 4:
                                        schx = bschx;
                                        schy = bschy - 1;
                                        if (schy <= minrangey) break;
                                        if (colorcode[schx, schy] == 0) break;
                                        schx = bschx;
                                        schy = bschy - 2;
                                        search[schx, schy] = 1;
                                        search[bschx, bschy] = 0;
                                        bdir = 4;
                                        rpct = true;
                                        break;//処理を中断してswitch文から抜けだす。

                                }
                                if (rpct) break;
                            }
                            break;


                        case 3:
                            for (int i = 1; i <= 4; i++)
                            {
                                switch (i)
                                {
                                    case 1:
                                        schx = bschx;
                                        schy = bschy - 1;
                                        if (schy <= minrangey) break;
                                        if (colorcode[schx, schy] == 0) break;
                                        schx = bschx;
                                        schy = bschy - 2;
                                        search[schx, schy] = 1;
                                        search[bschx, bschy] = 0;
                                        bdir = 4;
                                        rpct = true;
                                        break;//処理を中断してswitch文から抜けだす。
                                    case 2:
                                        schx = bschx + 1;
                                        schy = bschy;
                                        if (schx >= maxrangex) break;
                                        if (colorcode[schx, schy] == 0) break;
                                        schx = bschx + 2;
                                        schy = bschy;
                                        search[schx, schy] = 1;
                                        search[bschx, bschy] = 0;
                                        bdir = 3;
                                        rpct = true;
                                        break;
                                    case 3:
                                        schx = bschx;
                                        schy = bschy + 1; //方向判定
                                        if (schy >= maxrangey) break;
                                        if (colorcode[schx, schy] == 0) break;
                                        schx = bschx;
                                        schy = bschy + 2;
                                        search[schx, schy] = 1;
                                        search[bschx, bschy] = 0;
                                        bdir = 2;
                                        rpct = true;
                                        break;//処理を中断してswitch文から抜けだす。
                                    case 4:
                                        schx = bschx - 1;
                                        schy = bschy;
                                        if (schx <= minrangex) break;
                                        if (colorcode[schx, schy] == 0) break;
                                        schx = bschx - 2;
                                        schy = bschy;
                                        search[schx, schy] = 1;
                                        search[bschx, bschy] = 0;
                                        bdir = 1;
                                        rpct = true;
                                        break;//処理を中断してswitch文から抜けだす。

                                }
                                if (rpct) break;
                            }
                            break;
                        case 4:
                            for (int i = 1; i <= 4; i++)
                            {
                                switch (i)
                                {
                                    case 1:
                                        schx = bschx - 1;
                                        schy = bschy;
                                        if (schx <= minrangex) break;
                                        if (colorcode[schx, schy] == 0) break;
                                        schx = bschx - 2;
                                        schy = bschy;
                                        search[schx, schy] = 1;
                                        search[bschx, bschy] = 0;
                                        bdir = 1;
                                        rpct = true;
                                        break;//処理を中断してswitch文から抜けだす。
                                    case 2:
                                        schx = bschx;
                                        schy = bschy - 1;
                                        if (schy <= minrangey) break;
                                        if (colorcode[schx, schy] == 0) break;
                                        schx = bschx;
                                        schy = bschy - 2;
                                        search[schx, schy] = 1;
                                        search[bschx, bschy] = 0;
                                        bdir = 4;
                                        rpct = true;
                                        break;//処理を中断してswitch文から抜けだす。
                                    case 3:
                                        schx = bschx + 1;
                                        schy = bschy;
                                        if (schx >= maxrangex) break;
                                        if (colorcode[schx, schy] == 0) break;
                                        schx = bschx + 2;
                                        schy = bschy;
                                        search[schx, schy] = 1;
                                        search[bschx, bschy] = 0;
                                        bdir = 3;
                                        rpct = true;
                                        break;
                                    case 4:
                                        schx = bschx;
                                        schy = bschy + 1; //方向判定
                                        if (schy >= maxrangey) break;
                                        if (colorcode[schx, schy] == 0) break;
                                        schx = bschx;
                                        schy = bschy + 2;
                                        search[schx, schy] = 1;
                                        search[bschx, bschy] = 0;
                                        bdir = 2;
                                        rpct = true;
                                        break;//処理を中断してswitch文から抜けだす。

                                }
                                if (rpct) break;
                            }

                            break;
                    }


                    for (int i = 0; i <= 20; i++)//色塗り
                    {
                        for (int j = 0; j <= 20; j++)
                        {
                            for (int y = 20 * j; y < 20 * (j + 1); y++)
                            {
                                for (int x = 20 * i; x < 20 * (i + 1); x++)
                                {
                                    if (search[i, j] == 1)
                                    {
                                        bmp.SetPixel(x, y, Color.Red);
                                    }
                                    if (search[i, j] == 0)
                                    {
                                        // bmp.SetPixel(x, y, Color.White);
                                    }
                                }
                            }
                        }
                    }

                    bschx = schx;
                    bschy = schy;
                    rpct = false;
                    InterThreadRefresh(this.pictureBox1.Refresh);
                    Thread.Sleep(100);

                }//探索終わり





                // Graphics.DrawRectangle();

                //pictureBoxの中身を塗り替える
                InterThreadRefresh(this.pictureBox1.Refresh);

                //500ミリ秒=0.5秒待機する
                Thread.Sleep(500);
                make = false;
            }
        }

        ///<summary>
        ///穴掘り法
        /// </summary>
        private void Digging()
        {
            int[,] colorcode = new int[21, 21];
            int[,] check = new int[21, 21];
            make = true;
            bool colorMode = false;
            while (make)
            {

                //画面を白または黒で塗りつぶす
                for (int x = 0; x < pictureBox1.Width; x++)
                {
                    for (int y = 0; y < pictureBox1.Height; y++)
                    {
                        bmp.SetPixel(x, y, Color.White);
                    }
                }
                colorMode = !colorMode;



                for (int i = 0; i <= 20; i++)//全通路を壁にする
                {
                    for (int j = 0; j <= 20; j++)
                    {
                        colorcode[i, j] = 0;
                        check[i, j] = 0;

                        if (i == 0 || i == 20 || j == 0 || j == 20)
                        {
                            check[i, j] = 1;
                        }
                        //else 
                        //{
                        //colorcode[i, j] = 2;
                        //} 
                    } //0は壁(黒)　1は通路(白)　初期は2
                }//全通路壁終わり



                int dir = 0;

                int sx = 0;
                int sy = 0;
                int nx = 0;
                int ny = 0;
                int nnx = 0;
                int nny = 0;
                Boolean a = true;

                Boolean start = true;

                while (start)//最初の起点を決める
                {
                    sx = 9;
                    sy = 1;
                    if (sx % 2 == 0 || sy % 2 == 0) continue;
                    start = false;
                }//起点決め終わり

                colorcode[sx, sy] = 1;

                for (int z = 0; z < 10000; z++)
                {
                    dir = rnd.Next(1, 5);
                    Boolean nrp = false;


                    for (int i = 1; i <= 19; i++)
                    {
                        if (i % 2 == 0) continue;
                        for (int j = 1; j <= 19; j++)
                        {
                            if (j % 2 == 0) continue;
                            if (check[i, j] == 0)
                            {
                                nrp = true;
                                break;
                            }
                            if (i == 19 && j == 19) a = false;
                        }
                        if (nrp) break;
                    }


                    if (dir == 1)
                    {
                        nx = sx - 1;
                        nnx = sx - 2;
                        ny = sy;
                        nny = sy;
                        if (nx > 0 && nnx > 0 && ny > 0 && nny > 0 && nx < 20 && nnx < 20 && ny < 20 && nny < 20)
                        {

                            if (colorcode[nnx, nny] == 0)
                            {
                                colorcode[nx, ny] = 1;
                                check[nnx, nny] = 1;
                                colorcode[nnx, nny] = 1;
                                sx = nnx;
                                sy = nny;
                                continue;
                            }
                            if (colorcode[nnx, nny] == 1)
                            {
                                while (true)
                                {
                                    int ramx = rnd.Next(1, 20);
                                    int ramy = rnd.Next(1, 20);
                                    if (ramx % 2 == 0 || ramy % 2 == 0 || colorcode[ramx, ramy] == 0) continue;
                                    sx = ramx;
                                    sy = ramy;
                                    break;
                                }
                                continue;
                            }
                        }
                        else continue;
                    }

                    if (dir == 2)
                    {
                        nx = sx;
                        nnx = sx;
                        ny = sy + 1;
                        nny = sy + 2;
                        if (nx > 0 && nnx > 0 && ny > 0 && nny > 0 && nx < 20 && nnx < 20 && ny < 20 && nny < 20)
                        {

                            if (colorcode[nnx, nny] == 0)
                            {
                                colorcode[nx, ny] = 1;
                                check[nnx, nny] = 1;
                                colorcode[nnx, nny] = 1;
                                sx = nnx;
                                sy = nny;
                                continue;
                            }
                            if (colorcode[nnx, nny] == 1)
                            {
                                while (true)
                                {
                                    int ramx = rnd.Next(1, 20);
                                    int ramy = rnd.Next(1, 20);
                                    if (ramx % 2 == 0 || ramy % 2 == 0 || colorcode[ramx, ramy] == 0) continue;
                                    sx = ramx;
                                    sy = ramy;
                                    break;
                                }
                                continue;
                            }
                        }
                        else continue;
                    }

                    if (dir == 3)
                    {
                        nx = sx + 1;
                        nnx = sx + 2;
                        ny = sy;
                        nny = sy;
                        if (nx > 0 && nnx > 0 && ny > 0 && nny > 0 && nx < 20 && nnx < 20 && ny < 20 && nny < 20)
                        {

                            if (colorcode[nnx, nny] == 0)
                            {
                                colorcode[nx, ny] = 1;
                                check[nnx, nny] = 1;
                                colorcode[nnx, nny] = 1;
                                sx = nnx;
                                sy = nny;
                                continue;
                            }
                            if (colorcode[nnx, nny] == 1)
                            {
                                while (true)
                                {
                                    int ramx = rnd.Next(1, 20);
                                    int ramy = rnd.Next(1, 20);
                                    if (ramx % 2 == 0 || ramy % 2 == 0 || colorcode[ramx, ramy] == 0) continue;
                                    sx = ramx;
                                    sy = ramy;
                                    break;
                                }
                                continue;
                            }
                        }
                        else continue;
                    }

                    if (dir == 4)
                    {
                        nx = sx;
                        nnx = sx;
                        ny = sy - 1;
                        nny = sy - 2;
                        if (nx > 0 && nnx > 0 && ny > 0 && nny > 0 && nx < 20 && nnx < 20 && ny < 20 && nny < 20)
                        {

                            if (colorcode[nnx, nny] == 0)
                            {
                                colorcode[nx, ny] = 1;
                                check[nnx, nny] = 1;
                                colorcode[nnx, nny] = 1;
                                sx = nnx;
                                sy = nny;
                                continue;
                            }
                            if (colorcode[nnx, nny] == 1)
                            {
                                while (true)
                                {
                                    int ramx = rnd.Next(1, 20);
                                    int ramy = rnd.Next(1, 20);
                                    if (ramx % 2 == 0 || ramy % 2 == 0 || colorcode[ramx, ramy] == 0) continue;
                                    sx = ramx;
                                    sy = ramy;
                                    break;
                                }
                                continue;
                            }
                        }
                        else continue;
                    }

                }


                for (int i = 0; i <= 20; i++)//色塗り
                {
                    for (int j = 0; j <= 20; j++)
                    {
                        for (int y = 20 * j; y < 20 * (j + 1); y++)
                        {
                            for (int x = 20 * i; x < 20 * (i + 1); x++)
                            {
                                if (colorcode[i, j] == 0)
                                {
                                    bmp.SetPixel(x, y, Color.Black);
                                }
                                if (colorcode[i, j] == 1)
                                {
                                    bmp.SetPixel(x, y, Color.White);
                                }
                            }
                        }
                    }
                }//色塗り終わり







                //pictureBoxの中身を塗り替える
                InterThreadRefresh(this.pictureBox1.Refresh);

                //500ミリ秒=0.5秒待機する
                Thread.Sleep(500);
                make = false;
            }
            //探索はじめ
            int[,] search = new int[21, 21];
            //int sdir = 1;//進む向き
            int bdir = 1;//向いてる向き
            int schx = 1;
            int schy = 1;
            int bschx = 1;
            int bschy = 1;
            int dschx = 1;
            int dschy = 1;
            int maxrangex = 19;
            int minrangex = 1;
            int maxrangey = 19;
            int minrangey = 1;
            Boolean rpct = false;
            //探索q    b

            for (int i = 0; i <= 20; i++)
            {
                for (int j = 0; j <= 20; j++)
                {
                    search[i, j] = 0;
                }
            }

            while (bschx != 19 || bschy != 19)
            {

                search[bschx, bschy] = 1;//ひとつ前の現在地


                switch (bdir)
                {
                    case 1:
                        for (int i = 1; i <= 4; i++)
                        {
                            switch (i)
                            {
                                case 1:
                                    schx = bschx;
                                    schy = bschy + 1; //方向判定
                                    if (schy >= maxrangey) break;
                                    if (colorcode[schx, schy] == 0) break;
                                    schx = bschx;
                                    schy = bschy + 2;
                                    search[schx, schy] = 1;
                                    search[bschx, bschy] = 0;
                                    bdir = 2;
                                    rpct = true;
                                    break;//処理を中断してswitch文から抜けだす。
                                case 2:
                                    schx = bschx - 1;
                                    schy = bschy;
                                    if (schx <= minrangex) break;
                                    if (colorcode[schx, schy] == 0) break;
                                    schx = bschx - 2;
                                    schy = bschy;
                                    search[schx, schy] = 1;
                                    search[bschx, bschy] = 0;
                                    bdir = 1;
                                    rpct = true;
                                    break;//処理を中断してswitch文から抜けだす。
                                case 3:
                                    schx = bschx;
                                    schy = bschy - 1;
                                    if (schy <= minrangey) break;
                                    if (colorcode[schx, schy] == 0) break;
                                    schx = bschx;
                                    schy = bschy - 2;
                                    search[schx, schy] = 1;
                                    search[bschx, bschy] = 0;
                                    bdir = 4;
                                    rpct = true;
                                    break;//処理を中断してswitch文から抜けだす。
                                case 4:
                                    schx = bschx + 1;
                                    schy = bschy;
                                    if (schx >= maxrangex) break;
                                    if (colorcode[schx, schy] == 0) break;
                                    schx = bschx + 2;
                                    schy = bschy;
                                    search[schx, schy] = 1;
                                    search[bschx, bschy] = 0;
                                    bdir = 3;
                                    rpct = true;
                                    break;
                            }
                            if (rpct) break;
                        }//処理を中断してswitch文から抜けだす。
                        break;

                    case 2:
                        for (int i = 1; i <= 4; i++)
                        {
                            switch (i)
                            {
                                case 1:
                                    schx = bschx + 1;
                                    schy = bschy;
                                    if (schx >= maxrangex) break;
                                    if (colorcode[schx, schy] == 0) break;
                                    schx = bschx + 2;
                                    schy = bschy;
                                    search[schx, schy] = 1;
                                    search[bschx, bschy] = 0;
                                    bdir = 3;
                                    rpct = true;
                                    break;
                                case 2:
                                    schx = bschx;
                                    schy = bschy + 1; //方向判定
                                    if (schy >= maxrangey) break;
                                    if (colorcode[schx, schy] == 0) break;
                                    schx = bschx;
                                    schy = bschy + 2;
                                    search[schx, schy] = 1;
                                    search[bschx, bschy] = 0;
                                    bdir = 2;
                                    rpct = true;
                                    break;//処理を中断してswitch文から抜けだす。
                                case 3:
                                    schx = bschx - 1;
                                    schy = bschy;
                                    if (schx <= minrangex) break;
                                    if (colorcode[schx, schy] == 0) break;
                                    schx = bschx - 2;
                                    schy = bschy;
                                    search[schx, schy] = 1;
                                    search[bschx, bschy] = 0;
                                    bdir = 1;
                                    rpct = true;
                                    break;//処理を中断してswitch文から抜けだす。
                                case 4:
                                    schx = bschx;
                                    schy = bschy - 1;
                                    if (schy <= minrangey) break;
                                    if (colorcode[schx, schy] == 0) break;
                                    schx = bschx;
                                    schy = bschy - 2;
                                    search[schx, schy] = 1;
                                    search[bschx, bschy] = 0;
                                    bdir = 4;
                                    rpct = true;
                                    break;//処理を中断してswitch文から抜けだす。

                            }
                            if (rpct) break;
                        }
                        break;


                    case 3:
                        for (int i = 1; i <= 4; i++)
                        {
                            switch (i)
                            {
                                case 1:
                                    schx = bschx;
                                    schy = bschy - 1;
                                    if (schy <= minrangey) break;
                                    if (colorcode[schx, schy] == 0) break;
                                    schx = bschx;
                                    schy = bschy - 2;
                                    search[schx, schy] = 1;
                                    search[bschx, bschy] = 0;
                                    bdir = 4;
                                    rpct = true;
                                    break;//処理を中断してswitch文から抜けだす。
                                case 2:
                                    schx = bschx + 1;
                                    schy = bschy;
                                    if (schx >= maxrangex) break;
                                    if (colorcode[schx, schy] == 0) break;
                                    schx = bschx + 2;
                                    schy = bschy;
                                    search[schx, schy] = 1;
                                    search[bschx, bschy] = 0;
                                    bdir = 3;
                                    rpct = true;
                                    break;
                                case 3:
                                    schx = bschx;
                                    schy = bschy + 1; //方向判定
                                    if (schy >= maxrangey) break;
                                    if (colorcode[schx, schy] == 0) break;
                                    schx = bschx;
                                    schy = bschy + 2;
                                    search[schx, schy] = 1;
                                    search[bschx, bschy] = 0;
                                    bdir = 2;
                                    rpct = true;
                                    break;//処理を中断してswitch文から抜けだす。
                                case 4:
                                    schx = bschx - 1;
                                    schy = bschy;
                                    if (schx <= minrangex) break;
                                    if (colorcode[schx, schy] == 0) break;
                                    schx = bschx - 2;
                                    schy = bschy;
                                    search[schx, schy] = 1;
                                    search[bschx, bschy] = 0;
                                    bdir = 1;
                                    rpct = true;
                                    break;//処理を中断してswitch文から抜けだす。

                            }
                            if (rpct) break;
                        }
                        break;
                    case 4:
                        for (int i = 1; i <= 4; i++)
                        {
                            switch (i)
                            {
                                case 1:
                                    schx = bschx - 1;
                                    schy = bschy;
                                    if (schx <= minrangex) break;
                                    if (colorcode[schx, schy] == 0) break;
                                    schx = bschx - 2;
                                    schy = bschy;
                                    search[schx, schy] = 1;
                                    search[bschx, bschy] = 0;
                                    bdir = 1;
                                    rpct = true;
                                    break;//処理を中断してswitch文から抜けだす。
                                case 2:
                                    schx = bschx;
                                    schy = bschy - 1;
                                    if (schy <= minrangey) break;
                                    if (colorcode[schx, schy] == 0) break;
                                    schx = bschx;
                                    schy = bschy - 2;
                                    search[schx, schy] = 1;
                                    search[bschx, bschy] = 0;
                                    bdir = 4;
                                    rpct = true;
                                    break;//処理を中断してswitch文から抜けだす。
                                case 3:
                                    schx = bschx + 1;
                                    schy = bschy;
                                    if (schx >= maxrangex) break;
                                    if (colorcode[schx, schy] == 0) break;
                                    schx = bschx + 2;
                                    schy = bschy;
                                    search[schx, schy] = 1;
                                    search[bschx, bschy] = 0;
                                    bdir = 3;
                                    rpct = true;
                                    break;
                                case 4:
                                    schx = bschx;
                                    schy = bschy + 1; //方向判定
                                    if (schy >= maxrangey) break;
                                    if (colorcode[schx, schy] == 0) break;
                                    schx = bschx;
                                    schy = bschy + 2;
                                    search[schx, schy] = 1;
                                    search[bschx, bschy] = 0;
                                    bdir = 2;
                                    rpct = true;
                                    break;//処理を中断してswitch文から抜けだす。

                            }
                            if (rpct) break;
                        }

                        break;
                }


                for (int i = 0; i <= 20; i++)//色塗り
                {
                    for (int j = 0; j <= 20; j++)
                    {
                        for (int y = 20 * j; y < 20 * (j + 1); y++)
                        {
                            for (int x = 20 * i; x < 20 * (i + 1); x++)
                            {
                                if (search[i, j] == 1)
                                {
                                    bmp.SetPixel(x, y, Color.Red);
                                }
                                if (search[i, j] == 0)
                                {
                                    // bmp.SetPixel(x, y, Color.White);
                                }
                            }
                        }
                    }
                }

                bschx = schx;
                bschy = schy;
                rpct = false;
                InterThreadRefresh(this.pictureBox1.Refresh);
                Thread.Sleep(100);

            }//探索終わり

            //
        }

        ///<summary>
        ///壁のばし法
        /// </summary>
        private void WallGrowth()
        {

            make = true;
            bool colorMode = false;
            while (make)
            {

                //画面を白または黒で塗りつぶす
                for (int x = 0; x < pictureBox1.Width; x++)
                {
                    for (int y = 0; y < pictureBox1.Height; y++)
                    {
                        bmp.SetPixel(x, y, Color.White);
                    }
                }
                colorMode = !colorMode;

                int[,] colorcode = new int[21, 21];
                int[,] check = new int[21, 21];

                for (int i = 0; i <= 20; i++)//全通路を壁にする
                {
                    for (int j = 0; j <= 20; j++)
                    {


                        if (i == 0 || j == 0 || i == 20 || j == 20)
                        {
                            colorcode[i, j] = 0;
                        }
                        else if (i == 1 || j == 1 || i == 19 || j == 19)
                        {
                            colorcode[i, j] = 0;
                        }
                        else if (i == 2 || j == 2 || i == 18 || j == 18)
                        {
                            colorcode[i, j] = 0;
                        }
                        else if (i > 2 && i < 18 && j > 2 && j < 18)
                        {
                            colorcode[i, j] = 1;
                        }

                    } //0は壁(黒)　1は通路(白)
                }//全通路壁終わり


                int dir = 0;

                int sx = 0;
                int sy = 0;
                int nx = 0;
                int ny = 0;
                int nnx = 0;
                int nny = 0;
                Boolean a = true;

                Boolean start = true;

                while (start)//最初の起点を決める
                {
                    sx = 10;
                    sy = 10;
                    if (sx % 2 == 1 || sy % 2 == 1) continue;
                    start = false;
                }//起点決め終わり

                colorcode[sx, sy] = 0;

                for (int z = 0; z < 10000; z++)
                {
                    dir = rnd.Next(1, 5);
                    Boolean nrp = false;


                    for (int i = 0; i <= 20; i++)
                    {
                        if (i % 2 == 1) continue;
                        for (int j = 0; j <= 20; j++)
                        {
                            if (j % 2 == 1) continue;
                            if (check[i, j] == 0)
                            {
                                nrp = true;
                                break;
                            }
                            if (i == 19 && j == 19) a = false;
                        }
                        if (nrp) break;
                    }


                    if (dir == 1)
                    {
                        nx = sx - 1;
                        nnx = sx - 2;
                        ny = sy;
                        nny = sy;
                        if (nx >= 2 && nnx >= 2 && ny >= 2 && nny >= 2 && nx <= 18 && nnx <= 18 && ny <= 18 && nny <= 18)
                        {

                            if (colorcode[nnx, nny] == 1)
                            {
                                colorcode[nx, ny] = 0;
                                check[nnx, nny] = 1;
                                colorcode[nnx, nny] = 0;
                                sx = nnx;
                                sy = nny;
                                continue;
                            }
                            if (colorcode[nnx, nny] == 0)
                            {
                                while (true)
                                {
                                    int ramx = rnd.Next(2, 19);
                                    int ramy = rnd.Next(2, 19);
                                    if (ramx % 2 == 1 || ramy % 2 == 1 || colorcode[ramx, ramy] == 1) continue;
                                    sx = ramx;
                                    sy = ramy;
                                    break;
                                }
                                continue;
                            }
                        }
                        else continue;
                    }

                    if (dir == 2)
                    {
                        nx = sx;
                        nnx = sx;
                        ny = sy + 1;
                        nny = sy + 2;
                        if (nx >= 2 && nnx >= 2 && ny >= 2 && nny >= 2 && nx <= 18 && nnx <= 18 && ny <= 18 && nny <= 18)
                        {

                            if (colorcode[nnx, nny] == 1)
                            {
                                colorcode[nx, ny] = 0;
                                check[nnx, nny] = 1;
                                colorcode[nnx, nny] = 0;
                                sx = nnx;
                                sy = nny;
                                continue;
                            }
                            if (colorcode[nnx, nny] == 0)
                            {
                                while (true)
                                {
                                    int ramx = rnd.Next(2, 19);
                                    int ramy = rnd.Next(2, 19);
                                    if (ramx % 2 == 1 || ramy % 2 == 1 || colorcode[ramx, ramy] == 1) continue;
                                    sx = ramx;
                                    sy = ramy;
                                    break;
                                }
                                continue;
                            }
                        }
                        else continue;
                    }

                    if (dir == 3)
                    {
                        nx = sx + 1;
                        nnx = sx + 2;
                        ny = sy;
                        nny = sy;
                        if (nx >= 2 && nnx >= 2 && ny >= 2 && nny >= 2 && nx <= 18 && nnx <= 18 && ny <= 18 && nny <= 18)
                        {

                            if (colorcode[nnx, nny] == 1)
                            {
                                colorcode[nx, ny] = 0;
                                check[nnx, nny] = 1;
                                colorcode[nnx, nny] = 0;
                                sx = nnx;
                                sy = nny;
                                continue;
                            }
                            if (colorcode[nnx, nny] == 0)
                            {
                                while (true)
                                {
                                    int ramx = rnd.Next(2, 19);
                                    int ramy = rnd.Next(2, 19);
                                    if (ramx % 2 == 1 || ramy % 2 == 1 || colorcode[ramx, ramy] == 1) continue;
                                    sx = ramx;
                                    sy = ramy;
                                    break;
                                }
                                continue;
                            }
                        }
                        else continue;
                    }

                    if (dir == 4)
                    {
                        nx = sx;
                        nnx = sx;
                        ny = sy - 1;
                        nny = sy - 2;
                        if (nx >= 2 && nnx >= 2 && ny >= 2 && nny >= 2 && nx <= 18 && nnx <= 18 && ny <= 18 && nny <= 18)
                        {

                            if (colorcode[nnx, nny] == 1)
                            {
                                colorcode[nx, ny] = 0;
                                check[nnx, nny] = 1;
                                colorcode[nnx, nny] = 0;
                                sx = nnx;
                                sy = nny;
                                continue;
                            }
                            if (colorcode[nnx, nny] == 0)
                            {
                                while (true)
                                {
                                    int ramx = rnd.Next(2, 19);
                                    int ramy = rnd.Next(2, 19);
                                    if (ramx % 2 == 1 || ramy % 2 == 1 || colorcode[ramx, ramy] == 1) continue;
                                    sx = ramx;
                                    sy = ramy;
                                    break;
                                }
                                continue;
                            }
                        }
                        else continue;
                    }

                }



                for (int i = 0; i <= 20; i++)//色塗り
                {
                    for (int j = 0; j <= 20; j++)
                    {
                        for (int y = 20 * j; y < 20 * (j + 1); y++)
                        {
                            for (int x = 20 * i; x < 20 * (i + 1); x++)
                            {
                                if (colorcode[i, j] == 0)
                                {
                                    bmp.SetPixel(x, y, Color.Black);
                                }
                                if (colorcode[i, j] == 1)
                                {
                                    bmp.SetPixel(x, y, Color.White);
                                }
                            }
                        }
                    }
                }//色塗り終わり

                //探索はじめ
                int[,] search = new int[21, 21];
                //int sdir = 1;//進む向き
                int bdir = 1;//向いてる向き
                int schx = 1;
                int schy = 1;
                int bschx = 3;
                int bschy = 3;
                int dschx = 1;
                int dschy = 1;
                int maxrangex = 17;
                int minrangex = 3;
                int maxrangey = 17;
                int minrangey = 3;
                Boolean rpct = false;
                //探索q    b

                for (int i = 0; i <= 20; i++)
                {
                    for (int j = 0; j <= 20; j++)
                    {
                        search[i, j] = 0;
                    }
                }

                while (bschx != 17 || bschy != 17)
                {

                    search[bschx, bschy] = 1;//ひとつ前の現在地


                    switch (bdir)
                    {
                        case 1:
                            for (int i = 1; i <= 4; i++)
                            {
                                switch (i)
                                {
                                    case 1:
                                        schx = bschx;
                                        schy = bschy + 1; //方向判定
                                        if (schy >= maxrangey) break;
                                        if (colorcode[schx, schy] == 0) break;
                                        schx = bschx;
                                        schy = bschy + 2;
                                        search[schx, schy] = 1;
                                        search[bschx, bschy] = 0;
                                        bdir = 2;
                                        rpct = true;
                                        break;//処理を中断してswitch文から抜けだす。
                                    case 2:
                                        schx = bschx - 1;
                                        schy = bschy;
                                        if (schx <= minrangex) break;
                                        if (colorcode[schx, schy] == 0) break;
                                        schx = bschx - 2;
                                        schy = bschy;
                                        search[schx, schy] = 1;
                                        search[bschx, bschy] = 0;
                                        bdir = 1;
                                        rpct = true;
                                        break;//処理を中断してswitch文から抜けだす。
                                    case 3:
                                        schx = bschx;
                                        schy = bschy - 1;
                                        if (schy <= minrangey) break;
                                        if (colorcode[schx, schy] == 0) break;
                                        schx = bschx;
                                        schy = bschy - 2;
                                        search[schx, schy] = 1;
                                        search[bschx, bschy] = 0;
                                        bdir = 4;
                                        rpct = true;
                                        break;//処理を中断してswitch文から抜けだす。
                                    case 4:
                                        schx = bschx + 1;
                                        schy = bschy;
                                        if (schx >= maxrangex) break;
                                        if (colorcode[schx, schy] == 0) break;
                                        schx = bschx + 2;
                                        schy = bschy;
                                        search[schx, schy] = 1;
                                        search[bschx, bschy] = 0;
                                        bdir = 3;
                                        rpct = true;
                                        break;
                                }
                                if (rpct) break;
                            }//処理を中断してswitch文から抜けだす。
                            break;

                        case 2:
                            for (int i = 1; i <= 4; i++)
                            {
                                switch (i)
                                {
                                    case 1:
                                        schx = bschx + 1;
                                        schy = bschy;
                                        if (schx >= maxrangex) break;
                                        if (colorcode[schx, schy] == 0) break;
                                        schx = bschx + 2;
                                        schy = bschy;
                                        search[schx, schy] = 1;
                                        search[bschx, bschy] = 0;
                                        bdir = 3;
                                        rpct = true;
                                        break;
                                    case 2:
                                        schx = bschx;
                                        schy = bschy + 1; //方向判定
                                        if (schy >= maxrangey) break;
                                        if (colorcode[schx, schy] == 0) break;
                                        schx = bschx;
                                        schy = bschy + 2;
                                        search[schx, schy] = 1;
                                        search[bschx, bschy] = 0;
                                        bdir = 2;
                                        rpct = true;
                                        break;//処理を中断してswitch文から抜けだす。
                                    case 3:
                                        schx = bschx - 1;
                                        schy = bschy;
                                        if (schx <= minrangex) break;
                                        if (colorcode[schx, schy] == 0) break;
                                        schx = bschx - 2;
                                        schy = bschy;
                                        search[schx, schy] = 1;
                                        search[bschx, bschy] = 0;
                                        bdir = 1;
                                        rpct = true;
                                        break;//処理を中断してswitch文から抜けだす。
                                    case 4:
                                        schx = bschx;
                                        schy = bschy - 1;
                                        if (schy <= minrangey) break;
                                        if (colorcode[schx, schy] == 0) break;
                                        schx = bschx;
                                        schy = bschy - 2;
                                        search[schx, schy] = 1;
                                        search[bschx, bschy] = 0;
                                        bdir = 4;
                                        rpct = true;
                                        break;//処理を中断してswitch文から抜けだす。

                                }
                                if (rpct) break;
                            }
                            break;


                        case 3:
                            for (int i = 1; i <= 4; i++)
                            {
                                switch (i)
                                {
                                    case 1:
                                        schx = bschx;
                                        schy = bschy - 1;
                                        if (schy <= minrangey) break;
                                        if (colorcode[schx, schy] == 0) break;
                                        schx = bschx;
                                        schy = bschy - 2;
                                        search[schx, schy] = 1;
                                        search[bschx, bschy] = 0;
                                        bdir = 4;
                                        rpct = true;
                                        break;//処理を中断してswitch文から抜けだす。
                                    case 2:
                                        schx = bschx + 1;
                                        schy = bschy;
                                        if (schx >= maxrangex) break;
                                        if (colorcode[schx, schy] == 0) break;
                                        schx = bschx + 2;
                                        schy = bschy;
                                        search[schx, schy] = 1;
                                        search[bschx, bschy] = 0;
                                        bdir = 3;
                                        rpct = true;
                                        break;
                                    case 3:
                                        schx = bschx;
                                        schy = bschy + 1; //方向判定
                                        if (schy >= maxrangey) break;
                                        if (colorcode[schx, schy] == 0) break;
                                        schx = bschx;
                                        schy = bschy + 2;
                                        search[schx, schy] = 1;
                                        search[bschx, bschy] = 0;
                                        bdir = 2;
                                        rpct = true;
                                        break;//処理を中断してswitch文から抜けだす。
                                    case 4:
                                        schx = bschx - 1;
                                        schy = bschy;
                                        if (schx <= minrangex) break;
                                        if (colorcode[schx, schy] == 0) break;
                                        schx = bschx - 2;
                                        schy = bschy;
                                        search[schx, schy] = 1;
                                        search[bschx, bschy] = 0;
                                        bdir = 1;
                                        rpct = true;
                                        break;//処理を中断してswitch文から抜けだす。

                                }
                                if (rpct) break;
                            }
                            break;
                        case 4:
                            for (int i = 1; i <= 4; i++)
                            {
                                switch (i)
                                {
                                    case 1:
                                        schx = bschx - 1;
                                        schy = bschy;
                                        if (schx <= minrangex) break;
                                        if (colorcode[schx, schy] == 0) break;
                                        schx = bschx - 2;
                                        schy = bschy;
                                        search[schx, schy] = 1;
                                        search[bschx, bschy] = 0;
                                        bdir = 1;
                                        rpct = true;
                                        break;//処理を中断してswitch文から抜けだす。
                                    case 2:
                                        schx = bschx;
                                        schy = bschy - 1;
                                        if (schy <= minrangey) break;
                                        if (colorcode[schx, schy] == 0) break;
                                        schx = bschx;
                                        schy = bschy - 2;
                                        search[schx, schy] = 1;
                                        search[bschx, bschy] = 0;
                                        bdir = 4;
                                        rpct = true;
                                        break;//処理を中断してswitch文から抜けだす。
                                    case 3:
                                        schx = bschx + 1;
                                        schy = bschy;
                                        if (schx >= maxrangex) break;
                                        if (colorcode[schx, schy] == 0) break;
                                        schx = bschx + 2;
                                        schy = bschy;
                                        search[schx, schy] = 1;
                                        search[bschx, bschy] = 0;
                                        bdir = 3;
                                        rpct = true;
                                        break;
                                    case 4:
                                        schx = bschx;
                                        schy = bschy + 1; //方向判定
                                        if (schy >= maxrangey) break;
                                        if (colorcode[schx, schy] == 0) break;
                                        schx = bschx;
                                        schy = bschy + 2;
                                        search[schx, schy] = 1;
                                        search[bschx, bschy] = 0;
                                        bdir = 2;
                                        rpct = true;
                                        break;//処理を中断してswitch文から抜けだす。

                                }
                                if (rpct) break;
                            }

                            break;
                    }


                    for (int i = 0; i <= 20; i++)//色塗り
                    {
                        for (int j = 0; j <= 20; j++)
                        {
                            for (int y = 20 * j; y < 20 * (j + 1); y++)
                            {
                                for (int x = 20 * i; x < 20 * (i + 1); x++)
                                {
                                    if (search[i, j] == 1)
                                    {
                                        bmp.SetPixel(x, y, Color.Red);
                                    }
                                    if (search[i, j] == 0)
                                    {
                                        // bmp.SetPixel(x, y, Color.White);
                                    }
                                }
                            }
                        }
                    }

                    bschx = schx;
                    bschy = schy;
                    rpct = false;
                    InterThreadRefresh(this.pictureBox1.Refresh);
                    Thread.Sleep(100);

                }//探索終わり


                //pictureBoxの中身を塗り替える
                InterThreadRefresh(this.pictureBox1.Refresh);

                //500ミリ秒=0.5秒待機する
                Thread.Sleep(500);
                make = false;
            }



            //pictureBoxの中身を塗り替える
            InterThreadRefresh(this.pictureBox1.Refresh);

            //500ミリ秒=0.5秒待機する
            Thread.Sleep(500);
        }






        /// <summary>
        /// ボタンを押したときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            int number;
            if (!int.TryParse(textBox1.Text, out number) || !int.TryParse(textBox2.Text, out number))
            {
                MessageBox.Show("1以上の整数値で幅・高さを入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //スレッドを分割し，mainProcess関数を実行する
            if (comboBox1.SelectedIndex == 0)
            {
                ThreadSeparate(ref drawThread, CutDown);
            }
            if (comboBox1.SelectedIndex == 1)
            {
                ThreadSeparate(ref drawThread, Digging);
            }
            if (comboBox1.SelectedIndex == 2)
            {
                ThreadSeparate(ref drawThread, WallGrowth);
            }


            ////スレッド分割なしの場合を体験してみよう
            //mainProcess();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
