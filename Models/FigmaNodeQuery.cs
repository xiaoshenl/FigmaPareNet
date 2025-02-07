using System.ComponentModel.DataAnnotations;

namespace FigmaPareNet.Models
{
    public class FigmaNodeQuery
    {
        [Required]
        public string FileKey { get; set; }
        [Required]
        public string NodeId { get; set; }
    }
}
