using EventRegistrationApp.Data;
using Microsoft.JSInterop;
using System.Text.Json;

namespace EventRegistrationApp.Services
{
    public class EventService
    {
        private const string StorageKey = "savedEvent";
        private readonly IJSRuntime _js;
        //private readonly ILogger<EventService> _logger;

        public Event CurrentEvent { get; private set; } = new();

        public EventService(IJSRuntime js)
        {
            _js = js;
        }

        // public EventService(IJSRuntime js, ILogger<EventService> logger)
        // {
        //     _js = js;
        //     _logger = logger;
        // }
        public async Task LoadEventAsync()
        {
            var json = await _js.InvokeAsync<string>("localStorage.getItem", StorageKey);
            if (!string.IsNullOrWhiteSpace(json))
            {
                CurrentEvent = JsonSerializer.Deserialize<Event>(json) ?? new();
            }
        
        }

        public async Task SaveEventAsync(Event evt)
        {
            CurrentEvent = evt;
            var json = JsonSerializer.Serialize(CurrentEvent);
            await _js.InvokeVoidAsync("localStorage.setItem", StorageKey, json);
        }

        public async Task AddRegistrationAsync(Registration reg)
        {
            CurrentEvent.Registrations.Add(reg);
            CurrentEvent.TotalRegistration = CurrentEvent.Registrations.Count;
            await SaveEventAsync(CurrentEvent);
          //  _logger.LogInformation("Saving event with {Count} registrations", CurrentEvent.Registrations.Count);
        }

        public async Task ClearEventAsync()
        {
            await _js.InvokeVoidAsync("localStorage.removeItem", StorageKey);
            CurrentEvent = new Event(); // reset in memory as well
           // _logger.LogInformation("Event cleared from local storage and reset in memory.");
    
}

    }
    
}
