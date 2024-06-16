namespace AspektAssignment.Domain.Models
{
    public class Company : BaseEntity
    {
        public virtual List<Contact> Contacts { get; set; }
        public Company()
        {
            Contacts = new List<Contact>();
        }
    }
}
