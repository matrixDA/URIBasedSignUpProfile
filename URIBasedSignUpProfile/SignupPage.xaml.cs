using System.Text.RegularExpressions;

namespace URIBasedSignUpProfile;

public partial class SignupPage : ContentPage
{
	public SignupPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        /*
         Regex Explaination:
                - Start with numbers and letters
                - Then can include 0 or more numbers, letter, and special character
                - Before the @, has to end with at least 1 or more number/s or letter/s, no special character 
                - After the @, has to have 1 or more letters or numbers, no special character
                - Then can include 0 or more special character with numbers and letters
                - Before the . has to end with at least 1 number or letter
                - After the . the top level domain has to have at least 2 alphabet characters.
         */
        Regex emailRegex = new Regex(@"^[a-zA-Z0-9]+[a-zA-Z0-9._%+-]*[a-zA-Z0-9]+@[a-zA-Z0-9]+[a-zA-Z0-9.-]*[a-zA-Z0-9]+\.[a-zA-Z]{2,}$");

		var signupData = new Dictionary<string, object>()
		{
			{"username", $"{username.Text}" },
			{"email", $"{email.Text}" },
			{"password", $"{password.Text}" },
			{"confPassword", $"{confPassword.Text}" }
		};

		if (string.IsNullOrEmpty(username.Text)) 
		{
			LblVisibleUsername.IsVisible = true;
			LblVisibleUsername.Text = "Username can not be empty";
		}
        else LblVisibleUsername.IsVisible = false;

        if (string.IsNullOrEmpty(email.Text))
        {
            LblVisiblEmail.IsVisible = true;
            LblVisiblEmail.Text = "Email can not be empty";
        }
        else
        {
            if (!emailRegex.IsMatch(email.Text))
            {
                LblVisiblEmail.IsVisible = true;
                LblVisiblEmail.Text = "Email is not in the correct formating.";
            }
            else
                LblVisiblEmail.IsVisible = false;
        }

        if (string.IsNullOrEmpty(password.Text))
        {
            LblVisiblePassword.IsVisible = true;
            LblVisiblePassword.Text = "Password can not be empty";
        }
        else
        { 
            LblVisiblePassword.IsVisible = false;
        }


        if (string.IsNullOrEmpty(confPassword.Text))
        {
            LblVisibleConfPassword.IsVisible = true;
            LblVisibleConfPassword.Text = "Confirm Password can not be empty";
        }
        else
            LblVisibleConfPassword.IsVisible = false;

        if (!string.IsNullOrEmpty(password.Text) && !string.IsNullOrEmpty(confPassword.Text))
        {
           if (password.Text != confPassword.Text)
            {
                LblVisibleConfPassword.IsVisible = true;
                LblVisibleConfPassword.Text = "Password does not match";
                LblVisiblePassword.IsVisible = true;
                LblVisiblePassword.Text = "Password does not match";
            }
           else
            {
                LblVisiblePassword.IsVisible = false;
                LblVisibleConfPassword.IsVisible = false;
            }  
        }

        if (LblVisibleUsername.IsVisible == false && LblVisiblEmail.IsVisible == false &&
            LblVisiblePassword.IsVisible == false && LblVisibleConfPassword.IsVisible == false)
        {
            Shell.Current.GoToAsync(nameof(ProfilePage), signupData);
        }
    }
}