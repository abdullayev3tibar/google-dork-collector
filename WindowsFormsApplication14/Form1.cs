using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using OpenQA.Selenium;
using System.Net;

namespace WindowsFormsApplication14
{
    public partial class Form1 : Form
    {
  
        IWebDriver browserGOOGLE = new OpenQA.Selenium.Chrome.ChromeDriver();
        int sayi = 0;
        int defe = 0;
        String currentURL;
        public Form1()
        {
            InitializeComponent();
        }
        private void button5_Click(object sender, EventArgs e)   
        {
            buttonBasla.Enabled = false;
            button3.Enabled = true;
            timer1.Enabled = true;
            currentURL = browserGOOGLE.Url;
           
        }     
        private void Form1_Load(object sender, EventArgs e)
        {
            browserGOOGLE.Navigate().GoToUrl("https://google.com");
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                String currentURL = browserGOOGLE.Url;
                IList<IWebElement> all = browserGOOGLE.FindElements(By.CssSelector("div[class='yuRUbf'] > a"));

                StringBuilder str = new StringBuilder();
                for (var i = 0; i < all.Count; i++)
                {
                    string link = all[i].GetAttribute("href");
                    string linkdenParca = link.Substring(0, 18);

                    string linkler = Convert.ToString(str);
                    if (linkler.Contains(linkdenParca))
                    {

                    }
                    else
                    {
                        if (richTextBox1.Text.Contains(linkdenParca))
                        {
                        }
                        else
                        {
                           
                                str.Append(link + Environment.NewLine);
                                label2.Text = Convert.ToString(richTextBox1.Lines.Count());
                   
                        }
                    }

                }
                richTextBox1.AppendText(str + "");
                browserGOOGLE.Navigate().GoToUrl(currentURL + "&start=" + Convert.ToString(sayi));
                sayi = sayi + 10;
            }
            catch
            {
                buttonBasla.Enabled = true;
                button3.Enabled = false;
                timer1.Enabled = false;
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            label2.Text = Convert.ToString(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sayi = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buttonBasla.Enabled = true;
            button3.Enabled = false;
            timer1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
           // using (var webClient = new System.Net.WebClient())
           /// {
           //     string result = webClient.DownloadString("http://stackoverflow.com/questions/3231969/download-file-from-url-to-a-string");
           // }
            timer2.Enabled = true;
            
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Thread ty = new Thread(test);
            ty.Start();
        }
       private void test()
        {
            defe = defe + 1;
            var list = richTextBox1.Lines;
            int listSayi = list.Count();
            try
            {
                if (listSayi > defe)
                {

                    WebClient webb = new WebClient();
                    string responce = webb.DownloadString(list[defe]);
                    if (responce.Contains("localhost"))
                    {
                       // richTextBox2.AppendText(list[defe] + Environment.NewLine);
                    }
                }
            }
            catch { }
        }
        }
    }

public static class StringExt
{
    public static bool IsNumeric(this string text)
    {
        double test;
        return double.TryParse(text, out test);
    }
}