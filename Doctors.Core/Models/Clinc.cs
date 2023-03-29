
namespace Doctors.Core.Models;

public class Clinc {

    public long Id {get; set;}
    public string Name {get; set;}
    public string Description {get; set;}
    public List<Doctor> Doctors {get; set;}
}