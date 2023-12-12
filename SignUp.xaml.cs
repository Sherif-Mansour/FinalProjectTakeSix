using System.Text.RegularExpressions;

namespace FinalProjectTakeSix
{
    public partial class SignUp : ContentPage
    {
        // Instantiate a singleton instance of DbService
        private DbService dbService = DbService.Instance;

        // Constructor for the SignUp Class
        public SignUp()
        {
            InitializeComponent();

            // Uncomment the line below to clear table and restart PK sequence from 1
            /*dbService.ClearMemberTable();*/

            // Uncomment the line below to insert dummy data and comment out again or data will be inserted each time program is run.
            /*InsertDummyData();*/

        }

        // Event handler for the SignUp button click
        private void OnClickSignUp(object sender, EventArgs e)
        {
            // Validate input fields before proceeding
            if (ValidateInput())
            {
                // Create a new Member object with input values
                var newMember = new Member(
                    userId: 0,
                    userName: UsernameEntry.Text,
                    password: PasswordEntry.Text,
                    firstName: FirstNameEntry.Text,
                    lastName: LastNameEntry.Text,
                    address: AddressEntry.Text,
                    city: CityEntry.Text,
                    region: RegionEntry.Text,
                    postalCode: PostalCodeEntry.Text,
                    country: CountryEntry.Text,
                    phoneNumber: PhoneNumberEntry.Text,
                    email: EmailEntry.Text,
                    gender: GenderEntry.Text,
                    dateOfBirth: DateTime.Parse(DateOfBirthEntry.Text),
                    membershipType: MembershipTypeEntry.Text,
                    healthInformation: HealthInformationEntry.Text,
                    fitnessGoals: FitnessGoalsEntry.Text,
                    emergencyContactName: EmergencyContactNameEntry.Text,
                    emergencyContactNumber: EmergencyContactNumberEntry.Text,
                    preferredWorkoutTime: PreferredWorkoutTimeEntry.Text,
                    trainingSessionsPerWeek: int.Parse(TrainingSessionsPerWeekEntry.Text),
                    hasMedicalConditions: bool.Parse(MedicalConditionsEntry.Text),
                    wantsPersonalTraining: bool.Parse(PersonalTrainingEntry.Text),
                    optedInForNewsLetter: bool.Parse(OptInForNewsletterEntry.Text),
                    lastCheckInDateTime: DateTime.Parse(LastCheckInDateTimeEntry.Text)
                    );

                // Insert the new member into the database using the dbService instance
                dbService.InsertMember(newMember);

                // Clear input fields after successful insertion
                ClearInputFields();

                // Display a success message
                DisplayAlert("Success", "Member added successfully!", "OK");
            }
        }

        // Method to clear all input fields
        private void ClearInputFields()
        {
            // Clear each entry field
            UsernameEntry.Text = string.Empty;
            PasswordEntry.Text = string.Empty;
            ConfirmPasswordEntry.Text = string.Empty;
            FirstNameEntry.Text = string.Empty;
            LastNameEntry.Text = string.Empty;
            AddressEntry.Text = string.Empty;
            CityEntry.Text = string.Empty;
            RegionEntry.Text = string.Empty;
            PostalCodeEntry.Text = string.Empty;
            CountryEntry.Text = string.Empty;
            PhoneNumberEntry.Text = string.Empty;
            EmailEntry.Text = string.Empty;
            GenderEntry.Text = string.Empty;
            DateOfBirthEntry.Text = string.Empty;
            MembershipTypeEntry.Text = string.Empty;
            HealthInformationEntry.Text = string.Empty;
            FitnessGoalsEntry.Text = string.Empty;
            EmergencyContactNameEntry.Text = string.Empty;
            EmergencyContactNumberEntry.Text = string.Empty;
            PreferredWorkoutTimeEntry.Text = string.Empty;
            TrainingSessionsPerWeekEntry.Text = string.Empty;
            MedicalConditionsEntry.Text = string.Empty;
            PersonalTrainingEntry.Text = string.Empty;
            OptInForNewsletterEntry.Text = string.Empty;
            LastCheckInDateTimeEntry.Text = string.Empty;
        }

        // Method to validate input fields
        private bool ValidateInput()
        {
            if (!ValidateRequiredField(UsernameEntry, "Username")) return false;

            if (!ValidateConfirmPassword(PasswordEntry, ConfirmPasswordEntry)) return false;

            if (!ValidateRequiredField(FirstNameEntry, "First Name")) return false;
            if (!ValidateRequiredField(LastNameEntry, "Last Name")) return false;
            if (!ValidateRequiredField(AddressEntry, "Address")) return false;
            if (!ValidateRequiredField(CityEntry, "City")) return false;
            if (!ValidateRequiredField(RegionEntry, "Region")) return false;
            if (!ValidatePostalCode(PostalCodeEntry.Text)) return false;
            if (!ValidateRequiredField(CountryEntry, "Country")) return false;

            if (!ValidatePhoneNumber(PhoneNumberEntry.Text)) return false;
            if (!ValidateEmail(EmailEntry.Text)) return false;
            if (!ValidateGender(GenderEntry.Text)) return false;
            if (!ValidateDateOfBirth(DateOfBirthEntry.Text)) return false;
            if (!ValidateMembershipType(MembershipTypeEntry.Text)) return false;
            if (!ValidateRequiredField(HealthInformationEntry, "Health Information")) return false;
            if (!ValidateFitnessGoals(FitnessGoalsEntry.Text)) return false;

            if (!ValidateRequiredField(EmergencyContactNameEntry, "Emergency Contact Name")) return false;
            if (!ValidateRequiredField(EmergencyContactNumberEntry, "Emergency Contact Number")) return false;
            if (!ValidatePhoneNumber(EmergencyContactNumberEntry.Text)) return false;

            if (!ValidatePreferredWorkoutTime(PreferredWorkoutTimeEntry.Text)) return false;
            if (!ValidateTrainingSessionsPerWeek(TrainingSessionsPerWeekEntry.Text)) return false;

            if (!ValidateBooleanField(MedicalConditionsEntry, "Has Medical Conditions")) return false;
            if (!ValidateBooleanField(PersonalTrainingEntry, "Wants Personal Training")) return false;
            if (!ValidateBooleanField(OptInForNewsletterEntry, "Opted In for Newsletter")) return false;

            if (!ValidateDateField(LastCheckInDateTimeEntry, "Last Check-In Date Time")) return false;

            return true;
        }

        private bool ValidateRequiredField(Entry entry, string fieldName)
        {
            if (string.IsNullOrEmpty(entry.Text))
            {
                DisplayAlert("Validation Error", $"{fieldName} is required.", "OK");
                return false;
            }
            return true;
        }

        private bool ValidatePhoneNumber(string phoneNumber)
        {
            // Check if the phone number is null or empty
            if (string.IsNullOrEmpty(phoneNumber))
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

        private bool ValidateEmail(string email)
        {
            // Check if the email is null or empty
            if (string.IsNullOrEmpty(email))
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

        private bool ValidateGender(string gender)
        {
            if (string.IsNullOrEmpty(gender))
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

        private bool ValidateDateOfBirth(string dateOfBirthText)
        {
            if (string.IsNullOrEmpty(dateOfBirthText))
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

        private bool ValidateMembershipType(string membershipType)
        {
            if (string.IsNullOrEmpty(membershipType))
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

        private bool ValidateFitnessGoals(string fitnessGoals)
        {
            if (string.IsNullOrEmpty(fitnessGoals))
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

        private bool ValidatePreferredWorkoutTime(string preferredWorkoutTime)
        {
            if (string.IsNullOrEmpty(preferredWorkoutTime))
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

        private bool ValidateTrainingSessionsPerWeek(string trainingSessionsPerWeekText)
        {
            if (string.IsNullOrEmpty(trainingSessionsPerWeekText))
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

        private bool ValidateBooleanField(Entry entry, string fieldName)
        {
            if (string.IsNullOrEmpty(entry.Text))
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

        private bool ValidateConfirmPassword(Entry passwordEntry, Entry confirmPasswordEntry)
        {
            string password = passwordEntry.Text;
            string confirmPassword = confirmPasswordEntry.Text;

            if (string.IsNullOrEmpty(password))
            {
                DisplayAlert("Validation Error", "Password is required.", "OK");
                return false;
            }

            if (string.IsNullOrEmpty(confirmPassword))
            {
                DisplayAlert("Validation Error", "Confirm Password is required.", "OK");
                return false;
            }

            if (password != confirmPassword)
            {
                DisplayAlert("Validation Error", "Password and Confirm Password do not match.", "OK");
                return false;
            }

            return true;
        }

        private bool ValidateDateField(Entry entry, string fieldName)
        {
            if (string.IsNullOrEmpty(entry.Text))
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

        private bool ValidatePostalCode(string postalCode)
        {
            if (postalCode == null)
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

        private void InsertDummyData()
        {
            dbService.InsertMember(new Member(1, "JohnDoe", "123456789", "John", "Doe", "123 Main St", "Calgary", "Alberta", "T1X 0X0", "Canada", "4035551234", "john@example.com", "Male", new DateTime(1985, 5, 12), "Premium", "No health issues", "Build muscle", "Jane Doe", "4035555678", "Evening", 3, false, true, true, DateTime.Now.AddMonths(-2)));
            dbService.InsertMember(new Member(2, "JaneDoe", "123456789", "Jane", "Doe", "456 Oak St", "Calgary", "Alberta", "T2Y 9Z9", "Canada", "4035555678", "jane@example.com", "Female", new DateTime(1990, 7, 18), "Gold", "No health issues", "Weight loss", "John Doe", "4035554321", "Morning", 5, false, false, false, DateTime.Now.AddMonths(-3)));
            dbService.InsertMember(new Member(3, "AliceSmith", "123456789", "Alice", "Smith", "789 Maple Ave", "Calgary", "Alberta", "T3Z 8W8", "Canada", "4035558765", "alice@example.com", "Female", new DateTime(1988, 10, 25), "Basic", "Allergies", "Cardio fitness", "Bob Smith", "4035559876", "Afternoon", 2, true, false, true, DateTime.Now.AddMonths(-4)));
            dbService.InsertMember(new Member(4, "BobJohnson", "123456789", "Bob", "Johnson", "101 Pine Blvd", "Calgary", "Alberta", "T4A 1B1", "Canada", "4035552345", "bob@example.com", "Male", new DateTime(1982, 3, 8), "Premium", "Diabetes", "Muscle toning", "Sara Johnson", "4035555432", "Evening", 4, true, true, false, DateTime.Now.AddMonths(-5)));
            dbService.InsertMember(new Member(5, "EmilyBrown", "123456789", "Emily", "Brown", "202 Cedar Rd", "Calgary", "Alberta", "T5C 2D2", "Canada", "4035557890", "emily@example.com", "Female", new DateTime(1995, 12, 3), "Gold", "No health issues", "Weight loss", "Chris Brown", "4035556789", "Morning", 5, false, false, true, DateTime.Now.AddMonths(-6)));
            dbService.InsertMember(new Member(6, "MichaelLee", "123456789", "Michael", "Lee", "303 Birch St", "Calgary", "Alberta", "T6E 3F3", "Canada", "4035555432", "michael@example.com", "Male", new DateTime(1987, 6, 15), "Basic", "No health issues", "Cardio fitness", "Karen Lee", "4035558765", "Afternoon", 3, false, true, false, DateTime.Now.AddMonths(-7)));
            dbService.InsertMember(new Member(7, "OliviaMiller", "123456789", "Olivia", "Miller", "404 Elm Ave", "Calgary", "Alberta", "T7G 4G4", "Canada", "4035554321", "olivia@example.com", "Female", new DateTime(1992, 2, 28), "Premium", "Asthma", "Build muscle", "David Miller", "4035551234", "Evening", 4, true, false, true, DateTime.Now.AddMonths(-8)));
            dbService.InsertMember(new Member(8, "WilliamSmith", "123456789", "William", "Smith", "505 Oak St", "Calgary", "Alberta", "T8H 5H5", "Canada", "4035559876", "william@example.com", "Male", new DateTime(1980, 9, 10), "Gold", "No health issues", "Weight loss", "Emma Smith", "4035558765", "Morning", 5, false, true, false, DateTime.Now.AddMonths(-9)));
            dbService.InsertMember(new Member(9, "SophiaTaylor", "123456789", "Sophia", "Taylor", "606 Maple Ave", "Calgary", "Alberta", "T9I 6I6", "Canada", "4035558765", "sophia@example.com", "Female", new DateTime(1983, 8, 22), "Basic", "No health issues", "Cardio fitness", "James Taylor", "4035552345", "Afternoon", 3, true, false, true, DateTime.Now.AddMonths(-10)));
            dbService.InsertMember(new Member(10, "BenjaminAnderson", "123456789", "Benjamin", "Anderson", "707 Pine Blvd", "Calgary", "Alberta", "T10J 7J7", "Canada", "4035556789", "benjamin@example.com", "Male", new DateTime(1991, 4, 5), "Premium", "No health issues", "Muscle toning", "Ava Anderson", "4035559876", "Evening", 4, false, true, false, DateTime.Now.AddMonths(-11)));
            dbService.InsertMember(new Member(11, "AvaWilson", "123456789", "Ava", "Wilson", "808 Cedar Rd", "Calgary", "Alberta", "T11K 8K8", "Canada", "4035557890", "ava@example.com", "Female", new DateTime(1986, 1, 7), "Gold", "No health issues", "Weight loss", "Ethan Wilson", "4035555678", "Morning", 5, true, false, true, DateTime.Now.AddMonths(-12)));
            dbService.InsertMember(new Member(12, "EthanMoore", "123456789", "Ethan", "Moore", "909 Birch St", "Calgary", "Alberta", "T12L 9L9", "Canada", "4035552345", "ethan@example.com", "Male", new DateTime(1989, 11, 20), "Basic", "No health issues", "Cardio fitness", "Chloe Moore", "4035554321", "Afternoon", 3, false, false, false, DateTime.Now.AddMonths(-13)));
            dbService.InsertMember(new Member(13, "ChloeBaker", "123456789", "Chloe", "Baker", "1010 Elm Ave", "Calgary", "Alberta", "T13M 1M1", "Canada", "4035555678", "chloe@example.com", "Female", new DateTime(1984, 7, 14), "Premium", "No health issues", "Build muscle", "Henry Baker", "403555-8765", "Evening", 4, true, true, true, DateTime.Now.AddMonths(-14)));
            dbService.InsertMember(new Member(14, "HenryCooper", "123456789", "Henry", "Cooper", "1111 Oak St", "Calgary", "Alberta", "T14N 2N2", "Canada", "4035558765", "henry@example.com", "Male", new DateTime(1981, 3, 28), "Gold", "No health issues", "Muscle toning", "Grace Cooper", "4035554321", "Morning", 5, false, true, false, DateTime.Now.AddMonths(-15)));
            dbService.InsertMember(new Member(15, "GraceFisher", "123456789", "Grace", "Fisher", "1212 Maple Ave", "Calgary", "Alberta", "T15O 3O3", "Canada", "4035552345", "grace@example.com", "Female", new DateTime(1994, 9, 2), "Basic", "No health issues", "Cardio fitness", "Jacob Fisher", "4035557890", "Afternoon", 3, true, false, true, DateTime.Now.AddMonths(-16)));
            dbService.InsertMember(new Member(16, "JacobGraham", "123456789", "Jacob", "Graham", "1313 Pine Blvd", "Calgary", "Alberta", "T16P 4P4", "Canada", "4035557890", "jacob@example.com", "Male", new DateTime(1988, 5, 16), "Premium", "No health issues", "Weight loss", "Sophie Graham", "4035555678", "Evening", 4, false, false, false, DateTime.Now.AddMonths(-17)));
            dbService.InsertMember(new Member(17, "SophieHarper", "123456789", "Sophie", "Harper", "1414 Cedar Rd", "Calgary", "Alberta", "T17Q 5Q5", "Canada", "4035554321", "sophie@example.com", "Female", new DateTime(1983, 1, 31), "Gold", "No health issues", "Cardio fitness", "Jack Harper", "4035558765", "Morning", 5, true, true, true, DateTime.Now.AddMonths(-18)));
            dbService.InsertMember(new Member(18, "JackIngram", "123456789", "Jack", "Ingram", "1515 Birch St", "Calgary", "Alberta", "T18R 6R6", "Canada", "4035555678", "jack@example.com", "Male", new DateTime(1990, 8, 7), "Basic", "No health issues", "Muscle toning", "Lily Ingram", "4035552345", "Afternoon", 3, false, true, false, DateTime.Now.AddMonths(-19)));
            dbService.InsertMember(new Member(19, "LilyJordan", "123456789", "Lily", "Jordan", "1616 Elm Ave", "Calgary", "Alberta", "T19S 7S7", "Canada", "4035558765", "lily@example.com", "Female", new DateTime(1985, 4, 18), "Premium", "No health issues", "Build muscle", "Mason Jordan", "4035557890", "Evening", 4, true, false, true, DateTime.Now.AddMonths(-20)));
            dbService.InsertMember(new Member(20, "MasonKing", "123456789", "Mason", "King", "1717 Oak St", "Calgary", "Alberta", "T20T 8T8", "Canada", "4035557890", "mason@example.com", "Male", new DateTime(1982, 12, 12), "Gold", "No health issues", "Weight loss", "Olivia King", "4035555678", "Morning", 5, false, false, false, DateTime.Now.AddMonths(-21)));
        }
    }
}
