using Microsoft.AspNetCore.Identity;

namespace PVI.KR.DataAccess.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Image> UserImages { get; set; }
    }
}
