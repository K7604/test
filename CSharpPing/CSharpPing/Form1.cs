using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using Newtonsoft.Json;
using System.IO;


namespace CSharpPing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bntPing_Click(object sender, EventArgs e)
        {
            List<PingResult> pingResults = new List<PingResult>();
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;
            PingReply first = pingSender.Send(txtBox1.Text, timeout, buffer, options);
            if (first.Status == IPStatus.Success)
            {
                pingResults.Add(new PingResult()
                {
                    address = first.Address.ToString(),
                    time = first.RoundtripTime.ToString()
                });
            }
            PingReply second = pingSender.Send(txtBox1.Text, timeout, buffer, options);
            if (second.Status == IPStatus.Success)
            {
                pingResults.Add(new PingResult()
                {
                    address = second.Address.ToString(),
                    time = second.RoundtripTime.ToString()
                });
            }
            PingReply third = pingSender.Send(txtBox1.Text, timeout, buffer, options);
            if (third.Status == IPStatus.Success)
            {
                pingResults.Add(new PingResult()
                {
                    address = third.Address.ToString(),
                    time = third.RoundtripTime.ToString()
                });
            }
            PingReply fourth = pingSender.Send(txtBox1.Text, timeout, buffer, options);
            if (fourth.Status == IPStatus.Success)
            {
                pingResults.Add(new PingResult()
                {
                    address = fourth.Address.ToString(),
                    time = fourth.RoundtripTime.ToString()
                });
            }
            string json = JsonConvert.SerializeObject(pingResults);
            string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var path = Path.Combine(dataPath, @"PingList.json");
            TextWriter tw = new StreamWriter(path, true);
            tw.WriteLine(json);
            tw.Close();
        }
    }
}
