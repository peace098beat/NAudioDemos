using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tutorial
{
    public partial class Form1 : Form
    {

        /// <summary>
        /// フォームの初期設定。
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            // ボタンの初期状態
            this.Text = @"C# Audio Tutorial 8 - EffectStream Part 2";
            linkLabel1.Text = "https://www.youtube.com/watch?v=LbYuIjQD0Bk&t=12s";
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //リンク先に移動したことにする
            linkLabel1.LinkVisited = true;
            //ブラウザで開く
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }

    }
}
