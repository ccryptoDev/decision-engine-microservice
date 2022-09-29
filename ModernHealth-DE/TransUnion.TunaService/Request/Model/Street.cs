namespace DecisionEngine.TunaService.Request.Model
{
    public class Street
    {
        public string number { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string preDirectional { get; set; }
        public Unit unit { get; set; }
    }

    public class Unit
    {
        public string type { get; set; }
        public string number { get; set; }
    }
}
