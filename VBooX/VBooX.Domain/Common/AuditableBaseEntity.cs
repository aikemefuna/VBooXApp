﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VBooX.Domain.Common
{
    public abstract class AuditableBaseEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
