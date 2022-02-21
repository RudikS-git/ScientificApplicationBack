using Domain.Entities;
using Domain.Entities.Base;
using Domain.Entities.Base.FieldTypes;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public interface IApplicationContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Submission> Submissions { get; set; }

        public DbSet<FieldType> FieldTypes { get; set; }
        public DbSet<InputField> InputFields { get; set; }
        public DbSet<SelectField> SelectFields { get; set; }

        Task<int> SaveChangesAsync();
    }
}