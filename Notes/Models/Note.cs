using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;

namespace Notes.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Text { get; set; }

        public int TimesClicked { get; set; }

        public string String
        {
            get
            {
                if (TimesClicked == 0)
                {
                    return string.Empty;
                }
                
                return $"Нажато: {TimesClicked} раз";
            }
        }

        public Color LayoutBackgroundColor
        {
            get
            {
                if (TimesClicked == 0)
                {
                    return Color.FromRgb(0xc6, 0xe6, 0xff);
                }

                return Color.FromRgb(0xaf, 0xaf, 0xdf);
            }
        }

        public Color TextColor
        {
            get
            {
                if (TimesClicked == 0)
                {
                    return Color.FromRgb(0x56, 0x56, 0x5f);
                }

                return Color.White;
            }
        }
    }
}
