using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Notes.Data;
using System.IO;

namespace Notes
{
    public partial class App : Application
    {
        static readonly DataBase _dataBase = new DataBase(
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "NotesDataBase.db3"));

        public static DataBase DataBase => _dataBase;

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
