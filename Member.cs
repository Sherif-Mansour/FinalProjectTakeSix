using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectTakeSix
{
    // Definition of the Member class.
    public class Member
    {
        // Private fields to store member information.
        int userId;
        string userName;
        string password;
        string firstName;
        string lastName;
        string address;
        string city;
        string region;
        string postalCode;
        string country;
        string phoneNumber;
        string email;
        string gender;
        DateTime dateOfBirth;
        string membershipType;
        string healthInformation;
        string fitnessGoals;
        string emergencyContactName;
        string emergencyContactNumber;
        string preferredWorkoutTime;
        int trainingSessionsPerWeek;
        bool hasMedicalConditions;
        bool wantsPersonalTraining;
        bool optedInForNewsLetter;
        DateTime lastCheckInDateTime;

        // Public properties with get and set accessors for accessing private fields
        public int UserId { get => userId; set => userId = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
        public string Region { get => region; set => region = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }
        public string Country { get => country; set => country = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
        public string Gender { get => gender; set => gender = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string MembershipType { get => membershipType; set => membershipType = value; }
        public string HealthInformation { get => healthInformation; set => healthInformation = value; }
        public string FitnessGoals { get => fitnessGoals; set => fitnessGoals = value; }
        public string EmergencyContactName { get => emergencyContactName; set => emergencyContactName = value; }
        public string EmergencyContactNumber { get => emergencyContactNumber; set => emergencyContactNumber = value; }
        public string PreferredWorkoutTime { get => preferredWorkoutTime; set => preferredWorkoutTime = value; }
        public int TrainingSessionsPerWeek { get => trainingSessionsPerWeek; set => trainingSessionsPerWeek = value; }
        public bool HasMedicalConditions { get => hasMedicalConditions; set => hasMedicalConditions = value; }
        public bool WantsPersonalTraining { get => wantsPersonalTraining; set => wantsPersonalTraining = value; }
        public bool OptedInForNewsLetter { get => optedInForNewsLetter; set => optedInForNewsLetter = value; }
        public DateTime LastCheckInDateTime { get => lastCheckInDateTime; set => lastCheckInDateTime = value; }

        // Constructor to initialize member object with provided values
        public Member(int userId, string userName, string password, string firstName, string lastName, string address, string city, string region, string postalCode, string country, string phoneNumber, string email, string gender, DateTime dateOfBirth, string membershipType, string healthInformation, string fitnessGoals, string emergencyContactName, string emergencyContactNumber, string preferredWorkoutTime, int trainingSessionsPerWeek, bool hasMedicalConditions, bool wantsPersonalTraining, bool optedInForNewsLetter, DateTime lastCheckInDateTime)
        {
            // Initializing private fields with provided values
            this.userId = userId;
            this.userName = userName;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.region = region;
            this.postalCode = postalCode;
            this.country = country;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.gender = gender;
            this.dateOfBirth = dateOfBirth;
            this.membershipType = membershipType;
            this.healthInformation = healthInformation;
            this.fitnessGoals = fitnessGoals;
            this.emergencyContactName = emergencyContactName;
            this.emergencyContactNumber = emergencyContactNumber;
            this.preferredWorkoutTime = preferredWorkoutTime;
            this.trainingSessionsPerWeek = trainingSessionsPerWeek;
            this.hasMedicalConditions = hasMedicalConditions;
            this.wantsPersonalTraining = wantsPersonalTraining;
            this.optedInForNewsLetter = optedInForNewsLetter;
            this.lastCheckInDateTime = lastCheckInDateTime;
        }

        // Override of the ToString() method to provide a formatted string representation of the member object
        public override string ToString()
        {
            return $"User Id: {userId} || User Name: {userName} || Name: {firstName} {lastName} || Gender: {Gender}\nDate of Birth (YYYY/MM/DD): {dateOfBirth}\nContact: {address}, {city}, {region} {postalCode} {country} || {phoneNumber} || {email}\nMembership Type: {membershipType} || Health Information: {healthInformation} || Fitness Goals: {fitnessGoals}\nEmergency Contact Name: {emergencyContactName} || Emergency Contact Number: {emergencyContactNumber}\nPreferred Workout Time: {preferredWorkoutTime} || Training Sessions per Week: {trainingSessionsPerWeek} || Has Medical Conditions? {HasMedicalConditions} || Wants Personal Training? {wantsPersonalTraining} || Opted In for Newsletter? {optedInForNewsLetter}\nLast Check In Date (YYYY/MM/DD): {lastCheckInDateTime}\n";
        }
    }
}
