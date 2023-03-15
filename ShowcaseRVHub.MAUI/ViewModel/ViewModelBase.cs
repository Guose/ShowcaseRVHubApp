using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ShowcaseRVHub.MAUI.ViewModel
{
    public class ViewModelBase : ObservableObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler MyPropertyChanged;

        protected virtual void OnMyPropertyChanged(string propertyName)
        {
            MyPropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void Dispose() { }
    }
}
