# .NET MAUI Final Project 2023

_<sup>Last Updated: December 11, 2023 4:12:07 AM (UTC)</sup>_

_Developed by Hieu Pham, Sherif Mansour, and Kris Schneider_

* [.NET MAUI Final Project 2023](#net-maui-final-project-2023)
  * [A short summarization of the app](#a-short-summarization-of-the-app)
    * [How to use the app](#how-to-use-the-app)
      * [Sign Up](#sign-up)
      * [Log In](#log-in)
      * [Search Members](#search-members)
      * [Update Member Information](#update-member-information)
      * [Delete Members](#delete-members)
    * [Program Structure](#program-structure)
      * [Methods employed](#methods-employed)
  * [Tools used for developing the project](#tools-used-for-developing-the-project)
    * [Getting Started (For developers only)](#getting-started-for-developers-only)
      * [Build and run the app](#build-and-run-the-app)

## A short summarization of the app

Once you've signed up and logged in, you can perform a search, choose a member from the search results, and add a new entry to update the desired field by clicking the update button. The process for deleting is similar: you search, select, click delete, confirm the deletion, and then voilà.

### How to use the app

#### Sign Up

To use the SKH Gym Management App, you need to sign up with your credentials.

1. Open the app on your device.

2. Click on the "Sign Up" button.

3. Fill in the required information (e.g., username, password, email).

4. Click the "Submit" button to create your account.

--------

#### Log In

After signing up, log in to access the app's functionalities.

1. Click on the "Log In" button.

2. Enter your username and password.

3. Click the "Login" button.

--------

#### Search Members

Once logged in, you can search for members in the database.

1. Click on the "Search" button.

2. Enter the member's information (e.g., name, ID) in the search field.

3. Select the desired member from the search results.

--------

#### Update Member Information

After selecting a member, you can update their information.

1. Click on the "Update" button.

2. Type the new information in the corresponding fields.

3. Click the "Update" button to save the changes.

--------

#### Delete Members

If you need to remove a member from the database, follow these steps.

1. Search for the member as described in the "Search Members" section.

2. Select the member you want to delete.

3. Click on the "Delete" button.

4. Confirm the deletion.

---------

### Program Structure

1. _`App.xaml` & `App.xaml.cs`_:

    Defines the main application class and lifecycle events.
    Manages initialization and startup logic for the SKH Gym Management App.

2. _`MainPage.xaml` & `MainPage.xaml.cs`_:

    Scrollable main page with a logo, welcome message, and buttons for sign-up, log-in, and member management.
    Configured button properties for size, color, and event handlers.
    Logic for button clicks implemented in _`MainPage.xaml.cs`_.

3. _`SignUp.xaml` & `SignUp.xaml.cs`_:

    Scrollable Sign-Up page with input fields organized using `ScrollView()` and `VerticalStackLayout()`.
    Each input field arranged using `HorizontalStackLayout()`.
    `SignUpButton` triggers `OnClickSignUp()` event on click.

4. _`LogIn.xaml` & `LogIn.xaml.cs`_:

    Scrollable Log In page with username, password input fields, and the "Login" button.
    Layout organized using `ScrollView()` and `VerticalStackLayout()`.
    LogInButton triggers `OnClickLogIn()` event on click.

5. _`ManageMember.xaml` & `ManageMember.xaml.cs`_:

    Scrollable page for managing members with a search bar, search results, and sections for selected member details and update fields.
    Input fields organized using various layouts like `StackLayout()` and `HorizontalStackLayout()`.
    Buttons for updating and deleting members with corresponding event handlers (`OnClickUpdate()` and `OnClickDelete()`).

--------

#### Methods employed

1. In _`SignUp.xaml.cs`_

   * `OnClickSignUp()`
    Handles the click event of the `SignUpButton()`.
    Includes logic to validate user inputs, process the sign-up request, and navigate to the appropriate page.

2. In _`LogIn.xaml.cs`_

   * `OnClickLogIn()`
      Handles the click event of the `LogInButton()`.
      Includes logic to authenticate user credentials, process the log-in request, and navigate to the main application page.

3. In _`ManageMember.xaml.cs`_

   * `OnSearchTextChanged()`
      Handles the text changed event of the `MemberSearchBar`.
      Includes logic to filter and update the displayed search results based on the entered text.

   * `OnItemSelected()`
      Handles the item selected event of the `SearchResultsListView`.
      Includes logic to display detailed information about the selected member.

   * `OnClickUpdate()`
      Handles the click event of the "UpdateButton".
      Includes logic to update the member's information based on the entered data in the update fields.

   * `OnClickDelete()`
      Handles the click event of the "DeleteButton".
      Includes logic to delete the selected member from the system.

Feel free to reach out if you encounter any issues or have suggestions for improvement. Thank you for using the SKH Gym Management App!

--------

## Tools used for developing the project

* _Visual Studio 2022/JetBrains Rider_
* _dotNET SDK_
* _Visual Studio Code (VSCode)/VSCodium_ (Optional)

### Getting Started (For developers only)

1. **Installation**
    Clone the repository to your local machine.

    ```bash
    git clone https://github.com/Zliced13/FP_SPSU23.git
    ```

2. **Navigate to the project directory.**

    ```bash
    cd "a_directory/FP_SPSU23"
    ```

#### Build and run the app

1. **Prerequisite Steps**

    1. Open the solution in _Visual Studio 2022/JetBrains Rider_, or your preferred IDE.

    1. Please note, the following _NuGet_ are required: **`Microsoft.sqlite.core`** and **`sqlitepclraw.bundle_E_sqlite3`**.
        These can be installed by running,

        ```bash
        dotnet add package Microsoft.sqlite.core
        dotnet add package sqlitepclraw.bundle_E_sqlite3
        ```

        Or by using your IDEs built-in _NuGet_ package manager GUI.

2. **Building and Running the App**

    _IMPORTANT NOTE:_
    _Before running the app, ensure that you comment out the dummy data to prevent it from being inserted into the database inadvertently. Failure to do so may result in unwanted data being added to the database during the initial run. Please refer to the code comments for guidance on how to comment out the dummy data._

   1. Make sure you have **_.NET MAUI_** installed on your machine.
     If you don't have **_.NET MAUI_** on your system; you can install it by running,

      _Note: Make sure your working directory in your terminal is SET to the folder you cloned the project to._

        ```bash
        dotnet workload install maui -s 'https://api.nuget.org/v3/index.json'
        ```

   1. In the IDE of your choice, click the "Build" button to compile the project. Then click the "Run" button to run and deploy the app.
