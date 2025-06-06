using System.ComponentModel.DataAnnotations;

namespace DittoBox.API.GroupManagement.Domain.Models.Queries
{
    public record GetGroupQuery(
        [Required] int GroupId
    );
}