namespace AppointmentManagement.DTO;

public class ReadAppointmentDto
{
    public Guid Id { get; set; }
    public string ProfessionalId { get; set; }
    public Guid ClinicId { get; set; }
    public string PatientId { get; set; }
    public string PatientName { get; set; }
    public string PatientPhone { get; set; }
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public string Type { get; set; }
    public int Status { get; set; }
    public string Notes { get; set; }
    public bool ShowedUp { get; set; }
    public string BookingChannel { get; set; }
}
