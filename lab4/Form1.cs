using System;
using System.Windows.Forms;

namespace lab4
{
    public partial class Form1 : Form
    {
        int gTime = 5;
        string encodedMessage = "";
        string sourceMessage;
        int M = 32;
        string key = "33922";
        Form2 form2;


        public Form1()
        {
            InitializeComponent();
        }

        private void EncodeMessage()
        {            
            sourceMessage = textBox1.Text;
            string tmp = sourceMessage;
            encodedMessage = "";
            int j = 0;
            for (int t = 0; t < gTime; t++, j = 0)
            {
                for (int i = 0; i < sourceMessage.Length; i++)
                {
                    encodedMessage += (char)((int)tmp[i] + key[j]);
                    j++;
                    if (j == key.Length)
                        j = 0;

                    //encodedMessage += (char)(((((int)tmp[j] - 1071) + key[i]) % M) + 1071);
                }
                tmp = encodedMessage;
                encodedMessage = "";
            }

            encodedMessage = tmp;
            textBox2.Text = encodedMessage;
        }

        private void SendMessage()
        {
            form2 = new Form2(encodedMessage, gTime, key);
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EncodeMessage();
            MessageBox.Show("Текст зашифрован и отправлен!");
            SendMessage();
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(((int)'ģ').ToString());
            //MessageBox.Show(((char)293).ToString());
        }
    }
}
