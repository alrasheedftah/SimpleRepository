using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doctors.Core.Interfaces;
using Doctors.Core.Models;
using Doctors.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Doctors.EF.Repositories;

public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
{
    private readonly DoctorsDbContext _context;
    public DoctorRepository(DoctorsDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Doctor>> GetSpecialDoctors()
    {
       return await _context.Docotors.ToListAsync();
    }
}
