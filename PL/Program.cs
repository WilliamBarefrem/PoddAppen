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

            var connectionString =
                "mongodb+srv://muretdurakovic_db_user:Denko@poddappen.z6ewler.mongodb.net/?appName=PoddAppen";

            // Repositories
            IRepository<PoddFeed> poddRepo = new MongoPoddFeedRepository(connectionString);
            IRepository<Category> categoryRepo = new MongoCategoryRepository(connectionString);

            // Services – dessa SKA skickas in till Form1
            IPoddFeedService poddService = new PoddFeedService(poddRepo);
            ICategoryService categoryService = new CategoryService(categoryRepo);

            Application.Run(new Form1(poddService, categoryService));
        }
    }
}