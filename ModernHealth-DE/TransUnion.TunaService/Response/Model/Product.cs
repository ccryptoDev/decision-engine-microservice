namespace DecisionEngine.TunaService.Response.Model
{
    public partial class Product
    {
        public string code { get; set; }

        //[XmlElement(elementName: "subject")]
        //public List<Subject> subject { get; set; }

        public Subject subject { get; set; }
        public ProductError error { get; set; }
    }
}
