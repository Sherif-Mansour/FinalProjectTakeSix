namespace FinalProjectTakeSix
{
    // Definition of the MainPage class, which is a partial class of ContentPage
    public partial class MainPage : ContentPage
    {
        // Constructor for MainPage
        public MainPage()
        {
            // Initialize the component (UI elements) for MainPage
            InitializeComponent();
        }

        // Event handler for the SignUpButton click event
        private void OnClickSignUp(object sender, EventArgs e)
        {
            // Navigate to the SignUp page using Shell navigation
            Shell.Current.GoToAsync("//SignUp");
        }

        // Event handler for the LogInButton click event
        private void OnClickLogIn(object sender, EventArgs e)
        {
            // Navigate to the LogIn page using Shell navigation
            Shell.Current.GoToAsync("//LogIn");
        }

        // Event handler for the ManageMemberButton click event
        private void OnClickManageMember(object sender, EventArgs e)
        {
            // Navigate to the ManageMember page using Shell navigation
            Shell.Current.GoToAsync("//ManageMember");
        }
    }
}