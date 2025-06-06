namespace DittoBox.API.GroupManagement.Domain.Models.ValueObject
{
    public class ContainerUnlinking
    {
        public int Id { get; set; }
        public int ContainerId { get; set; }
        public int GroupId { get; set; }
        public DateTime UnregistrationDate { get; set; }
        public int UnregisteringUserId { get; set; }
    }
}
