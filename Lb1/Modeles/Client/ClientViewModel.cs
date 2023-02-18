using Lb1.Modeles.Citizenship;
using Lb1.Modeles.MaritalStatus;
using Lb1.Modeles.Town;

namespace Lb1.Modeles.Client
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Male { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public string IssuedBy { get; set; }
        public DateTime IssueDate { get; set; }
        public string IdentificationNumber { get; set; }
        public string BirthPlace { get; set; }
        public string ResidenceActualAddress { get; set; }
        public string HomePhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string Email { get; set; }
        public string PlaceOfWork { get; set; }
        public string Occupation { get; set; }
        public TownViewModel Town { get; set; }
        public MaritalStatusViewModel MaritalStatus { get; set; }
        public CitizenshipViewModel Citizenship { get; set; }
        public bool IsRetired { get; set; }
        public double Income { get; set; }
    }
}
