namespace FinalProjectTakeSix
{
    // The LogIn class, derived from ContentPage
    public partial class LogIn : ContentPage
    {
        // Constructor for the LogIn class
        public LogIn()
        {
            InitializeComponent();
        }

        // Event handler for the Log In button click
        private async void OnClickLogIn(object sender, EventArgs e)
        {
            // Retrieve entered username and password
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            // Check if the credentials are valid
            bool loginSuccess = CheckCredentials(username, password);

            // Display appropriate alert based on login success
            if (loginSuccess)
            {
                await DisplayAlert("Success", "Login successful!", "OK");

                // Clear the entered username and password
                UsernameEntry.Text = string.Empty;
                PasswordEntry.Text = string.Empty;
            }
            else
            {
                await DisplayAlert("Error", "Invalid username or password.", "OK");
            }
        }

        // Method to check the entered credentials against the database
        private bool CheckCredentials(string username, string password)
        {
            // Retrieve member from the database based on username and password
            Member member = DbService.Instance.GetMemberByUsernameAndPassword(username, password);

            // Return true if a member is found, indicating valid credentials
            return member != null;
        }
    }
}