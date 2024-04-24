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
        private string first = "250";
        private string second = "250";
        private string third = "600";
        private string fourth = "600";
        private string fifth = "32";
        private string sixth = "0,14";
        private string seventh = "I";
        private string eighth = "48";

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "192.168.100.153";
        }

        private void SendZplOverTcp()
        {
            _ipAdress = textBox1.Text; //192.168.100.153
            Connection conn = new TcpConnection(_ipAdress, 9100);
            try
            {
                conn.Open();

                string zplData = "^XA^FO20,20^A0N,25,25^FDЭто тест zpl.^FS^XZ";
                string zplData2 = "^XA" + 
                    $"^AA,1,10,10,2^FO152,290^FD{first}^FS" +
                    $"^AA,1,10,10,2^FO152,290^FD{second}^FS" + 
                    $"^AA,1,10,10,2^FO320,290^FD{third}^FS" +
                    $"^AA,1,7,9,2^FO285,332^FD{fourth}^FS" +
                    $"^AA,1,7,9,2^FO285,355^FD{fifth}^FS" +
                    $"^AA,1,7,9,2^FO282,382^FD{sixth}^FS" +
                    $"^AA,1,7,9,2^FO290,408^FD{seventh}^FS" +
                    $"^AA,1,7,9,2^FO290,446^FD{eighth}^FS" +
                    "^XZ";

                string zplData3 = "^XA\r\n^AA,1,10,10,2^FO152,290^FD250^FS\r\n^AA,1,10,10,2^FO233,290^FD250^FS \r\n^AA,1,10,10,2^FO320,290^FD600^FS\r\n^AA,1,7,9,2^FO285,332^FD600^FS\r\n^AA,1,7,9,2^FO285,355^FD35^FS\r\n^AA,1,7,9,2^FO282,382^FD0,14^FS\r\n^AA,1,7,9,2^FO290,408^FDI^FS\r\n^AA,1,7,9,2^FO290,446^FD48^FS\r\n^XZ";

                conn.Write(Encoding.UTF8.GetBytes(zplData3));
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
