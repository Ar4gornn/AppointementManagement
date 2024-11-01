namespace AppointmentManagement.DTO;

public class CreateAppointmentDto
{
    public string ProfessionalId { get; set; }
    public Guid ClinicId { get; set; }
    public string PatientId { get; set; }
    public string PatientName { get; set; }
    public string PatientPhone { get; set; }
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public string Type { get; set; }
    public string Notes { get; set; }
}
