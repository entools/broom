﻿using EntoolsBroom.Annotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace EntoolsBroom.ViewModel
{
    class ModelBase :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
