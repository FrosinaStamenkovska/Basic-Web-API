﻿namespace AspektAssignment.Domain.Models
{
    public class Contact : BaseEntity
    {
        public int CompanyId { get; set; }
        public int CountryId { get; set; }
        public virtual Company Company { get; set; }
        public virtual Country Country { get; set; }
        
    }
}
