//CPRG Group 2. Jesse Taylor, Seth Dijkstra, Issac Saffran
//Traveless flight system that reads reservation bin file and csv file
//Can accept user input for searching flights or reservation and return results.
//Users can edit or cancel reservations and they will be removed from the bin file.

using Traveless.Data;

namespace Traveless;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}
}
