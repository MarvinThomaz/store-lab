using Store.Common.Attributes;

namespace Store.Product.Presentation.V1.Models.Request
{
    public class CreatePhotoRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public byte[] Data { get; set; }
    }
}