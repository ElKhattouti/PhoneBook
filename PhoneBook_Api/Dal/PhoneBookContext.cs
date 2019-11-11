using Microsoft.EntityFrameworkCore;
using PhoneBook_Models;

namespace PhoneBook_Api.Dal
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext() { }
        public PhoneBookContext(DbContextOptions<PhoneBookContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=postgresql-oceanstudio.alwaysdata.net;Database=oceanstudio_phonebook;Username=oceanstudio;Password=bil442.ad");

        public virtual DbSet<Contact> Contacts { get; set; }

    }
}
