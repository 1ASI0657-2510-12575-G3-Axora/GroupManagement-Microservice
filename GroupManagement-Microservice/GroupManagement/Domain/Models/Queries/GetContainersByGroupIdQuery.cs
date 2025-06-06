using System.ComponentModel.DataAnnotations;

namespace DittoBox.API.GroupManagement.Domain.Models.Queries
{
    public record GetContainersByGroupIdQuery(
        [Required] int GroupId
    );
}