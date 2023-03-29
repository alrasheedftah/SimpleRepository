using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doctors.Core.Interfaces;
using Doctors.Core.Models;
using Doctors.EF.Context;

namespace Doctors.EF.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly DoctorsDbContext _context;
    public UnitOfWork(DoctorsDbContext context,IDoctorRepository docotorRepository, IBaseRepository<Clinc> clincRepository)
    {
        DocotorRepository = docotorRepository;
        ClincRepository = clincRepository;
        _context = context;

    }

    public IDoctorRepository DocotorRepository { get; private set; }

    public IBaseRepository<Clinc> ClincRepository { get; private set; }

    public async Task<int> Compolete() 
    {
       return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
