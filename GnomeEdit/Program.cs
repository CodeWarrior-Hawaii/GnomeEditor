using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Game;
using Microsoft.Xna.Framework;

namespace GnomeEdit
{
    class Program
    {
        public static BackgroundWorker LoadGameBackgroundWorker { get; set; }
        static void Main(string[] args)
        {
            LoadGameBackgroundWorker = new BackgroundWorker();
            LoadGameBackgroundWorker.DoWork += worker_doWork;
            LoadGameBackgroundWorker.RunWorkerCompleted += worker_finish;
            LoadGameBackgroundWorker.RunWorkerAsync();
            Thread.Sleep(20000);
            

            Console.WriteLine("Press A key");
        }

        private static void worker_doWork(object sender, DoWorkEventArgs e)
        {
            var game = GnomanEmpire.Instance;
            
            game.LoadGame("world01.sav");
        }

        private static void worker_finish(object sender, RunWorkerCompletedEventArgs e)
        {
            DoTheRest();
        }

        private static void DoTheRest()
        {
            try
            {
                var entities = GnomanEmpire.Instance.EntityManager.Entities;
                foreach (var gameEntity in entities)
                {
                    Console.WriteLine(gameEntity.Value.Name());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        
    }
}
