using Lb1.DB.Entites.BankE.CreditE;

namespace Lb1.DB.Entites.ATM
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Pin { get; set; }

        public ICollection<CreditList> CreditLists { get; set; }
    }
}
