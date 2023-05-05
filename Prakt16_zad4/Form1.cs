using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prakt16_zad4
{
    public partial class Form1 : Form
    {
        string file;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                file = openFileDialog1.FileName;
                button1.Visible = false;
                textBox1.Visible = true;
                label1.Visible = true;
                button2.Visible = true;
            }
            else MessageBox.Show("Вы не выбрали файл!", "Сообщение", MessageBoxButtons.OK);
           
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                if (long.Parse(textBox1.Text) > 0)
                {
                    Dictionary<string, long> count = new Dictionary<string, long>();
                    using (StreamReader st = new StreamReader(file))
                    {
                        string read;
                        while ((read = st.ReadLine()) != null)
                        {
                            listBox1.Items.Add(read);
                            string[] str = read.Split(' ');
                            string country = str[0];
                            //Если у нас миллионное население
                            if (str.Length == 4)
                            {
                                long num = long.Parse($"{str[1]}{str[2]}{str[3]}");
                                count[country] = num;
                            }
                            //Если миллиардное население
                            else if (str.Length == 5)
                            {
                                long num = long.Parse($"{str[1]}{str[2]}{str[3]}{str[4]}");
                                count[country] = num;
                            }

                        }
                    }
                    var filter = count.Where(a => a.Value > long.Parse(textBox1.Text)).OrderBy(a => a.Key.Length).ThenBy(a => a.Key);
                    foreach (var con in filter)
                    {
                        listBox2.Items.Add($"{con.Key} {con.Value}");
                    }
                    panel1.Visible = true;
                    panel2.Visible = true;
                    panel2.Visible = true;
                }
                else MessageBox.Show("Невозможно ввести отрицательное число населения", "Сообщение", MessageBoxButtons.OK);
            }
            catch { MessageBox.Show("Было введенно некорректное число!", "Сообщение", MessageBoxButtons.OK); }

        }
    }
}
