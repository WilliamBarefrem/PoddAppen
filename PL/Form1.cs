using System;
using System.Windows.Forms;
using BL;
using Models;

namespace PL
{
    public partial class Form1 : Form
    {
        // 1) Fält för servicen
        private readonly IPoddFeedService _service;

        // 2) Konstruktorn tar emot IPoddFeedService
        public Form1(IPoddFeedService service)
        {
            InitializeComponent();
            _service = service;
        }

        private void btnLaggTill_Click(object sender, EventArgs e)
        {
            string namn = txtName.Text;
            string rss = txtRssUrl.Text;

            var nyPodd = new PoddFeed
            {
                Name = namn,
                RssUrl = rss
            };


            _service.Add(nyPodd);

            LaddaPoddarTillLista();

            txtName.Clear();
            txtRssUrl.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LaddaPoddarTillLista();
        }

        private void LaddaPoddarTillLista()
        {
            lstPoddar.Items.Clear();

            List<PoddFeed> feeds = _service.GetAll();

            foreach (var feed in feeds)
            {
                lstPoddar.Items.Add($"{feed.Id}: {feed.Name}");
            }
        }
    }
}