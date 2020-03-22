namespace Motobike.BusinessLogic.ViewModels.Request
{
    public class OrderRequest
    {
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string RegistryNumber { get; set; }
        public string TypeOfNumber { get; set; }
        public string Shape { get; set; } 
        public string Font { get; set; }
        public string SVGData { get; set; }
    }
}
