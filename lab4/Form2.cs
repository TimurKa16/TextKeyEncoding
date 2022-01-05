using System;
using System.Windows.Forms;

namespace lab4
{
    public partial class Form2 : Form
    {
        string encodedMessage;
        string sourceMessage = "";
        int M = 32;
        string key;
        int gTime;


        public Form2(string encodedMessage, int gTime, string key)
        {
            InitializeComponent();
            this.encodedMessage = encodedMessage;
            this.gTime = gTime;
            this.key = key;
        }

        private void EncodeMessage()
        {
            encodedMessage = textBox1.Text;
            sourceMessage = "";
            string tmp = encodedMessage;
            int j = 0;
            for (int t = 0; t < gTime; t++, j = 0)
            {
                for (int i = 0; i < encodedMessage.Length; i++)
                {
                    sourceMessage += (char)((int)tmp[i] - key[j]);
                    j++;
                    if (j == key.Length)
                        j = 0;
                }
                tmp = sourceMessage;
                sourceMessage = "";
            }
            sourceMessage = tmp;
            textBox2.Text = sourceMessage;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EncodeMessage();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = encodedMessage;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
