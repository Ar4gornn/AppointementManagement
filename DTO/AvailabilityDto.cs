namespace AppointmentManagement.DTO;

public class AvailabilityDto
{
    public Guid Id { get; set; }
    public Guid ClinicId { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}