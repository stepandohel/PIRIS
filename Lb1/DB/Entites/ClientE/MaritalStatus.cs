namespace Lb1.DB.Entites.ClientE
{
    public class MaritalStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public ICollection<Client> Clients { get; set; }
    }
}
