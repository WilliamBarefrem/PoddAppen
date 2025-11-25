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

            // TODO: byt till din riktiga connection string från Atlas
            var connectionString = "mongodb+srv://muretdurakovic_db_user:Denko@poddappen.z6ewler.mongodb.net/?appName=PoddAppen";

            // Poddar via Mongo
            IRepository<PoddFeed> poddRepo = new MongoPoddFeedRepository(connectionString);
            IPoddFeedService poddService = new PoddFeedService(poddRepo);

            // Kategorier via Mongo
            IRepository<Category> categoryRepo = new MongoCategoryRepository(connectionString);
            ICategoryService categoryService = new CategoryService(categoryRepo);

            Application.Run(new Form1(poddService, categoryService));
        }
    }
}
