using ShowcaseRVHub.MAUI.Model;
using ShowcaseRVHub.MAUI.View;
using System.Collections.ObjectModel;

namespace ShowcaseRVHub.MAUI.ViewModel
{
    [QueryProperty(nameof(User), "User")]
    public partial class RVNavigationViewModel : ViewModelBase
    {
        RVService _rvService;
        public RVNavigationViewModel()
        {
            _rvService = new RVService();
        }        

        [ObservableProperty]
        UserModel user;

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
                var vehicles = await _rvService.GetRVsAsync();

                foreach (var vehicle in vehicles)
                {
                    if (!vehicle.IsBooked)
                        continue;

                    RVs.Add(vehicle);
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
                var vehicles = await _rvService.GetRVsAsync();

                foreach (var vehicle in vehicles)
                {
                    if (vehicle.IsBooked)
                        continue;

                    RVs.Add(vehicle);
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
