namespace Lb1.DB.Entites
{
    public class MaritalStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public ICollection<Client> Clients { get; set; }
    }
}
