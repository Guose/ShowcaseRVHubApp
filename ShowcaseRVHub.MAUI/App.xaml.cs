using Syncfusion.Licensing;

namespace ShowcaseRVHub.MAUI
{
    public partial class App : Application
    {
        public App()
        {
            //Register Syncfusion license
            SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt+QHJqXU1hXk5Hd0BLVGpAblJ3T2ZQdVt5ZDU7a15RRnVfRF1lSHZSdUBgXXtbcw==;Mgo+DSMBPh8sVXJ1S0R+VFpFdEBBXHxAd1p/VWJYdVt5flBPcDwsT3RfQF5jT35Vd01iWnpddHJURQ==;ORg4AjUWIQA/Gnt2VFhiQllPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9gSXhTcERrWHxbc3BSRWM=;MjMzNjU2OUAzMjMxMmUzMDJlMzBKL0lpa1FiSGR4MFc0bGg4WC9nVy94czNGRnY1d3dwZTFPY3NVdGU2WitzPQ==;MjMzNjU3MEAzMjMxMmUzMDJlMzBEeEhsNVRkNFhTSVhldTZ3NHprRnNEMkk0MXdZVmlqWnREcVJaWkRMYkdVPQ==;NRAiBiAaIQQuGjN/V0d+Xk9MfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5VdkNiUX5ddXdQQmdf;MjMzNjU3MkAzMjMxMmUzMDJlMzBSbkh1d0V2K2dnSTZUWUhPNkNLQ1M1bWZmRlVUcmdKMmd1L2k0MTdSU25RPQ==;MjMzNjU3M0AzMjMxMmUzMDJlMzBrOU9sVnpKaC9IK2RacXhRYjJudnFoUlRreDRrQWxJYklLNEk0S1kycGdVPQ==;Mgo+DSMBMAY9C3t2VFhiQllPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9gSXhTcERrWHxbc3JUQWM=;MjMzNjU3NUAzMjMxMmUzMDJlMzBYNEpJOG5hNnVrNldORXhFZDBTZzJWVkVaV0I4dDYyUTVESHpzYUNaVFRZPQ==;MjMzNjU3NkAzMjMxMmUzMDJlMzBvajhUN2doaHBDZWpwVVdwWWt3T3pKUUVOdVR1UGY4RENZUWNZZXM0WmVrPQ==;MjMzNjU3N0AzMjMxMmUzMDJlMzBSbkh1d0V2K2dnSTZUWUhPNkNLQ1M1bWZmRlVUcmdKMmd1L2k0MTdSU25RPQ==");

            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}