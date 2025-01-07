namespace People;

public partial class App : Application
{
	public static PersonRepository CVPersonRepo { get; private set; }

	public App(PersonRepository velascoRepo)
	{
		InitializeComponent();
		CVPersonRepo = velascoRepo;
		// TODO: Initialize the PersonRepository property with the PersonRespository singleton object

	}

	protected override Window CreateWindow(IActivationState activationState)
	{
		return new Window(new AppShell());
	}
}