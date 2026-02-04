namespace Coffee.Kiosk.CMS.DTOs
{
    public class DisplayDTO
    {
        public string PrimaryID { get; set; } = string.Empty;  

        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {MiddleName} {LastName}".Replace("  ", " ").Trim();

        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string EmergencyFirstName { get; set; } = string.Empty;
        public string EmergencyLastName { get; set; } = string.Empty;
        public string EmergencyNumber { get; set; } = string.Empty;

        public string JobTitle { get; set; } = string.Empty;
        public string Salary { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;          
        public string Department { get; set; } = string.Empty;    
        public string EmploymentType { get; set; } = string.Empty; 
        public string Status { get; set; } = string.Empty;

        public string? ProfilePicturePath { get; set; }

    }
}
