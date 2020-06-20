using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinApp.Models
{
    public class MasterMenuItem
    {
        public string Title { get; set; }
        public string IconSource { get; set; }
        public Color BackgroundColor { get; set; }
        public Type TargetType { get; set; }

        public MasterMenuItem(string title, string iconsrc, Color col, Type target)
        {
            this.Title = title;
            this.IconSource = iconsrc;
            this.BackgroundColor = col;
            this.TargetType = target;
        }
    }
}
