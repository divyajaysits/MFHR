namespace MF.HR.Entity
{
    public class Employee
    {

        public int ID { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public int? TitleId { get; set; } = null;
        public int? CivilStatusId { get; set; } = null;
        public int? DepartmentId { get; set; } = null;
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateTime Dateofbirth { get; set; } = DateTime.MinValue;
        public int? GenderId { get; set; } = null;
        public string NIC { get; set; } = "";
        public string Nationality { get; set; } = "";
        public string Email { get; set; } = "";
        public string MobilePhoneNo { get; set; } = "";
        public string AddressLine1 { get; set; } = "";
        public string AddressLine2 { get; set; } = "";
        public string City { get; set; } = "";
        public string Country { get; set; } = "";

        public string EPFNo { get; set; } = "";
        public string Designation { get; set; } = "";
        public DateTime DateJoined { get; set; } = DateTime.MinValue;

    }
}
