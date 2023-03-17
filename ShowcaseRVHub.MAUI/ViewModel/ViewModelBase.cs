namespace ShowcaseRVHub.MAUI.ViewModel
{
    public partial class ViewModelBase : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBust))]
        bool isBusy;

        [ObservableProperty]
        string title;

        public bool IsNotBust => !IsBusy;

        protected virtual void Dispose() { }
    }
}
