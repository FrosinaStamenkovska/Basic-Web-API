namespace AspektAssignment.Domain.Models
{
    public class Country: BaseEntity
    {
        public virtual List<Contact> Contacts { get; set; }
        public Country()
        {
            Contacts = new List<Contact>();
        }

    }
}
