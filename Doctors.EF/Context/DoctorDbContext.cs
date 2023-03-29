
// using Microsoft.
using Doctors.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Doctors.EF.Context;

public class DoctorsDbContext : DbContext {
 public DoctorsDbContext() : base()
 {
 }
    public DbSet<Doctor> Docotors  {get;set;}
    public DoctorsDbContext(DbContextOptions<DoctorsDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
            options.UseSqlServer("DATA SOURCE=.;DATABASE=DoctorDB;UID=sa;PWD=Rasta297199;");
    }
}