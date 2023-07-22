using System.Collections.ObjectModel;

namespace ShowcaseRVHub.MAUI.ViewModel
{
    [QueryProperty(nameof(User), "User")]
    public partial class RVNavigationViewModel : ViewModelBase
    {
        readonly RvDataService _rvService;
        public RVNavigationViewModel()
        {
            _rvService = new RvDataService();
        }

        public Dictionary<string, object> ParameterObjs { get; set; } = new Dictionary<string, object>();

        [ObservableProperty]
        UserModel user;

        [ObservableProperty]
        string buttonText;

        public ObservableCollection<RVModel> RVsCollection { get; set; } = new();

        [RelayCommand]
        public async Task GoToRVCheckInOrOut(RVModel model)
        {
            try
            {
                if (model == null)
                    return;

                if (ParameterObjs.Count <= 0)
                {
                    ParameterObjs.Add("RvModel", model);
                    ParameterObjs.Add("User", User);
                }

                await Shell.Current.GoToAsync($"{nameof(RentalCheckOutView)}?ButtonText={ButtonText}", true, ParameterObjs);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"---> Unable to navigate to the next page. EXCEPTION: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }            
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

                ButtonText = "Check Out";

                RVsCollection.Clear();

                var vehicles = await _rvService.GetAllRVsAsync();

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

                ButtonText = "Check In";

                RVsCollection.Clear();

                var vehicles = await _rvService.GetAllRVsAsync();

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
