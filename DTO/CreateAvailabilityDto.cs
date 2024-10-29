namespace AppointmentManagement.DTO;

public class CreateAvailabilityDto
{
    public Guid ClinicId { get; set; }
    public int DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}