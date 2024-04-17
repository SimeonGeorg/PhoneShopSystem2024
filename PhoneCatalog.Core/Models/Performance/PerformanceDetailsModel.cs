namespace PhoneCatalog.Core.Models.Performance
{
    public class PerformanceDetailsModel
    {
        public int Id { get; set; }
        public string Ram { get; set; } = null!;
      
        public string Processor { get; set; } = null!;
     
        public string Storage { get; set; } = null!;
       
        public string CameraPxl { get; set; } = null!;
       
        public string Battery { get; set; } = null!;
       
        public int PhoneId { get; set; }
       
    }
}
