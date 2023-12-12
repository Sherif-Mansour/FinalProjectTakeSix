using System.Text.RegularExpressions;

namespace FinalProjectTakeSix
{
    public partial class ManageMember : ContentPage
    {
        // Database Service instance
        private DbService _dbService = DbService.Instance;

        // List to store search results
        private List<Member> _searchResults;

        // constructor
        public ManageMember()
        {
            InitializeComponent();
            
            // Event handler for member search bar text change
            MemberSearchBar.TextChanged += OnMemberSearchTextChanged;

            // Even handler for item selection in sear results list 
            SearchResultsListView.ItemSelected += OnSearchResultSelected;
        }

        // Event handler for the update button click
        private async void OnClickUpdate(object sender, EventArgs e)
        {
            if (_searchResults != null && _searchResults.Any())
            {
                var selectedMember = _searchResults.FirstOrDefault();

                // Validate updated member information
                if (!ValidateUpdatedMemberInput())
                {
                    // Validation failed, do not proceed with the update
                    return;
                }

                // Update member information
                UpdateMemberInformation(selectedMember);

                // Display success alert
                await DisplayAlert("Success", "Member information updated successfully!", "OK");

                // Clear input fields after successful update
                ClearInputFields();
            }
        }

        // Method to update member information
        private void UpdateMemberInformation(Member selectedMember)
        {
            // Update member properties if corresponding entry fields are not empty
            if (!string.IsNullOrWhiteSpace(NewUsernameEntry.Text)) { selectedMember.UserName = NewUsernameEntry.Text; }
            if (!string.IsNullOrWhiteSpace(NewPasswordEntry.Text)) { selectedMember.Password = NewPasswordEntry.Text; }
            if (!string.IsNullOrWhiteSpace(NewFirstNameEntry.Text)) { selectedMember.FirstName = NewFirstNameEntry.Text; }
            if (!string.IsNullOrWhiteSpace(NewLastNameEntry.Text)) { selectedMember.LastName = NewLastNameEntry.Text; }
            if (!string.IsNullOrWhiteSpace(NewAddressEntry.Text)) { selectedMember.Address = NewAddressEntry.Text; }
            if (!string.IsNullOrWhiteSpace(NewCityEntry.Text)) { selectedMember.City = NewCityEntry.Text; }
            if (!string.IsNullOrWhiteSpace(NewRegionEntry.Text)) { selectedMember.Region = NewRegionEntry.Text; }
            if (!string.IsNullOrWhiteSpace(NewPostalCodeEntry.Text)) { selectedMember.PostalCode = NewPostalCodeEntry.Text; }
            if (!string.IsNullOrWhiteSpace(NewCountryEntry.Text)) { selectedMember.Country = NewCountryEntry.Text; }
            if (!string.IsNullOrWhiteSpace(NewPhoneNumberEntry.Text)) { selectedMember.PhoneNumber = NewPhoneNumberEntry.Text; }
            if (!string.IsNullOrWhiteSpace(NewEmailEntry.Text)) { selectedMember.Email = NewEmailEntry.Text; }
            if (!string.IsNullOrWhiteSpace(NewGenderEntry.Text)) { selectedMember.Gender = NewGenderEntry.Text; }
            if (!string.IsNullOrWhiteSpace(NewDateOfBirthEntry.Text)) { selectedMember.DateOfBirth = DateTime.Parse(NewDateOfBirthEntry.Text); }
            if (!string.IsNullOrWhiteSpace(NewMembershipTypeEntry.Text)) { selectedMember.MembershipType = NewMembershipTypeEntry.Text; }
            if (!string.IsNullOrWhiteSpace(NewFitnessGoalsEntry.Text)) { selectedMember.FitnessGoals = NewFitnessGoalsEntry.Text; }
            if (!string.IsNullOrWhiteSpace(NewEmergencyContactNameEntry.Text)) { selectedMember.EmergencyContactName = NewEmergencyContactNameEntry.Text; }
            if (!string.IsNullOrWhiteSpace(NewEmergencyContactNumberEntry.Text)) { selectedMember.EmergencyContactNumber = NewEmergencyContactNumberEntry.Text; }
            if (!string.IsNullOrWhiteSpace(NewPreferredWorkoutTimeEntry.Text)) { selectedMember.PreferredWorkoutTime = NewPreferredWorkoutTimeEntry.Text; }
            if (!string.IsNullOrWhiteSpace(NewTrainingSessionsPerWeekEntry.Text)) { selectedMember.TrainingSessionsPerWeek = int.Parse(NewTrainingSessionsPerWeekEntry.Text); }
            if (!string.IsNullOrWhiteSpace(NewMedicalConditionsEntry.Text)) { selectedMember.HasMedicalConditions = bool.Parse(NewMedicalConditionsEntry.Text); }
            if (!string.IsNullOrWhiteSpace(NewPersonalTrainingEntry.Text)) { selectedMember.WantsPersonalTraining = bool.Parse(NewPersonalTrainingEntry.Text); }
            if (!string.IsNullOrWhiteSpace(NewOptInForNewsletterEntry.Text)) { selectedMember.OptedInForNewsLetter = bool.Parse(NewOptInForNewsletterEntry.Text); }
            if (!string.IsNullOrWhiteSpace(NewLastCheckInDateTimeEntry.Text)) { selectedMember.LastCheckInDateTime = DateTime.Parse(NewLastCheckInDateTimeEntry.Text); }

            // Update the member in the database
            _dbService.UpdateMember(selectedMember);

            // Display updated member details
            SelectedMemberDetailsLabel.Text = selectedMember.ToString();
        }

        // Method to validate input fields before updating member information
        private bool ValidateUpdatedMemberInput()
        {
            if (!string.IsNullOrWhiteSpace(NewUsernameEntry.Text) && !ValidateRequiredField(NewUsernameEntry, "Username")) return false;
            if (!string.IsNullOrWhiteSpace(NewPasswordEntry.Text) && !ValidatePassword(NewPasswordEntry.Text)) return false;
            if (!string.IsNullOrWhiteSpace(NewConfirmPasswordEntry.Text) && !ValidateConfirmPassword(NewPasswordEntry, NewConfirmPasswordEntry)) return false;
            if (!string.IsNullOrWhiteSpace(NewFirstNameEntry.Text) && !ValidateRequiredField(NewFirstNameEntry, "First Name")) return false;
            if (!string.IsNullOrWhiteSpace(NewLastNameEntry.Text) && !ValidateRequiredField(NewLastNameEntry, "Last Name")) return false;
            if (!string.IsNullOrWhiteSpace(NewAddressEntry.Text) && !ValidateRequiredField(NewAddressEntry, "Address")) return false;
            if (!string.IsNullOrWhiteSpace(NewCityEntry.Text) && !ValidateRequiredField(NewCityEntry, "City")) return false;
            if (!string.IsNullOrWhiteSpace(NewRegionEntry.Text) && !ValidateRequiredField(NewRegionEntry, "Region")) return false;
            if (!string.IsNullOrWhiteSpace(NewPostalCodeEntry.Text) && !ValidatePostalCode(NewPostalCodeEntry.Text)) return false;
            if (!string.IsNullOrWhiteSpace(NewCountryEntry.Text) && !ValidateRequiredField(NewCountryEntry, "Country")) return false;
            if (!string.IsNullOrWhiteSpace(NewPhoneNumberEntry.Text) && !ValidatePhoneNumber(NewPhoneNumberEntry.Text)) return false;
            if (!string.IsNullOrWhiteSpace(NewEmailEntry.Text) && !ValidateEmail(NewEmailEntry.Text)) return false;
            if (!string.IsNullOrWhiteSpace(NewGenderEntry.Text) && !ValidateGender(NewGenderEntry.Text)) return false;
            if (!string.IsNullOrWhiteSpace(NewDateOfBirthEntry.Text) && !ValidateDateOfBirth(NewDateOfBirthEntry.Text)) return false;
            if (!string.IsNullOrWhiteSpace(NewMembershipTypeEntry.Text) && !ValidateMembershipType(NewMembershipTypeEntry.Text)) return false;
            if (!string.IsNullOrWhiteSpace(NewFitnessGoalsEntry.Text) && !ValidateFitnessGoals(NewFitnessGoalsEntry.Text)) return false;
            if (!string.IsNullOrWhiteSpace(NewEmergencyContactNameEntry.Text) && !ValidateRequiredField(NewEmergencyContactNameEntry, "Emergency Contact Name")) return false;
            if (!string.IsNullOrWhiteSpace(NewEmergencyContactNumberEntry.Text) && !ValidatePhoneNumber(NewEmergencyContactNumberEntry.Text)) return false;
            if (!string.IsNullOrWhiteSpace(NewPreferredWorkoutTimeEntry.Text) && !ValidatePreferredWorkoutTime(NewPreferredWorkoutTimeEntry.Text)) return false;
            if (!string.IsNullOrWhiteSpace(NewTrainingSessionsPerWeekEntry.Text) && !ValidateTrainingSessionsPerWeek(NewTrainingSessionsPerWeekEntry.Text)) return false;
            if (!string.IsNullOrWhiteSpace(NewMedicalConditionsEntry.Text) && !ValidateBooleanField(NewMedicalConditionsEntry, "Has Medical Conditions")) return false;
            if (!string.IsNullOrWhiteSpace(NewPersonalTrainingEntry.Text) && !ValidateBooleanField(NewPersonalTrainingEntry, "Wants Personal Training")) return false;
            if (!string.IsNullOrWhiteSpace(NewOptInForNewsletterEntry.Text) && !ValidateBooleanField(NewOptInForNewsletterEntry, "Opted In for Newsletter")) return false;
            if (!string.IsNullOrWhiteSpace(NewLastCheckInDateTimeEntry.Text) && !ValidateDateField(NewLastCheckInDateTimeEntry, "Last Check-In Date Time")) return false;

            return true;
        }

        // Method to validate required field entry
        private bool ValidateRequiredField(Entry entry, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(entry.Text))
            {
                DisplayAlert("Validation Error", $"{fieldName} is required.", "OK");
                return false;
            }
            return true;
        }

        // Method to validate password
        private bool ValidatePassword(string password)
        {
            // Check if the password is null or empty
            if (string.IsNullOrWhiteSpace(password))
            {
                DisplayAlert("Validation Error", "New Password is required.", "OK");
                return false;
            }

            return true;
        }

        // Method to valide confirm password 
        private bool ValidateConfirmPassword(Entry newPasswordEntry, Entry confirmNewPasswordEntry)
        {
            string newPassword = newPasswordEntry.Text;
            string confirmNewPassword = confirmNewPasswordEntry.Text;

            // Check if the new password is null or empty
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                DisplayAlert("Validation Error", "New Password is required.", "OK");
                return false;
            }

            // Check if the confirm password is null or empty
            if (string.IsNullOrWhiteSpace(confirmNewPassword))
            {
                DisplayAlert("Validation Error", "Confirm Password is required.", "OK");
                return false;
            }

            // Check if the new password and confirm password match
            if (newPassword != confirmNewPassword)
            {
                DisplayAlert("Validation Error", "Password and Confirm Password do not match.", "OK");
                return false;
            }

            return true;
        }

        // Method to validate postal code update
        private bool ValidatePostalCode(string postalCode)
        {
            // Check if the postal code is null or empty
            if (string.IsNullOrWhiteSpace(postalCode))
            {
                DisplayAlert("Validation Error", "Postal code is required.", "OK");
                return false;
            }

            // Canadian postal code pattern: "A1A 1A1" or "A1A1A1"
            string postalCodePattern = @"^[A-Za-z]\d[A-Za-z] \d[A-Za-z]\d$|^[A-Za-z]\d[A-Za-z]\d[A-Za-z]\d$";

            if (!Regex.IsMatch(postalCode, postalCodePattern))
            {
                DisplayAlert("Validation Error", "Invalid Canadian Postal Code format. Please enter a valid postal code.", "OK");
                return false;
            }

            return true;
        }

        // Method to validate phone number update
        private bool ValidatePhoneNumber(string phoneNumber)
        {
            // Check if the phone number is null or empty
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                DisplayAlert("Validation Error", "Phone Number is required.", "OK");
                return false;
            }

            // Pattern to match 10 digits, with optional hyphens or parentheses
            string phoneNumberPattern = @"^(\d{10}|\(\d{3}\)\s?\d{3}-?\d{4})$";

            if (!Regex.IsMatch(phoneNumber, phoneNumberPattern))
            {
                DisplayAlert("Validation Error", "Invalid Phone Number format. Please enter a valid 10-digit phone number.", "OK");
                return false;
            }

            return true;
        }

        // Method to validate an email address update
        private bool ValidateEmail(string email)
        {
            // Check if the email is null or empty
            if (string.IsNullOrWhiteSpace(email))
            {
                DisplayAlert("Validation Error", "Email is required.", "OK");
                return false;
            }

            string emailPattern = @"^\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";
            if (!Regex.IsMatch(email, emailPattern))
            {
                DisplayAlert("Validation Error", "Invalid Email format. Please enter a valid email address.", "OK");
                return false;
            }

            return true;
        }

        // Method to validate Gender update
        private bool ValidateGender(string gender)
        {
            if (string.IsNullOrWhiteSpace(gender))
            {
                DisplayAlert("Validation Error", "Gender is required.", "OK");
                return false;
            }

            gender = gender.Trim().ToLower();

            if (gender != "male" && gender != "female")
            {
                DisplayAlert("Validation Error", "Invalid Gender. Please enter either 'Male' or 'Female'.", "OK");
                return false;
            }

            return true;
        }

        // Method to validate date of birth update
        private bool ValidateDateOfBirth(string dateOfBirthText)
        {
            if (string.IsNullOrWhiteSpace(dateOfBirthText))
            {
                DisplayAlert("Validation Error", "Date of Birth is required.", "OK");
                return false;
            }

            if (!DateTime.TryParse(dateOfBirthText, out DateTime dateOfBirth))
            {
                DisplayAlert("Validation Error", "Invalid Date of Birth. Please enter a valid date.", "OK");
                return false;
            }

            // Additional check for a reasonable age (e.g., not in the future)
            if (dateOfBirth > DateTime.Now)
            {
                DisplayAlert("Validation Error", "Date of Birth cannot be in the future.", "OK");
                return false;
            }

            return true;
        }

        // Method to validate MembershipType update
        private bool ValidateMembershipType(string membershipType)
        {
            if (string.IsNullOrWhiteSpace(membershipType))
            {
                DisplayAlert("Validation Error", "Membership Type is required.", "OK");
                return false;
            }

            string[] validMembershipTypes = { "machines", "personal training", "both" };
            string inputMembershipType = membershipType.ToLower();

            if (!validMembershipTypes.Contains(inputMembershipType))
            {
                DisplayAlert("Validation Error", "Invalid Membership Type. Please enter 'machines', 'personal training', or 'both'.", "OK");
                return false;
            }

            return true;
        }

        // Method to validate Fitness Goals update
        private bool ValidateFitnessGoals(string fitnessGoals)
        {
            if (string.IsNullOrWhiteSpace(fitnessGoals))
            {
                DisplayAlert("Validation Error", "Fitness Goals are required.", "OK");
                return false;
            }

            fitnessGoals = fitnessGoals.ToLower();

            if (!(fitnessGoals == "lose weight" || fitnessGoals == "build muscle" || fitnessGoals == "both"))
            {
                DisplayAlert("Validation Error", "Invalid Fitness Goals. Choose 'Lose Weight', 'Build Muscle', or 'Both'.", "OK");
                return false;
            }

            return true;
        }

        // Method to validate preferred workout time update
        private bool ValidatePreferredWorkoutTime(string preferredWorkoutTime)
        {
            if (string.IsNullOrWhiteSpace(preferredWorkoutTime))
            {
                DisplayAlert("Validation Error", "Preferred Workout Time is required.", "OK");
                return false;
            }

            string[] validWorkoutTimes = { "morning", "afternoon", "evening", "anytime" };
            preferredWorkoutTime = preferredWorkoutTime.ToLower();

            if (!validWorkoutTimes.Contains(preferredWorkoutTime))
            {
                DisplayAlert("Validation Error", "Invalid Preferred Workout Time. Please choose morning, afternoon, evening, or anytime.", "OK");
                return false;
            }

            return true;
        }

        // method to validate number of training sessions per week
        private bool ValidateTrainingSessionsPerWeek(string trainingSessionsPerWeekText)
        {
            if (string.IsNullOrWhiteSpace(trainingSessionsPerWeekText))
            {
                DisplayAlert("Validation Error", "Training Sessions Per Week is required.", "OK");
                return false;
            }

            if (!int.TryParse(trainingSessionsPerWeekText, out int trainingSessionsPerWeek))
            {
                DisplayAlert("Validation Error", "Invalid Training Sessions Per Week. Please enter a valid number.", "OK");
                return false;
            }

            if (trainingSessionsPerWeek > 7)
            {
                DisplayAlert("Validation Error", "Training Sessions Per Week cannot be more than 7 days.", "OK");
                return false;
            }

            return true;
        }

        // Method to validate boolean fields update
        private bool ValidateBooleanField(Entry entry, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(entry.Text))
            {
                DisplayAlert("Validation Error", $"{fieldName} is required.", "OK");
                return false;
            }

            if (!bool.TryParse(entry.Text.ToLower(), out bool fieldValue))
            {
                DisplayAlert("Validation Error", $"Invalid input for {fieldName}. Please enter True or False.", "OK");
                return false;
            }

            return true;
        }

        // Method to validate last check-in date field update
        private bool ValidateDateField(Entry entry, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(entry.Text))
            {
                DisplayAlert("Validation Error", $"{fieldName} is required.", "OK");
                return false;
            }

            if (!DateTime.TryParse(entry.Text, out DateTime fieldValue))
            {
                DisplayAlert("Validation Error", $"Invalid input for {fieldName}. Please enter a valid date.", "OK");
                return false;
            }

            return true;
        }

        // Clear all input fields after an operation
        private void ClearInputFields()
        {
            NewUsernameEntry.Text = string.Empty;
            NewPasswordEntry.Text = string.Empty;
            NewConfirmPasswordEntry.Text = string.Empty;
            NewFirstNameEntry.Text = string.Empty;
            NewLastNameEntry.Text = string.Empty;
            NewAddressEntry.Text = string.Empty;
            NewCityEntry.Text = string.Empty;
            NewRegionEntry.Text = string.Empty;
            NewPostalCodeEntry.Text = string.Empty;
            NewCountryEntry.Text = string.Empty;
            NewPhoneNumberEntry.Text = string.Empty;
            NewEmailEntry.Text = string.Empty;
            NewGenderEntry.Text = string.Empty;
            NewDateOfBirthEntry.Text = string.Empty;
            NewMembershipTypeEntry.Text = string.Empty;
            NewFitnessGoalsEntry.Text = string.Empty;
            NewEmergencyContactNameEntry.Text = string.Empty;
            NewEmergencyContactNumberEntry.Text = string.Empty;
            NewPreferredWorkoutTimeEntry.Text = string.Empty;
            NewTrainingSessionsPerWeekEntry.Text = string.Empty;
            NewMedicalConditionsEntry.Text = string.Empty;
            NewPersonalTrainingEntry.Text = string.Empty;
            NewOptInForNewsletterEntry.Text = string.Empty;
            NewLastCheckInDateTimeEntry.Text = string.Empty;
        }

        // Event handler for the delete button click
        private async void OnClickDelete(object sender, EventArgs e)
        {
            if (_searchResults != null && _searchResults.Any())
            {
                var selectedMember = _searchResults.FirstOrDefault();

                // Confirm member deletion with the user
                bool result = await DisplayAlert("Delete Member", $"Are you sure you want to delete {selectedMember.UserName}?", "Yes", "No");

                if (result)
                {
                    // Delete member from the database
                    _dbService.DeleteMember(selectedMember.UserId);

                    // Clear selected member details
                    SelectedMemberDetailsLabel.Text = string.Empty;

                    // Refresh search results
                    SearchMember(MemberSearchBar.Text);
                }
            }
        }

        // Display details of the selected member
        private void OnSearchResultSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var selectedMember = (Member)e.SelectedItem;
                SelectedMemberDetailsLabel.Text = selectedMember.ToString();
            }
        }

        // Trigger member search based on the entered text
        private void OnMemberSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            SearchMember(e.NewTextValue);
        }

        // Perform member search and update search results list
        private void SearchMember(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                _searchResults = new List<Member>();
                SearchResultsListView.ItemsSource = _searchResults;
                return;
            }

            _searchResults = _dbService.GetMembersBySearchText(searchText);

            SearchResultsListView.ItemsSource = _searchResults;
        }
    }
}