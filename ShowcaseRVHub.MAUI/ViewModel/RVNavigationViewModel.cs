using ShowcaseRVHub.MAUI.Model;
using ShowcaseRVHub.MAUI.View;
using System.Collections.ObjectModel;

namespace ShowcaseRVHub.MAUI.ViewModel
{
    [QueryProperty(nameof(User), "User")]
    public partial class RVNavigationViewModel : ViewModelBase
    {
        readonly RVChecklistViewModel _checklistViewModel;
        readonly RVService _rvService;
        public RVNavigationViewModel()
        {
            _checklistViewModel = new RVChecklistViewModel();
            _rvService = new RVService();
        }

        bool isCheckOut;

        [ObservableProperty]
        UserModel user;

        public ObservableCollection<RVModel> RVsCollection { get; set; } = new();

        [RelayCommand]
        public async Task GoToChecklist(RVModel model)
        {
            if (model == null)
                return;

            if (isCheckOut)
                _checklistViewModel.ButtonText = "Check Out";
            else
                _checklistViewModel.ButtonText = "Check In";

            await Shell.Current.GoToAsync(nameof(RVChecklistView), true, new Dictionary<string, object>
            {
                { nameof(RVModel), model }
            });
        }

        [RelayCommand]
        public async Task GetDepartureRvsAsync()
        {
            if (IsBusy)
                return;

            try
            {
                if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("No connectivity!", $"Please check internet and try again.", "OK");
                    return;
                }

                IsBusy = true;

                isCheckOut = true;

                RVsCollection.Clear();

                var vehicles = await _rvService.GetRVsAsync();

                foreach (var vehicle in vehicles)
                {
                    if (vehicle.IsBooked)
                        continue;

                    RVsCollection.Add(vehicle);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"---> Unable to GET departured RV's: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        public async Task GetArrivalRvsAsync()
        {
            if (IsBusy)
                return;

            try
            {
                if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("No connectivity!", $"Please check internet and try again.", "OK");
                    return;
                }

                IsBusy = true;

                RVsCollection.Clear();

                isCheckOut = false;

                var vehicles = await _rvService.GetRVsAsync();

                foreach (var vehicle in vehicles)
                {
                    if (!vehicle.IsBooked)
                        continue;

                    RVsCollection.Add(vehicle);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"---> Unable to GET departured RV's: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }
    }
}
