namespace ReSharperTnT.Models
{
    public class ResharperTip
    {
        public ResharperTip(string tip)
        {
            Tip = tip;
            Success = true;
        }

        public bool Success { get; set; }
        public string Tip { get; set; }

        public override string ToString()
        {
            return string.Format("Tip: {0}", Tip);
        }
    }
}