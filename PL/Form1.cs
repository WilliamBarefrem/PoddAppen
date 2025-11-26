using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BL;
using Models;
using Microsoft.VisualBasic;

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
            LaddaKategoriFilterCombo();
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
                lstPoddar.Items.Add(feed.Name);
            }
        }

        private void btnLaggTill_Click(object sender, EventArgs e)
        {
            string namn = txtName.Text;
            string rss = txtRssUrl.Text;

            if (lstCategories.SelectedIndex < 0)
            {
                MessageBox.Show("Välj en kategori först.");
                return;
            }

            // Hämta alla kategorier och ta den med samma index som det som valts i listan
            var categories = _categoryService.GetAll();
            var selectedCategory = categories[lstCategories.SelectedIndex];

            var nyPodd = new PoddFeed
            {
                Name = namn,
                RssUrl = rss,
                CategoryId = selectedCategory.Id!   // ← korrekt Mongo-ID
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
                lstCategories.Items.Add(c.Name);
            }
        }




        private void btnTaBortPodd_Click_1(object sender, EventArgs e)
        {
            {
                int index = lstPoddar.SelectedIndex;
                if (index < 0) return;

                var feeds = _poddService.GetAll();
                var valdPodd = feeds[index];

                _poddService.Delete(valdPodd.Id!);

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
            int index = lstCategories.SelectedIndex;
            if (index < 0)
                return;

            // Hämta alla kategorier från databasen
            var categories = _categoryService.GetAll();

            // Ta fram kategorin baserat på index
            var selectedCategory = categories[index];

            // Bekräftelse (krav i user story)
            var result = MessageBox.Show(
                "Vill du verkligen ta bort denna kategori?",
                "Bekräfta",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                _categoryService.Delete(selectedCategory.Id!);  // ← ID kommer från Mongo, inte från listboxen

                LaddaKategorierTillLista();
            }
        }

        private void btnLaddaRss_Click(object sender, EventArgs e)
        {
            string rssUrl = txtRssUrl.Text;

            // OM en podd är vald i listan: använd dess RSS-URL
            if (lstPoddar.SelectedIndex >= 0)
            {
                var feeds = _poddService.GetAll();
                var feed = feeds[lstPoddar.SelectedIndex];

                if (!string.IsNullOrWhiteSpace(feed.RssUrl))
                {
                    rssUrl = feed.RssUrl;
                    txtRssUrl.Text = feed.RssUrl;
                }
            }

            // Ingen RSS = inget att ladda
            if (string.IsNullOrWhiteSpace(rssUrl))
            {
                MessageBox.Show("Ingen RSS-URL att ladda.");
                return;
            }

            try
            {
                _currentEpisodes = _poddService.LoadEpisodesFromRss(rssUrl);

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

        private void btnShowRenamePodd_Click(object sender, EventArgs e)
        {
            int index = lstPoddar.SelectedIndex;
            if (index < 0)
            {
                MessageBox.Show("Välj en podd först.");
                return;
            }

            // Visa popup
            string newName = Interaction.InputBox(
                "Skriv in nytt namn för podden:",
                "Byt namn",
                ""
            );

            // Avbröt?
            if (string.IsNullOrWhiteSpace(newName))
                return;

            // Hämta podden
            var feeds = _poddService.GetAll();
            var feed = feeds[index];

            feed.Name = newName;

            _poddService.Update(feed);

            LaddaPoddarTillLista();
        }

        private void btnChangePoddCategory_Click(object sender, EventArgs e)
        {
            int index = lstPoddar.SelectedIndex;
            if (index < 0)
            {
                MessageBox.Show("Välj en podd först.");
                return;
            }

            // Popup där man skriver kategorinamnet man vill byta till
            string newCategoryName = Interaction.InputBox(
                "Skriv in namnet på den nya kategorin:",
                "Byt kategori",
                ""
            );

            // Avbröt?
            if (string.IsNullOrWhiteSpace(newCategoryName))
                return;

            // Hämta alla kategorier
            var categories = _categoryService.GetAll();

            // Leta efter kategori med det namnet
            var newCategory = categories.FirstOrDefault(c =>
                c.Name.Equals(newCategoryName, StringComparison.OrdinalIgnoreCase));

            if (newCategory == null)
            {
                MessageBox.Show("Ingen kategori med det namnet hittades.");
                return;
            }

            // Hämta vald podd
            var feeds = _poddService.GetAll();
            var feed = feeds[index];

            // Uppdatera kategori-ID
            feed.CategoryId = newCategory.Id;

            _poddService.Update(feed);

            MessageBox.Show("Kategori uppdaterad!");

            LaddaPoddarTillLista();
        }

        private void LaddaKategoriFilterCombo()
        {
            cmbCategoryFilter.Items.Clear();

            // Lägg till "Alla"
            cmbCategoryFilter.Items.Add("Alla");

            var categories = _categoryService.GetAll();

            foreach (var c in categories)
            {
                cmbCategoryFilter.Items.Add(c.Name);
            }

            // Default -> "Alla"
            cmbCategoryFilter.SelectedIndex = 0;
        }

        private void btnRenameCategory_Click(object sender, EventArgs e)
        {
            int index = lstCategories.SelectedIndex;
            if (index < 0)
            {
                MessageBox.Show("Välj en kategori först.");
                return;
            }

            // 2. Hämta alla kategorier och välj den markerade
            var categories = _categoryService.GetAll();
            var selectedCategory = categories[index];

            // 3. Visa popup för nytt namn (förifyllt med nuvarande namn)
            string newName = Interaction.InputBox(
                "Skriv in nytt namn för kategorin:",
                "Byt kategorinamn",
                selectedCategory.Name
            );

            // 4. Om användaren avbryter eller lämnar tomt → gör inget
            if (string.IsNullOrWhiteSpace(newName))
                return;

            // 5. Uppdatera kategoriobjektet
            selectedCategory.Name = newName;

            // 6. Spara via service (går vidare till Mongo)
            _categoryService.Update(selectedCategory);

            // 7. Ladda om listan så nya namnet syns
            LaddaKategorierTillLista();
        }

        private void cmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cmbCategoryFilter.SelectedItem.ToString();

            // Om "Alla" → visa alla
            if (selected == "Alla")
            {
                LaddaPoddarTillLista();
                return;
            }

            // Hämta kategorier och hitta vald
            var categories = _categoryService.GetAll();
            var selectedCategory = categories.FirstOrDefault(c => c.Name == selected);

            if (selectedCategory == null)
                return;

            var feeds = _poddService.GetAll();

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


