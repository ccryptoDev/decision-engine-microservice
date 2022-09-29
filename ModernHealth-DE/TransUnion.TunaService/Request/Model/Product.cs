namespace DecisionEngine.TunaService.Request.Model
{
    public partial class Product
    {
        public string code { get; set; }

        //[XmlElement(elementName: "subject")]
        //public List<Subject> subject { get; set; }
        public Subject subject { get; set; }
        public ResponseInstructions responseInstructions { get; set; }
        public PermissiblePurpose permissiblePurpose { get; set; }
    }
}
