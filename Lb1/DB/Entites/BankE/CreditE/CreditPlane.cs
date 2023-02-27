namespace Lb1.DB.Entites.BankE.CreditE
{
    public class CreditPlane
    {
        public int Id { get; set; }
        public string CreditType { get; set; }
        public string Name { get; set; }
        public double Percent { get; set; }

        public ICollection<CreditList> CreditLists { get; set; }
    }
}
