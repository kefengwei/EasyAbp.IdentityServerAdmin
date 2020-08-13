using System.ComponentModel.DataAnnotations;

namespace EasyAbp.IdentityServerAdmin.Clients.Dtos
{
    public class CreateClientInputDto
    {
        /// <summary>
        /// Unique ID of the client
        /// </summary>
        [Required]
        public string ClientId { get; set; }

        /// <summary>
        /// Client display name (used for logging and consent screen)
        /// </summary>
        [Required]
        public string ClientName { get; set; }

        /// <summary>
        /// URI to further information about client (used on consent screen)
        /// </summary>
        public string ClientUri { get; set; }

        /// <summary>
        /// URI to client logo (used on consent screen)
        /// </summary>
        public string LogoUri { get; set; }

        public string LogoutUri { get; set; }

        public string Description { get; set; }

        public ClientType ClientType { get; set; } = ClientType.Empty;
    }
}
