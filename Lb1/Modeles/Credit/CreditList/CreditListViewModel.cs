using Lb1.Modeles.Client;
using Lb1.Modeles.Credit.CreditPlane;

namespace Lb1.Modeles.Credit.CreditList
{
    public class CreditListViewModel
    {
        public int Id { get; set; }
        public int CreditPlaneId { get; set; }
        public CreditPlaneViewModel CreditPlane { get; set; }
        public int ClientId { get; set; }
        public ClientViewModel Client { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public double StartAmount { get; set; }
        public double PercentAmount { get; set; }
    }
}
