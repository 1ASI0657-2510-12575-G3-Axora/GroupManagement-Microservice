namespace DittoBox.API.GroupManagement.Domain.Models.ValueObject
{
    public class ContainerLinking
    {
        public int Id { get; set; }
        public int ContainerId { get; set; }
        public int GroupId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int RegisteringUserId { get; set; }
    }
}
