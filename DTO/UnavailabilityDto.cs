namespace AppointmentManagement.DTO;

public class UnavailabilityDto
{
    public Guid Id { get; set; }
    public Guid ClinicId { get; set; }
    public DateTime StartDateTime { get; set; }  // Combine Date and TimeSpan to DateTime
    public DateTime EndDateTime { get; set; }    // Combine Date and TimeSpan to DateTime
    public bool IsAllDay { get; set; }
}