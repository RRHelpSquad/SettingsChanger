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
        public string[] initial = new string[1047];
        public string[] values = new string[1047];
        public int counter = 0;
        public StreamReader teletext = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\My Games\\paladinsroyale\\RealmGame\\Config\\RealmSystemSettings.ini");
        public StreamWriter output = new StreamWriter("output.ini");
        public Form1()
        {

            InitializeComponent();
            checkBox1.Hide();
            textBox1.Hide();
            checkBox2.Hide();
            button3.Hide();
            while (teletext.Peek() != -1)
            {
                string[] split = teletext.ReadLine().Split('=');
                listBox1.Items.Add(split[0]);
                if (split[0] != "" && !split[0].Contains("["))
                {
                    for (int i = 1; i < split.Count(); i++)
                    {
                        values[counter] += split[i];
                        if (i != split.Count() - 1)
                        {
                            values[counter] += "=";
                        }
                    }
                }
                counter++;
            }
            teletext.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBox1.Text = values[listBox1.SelectedIndex];
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
            else if (listBox1.Items[listBox1.SelectedIndex].ToString() != "" && !listBox1.Items[listBox1.SelectedIndex].ToString().Contains('['))
            {
                checkBox1.Hide();
                textBox1.Text = values[listBox1.SelectedIndex];
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
            if (checkBox1.Checked)
            {
                values[listBox1.SelectedIndex] = "true";
            }
            else
            {
                values[listBox1.SelectedIndex] = "false";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            values[listBox1.SelectedIndex] = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < counter; i++)
            {
                output.Write(listBox1.Items[i]);
                if (listBox1.Items[i].ToString() != "" && !listBox1.Items[i].ToString().Contains("["))
                {
                    output.Write("=" + values[i]);
                }
                output.Write("\r\n");
            }
            output.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkBox2.Show();
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
            StreamWriter outputreal = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\My Games\\paladinsroyale\\RealmGame\\Config\\RealmSystemSettings.ini");
            for (int i = 0; i < counter; i++)
            {
                outputreal.Write(listBox1.Items[i]);
                if (listBox1.Items[i].ToString() != "" && !listBox1.Items[i].ToString().Contains("["))
                {
                    outputreal.Write("=" + values[i]);
                }
                outputreal.Write("\r\n");
            }
            outputreal.Close();
        }
    }
}
