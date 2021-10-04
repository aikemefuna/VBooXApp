using System;
using VBooX.Domain.Common;

namespace VBooX.Domain.Entities
{
    public class ResetToken : AuditableBaseEntity
    {
        public int SecurityTokenId { get; set; }

        public string Token { get; set; }

        public string PasswordToken { get; set; }

        public string UserId { get; set; }

        public DateTime DateGenerated { get; set; }

        public DateTime ExpiryDate { get; set; }

        public string UsedFor { get; set; }

        public bool IsUsed { get; set; }

        public bool IsExpired { get; set; }
    }
}
