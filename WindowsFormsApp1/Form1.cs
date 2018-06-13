using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public List<string> initial = new List<string>();
        public List<string> values = new List<string>();
        public int counter = 0;
        public string chosen = "";
        public StreamReader teletext;
        public StreamWriter output = new StreamWriter("output.ini");
        public Form1()
        {

            InitializeComponent();
            listBox1.Hide();
            checkBox1.Hide();
            textBox1.Hide();
            checkBox2.Hide();
            button3.Hide();
            listBox2.Items.Add("RealmGame");
            listBox2.Items.Add("RealmInput");
            listBox2.Items.Add("RealmSystemSettings");
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] temp = initial[listBox1.SelectedIndex].Split('=');
            checkBox1.Text = initial[listBox1.SelectedIndex];
            checkBox1.Text = checkBox1.Text.ToLower();
            if (checkBox1.Text == "true" || checkBox1.Text == "false")
            {
                textBox1.Hide();
                if (checkBox1.Text == "true")
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }
                checkBox1.Show();
            }
            else if (listBox1.Items[listBox1.SelectedIndex].ToString() != "" && !listBox1.Items[listBox1.SelectedIndex].ToString().Contains('[') && !listBox1.Items[listBox1.SelectedIndex].ToString().Contains("Bindings"))
            {
                temp = initial[listBox1.SelectedIndex].Split('=');
                checkBox1.Hide();
                textBox1.Text = temp[1];
                textBox1.Show();
            }
            else if (listBox1.Items[listBox1.SelectedIndex].ToString().Contains("Bindings"))
            {
                temp = initial[listBox1.SelectedIndex].Split(',');
                checkBox1.Hide();
                textBox1.Text = /*initial[listBox1.SelectedIndex]*/ temp[1];
                textBox1.Show();
            }
            else
            {
                checkBox1.Hide();
                textBox1.Hide();
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string[] temp = initial[listBox1.SelectedIndex].Split('=');
            if (checkBox1.Checked)
            {
                initial[listBox1.SelectedIndex] = temp[0] + "true";
            }
            else
            {
                initial[listBox1.SelectedIndex] = temp[0] + "true";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //values[listBox1.SelectedIndex] = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*for (int i = 0; i < counter; i++)
            {
                output.Write(listBox1.Items[i]);
                if (listBox1.Items[i].ToString() != "" && !listBox1.Items[i].ToString().Contains("["))
                {
                    output.Write("=" + values[i]);
                }
                output.Write("\r\n");
            }
            output.Close();*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*checkBox2.Show();*/
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                button3.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StreamWriter outputreal = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\My Games\\paladinsroyale\\RealmGame\\Config\\" + chosen +".ini");
            for (int i = 0; i < counter; i++)
            {
                outputreal.Write(listBox1.Items[i]);
                if (listBox1.Items[i].ToString() != "" && !listBox1.Items[i].ToString().Contains("[") && !listBox1.Items[i].ToString().Contains("Bindings"))
                {
                    outputreal.Write("=" + values[i]);
                }
                else if (listBox1.Items[i].ToString().Contains("Bindings"))
                {

                }
                outputreal.Write("\r\n");
            }
            outputreal.Close();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            chosen = listBox2.Items[listBox2.SelectedIndex].ToString();
            teletext = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\My Games\\paladinsroyale\\RealmGame\\Config\\" + chosen + ".ini");
            while (teletext.Peek() != -1)
            {
                /*string[] split = teletext.ReadLine().Split('=');
                if (split[0] != "" && !split[0].Contains("["))
                {
                    listBox1.Items.Add(split[0]);
                    values.Add(split[1]);
                    for (int i = 2; i < split.Count(); i++)
                    {
                        values[counter] += split[i];
                        if (i != split.Count() - 1)
                        {
                            values[counter] += "=";
                        }
                    }
                    counter++;
                }*/
                string split = teletext.ReadLine();
                string[] temp = new string[100];
                if (split.Contains("Bindings"))
                {
                    temp = split.Split(',');
                }
                else
                {
                    temp = split.Split('=');
                }
                listBox1.Items.Add(temp[0]);
                initial.Add(split);
            }
            teletext.Close();
            listBox2.Hide();
            listBox1.Show();
        }
    }
}
