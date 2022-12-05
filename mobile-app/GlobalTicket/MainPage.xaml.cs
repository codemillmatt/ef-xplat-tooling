using GlobalTicket.Services;
using GlobalTicket.Models;


namespace GlobalTicket;

public partial class MainPage : ContentPage
{
	int count = 0;
	private readonly TicketService _ticketService;

    private IEnumerable<EventInfo> _events = null;

	public MainPage(TicketService service)
	{
		InitializeComponent();

		_ticketService = service;
	}

    private void GetDataBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        _events = _ticketService.GetAllEvents();

        
        theCollection.ItemsSource = _events;
        
    }
}


