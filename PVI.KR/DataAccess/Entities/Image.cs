using System.ComponentModel.DataAnnotations.Schema;

namespace PVI.KR.DataAccess.Entities
{
    public class Image
    {
        public Guid Id { get; set; }

        public string InternalTags { get; set; }

        [NotMapped]
        public string[] Tags
        {
            get
            {
                return InternalTags.Split(';');
            }
            set
            {
                InternalTags = string.Join(";", value.Select(p => p).ToArray());
            }
        }

        public string Src { get; set; }



        public List<User> UserImages { get; set; }
    }
}
