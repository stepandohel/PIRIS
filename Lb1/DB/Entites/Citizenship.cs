﻿namespace Lb1.DB.Entites
{
    public class Citizenship
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Client> Clients { get; set; }
    }
}
