namespace URIBasedSignUpProfile;
[QueryProperty(nameof(UserName), "username")]
[QueryProperty(nameof(Email), "email")]
[QueryProperty(nameof(Password), "password")]

public partial class ProfilePage : ContentPage
{
	public string UserName { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }

	public ProfilePage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		DisplayAlert("Confirmation", "Congratulations, you successfully signed-up.", "Ok");
		LblUsername1.Text = UserName;
		LblUsername2.Text = UserName;
		LblEmail.Text = Email;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }
}