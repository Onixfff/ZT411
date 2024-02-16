using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zebra;
using Zebra.Sdk.Comm;
using Zebra.Sdk.Comm.Internal;

namespace ZT411
{
    public partial class Form1 : Form
    {
        private string _ipAdress;
        public Form1()
        {
            InitializeComponent();
        }

        private void SendZplOverTcp()
        {
            _ipAdress = textBox1.Text;
            Connection conn = new TcpConnection(_ipAdress, 9100);
            try
            {
                conn.Open();

                string zplData = "^XA^FO20,20^A0N,25,25^FDЭто тест zpl.^FS^XZ";

                conn.Write(Encoding.UTF8.GetBytes(zplData));
                Console.WriteLine("Всё прошло");
                MessageBox.Show("Всё прошло");
            }
            catch (ConnectionException ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
            }
            finally { conn.Close(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendZplOverTcp();
        }
    } 
}
