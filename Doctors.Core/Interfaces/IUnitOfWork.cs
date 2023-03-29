
using Doctors.Core.Models;

namespace Doctors.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IDoctorRepository DocotorRepository {get;}
    IBaseRepository<Clinc> ClincRepository {get;}
    Task<int> Compolete();
}