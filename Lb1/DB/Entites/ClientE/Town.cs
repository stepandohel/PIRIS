namespace Lb1.DB.Entites.ClientE
{
    public class Town
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Client> Clients { get; set; }
    }
}
