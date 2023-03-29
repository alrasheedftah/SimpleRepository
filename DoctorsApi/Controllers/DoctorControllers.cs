using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Doctors.Core.Interfaces;
using Doctors.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DoctorsApi.Controllers;

[ApiController]
[Route("api/")]
public class DoctorControllers : Controller
{
    private readonly ILogger<DoctorControllers> _logger;
    private readonly IBaseRepository<Doctor> _doctorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DoctorControllers(ILogger<DoctorControllers> logger,IBaseRepository<Doctor> doctorRepository,IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _doctorRepository = doctorRepository;
        _unitOfWork = unitOfWork;
    }

    [HttpGet("doctors")]
    public async Task<IActionResult> Index([FromQuery] string name)
    {
        return Ok(await _unitOfWork.DocotorRepository.GetAll());
        // return Ok( await _doctorRepository.GetAll(new [] {"Clinc"}));
        // return Ok(await  _doctorRepository.Find(d => d.Name == name) );
    }


    [HttpPost("doctors")]
    public async Task<IActionResult> Create([FromBody] Doctor doctor)
    {
        return Ok(await  _doctorRepository.Add(new Doctor{ Name ="aaa",Description="aaaaa",ClinicId=1 }) );
    }


    [HttpGet("doctors/{id}")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public async Task<IActionResult> GetById(long id)
    {
       return Ok( await _doctorRepository.GetById(id));
    }
}
