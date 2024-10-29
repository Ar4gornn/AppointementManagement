namespace AppointmentManagement.DTO;

public class ReadAppointmentDto
{
    public Guid Id { get; set; }
    public string PatientName { get; set; }
    public string PatientNumber { get; set; }
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public string Type { get; set; }
    public string Notes { get; set; }
}