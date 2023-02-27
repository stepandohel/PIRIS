namespace Lb1.DB.Entites.Bank
{
    public class DepositPlane
    {
        public int Id { get; set; }
        public string DepositType { get; set; }
        public string Name { get; set; }
        public double Percent { get; set; }

        public ICollection<DepositList> DepositLists { get; set; }
    }
}
