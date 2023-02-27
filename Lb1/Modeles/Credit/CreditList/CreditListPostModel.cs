namespace Lb1.Modeles.Credit.CreditList
{
    public class CreditListPostModel
    {
        public int Id { get; set; }
        public int CreditPlaneId { get; set; }
        public int ClientId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public double StartAmount { get; set; }
        public double PercentAmount { get; set; }
        public int CreditCardId { get; set; }
    }
}
