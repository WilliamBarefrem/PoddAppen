using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using Models;
using Microsoft.VisualBasic;

namespace PL
{
    public partial class Form1 : Form
    {
        
        private readonly IPoddFeedService _poddService;
        private readonly ICategoryService _categoryService;
        private List<Episode> _currentEpisodes = new();

       
        public Form1(IPoddFeedService poddService, ICategoryService categoryService)
        {
            InitializeComponent();
            _poddService = poddService;
            _categoryService = categoryService;
        }

        
        private async void Form1_Load(object sender, EventArgs e)
        {
            await LaddaPoddarTillListaAsync();
            await LaddaKategorierTillListaAsync();
            await LaddaKategoriFilterComboAsync();
        }

        

        private async Task LaddaPoddarTillListaAsync()
        {
            lstPoddar.Items.Clear();

            List<PoddFeed> feeds = await _poddService.GetAllAsync();

            foreach (var feed in feeds)
            {
                lstPoddar.Items.Add(feed.Name);
            }
        }

        private async void btnLaggTill_Click(object sender, EventArgs e)
        {
            string namn = txtName.Text;
            string rss = txtRssUrl.Text;

            if (lstCategories.SelectedIndex < 0)
            {
                MessageBox.Show("Välj en kategori först.");
                return;
            }
            if (string.IsNullOrWhiteSpace(namn))
            {
                MessageBox.Show("Poddnamn får inte vara tomt.");
                return;
            }

            if (string.IsNullOrWhiteSpace(rss))
            {
                MessageBox.Show("RSS-URL får inte vara tom.");
                return;
            }

            var categories = await _categoryService.GetAllAsync();
            var selectedCategory = categories[lstCategories.SelectedIndex];

            var nyPodd = new PoddFeed
            {
                Name = namn,
                RssUrl = rss,
                CategoryId = selectedCategory.Id!  
            };

            await _poddService.AddAsync(nyPodd);

            await LaddaPoddarTillListaAsync();

            txtName.Clear();
            txtRssUrl.Clear();
        }

        

        private async Task LaddaKategorierTillListaAsync()
        {
            lstCategories.Items.Clear();

            List<Category> categories = await _categoryService.GetAllAsync();

            foreach (var c in categories)
            {
                lstCategories.Items.Add(c.Name);
            }
        }

        private async void btnTaBortPodd_Click_1(object sender, EventArgs e)
        {
           
            try
            {
                int index = lstPoddar.SelectedIndex;
                if (index < 0) return;


                var feeds = await _poddService.GetAllAsync();
                var valdPodd = feeds[index];

                await _poddService.DeleteAsync(valdPodd.Id!);

                await LaddaPoddarTillListaAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ett fel uppstod när podden skulle tas bort.\n" + ex.Message);
            }
        }

        private async void btnAddCategory_Click_1(object sender, EventArgs e)
        {
            string name = txtCategoryName.Text;

            var category = new Category
            {
                Name = name
            };

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Kategorinamn får inte vara tomt.");
                return;
            }

            await _categoryService.AddAsync(category);

            await LaddaKategorierTillListaAsync();
            txtCategoryName.Clear();
        }

        private async void btnDeleteCategory_Click_1(object sender, EventArgs e)
        {
            int index = lstCategories.SelectedIndex;
            if (index < 0)
                return;

            var categories = await _categoryService.GetAllAsync();
            var selectedCategory = categories[index];

            var result = MessageBox.Show(
                "Vill du verkligen ta bort denna kategori?",
                "Bekräfta",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                await _categoryService.DeleteAsync(selectedCategory.Id!);
                await LaddaKategorierTillListaAsync();
                await LaddaKategoriFilterComboAsync();
            }
        }

        private async void btnLaddaRss_Click(object sender, EventArgs e)
        {
            string rssUrl = txtRssUrl.Text;

            if (lstPoddar.SelectedIndex >= 0)
            {
                var feeds = await _poddService.GetAllAsync();
                var feed = feeds[lstPoddar.SelectedIndex];

                if (!string.IsNullOrWhiteSpace(feed.RssUrl))
                {
                    rssUrl = feed.RssUrl;
                    txtRssUrl.Text = feed.RssUrl;
                }
            }

            if (string.IsNullOrWhiteSpace(rssUrl))
            {
                MessageBox.Show("Ingen RSS-URL att ladda.");
                return;
            }

            try
            {
                _currentEpisodes = await _poddService.LoadEpisodesFromRssAsync(rssUrl);

                lstAvsnitt.Items.Clear();

                foreach (var ep in _currentEpisodes)
                {
                    lstAvsnitt.Items.Add(ep.Title);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kunde inte läsa RSS-flödet.\n" + ex.Message);
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

        private async void btnShowRenamePodd_Click(object sender, EventArgs e)
        {
            int index = lstPoddar.SelectedIndex;
            if (index < 0)
            {
                MessageBox.Show("Välj en podd först.");
                return;
            }

            string newName = Interaction.InputBox(
                "Skriv in nytt namn för podden:",
                "Byt namn",
                ""
            );

            if (string.IsNullOrWhiteSpace(newName))
                return;

            var feeds = await _poddService.GetAllAsync();
            var feed = feeds[index];

            feed.Name = newName;

            await _poddService.UpdateAsync(feed);

            await LaddaPoddarTillListaAsync();
        }

        private async void btnChangePoddCategory_Click(object sender, EventArgs e)
        {
            int index = lstPoddar.SelectedIndex;
            if (index < 0)
            {
                MessageBox.Show("Välj en podd först.");
                return;
            }

            string newCategoryName = Interaction.InputBox(
                "Skriv in namnet på den nya kategorin:",
                "Byt kategori",
                ""
            );

            if (string.IsNullOrWhiteSpace(newCategoryName))
                return;

            var categories = await _categoryService.GetAllAsync();

            var newCategory = categories.FirstOrDefault(c =>
                c.Name.Equals(newCategoryName, StringComparison.OrdinalIgnoreCase));

            if (newCategory == null)
            {
                MessageBox.Show("Ingen kategori med det namnet hittades.");
                return;
            }

            var feeds = await _poddService.GetAllAsync();
            var feed = feeds[index];

            feed.CategoryId = newCategory.Id;

            await _poddService.UpdateAsync(feed);

            MessageBox.Show("Kategori uppdaterad!");

            await LaddaPoddarTillListaAsync();
        }

        private async Task LaddaKategoriFilterComboAsync()
        {
            cmbCategoryFilter.Items.Clear();
            cmbCategoryFilter.Items.Add("Alla");

            var categories = await _categoryService.GetAllAsync();

            foreach (var c in categories)
            {
                cmbCategoryFilter.Items.Add(c.Name);
            }

            cmbCategoryFilter.SelectedIndex = 0;
        }

        private async void btnRenameCategory_Click(object sender, EventArgs e)
        {
            int index = lstCategories.SelectedIndex;
            if (index < 0)
            {
                MessageBox.Show("Välj en kategori först.");
                return;
            }

            var categories = await _categoryService.GetAllAsync();
            var selectedCategory = categories[index];

            string newName = Interaction.InputBox(
                "Skriv in nytt namn för kategorin:",
                "Byt kategorinamn",
                selectedCategory.Name
            );

            if (string.IsNullOrWhiteSpace(newName))
                return;

            selectedCategory.Name = newName;

            await _categoryService.UpdateAsync(selectedCategory);

            await LaddaKategorierTillListaAsync();
            await LaddaKategoriFilterComboAsync();
        }

        private async void cmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cmbCategoryFilter.SelectedItem.ToString();

            if (selected == "Alla")
            {
                await LaddaPoddarTillListaAsync();
                return;
            }

            var categories = await _categoryService.GetAllAsync();
            var selectedCategory = categories.FirstOrDefault(c => c.Name == selected);

            if (selectedCategory == null)
                return;

            var feeds = await _poddService.GetAllAsync();

            var filtered = feeds
                .Where(f => f.CategoryId == selectedCategory.Id)
                .ToList();

            lstPoddar.Items.Clear();

            foreach (var feed in filtered)
            {
                lstPoddar.Items.Add(feed.Name);
            }
        }

        private void txtEpisodeInfo_TextChanged(object sender, EventArgs e)
        {
        }

        private void lblBiblotek_Click(object sender, EventArgs e)
        {
        }
    }
}