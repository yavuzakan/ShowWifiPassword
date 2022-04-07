using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wirelessPassword
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Visible = false;
           textBox2.Visible = false;
           textBox3.Visible = false;
            this.Text = "yavuz.akan@gmail.com";
            komut1();
            String data1 = textBox1.Text;
            data1 = data1.Replace("All User Profile     :", "");
            data1 = data1.Replace("-", "");
            string data = getBetween(data1, "User profiles", "000");
            textBox2.Text = data.Replace(" ", "");
            tocombo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Key Content            :
            komut2();

            string getir = textBox3.Text;
            string data3 = getBetween(getir, "Key Content            : ", "Cost ");
            textBox4.Text = data3;



        }


        public void komut1()
        {

            string q = "";
            try
            {
                String komut = "netsh wlan show profile";
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/C " + komut;

                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardInput = true;
                process.Start();




                while (!process.HasExited)
                {
                    q += process.StandardOutput.ReadToEnd();
                }

                q +="000";

            }
            catch (Exception ex)
            {

                q += "error";

            }
            textBox1.Text = q;

        }

        public void komut2()
        {

            string q = "";
            try
            {
                String komut = "netsh wlan show profile "+comboBox1.Text+" key=clear";
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/C " + komut;

                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardInput = true;
                process.Start();




                while (!process.HasExited)
                {
                    q += process.StandardOutput.ReadToEnd();
                }

                q +="000";

            }
            catch (Exception ex)
            {

                q += "error";

            }
            textBox3.Text = q;

        }

        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }

            return "";
        }

        public void tocombo()
        {

            try
            {
                int linecount = textBox2.Lines.Length;
                for (int i = 0; i<linecount; i++)
                {
                    string kontrol = textBox2.Lines[i].ToString();
                    if (kontrol == "")
                    { }
                    else
                    {
                        comboBox1.Items.Add(textBox2.Lines[i]);
                    }
                }
                comboBox1.SelectedIndex = 0;

            }
            catch { }
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }




    }
}
