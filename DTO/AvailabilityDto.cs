namespace AppointmentManagement.DTO;

public class AvailabilityDto
{
    public Guid Id { get; set; }
    public Guid ClinicId { get; set; }
    public int DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}
