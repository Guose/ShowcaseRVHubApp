using ShowcaseRVHub.MAUI.Model.Enums;

namespace ShowcaseRVHub.MAUI.Model
{
    public class RVChecklistModel
    {
        public int Id { get; set; }


        public bool IsExteriorCleaned { get; set; }
        public bool IsInteriorCleaned { get; set; }
        public bool IsTiresInspected { get; set; }        


        public int RVId { get; set; }
        public RVModel RVModel { get; set; }
        public List<FluidType> Fluids { get; set; }
        public List<LevelType> Levels { get; set; }
        public List<RoutineMaintenanceType> RoutineMaintenances { get; set; }
    }
}
