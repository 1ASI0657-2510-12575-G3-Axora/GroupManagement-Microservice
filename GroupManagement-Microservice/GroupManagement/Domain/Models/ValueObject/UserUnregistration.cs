namespace DittoBox.API.GroupManagement.Domain.Models.ValueObject
{
    public class UserUnregistration
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public DateTime UnregistrationDate { get; set; }
        public int UnregisteringUserId { get; set; }
    }
}
