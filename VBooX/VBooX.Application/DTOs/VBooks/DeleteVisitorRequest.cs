using System.ComponentModel.DataAnnotations;

namespace VBooX.Application.DTOs.VBooks
{
    public class DeleteVisitorRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
