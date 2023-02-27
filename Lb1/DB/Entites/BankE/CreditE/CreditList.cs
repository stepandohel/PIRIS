using Lb1.DB.Entites.ATM;
using Lb1.DB.Entites.ClientE;

namespace Lb1.DB.Entites.BankE.CreditE
{
    public class CreditList
    {
        public int Id { get; set; }
        public int CreditPlaneId { get; set; }
        public CreditPlane CreditPlane { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public double StartAmount { get; set; }
        public double PercentAmount { get; set; }
        public int CreditCardId { get; set; }
        public CreditCard CreditCard { get; set; }
    }
}
