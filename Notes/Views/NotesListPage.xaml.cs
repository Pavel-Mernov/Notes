using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Notes.Models;

namespace Notes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesListPage : ContentPage
    {
        private bool deleteButtonClicked = false;
        public NotesListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            collectionView.ItemsSource = await App.DataBase.Notes;

            base.OnAppearing();
        }

        private async void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection == null)
            {
                return;
            }

            Note note = e.CurrentSelection.FirstOrDefault() as Note;

            if (deleteButtonClicked)
            {
                await App.DataBase.DeleteNoteAsync(note);

                collectionView.ItemsSource = await App.DataBase.Notes;

                deleteButton_Clicked(sender, EventArgs.Empty);

                return;
            }

            note.TimesClicked++;

            await App.DataBase.SaveAsync(note);

            collectionView.ItemsSource = await App.DataBase.Notes;

            
        }

        private void deleteButton_Clicked(object sender, EventArgs e)
        {
            deleteButtonClicked = !deleteButtonClicked;

            if (deleteButtonClicked)
            {
                deleteButton.BackgroundColor = Color.FromRgb(0x5f, 0x5f, 0xff);
                deleteButton.TextColor = Color.FromRgb(0x9d, 0x9d, 0x9d);
            }
            else
            {
                deleteButton.BackgroundColor = Color.FromRgb(0xaf, 0xaf, 0xff);
                deleteButton.TextColor = Color.FromRgb(0xfd, 0xfd, 0xfd);
            }
        }

        private async void resetButton_Clicked(object sender, EventArgs e)
        {
            Note currentNote;

            foreach (var item in collectionView.ItemsSource)
            {
                currentNote = item as Note;
                currentNote.TimesClicked = 0;
                await App.DataBase.SaveAsync(currentNote);
            }

            collectionView.ItemsSource = await App.DataBase.Notes;
        }
    }
}