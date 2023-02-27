namespace Lb1.Modeles.Deposite.DepositList
{
    public class DepositListPostModel
    {
        public int DepositPlaneId { get; set; }
        public int ClientId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public double StartAmount { get; set; }
        public double PercentAmount { get; set; }
    }
}
