using Syncfusion.Maui.Calendar;

namespace ShowcaseRVHub.MAUI.Helpers
{
    public class CalendarBehaviorHelper : Behavior<SfCalendar>
    {
        private SfCalendar sfCalendar;
        public RentalModel Rental { get; set; }

        public CalendarBehaviorHelper(RentalModel rental)
        {
            Rental = rental;
        }

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
                Rental.RentalStart = (DateTime)sfCalendar.SelectedDateRange.StartDate;
                if (sfCalendar.SelectedDateRange.EndDate != null)
                {
                    Rental.RentalEnd = (DateTime)sfCalendar.SelectedDateRange.EndDate;
                }
                else
                {
                    Rental.RentalEnd = (DateTime)sfCalendar.SelectedDateRange.StartDate;
                }

                App.Current.MainPage.DisplayAlert($"StartDate: {Rental.RentalStart:dd/MM/yyyy}", 
                    $"EndDate: {Rental.RentalEnd:dd/MM/yyyy}", "OK");
            }
        }

        protected override void OnDetachingFrom(SfCalendar bindable)
        {
            base.OnDetachingFrom(bindable);

            if (sfCalendar != null)
            {
                sfCalendar.SelectionChanged -= SfCalendar_SelectionChanged;
            }

            sfCalendar = null;
        }
    }
}
