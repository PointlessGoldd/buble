using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] words = new string[]{
"выпербит",
"выпербить",
"выпирбит",
"запербит",
"запербить",
"запирбит",
"кеза",
"кезе",
"кезу",
"киза",
"кизе",
"кизу",
"отпербит",
"отпербить",
"отпирбит",
"пербит",
"пербить",
"пирбит",
"пирбить",
"подпербит",
"подпербить",
"подпирбит",
"хух"

};

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        StringBuilder word = new StringBuilder();
        
        private static int Compare(string key, string word)
        {
            int z = 0;
            if (word == key)
            {
                return 0;
            }
            while (true)
            {
                if (word[z] == key[z])
                {
                    z++;
                };
                if (key.Length == z)
                {
                    return -1;
                };
                if (word.Length == z)
                {
                    return 1;
                };
                if (word[z] > key[z])
                {
                    return -1;
                };
                if (word[z] < key[z])
                {
                    return 1;
                };
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            richTextBox1.Select(0, richTextBox1.Text.Length);
            richTextBox1.SelectionColor = Color.Black;
            for (int i = 0; i < richTextBox1.Text.Length; i++)
            {

                if (richTextBox1.Text[i] >= 'а' && richTextBox1.Text[i] <= 'я')
                {
                    word.Append(richTextBox1.Text[i]);
                }
                else
                {
                    if (word.Length > 0 && word.Length <= i)
                    {
                        int r = words.Length;
                        int l = 0;
                        do
                        {
                            int mid = l + (r - l) / 2;
                            if (Compare(Convert.ToString(word), words[mid]) == 0)
                            {
                                richTextBox1.Select(i - word.Length, word.Length);
                                richTextBox1.SelectionColor = Color.Blue;
                                break;
                            };
                            if (Compare(Convert.ToString(word), words[mid]) == -1)
                            { r = mid; };
                            if (Compare(Convert.ToString(word), words[mid]) == 1)
                            { l = mid + 1; };

                        } while (l < r);
                    };
                    word.Clear();
                }
            }

            

        }
    }
}
