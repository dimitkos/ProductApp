using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace ApiUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //HttpClient cl = new HttpClient();
            //cl.BaseAddress = new Uri("http://localhost:61342/product");
            //HttpResponseMessage response = cl.GetAsync("/getProducts").Result;

            //var pr = response.Content.ReadAsAsync<List<Product>>().Result;
            ////var pr = response.Content.ReadAsStringAsync().Result;
            //dataGridView1.DataSource = pr;

            GetAllProducts();

        }

        private async void GetAllProducts()
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("http://localhost:61342/product/getProducts"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var productJsonString = await response.Content.ReadAsStringAsync();

                        dataGridView1.DataSource = JsonConvert.DeserializeObject<Product>(productJsonString);

                    }
                }
            }
        }
    }
}
