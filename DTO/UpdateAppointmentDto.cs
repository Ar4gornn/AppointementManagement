namespace AppointmentManagement.DTO;

public class UpdateAppointmentDto
{
    public Guid Id { get; set; }
    public string PatientId { get; set; }
    public string PatientName { get; set; }
    public string PatientPhone { get; set; }
    public string Type { get; set; }
    public string Notes { get; set; }
    public TimeSpan StartAt { get; set; }
    public TimeSpan EndAt { get; set; }
}
