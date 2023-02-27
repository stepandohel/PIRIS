using Lb1.DB.Entites.ClientE;

namespace Lb1.DB.Entites.Bank
{
    public class DepositList
    {
        public int Id { get; set; }
        public int DepositPlaneId { get; set; }
        public DepositPlane DepositPlane { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public double StartAmount { get; set; }
        public double PercentAmount { get; set; }
    }
}
