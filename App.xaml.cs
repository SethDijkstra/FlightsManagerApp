using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using Traveless.Data;
//using Windows.Security.Cryptography.Core;

namespace Traveless;

public partial class App : Application
{
	public static List<Flight> AllFlights { get; set; }

	public static List<Reservation> AllReservations { get; set; } = new List<Reservation>();
    public static bool IsNewReservation { get; set; } = true;

    public App()
	{
		InitializeComponent();
		MainPage = new MainPage();
	}

	//Runs on start of app
    protected override void OnStart()
	{
		//Find path of application on any device
		string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        //Read content of csv file
        string[] csvFlights = System.IO.File.ReadAllLines(System.IO.Path.Combine(appPath, "..", "..", "..", "..", "..", "Resources", "Files", "flights.csv"));
		
		//Start new list?
		AllFlights = new List<Flight>();

		//Split each row into column data
		for (int row = 0; row < csvFlights.Length; row++)
		{
			Flight flight = new Flight(csvFlights[row]);
			AllFlights.Add(flight);
		}

		//Call load method to load binary file from same path as the csv
		string binAppPath = System.IO.Path.Combine(appPath, "..", "..", "..", "..", "..", "Resources", "Files", "reservations.bin");
		Load(binAppPath);

        base.OnStart();
    }

    static void Load(string filePath)
    {
        if (File.Exists(filePath))
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                App.AllReservations = (List<Reservation>)formatter.Deserialize(stream);
            }
            Debug.WriteLine($"Loaded {App.AllReservations.Count} reservations from {filePath}");
        }
    }
}
