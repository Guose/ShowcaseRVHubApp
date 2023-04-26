using ShowcaseRVHub.MAUI.Model;
using ShowcaseRVHub.MAUI.View;
using System.Collections.ObjectModel;

namespace ShowcaseRVHub.MAUI.ViewModel
{
    public partial class RVSelectorViewModel : ViewModelBase
    {
        public ObservableCollection<RVModel> RVs { get; } = new();

        [RelayCommand]
        async Task GoToDetails(RVModel rvModel)
        {
            if (rvModel == null)
                return;

            await Shell.Current.GoToAsync(nameof(RVDetailsPage), true, new Dictionary<string, object>
            {
                {"RvModel", rvModel }
            });
        }
    }
}
