using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectTakeSix
{
    // Definition of th DbService class.
    public class DbService
    {
        // Singleton instance of the DbService class.
        private static DbService _instance;

        // SQLite database connection.
        private SqliteConnection _dbCon;

        // Private constructor to initialize the database.
        private DbService()
        {
            InitializeDatabase();
        }

        // Singleton pattern: Get the instance of DbService
        public static DbService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DbService();
                }
                return _instance;
            }
        }

        // Method to initialize the SQLite database and create the Member table
        private void InitializeDatabase()
        {
            // Define the path for the SQLite database file
            string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "gym.db");

            // Create and open the SQLite connection
            _dbCon = new SqliteConnection($"Data Source={databasePath}");
            _dbCon.Open();

            // Create the Member table if it doesn't exist
            using (var createTableCmd = new SqliteCommand("CREATE TABLE IF NOT EXISTS Member (UserId INTEGER PRIMARY KEY, UserName TEXT, Password TEXT, FirstName TEXT, LastName TEXT, Address TEXT, City TEXT, Region TEXT, PostalCode TEXT, Country TEXT, PhoneNumber TEXT, Email TEXT, Gender TEXT, DateOfBirth DATETIME, MembershipType TEXT, HealthInformation TEXT, FitnessGoals TEXT, EmergencyContactName TEXT, EmergencyContactNumber TEXT, PreferredWorkoutTime TEXT, TrainingSessionsPerWeek INTEGER, HasMedicalConditions INTEGER, WantsPersonalTraining INTEGER, OptedInForNewsLetter INTEGER, LastCheckInDateTime DATETIME)", _dbCon))
            {
                createTableCmd.ExecuteNonQuery();
            }
        }

        // Method to insert a new Member into the Member table
        public void InsertMember(Member member)
        {
            // SQL command to insert a new Member
            using (var insertCommand = new SqliteCommand("INSERT INTO Member (UserName, Password, FirstName, LastName, Address, City, Region, PostalCode, Country, PhoneNumber, Email, Gender, DateOfBirth, MembershipType, HealthInformation, FitnessGoals, EmergencyContactName, EmergencyContactNumber, PreferredWorkoutTime, TrainingSessionsPerWeek, HasMedicalConditions, WantsPersonalTraining, OptedInForNewsLetter, LastCheckInDateTime) VALUES (@UserName, @Password, @FirstName, @LastName, @Address, @City, @Region, @PostalCode, @Country, @PhoneNumber, @Email, @Gender, @DateOfBirth, @MembershipType, @HealthInformation, @FitnessGoals, @EmergencyContactName, @EmergencyContactNumber, @PreferredWorkoutTime, @TrainingSessionsPerWeek, @HasMedicalConditions, @WantsPersonalTraining, @OptedInForNewsLetter, @LastCheckInDateTime)", _dbCon))
            {
                // Set parameters for the SQL command
                insertCommand.Parameters.AddWithValue("@UserName", member.UserName);
                insertCommand.Parameters.AddWithValue("@Password", member.Password);
                insertCommand.Parameters.AddWithValue("@FirstName", member.FirstName);
                insertCommand.Parameters.AddWithValue("@LastName", member.LastName);
                insertCommand.Parameters.AddWithValue("@Address", member.Address);
                insertCommand.Parameters.AddWithValue("@City", member.City);
                insertCommand.Parameters.AddWithValue("@Region", member.Region);
                insertCommand.Parameters.AddWithValue("@PostalCode", member.PostalCode);
                insertCommand.Parameters.AddWithValue("@Country", member.Country);
                insertCommand.Parameters.AddWithValue("@PhoneNumber", member.PhoneNumber);
                insertCommand.Parameters.AddWithValue("@Email", member.Email);
                insertCommand.Parameters.AddWithValue("@Gender", member.Gender);
                insertCommand.Parameters.AddWithValue("@DateOfBirth", member.DateOfBirth);
                insertCommand.Parameters.AddWithValue("@MembershipType", member.MembershipType);
                insertCommand.Parameters.AddWithValue("@HealthInformation", member.HealthInformation);
                insertCommand.Parameters.AddWithValue("@FitnessGoals", member.FitnessGoals);
                insertCommand.Parameters.AddWithValue("@EmergencyContactName", member.EmergencyContactName);
                insertCommand.Parameters.AddWithValue("@EmergencyContactNumber", member.EmergencyContactNumber);
                insertCommand.Parameters.AddWithValue("@PreferredWorkoutTime", member.PreferredWorkoutTime);
                insertCommand.Parameters.AddWithValue("@TrainingSessionsPerWeek", member.TrainingSessionsPerWeek);
                insertCommand.Parameters.AddWithValue("@HasMedicalConditions", member.HasMedicalConditions);
                insertCommand.Parameters.AddWithValue("@WantsPersonalTraining", member.WantsPersonalTraining);
                insertCommand.Parameters.AddWithValue("@OptedInForNewsLetter", member.OptedInForNewsLetter);
                insertCommand.Parameters.AddWithValue("@LastCheckInDateTime", member.LastCheckInDateTime);

                // Execute the SQL command
                insertCommand.ExecuteNonQuery();
            }
        }

        // Method to clear all records from the Member table
        public void ClearMemberTable()
        {
            // SQL command to delete all records from the Member table
            using (var clearTableCmd = new SqliteCommand("DELETE FROM Member", _dbCon))
            {
                clearTableCmd.ExecuteNonQuery();
            }

            // SQL command to reset the auto-increment sequence for the Member table
            using (var resetSequenceCmd = new SqliteCommand("DELETE FROM sqlite_sequence WHERE name='Member'", _dbCon))
            {
                resetSequenceCmd.ExecuteNonQuery();
            }
        }

        // Method to retrieve a Member by username and password
        public Member GetMemberByUsernameAndPassword(string username, string password)
        {
            // SQL command to select a Member by username and password
            using (var selectCommand = new SqliteCommand("SELECT * FROM Member WHERE UserName = @UserName AND Password = @Password", _dbCon))
            {
                // Set parameters for the SQL command
                selectCommand.Parameters.Add(new SqliteParameter("@UserName", username));
                selectCommand.Parameters.Add(new SqliteParameter("@Password", password));

                // Execute the SQL command and read the result
                using (var reader = selectCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Create a new Member object based on the retrieved data
                        Member member = new Member(
                            userId: reader.GetInt32(reader.GetOrdinal("UserId")),
                            userName: reader.GetString(reader.GetOrdinal("UserName")),
                            password: reader.GetString(reader.GetOrdinal("Password")),
                            firstName: reader.GetString(reader.GetOrdinal("FirstName")),
                            lastName: reader.GetString(reader.GetOrdinal("LastName")),
                            address: reader.GetString(reader.GetOrdinal("Address")),
                            city: reader.GetString(reader.GetOrdinal("City")),
                            region: reader.GetString(reader.GetOrdinal("Region")),
                            postalCode: reader.GetString(reader.GetOrdinal("PostalCode")),
                            country: reader.GetString(reader.GetOrdinal("Country")),
                            phoneNumber: reader.GetString(reader.GetOrdinal("PhoneNumber")),
                            email: reader.GetString(reader.GetOrdinal("Email")),
                            gender: reader.GetString(reader.GetOrdinal("Gender")),
                            dateOfBirth: reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                            membershipType: reader.GetString(reader.GetOrdinal("MembershipType")),
                            healthInformation: reader.GetString(reader.GetOrdinal("HealthInformation")),
                            fitnessGoals: reader.GetString(reader.GetOrdinal("FitnessGoals")),
                            emergencyContactName: reader.GetString(reader.GetOrdinal("EmergencyContactName")),
                            emergencyContactNumber: reader.GetString(reader.GetOrdinal("EmergencyContactNumber")),
                            preferredWorkoutTime: reader.GetString(reader.GetOrdinal("PreferredWorkoutTime")),
                            trainingSessionsPerWeek: reader.GetInt32(reader.GetOrdinal("TrainingSessionsPerWeek")),
                            hasMedicalConditions: reader.GetInt32(reader.GetOrdinal("HasMedicalConditions")) == 1,
                            wantsPersonalTraining: reader.GetInt32(reader.GetOrdinal("WantsPersonalTraining")) == 1,
                            optedInForNewsLetter: reader.GetInt32(reader.GetOrdinal("OptedInForNewsLetter")) == 1,
                            lastCheckInDateTime: reader.GetDateTime(reader.GetOrdinal("LastCheckInDateTime"))
                        );

                        return member;
                    }
                }
            }

            return null;
        }

        // Method to retrieve a list of Members based on a search text
        public List<Member> GetMembersBySearchText(string searchText)
        {
            // SQL command to select Members based on a search text
            using (var selectCommand = new SqliteCommand("SELECT * FROM Member WHERE UserName LIKE @SearchText OR FirstName LIKE @SearchText OR LastName LIKE @SearchText", _dbCon))
            {
                // Set parameters for the SQL command
                selectCommand.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                // Execute the SQL command and read the result
                using (var reader = selectCommand.ExecuteReader())
                {
                    List<Member> searchResults = new List<Member>();

                    while (reader.Read())
                    {
                        // Create a new Member object for each retrieved record
                        Member member = new Member(
                            userId: reader.GetInt32(reader.GetOrdinal("UserId")),
                            userName: reader.GetString(reader.GetOrdinal("UserName")),
                            password: reader.GetString(reader.GetOrdinal("Password")),
                            firstName: reader.GetString(reader.GetOrdinal("FirstName")),
                            lastName: reader.GetString(reader.GetOrdinal("LastName")),
                            address: reader.GetString(reader.GetOrdinal("Address")),
                            city: reader.GetString(reader.GetOrdinal("City")),
                            region: reader.GetString(reader.GetOrdinal("Region")),
                            postalCode: reader.GetString(reader.GetOrdinal("PostalCode")),
                            country: reader.GetString(reader.GetOrdinal("Country")),
                            phoneNumber: reader.GetString(reader.GetOrdinal("PhoneNumber")),
                            email: reader.GetString(reader.GetOrdinal("Email")),
                            gender: reader.GetString(reader.GetOrdinal("Gender")),
                            dateOfBirth: reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                            membershipType: reader.GetString(reader.GetOrdinal("MembershipType")),
                            healthInformation: reader.GetString(reader.GetOrdinal("HealthInformation")),
                            fitnessGoals: reader.GetString(reader.GetOrdinal("FitnessGoals")),
                            emergencyContactName: reader.GetString(reader.GetOrdinal("EmergencyContactName")),
                            emergencyContactNumber: reader.GetString(reader.GetOrdinal("EmergencyContactNumber")),
                            preferredWorkoutTime: reader.GetString(reader.GetOrdinal("PreferredWorkoutTime")),
                            trainingSessionsPerWeek: reader.GetInt32(reader.GetOrdinal("TrainingSessionsPerWeek")),
                            hasMedicalConditions: reader.GetInt32(reader.GetOrdinal("HasMedicalConditions")) == 1,
                            wantsPersonalTraining: reader.GetInt32(reader.GetOrdinal("WantsPersonalTraining")) == 1,
                            optedInForNewsLetter: reader.GetInt32(reader.GetOrdinal("OptedInForNewsLetter")) == 1,
                            lastCheckInDateTime: reader.GetDateTime(reader.GetOrdinal("LastCheckInDateTime"))
                        );

                        // Add the Member object to the list of search results
                        searchResults.Add(member);
                    }

                    return searchResults;
                }
            }
        }

        // Method to update an existing Member record
        public void UpdateMember(Member updatedMember)
        {
            // SQL command to update a Member record
            using (var updateCommand = new SqliteCommand("UPDATE Member SET UserName = @UserName, Password = @Password, FirstName = @FirstName, LastName = @LastName, Address = @Address, City = @City, Region = @Region, PostalCode = @PostalCode, Country = @Country, PhoneNumber = @PhoneNumber, Email = @Email, Gender = @Gender, DateOfBirth = @DateOfBirth, MembershipType = @MembershipType, HealthInformation = @HealthInformation, FitnessGoals = @FitnessGoals, EmergencyContactName = @EmergencyContactName, EmergencyContactNumber = @EmergencyContactNumber, PreferredWorkoutTime = @PreferredWorkoutTime, TrainingSessionsPerWeek = @TrainingSessionsPerWeek, HasMedicalConditions = @HasMedicalConditions, WantsPersonalTraining = @WantsPersonalTraining, OptedInForNewsLetter = @OptedInForNewsLetter, LastCheckInDateTime = @LastCheckInDateTime WHERE UserId = @UserId", _dbCon))
            {
                // Set parameters for the SQL command
                updateCommand.Parameters.AddWithValue("@UserId", updatedMember.UserId);
                updateCommand.Parameters.AddWithValue("@UserName", updatedMember.UserName);
                updateCommand.Parameters.AddWithValue("@Password", updatedMember.Password);
                updateCommand.Parameters.AddWithValue("@FirstName", updatedMember.FirstName);
                updateCommand.Parameters.AddWithValue("@LastName", updatedMember.LastName);
                updateCommand.Parameters.AddWithValue("@Address", updatedMember.Address);
                updateCommand.Parameters.AddWithValue("@City", updatedMember.City);
                updateCommand.Parameters.AddWithValue("@Region", updatedMember.Region);
                updateCommand.Parameters.AddWithValue("@PostalCode", updatedMember.PostalCode);
                updateCommand.Parameters.AddWithValue("@Country", updatedMember.Country);
                updateCommand.Parameters.AddWithValue("@PhoneNumber", updatedMember.PhoneNumber);
                updateCommand.Parameters.AddWithValue("@Email", updatedMember.Email);
                updateCommand.Parameters.AddWithValue("@Gender", updatedMember.Gender);
                updateCommand.Parameters.AddWithValue("@DateOfBirth", updatedMember.DateOfBirth);
                updateCommand.Parameters.AddWithValue("@MembershipType", updatedMember.MembershipType);
                updateCommand.Parameters.AddWithValue("@HealthInformation", updatedMember.HealthInformation);
                updateCommand.Parameters.AddWithValue("@FitnessGoals", updatedMember.FitnessGoals);
                updateCommand.Parameters.AddWithValue("@EmergencyContactName", updatedMember.EmergencyContactName);
                updateCommand.Parameters.AddWithValue("@EmergencyContactNumber", updatedMember.EmergencyContactNumber);
                updateCommand.Parameters.AddWithValue("@PreferredWorkoutTime", updatedMember.PreferredWorkoutTime);
                updateCommand.Parameters.AddWithValue("@TrainingSessionsPerWeek", updatedMember.TrainingSessionsPerWeek);
                updateCommand.Parameters.AddWithValue("@HasMedicalConditions", updatedMember.HasMedicalConditions);
                updateCommand.Parameters.AddWithValue("@WantsPersonalTraining", updatedMember.WantsPersonalTraining);
                updateCommand.Parameters.AddWithValue("@OptedInForNewsLetter", updatedMember.OptedInForNewsLetter);
                updateCommand.Parameters.AddWithValue("@LastCheckInDateTime", updatedMember.LastCheckInDateTime);

                // Execute the SQL command
                updateCommand.ExecuteNonQuery();
            }
        }

        // Method to delete a Member record by UserId
        public void DeleteMember(int userId)
        {
            // SQL command to delete a Member record by UserId
            using (var deleteCommand = new SqliteCommand("DELETE FROM Member WHERE UserId = @UserId", _dbCon))
            {
                // Set parameters for the SQL command
                deleteCommand.Parameters.AddWithValue("@UserId", userId);

                // Execute the SQL command
                deleteCommand.ExecuteNonQuery();
            }
        }
    }
}
