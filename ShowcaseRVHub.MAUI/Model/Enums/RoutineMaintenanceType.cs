using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowcaseRVHub.MAUI.Model.Enums
{
    public enum RoutineMaintenanceType : byte
    {
        None = 0,
        OilChange = 1,
        GeneratorTuneUp = 2,
        TireRotation = 3,
        Brakes = 4,
        TransmissionFluidChange = 5,
        Appliances = 6,
    }
}
