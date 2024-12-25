# BookStore Application

## Overview
BookStore Application is a Windows Presentation Foundation (WPF) project that simulates the management of a bookstore. It provides an intuitive interface to add, edit, delete, sell, and manage books in a database. Users can log in or register, ensuring secure access to the application.

This application demonstrates a practical implementation of the MVVM (Model-View-ViewModel) pattern combined with ADO.NET for database interaction.

---

## Features

### 1. User Management
- **Login**: Validate user credentials against the database.
- **Registration**: Allow new users to create an account.

### 2. Book Management (Admin Window)
- **Add a Book**: Insert new book details into the database.
- **Edit a Book**: Update existing book details.
- **Delete a Book**: Remove a book from the database.

### 3. Book Purchase (User Window)
- **Purchase**: Add a book to the user's purchase history and increment its sales count.
- **Purchase History**: View the purchase history of the user.

### 4. Database Management
- Interacts with a SQL Server database for all CRUD operations.
- Two main tables:
  - `Users`: Stores user credentials.
  - `Books`: Stores book details.
  - `Purchases`: Stores purchase details of all users.

### 5. Intuitive UI
- Built using WPF.
- Data grid displays book details, allowing easy management.
- Back buttons for easy navigation.

### 6. Validation
- Input validation for user registration, book creation, and editing.
- Password requirements enforced during registration.
- Genre and author names must consist of letters only.

---

## Tech Stack

### Frontend
- WPF (Windows Presentation Foundation)
- XAML for UI design

### Backend
- ADO.NET for database interaction
- MVVM pattern for clean architecture

### Database
- Microsoft SQL Server

---

## Installation and Setup

### Prerequisites
1. .NET Framework (version compatible with WPF).
2. Microsoft SQL Server (local or remote instance).
3. Visual Studio (recommended for running and debugging the project).

### Steps

#### 1. Clone the Repository
```bash
git clone https://github.com/fakhri2406/BookStore.git
cd BookStore
```

#### 2. Configure the Database
- Run the `BookStore.sql` script in SQL Server Management Studio (SSMS) to create the necessary database and tables.
- Update the connection string in `App.config` to match your database credentials:

```xml
<connectionStrings>
    <add name="BookStoreDB"
         connectionString="Data Source=<YourServer>;Initial Catalog=BookStore;User ID=<YourUsername>;Password=<YourPassword>;Encrypt=True;TrustServerCertificate=True;Integrated Security=False"
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

#### 3. Build and Run the Application
- Open the solution in Visual Studio.
- Restore NuGet packages (if applicable).
- Build the solution.
- Run the application.

---

## Project Structure

### 1. **Models**
- **`Book.cs`**: Represents the book entity.
- **`User.cs`**: Represents the user entity.
- **`Purchase.cs`**: Represents the purchase entity.

### 2. **DataAccess**
Handles interaction with the database using ADO.NET.
- **`DataAccess.cs`**: Contains methods for CRUD operations for both users and books.

### 3. **ViewModels**
Implements the MVVM pattern.
- **`BaseViewModel.cs`**: Provides property change notification.
- **`LoginViewModel.cs`**: Handles login logic.
- **`RegisterViewModel.cs`**: Handles registration logic.
- **`UserViewModel.cs`**: Manages the book purchase functionality for user.
- **`AdminViewModel.cs`**: Manages the book management functionality for admin.
- **`PurchaseHistoryViewModel.cs`**: Handles the logic of purchase history view.

### 4. **Views**
User interface components built with XAML.
- **`LoginWindow.xaml`**: Login screen.
- **`RegisterWindow.xaml`**: Registration screen.
- **`UserWindow.xaml`**: Main interface for book purchase.
- **`AdminWindow.xaml`**: Main interface for book management.
- **`PurchaseHistoryWindow.xaml`**: Interface for viewing puchase history.
- **`BookWindow.xaml`**: Interface for adding and editing book details.

### 5. **Resources**
- **`App.xaml`**: Entry point for the WPF application.
- **`App.config`**: Configuration file for database connection.

---

## Usage

### User Login and Registration
1. Launch the application.
2. On the login screen:
   - Enter valid credentials to log in.
   - Click "Go to Register" to create a new account.
   - To log in as admin, enter 'admin' to both username and password fields.
3. After logging in, the corresponding main window will appear.

### User Window
1. **Purchasing a Book**:
   - Click the "Purchase" button.
   - The book will be added to user's history.
2. **Viewing Purchase History**:
   - Click "Purchase History."
   - View the history.

### Admin Books
1. **Adding a Book**:
   - Click the "Add" button.
   - Fill in the book details and click "Save."
2. **Editing a Book**:
   - Select a book from the list.
   - Click "Edit."
   - Modify the details and click "Save."
3. **Deleting a Book**:
   - Select a book from the list.
   - Click "Delete."
   - Confirm the action.

---

## Database Schema

### Users Table
| Column    | Data Type    | Constraints       |
|-----------|--------------|-------------------|
| UserId    | INT          | Primary Key       |
| Username  | NVARCHAR(50) | Unique, Not Null |
| Password  | NVARCHAR(50) | Not Null          |

### Books Table
| Column          | Data Type       | Constraints                        |
|-----------------|-----------------|------------------------------------|
| BookId          | INT             | Primary Key                        |
| Title           | NVARCHAR(100)  | Not Null                           |
| Author          | NVARCHAR(100)  | Not Null                           |
| Publisher       | NVARCHAR(100)  | Not Null                           |
| Pages           | INT             | Not Null                           |
| Genre           | NVARCHAR(50)   | Not Null                           |
| PublicationYear | INT             | Not Null                           |
| Cost            | DECIMAL(10, 2) | Not Null                           |
| SalePrice       | DECIMAL(10, 2) | Not Null                           |
| IsContinuation  | BIT             | Not Null                           |
| ContinuationOf  | INT             | Nullable, Foreign Key (BookId)     |
| SalesCount      | INT             | Not Null, Default 0                |

### Purchases Table
| Column          | Data Type       | Constraints                        |
|-----------------|-----------------|------------------------------------|
| PurchaseId      | INT             | Primary Key                        |
| UserId          | INT             | Not Null, Foreign Key (UserId)     |
| BookId          | INT             | Not Null, Foreign Key (BookId)     |
| PurchaseDate    | DATETIME        | Not Null, Default Getdate()        |

---

## Future Improvements
1. Implement password hashing for user credentials.
2. Add advanced search and filtering options for books.
3. Enhance the UI with animations and responsive design.

---

## License
This project is open-source and available under the MIT License.
