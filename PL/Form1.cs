using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BL;
using Models;

namespace PL
{
    public partial class Form1 : Form
    {
        // Services från BL-lagret
        private readonly IPoddFeedService _poddService;
        private readonly ICategoryService _categoryService;
        private List<Episode> _currentEpisodes = new();

        // Konstruktor tar emot båda services
        public Form1(IPoddFeedService poddService, ICategoryService categoryService)
        {
            InitializeComponent();
            _poddService = poddService;
            _categoryService = categoryService;
        }

        // När formuläret öppnas
        private void Form1_Load(object sender, EventArgs e)
        {
            LaddaPoddarTillLista();
            LaddaKategorierTillLista();
        }

        // ---------------------------
        // PODDFEEDS
        // ---------------------------

        private void LaddaPoddarTillLista()
        {
            lstPoddar.Items.Clear();

            List<PoddFeed> feeds = _poddService.GetAll();

            foreach (var feed in feeds)
            {
                lstPoddar.Items.Add($"{feed.Id}: {feed.Name}");
            }
        }

        private void btnLaggTill_Click(object sender, EventArgs e)
        {
            string namn = txtName.Text;
            string rss = txtRssUrl.Text;

            // Kolla att en kategori är vald
            if (lstCategories.SelectedItem == null)
            {
                MessageBox.Show("Välj en kategori först.");
                return;
            }

            // Plocka ut kategori-id från t.ex. "1: Humor"
            string selectedCategory = lstCategories.SelectedItem.ToString();
            string categoryId = selectedCategory.Split(':')[0].Trim();

            var nyPodd = new PoddFeed
            {
                Name = namn,
                RssUrl = rss,
                CategoryId = categoryId      // ← KOPPLINGEN HÄR
            };

            _poddService.Add(nyPodd);

            LaddaPoddarTillLista();

            txtName.Clear();
            txtRssUrl.Clear();
        }




        // ---------------------------
        // KATEGORIER
        // ---------------------------

        private void LaddaKategorierTillLista()
        {
            lstCategories.Items.Clear();

            List<Category> categories = _categoryService.GetAll();

            foreach (var c in categories)
            {
                lstCategories.Items.Add($"{c.Id}: {c.Name}");
            }
        }




        private void btnTaBortPodd_Click_1(object sender, EventArgs e)
        {
            {
                if (lstPoddar.SelectedItem == null)
                    return;

                string selected = lstPoddar.SelectedItem.ToString();
                string id = selected.Split(':')[0].Trim();

                _poddService.Delete(id);

                LaddaPoddarTillLista();
            }

        }

        private void btnAddCategory_Click_1(object sender, EventArgs e)
        {
            string name = txtCategoryName.Text;

            var category = new Category
            {
                Name = name
            };

            _categoryService.Add(category);

            LaddaKategorierTillLista();
            txtCategoryName.Clear();
        }

        private void btnDeleteCategory_Click_1(object sender, EventArgs e)
        {
            {
                // Ingen vald kategori → gör inget
                if (lstCategories.SelectedItem == null)
                    return;

                // Hämta ID från vald rad
                string selected = lstCategories.SelectedItem.ToString();
                string id = selected.Split(':')[0].Trim();

                // Bekräftelseruta (krav från user story)
                DialogResult result = MessageBox.Show(
                    "Vill du verkligen ta bort kategorin?",
                    "Bekräfta",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    _categoryService.Delete(id);
                    LaddaKategorierTillLista();
                }
            }
        }

        private void btnLaddaRss_Click(object sender, EventArgs e)
        {
            string rssUrl = txtRssUrl.Text;

            // OM en podd är vald i listan: använd dess RssUrl istället
            if (lstPoddar.SelectedItem != null)
            {
                string selected = lstPoddar.SelectedItem.ToString();
                string id = selected.Split(':')[0].Trim();   // "1: Min podd" → "1"

                var feed = _poddService.GetById(id);
                if (feed != null && !string.IsNullOrWhiteSpace(feed.RssUrl))
                {
                    rssUrl = feed.RssUrl;
                    txtRssUrl.Text = feed.RssUrl; // synka textboxen också (nice men frivilligt)
                }
            }

            // Om vi fortfarande inte har någon URL → gör inget
            if (string.IsNullOrWhiteSpace(rssUrl))
                return;

            // Hämta avsnitt via service
            _currentEpisodes = _poddService.LoadEpisodesFromRss(rssUrl);

            // Fyll avsnittslistan
            lstAvsnitt.Items.Clear();

            foreach (var ep in _currentEpisodes)
            {
                lstAvsnitt.Items.Add(ep.Title);
            }
        }

        private void lstAvsnitt_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstAvsnitt.SelectedIndex;

            if (index < 0 || index >= _currentEpisodes.Count)
                return;

            var ep = _currentEpisodes[index];

            txtEpisodeInfo.Text =
                $"Titel: {ep.Title}{Environment.NewLine}" +
                $"Publicerad: {ep.PublishDate}{Environment.NewLine}{Environment.NewLine}" +
                $"{ep.Description}";

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

