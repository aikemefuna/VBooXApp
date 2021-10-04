namespace VBooX.Application.DTOs.Customer
{
    public class CustomerDTO
    {
        public string UserId { get; set; }
        public string AccessToken { get; set; }
        public string AccountNumber { get; set; }
        public string Photograph { get; set; }
        public string FullName { get; }
        public string PhoneNo { get; set; }
        public string Gender { get; set; }
        public string LGA { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        //public List<VisitorBook> VisitorBooks { get; set; }
    }
}
