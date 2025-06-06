using System.ComponentModel.DataAnnotations;
using DittoBox.API.GroupManagement.Domain.Models.Entities;
using DittoBox.API.GroupManagement.Domain.Models.ValueObject;

namespace DittoBox.API.GroupManagement.Domain.Models.Commands
{
    public record CreateGroupCommand(
        [Required, StringLength(64)] string Name,
        [Required] Location Location,
        [Required] int AccountId,
        [Required] FacilityType FacilityType
    );
}