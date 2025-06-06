using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;
using DittoBox.API.GroupManagement.Domain.Models.Commands;
using DittoBox.API.GroupManagement.Domain.Models.Handlers.Internal;
using DittoBox.API.GroupManagement.Domain.Models.Queries;
using DittoBox.API.GroupManagement.Domain.Models.Resources;
using Microsoft.AspNetCore.Mvc;

namespace DittoBox.API.GroupManagement.Interface.Controllers
{

    /// <summary>
    /// Controller for managing groups within the DittoBox API.
    /// This controller provides endpoints to register and unregister containers and users,
    /// transfer containers and users, and manage group-related queries.
    /// </summary>

    [ApiController]
    [Route("api/v1/[controller]")]
    public class GroupController (
        ICreateGroupCommandHandler createGroupCommandHandler,
        ILogger<GroupController> _logger,
        IGetGroupQueryHandler getGroupQueryHandler,
        IRegisterUserCommandHandler registerUserCommandHandler
    ) : ControllerBase
    {

       
         /// <summary>
        /// Unregisters a container from a specific group.
        /// </summary>
        /// <param name="groupId">The ID of the group from which the container is being unregistered.</param>
        /// <param name="command">The command containing the details of the container to unregister.</param>

        [HttpPost]
        [Route("{groupId}/unregister-container")]
        public void UnregisterContainer([FromRoute]int groupId, [FromBody]UnregisterContainerCommand command)
        {
            throw new NotImplementedException();
        }
          /// <summary>
        /// Transfers a container from one group to another.
        /// </summary>
        /// <param name="groupId">The ID of the group from which the container is being transferred.</param>
        /// <param name="command">The command containing the details of the transfer operation.</param>
        [HttpPost]
        [Route("{groupId}/transfer-container")]
        public void TransferContainer([FromRoute] int groupId, [FromBody] TransferContainerCommand command)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Registers a user to a specific group.
        /// </summary>
        /// <param name="groupId">The ID of the group to which the user is being registered.</param>
        /// <param name="command">The command containing the details of the user to register.</param>
        [HttpPost]
        [Route("{groupId}/register-user")]
        public async Task<CreatedAtActionResult> RegisterUserAsync([FromRoute]int groupId, [FromBody]RegisterUserCommand command)
        {
            try{
                await registerUserCommandHandler.Handle(command);
                return CreatedAtAction(nameof(GetGroup), new { GroupId = groupId }, command);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering user with email {email}", command.Email);
                return (CreatedAtActionResult)StatusCode(500, "Internal server error");
            }
        }
        
         /// <summary>
        /// Unregisters a user from a specific group.
        /// </summary>
        /// <param name="groupId">The ID of the group from which the user is being unregistered.</param>
        /// <param name="command">The command containing the details of the user to unregister.</param>

        [HttpPost]
        [Route("{groupId}/unregister-user")]
        public void UnregisterUser([FromRoute]int groupId, [FromBody]UnregisterUserCommand command)
        {
            throw new NotImplementedException();
        }

         /// <summary>
        /// Transfers a user from one group to another.
        /// </summary>
        /// <param name="groupId">The ID of the group from which the user is being transferred.</param>
        /// <param name="command">The command containing the details of the transfer operation.</param>

        [HttpPost]
        [Route("{groupId}/transfer-user")]
        public void TransferUser([FromRoute]int groupId, [FromBody]TransferUserCommand command)
        {
            throw new NotImplementedException();
        }

         /// <summary>
        /// Retrieves the location of a specific group.
        /// </summary>
        /// <param name="groupId">The ID of the group for which to retrieve the location.</param>
        /// <param name="query">The query containing any additional parameters for the request.</param>

        [HttpPost]
        [Route("{groupId}/get-group-location")]
        public void GetGroupLocation([FromRoute]int groupId, [FromBody]GetGroupLocationQuery query)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves the details of a specific group by its ID.
        /// </summary>
        /// <param name="groupId">The ID of the group to retrieve.</param>
        /// <returns>An ActionResult containing the group's details or a NotFound response if the group does not exist.</returns>
        
        [HttpGet]
        [Route("{groupId:int}")]
        public async Task<ActionResult<GroupResource>> GetGroup([FromRoute] int groupId)
        {
            try
            {
                var query = new GetGroupQuery(groupId);
                var response = await getGroupQueryHandler.Handle(query);
                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting group with groupId: {groupId}", groupId);
                return StatusCode(500, "Internal server error");
            }
        }
         /// <summary>
        /// Creates a new group with the specified command details.
        /// </summary>
        /// <param name="command">The command containing the details of the new group to create.</param>
        /// <returns>An ActionResult containing the created group's details or an error response if the creation fails.</returns>

        [HttpPost("create-group")]
        public async Task<ActionResult<GroupResource>> CreateGroup([FromBody] CreateGroupCommand command)
        {
            try
            {
                var response = await createGroupCommandHandler.Handle(command);
                _logger.LogInformation("Group created with name {name} and id {id}", response.Name, response.Id);
                return CreatedAtAction(nameof(GetGroup), new { GroupId = response.Id }, response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating group with name {name}", command.Name);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
