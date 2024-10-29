namespace AppointmentManagement.DTO;

public class CreateAppointmentDto
{
    public string PatientName { get; set; }
    public string PatientNumber { get; set; }
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public Guid ClinicId { get; set; }
    public string Type { get; set; }
    public string Notes { get; set; }
}