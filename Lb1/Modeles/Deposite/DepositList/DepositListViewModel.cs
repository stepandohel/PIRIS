using Lb1.Modeles.Client;
using Lb1.Modeles.Deposite.DepositPlane;

namespace Lb1.Modeles.Deposite.DepositList
{
    public class DepositListViewModel
    {
        public int Id { get; set; }
        public int DepositPlaneId { get; set; }
        public DepositPlaneViewModel DepositPlane { get; set; }
        public int ClientId { get; set; }
        public ClientViewModel Client { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public double StartAmount { get; set; }
        public double PercentAmount { get; set; }
    }
}
