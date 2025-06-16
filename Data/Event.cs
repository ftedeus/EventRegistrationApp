namespace EventRegistrationApp.Data;
public class Event
{
    public string Name { get; set; } = "Sample Event";
   // [Future30Days]
     public DateTime Date { get; set; } = DateTime.Now;
    public string Location { get; set; } = "Virtual";
    public string Description { get; set; } = "An awesome event!";
    public int TotalRegistration { get; set; } = 0;
    public List<Registration> Registrations { get; set; } = new();
}
