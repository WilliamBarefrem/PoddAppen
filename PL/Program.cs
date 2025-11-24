using System;
using System.Windows.Forms;
using BL;
using DAL;
using Models;

namespace PL
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // ====== PoddFeed setup ======
            IRepository<PoddFeed> poddRepo = new PoddFeedRepository();
            IPoddFeedService poddService = new PoddFeedService(poddRepo);

            // ====== Category setup ======
            IRepository<Category> categoryRepo = new CategoryRepository();
            ICategoryService categoryService = new CategoryService(categoryRepo);

            // ====== Start WinForms with BOTH services ======
            Application.Run(new Form1(poddService, categoryService));
        }
    }
}
