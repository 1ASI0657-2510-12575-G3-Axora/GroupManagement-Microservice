using System.ComponentModel.DataAnnotations;

namespace DittoBox.API.GroupManagement.Domain.Models.Commands
{
    public record RegisterContainerCommand(
        [Required] string Uiid
    );
}