using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WpfGarage.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        public virtual void NotifyPropertyChanged(params string[] propertynames)
        {
            if (PropertyChanged != null)
            {
                foreach (var p in propertynames)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(p));
                }
            }
        }
    }
}
