using System.ComponentModel.DataAnnotations;
using VBooX.Domain.Common;

namespace VBooX.Domain.Entities
{
    public class Client : AuditableBaseEntity
    {
        public int ClientId { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Address { get; set; }
        [StringLength(200)]
        public string Email { get; set; }
        [StringLength(200)]
        public string PhoneNo { get; set; }
        [StringLength(200)]
        public string Logo { get; set; }
        [StringLength(200)]
        public string BusinessType { get; set; }
        [StringLength(200)]
        public string SignatureUrl { get; set; }
        [StringLength(200)]
        public string AccountNumber { get; set; }
    }
}
