using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:44396/api/book";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            WebResponse response = request.GetResponse();
            Stream binaryResponse = response.GetResponseStream();
            StreamReader reader = new StreamReader(binaryResponse);
            string text = reader.ReadToEnd();
            richTextBox1.Text = text;
            List<Book> books = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Book>>(Text);
            dataGridView1.DataSource = books;

        }
    }
}
