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
        public Form1()
        {
            InitializeComponent();
        }

        private void SendZplOverTcp(string ipAdress)
        {
            Connection conn = new TcpConnection(ipAdress, TcpConnection.DEFAULT_ZPL_TCP_PORT);

            try
            {
                conn.Open();

                string zplData = "^XA^FO20,20^A0N,25,25^FDЭто тест zpl.^FS^XZ";

                conn.Write(Encoding.UTF8.GetBytes(zplData));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { conn.Close(); }
        }
    }
}
