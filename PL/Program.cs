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

            // 1. Skapa repo (DAL)
            IRepository<PoddFeed> repo = new PoddFeedRepository();

            // 2. Skapa service (BL)
            IPoddFeedService service = new PoddFeedService(repo);

            // 3. Skicka in service till formuläret
            Application.Run(new Form1(service));
        }
    }
}