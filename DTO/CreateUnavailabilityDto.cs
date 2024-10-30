namespace AppointmentManagement.DTO;

public class CreateUnavailabilityDto
{
    public Guid ClinicId { get; set; }
    public DateTime StartDateTime { get; set; }  // DateTime for combined date and time
    public DateTime EndDateTime { get; set; }    // DateTime for combined date and time
    public bool IsAllDay { get; set; }
}