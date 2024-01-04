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
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class NoteAddPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadNote(value);
            }
            get
            {
                Note note = (Note)BindingContext;

                if (note == null)
                {
                    return string.Empty;
                }

                return note.Id.ToString();
            }
        }
        public NoteAddPage()
        {
            InitializeComponent();
            editor.Text = string.Empty;

            BindingContext = new Note();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            editor.Text = string.Empty;
        }

        private async void LoadNote(string value)
        {
            try
            {
                int id = Convert.ToInt32(value);

                Note note = await App.DataBase[id];

                BindingContext = note;
            }
            catch (Exception)
            {
            }
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            Note note = new Note();

            note.TimesClicked = 0;
            note.Text = editor.Text;

            if (!string.IsNullOrWhiteSpace(note.Text))
            {
                await App.DataBase.SaveAsync(note);
            }
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            Note note = (Note)BindingContext;

            await App.DataBase.DeleteNoteAsync(note);

            await Shell.Current.GoToAsync("..");
        }
    }
}