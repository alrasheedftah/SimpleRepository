
namespace Doctors.Core.Models;

public class Doctor {

    public long Id {get; set;}
    public string Name {get; set;}
    public string Image {get; set;}
    public string Description {get; set;}
    public long ClinicId {get; set;}
    public Clinc Clinic {get; set;}
}