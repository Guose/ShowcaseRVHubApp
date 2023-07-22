using Syncfusion.Maui.Calendar;

namespace ShowcaseRVHub.MAUI.Helpers
{
    public class CalendarBehaviorHelper : Behavior<SfCalendar>
    {
        private SfCalendar sfCalendar;

        public static readonly BindableProperty StartRentalProperty = BindableProperty.Create(
        nameof(StartRental), typeof(DateTime), typeof(CalendarBehaviorHelper), default(DateTime));

        public static readonly BindableProperty EndRentalProperty = BindableProperty.Create(
            nameof(EndRental), typeof(DateTime), typeof(CalendarBehaviorHelper), default(DateTime));

        public DateTime StartRental
        {
            get => (DateTime)GetValue(StartRentalProperty);
            set => SetValue(StartRentalProperty, value);
        }

        public DateTime EndRental
        {
            get => (DateTime)GetValue(EndRentalProperty);
            set => SetValue(EndRentalProperty, value);
        }
        public bool IsDateRange { get; set; } = false;

        protected override void OnAttachedTo(SfCalendar bindable)
        {
            base.OnAttachedTo(bindable);
            sfCalendar = bindable;
            sfCalendar.SelectionChanged += SfCalendar_SelectionChanged;
        }

        private void SfCalendar_SelectionChanged(object sender, CalendarSelectionChangedEventArgs e)
        {
            if (sfCalendar.SelectedDateRange != null)
            {
                StartRental = (DateTime)sfCalendar.SelectedDateRange.StartDate;
                if (sfCalendar.SelectedDateRange.EndDate != null)
                {
                    EndRental = (DateTime)sfCalendar.SelectedDateRange.EndDate;
                    IsDateRange = true;
                }
                else
                {
                    EndRental = (DateTime)sfCalendar.SelectedDateRange.StartDate;
                }

                // Access the RentalCheckOutViewModel from the BindingContext of the SfCalendar
                var rentalCheckoutViewModel = sfCalendar.BindingContext as RentalCheckOutViewModel;

                if (rentalCheckoutViewModel != null && IsDateRange)
                {
                    // Set the StartRental and EndRental properties in the ViewModel
                    rentalCheckoutViewModel.StartRental = StartRental;
                    rentalCheckoutViewModel.EndRental = EndRental;
                }
            }
        }

        protected override void OnDetachingFrom(SfCalendar bindable)
        {
            base.OnDetachingFrom(bindable);

            if (sfCalendar != null)
            {
                sfCalendar.SelectionChanged -= SfCalendar_SelectionChanged;
            }
        }
    }
}
