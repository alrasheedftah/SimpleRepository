using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doctors.Core.Models;

namespace Doctors.Core.Interfaces;

public interface IDoctorRepository : IBaseRepository<Doctor>
{
    Task<IEnumerable<Doctor>> GetSpecialDoctors();
}
