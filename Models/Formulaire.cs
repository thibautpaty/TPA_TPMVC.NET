
namespace TPLOCAL1.Models
{
    public class Formulaire
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }

        public DateTime StartDate { get; set; }
        public string TrainingType { get; set; }

        public string CobolFormation { get; set; }
        public string CSharpFormation { get; set; }
    }
}
