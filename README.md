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
- **Set Discount**: Apply percentage-based discounts to books.
- **Search Books**: Filter books by title, author, genre, or publisher.

### 3. Book Purchase (User Window)
- **Purchase**: Add a book to the user's purchase history and increment its sales count.
- **Purchase History**: View the purchase history of the user.
- **Search Books**: Filter available books by title, author, genre, or publisher.

### 4. Discount Management
- **Admin Control**: Admins can set and manage discounts on books, which are reflected in purchase prices.

### 5. Database Management
- Interacts with a SQL Server database for all CRUD operations.
- Three main tables:
  - `Users`: Stores user credentials.
  - `Books`: Stores book details.
  - `Purchases`: Stores purchase details of all users.

### 6. Intuitive UI
- Built using WPF.
- Data grid displays book details, allowing easy management.
- Back buttons for easy navigation.
- Search functionality for efficient book management and browsing.

### 7. Validation
- Input validation for user registration, book creation, and editing.
- Password requirements enforced during registration.
- Genre and author names must consist of letters only.
- Discount percentages must be between 0 and 100.

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
1. .NET 8.0 (or higher).
2. Microsoft SQL Server (local or remote instance).
3. SQL Server Management Studio (SSMS).
4. Visual Studio (recommended for running and debugging the project).

### Steps

#### 1. Clone the Repository
```bash
git clone https://github.com/fakhri2406/BookStore.git
cd BookStore
```

#### 2. Configure the Database
- Open SSMS and create a server (or connect to one).
- Create a database with the name 'BookStore' using 'SQL Authentication' (set the username and password to 'admin').
- Run the any line of code `BookStore.sql` script and connect to the previously created server.
- Use the same authentication method and select 'True' in the 'Trust Server Certificate' field.
- Run the BookStore.sql script to create the necessary tables and perform other queries.
- Update the connection string in `App.config` to match your database credentials:

```xml
<connectionStrings>
    <add name="BookStoreDB"
         connectionString="Data Source=<YourServer>;Initial Catalog=BookStore;User ID=admin;Password=admin;Encrypt=True;TrustServerCertificate=True;Integrated Security=False"
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
- **`DataAccess.cs`**: Contains methods for CRUD operations for users, books, and purchases.

### 3. **ViewModels**
Implements the MVVM pattern.
- **`BaseViewModel.cs`**: Provides property change notification.
- **`LoginViewModel.cs`**: Handles login logic.
- **`RegisterViewModel.cs`**: Handles registration logic.
- **`UserViewModel.cs`**: Manages the book purchase and search functionality for users.
- **`AdminViewModel.cs`**: Manages the book management and search functionality for admins.
- **`PurchaseHistoryViewModel.cs`**: Handles the logic of purchase history view.

### 4. **Views**
User interface components built with XAML.
- **`LoginWindow.xaml`**: Login screen.
- **`RegisterWindow.xaml`**: Registration screen.
- **`UserWindow.xaml`**: Main interface for book purchase with search functionality.
- **`AdminWindow.xaml`**: Main interface for book management with search functionality.
- **`PurchaseHistoryWindow.xaml`**: Interface for viewing purchase history.
- **`BookWindow.xaml`**: Interface for adding and editing book details.
- **`SetDiscountWindow.xaml`**: Interface for setting discounts on books.

### 5. **Resources**
- **`App.xaml`**: Entry point for the WPF application with global styles implemented.
- **`App.config`**: Configuration file for database connection.

---

## Usage

### User Login and Registration
1. Launch the application.
2. On the login screen:
   - Enter valid credentials to log in.
   - Click "Register" to create a new account.
   - To log in as admin, enter 'admin' for both username and password fields.
3. After logging in, the corresponding main window will appear.

### User Window
1. **Purchasing a Book**:
   - Select a book from the list.
   - Click the "Purchase" button.
   - Confirm the purchase with the final price reflecting any applied discounts.
   - The book will be added to the user's history.
2. **Viewing Purchase History**:
   - Click "Purchase History."
   - View the history.
3. **Searching Books**:
   - Enter a search query in the search bar.
   - Click "Search" to filter books by title, author, genre, or publisher.
   - Click "Clear" to reset the search and view all books.

### Admin Window
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
4. **Setting a Discount**:
   - Select a book from the list.
   - Click the "Set Discount" button.
   - Enter the discount percentage (0-100) and save.
   - The discount will be applied to the book, affecting purchase prices.
5. **Searching Books**:
   - Enter a search query in the search bar.
   - Click "Search" to filter books by title, author, genre, or publisher.
   - Click "Clear" to reset the search and view all books.

---

## Database Schema

### Users Table
| Column    | Data Type    | Constraints       |
|-----------|--------------|-------------------|
| UserId    | INT          | Primary Key       |
| Username  | NVARCHAR(50) | Unique, Not Null  |
| Password  | NVARCHAR(50) | Not Null          |

### Books Table
| Column             | Data Type       | Constraints                        |
|--------------------|-----------------|------------------------------------|
| BookId             | INT             | Primary Key                        |
| Title              | NVARCHAR(100)   | Not Null                           |
| Author             | NVARCHAR(100)   | Not Null                           |
| Publisher          | NVARCHAR(100)   | Not Null                           |
| Pages              | INT             | Not Null                           |
| Genre              | NVARCHAR(50)    | Not Null                           |
| PublicationYear    | INT             | Not Null                           |
| Cost               | DECIMAL(10, 2)  | Not Null                           |
| SalePrice          | DECIMAL(10, 2)  | Not Null                           |
| Discount           | DECIMAL(5,2)    | Not Null, Default 0                |
| IsContinuation     | BIT             | Not Null                           |
| ContinuationOf     | INT             | Nullable, Foreign Key (BookId)     |
| SalesCount         | INT             | Not Null, Default 0                |

### Purchases Table
| Column          | Data Type    | Constraints                        |
|-----------------|--------------|------------------------------------|
| PurchaseId      | INT          | Primary Key                        |
| UserId          | INT          | Not Null, Foreign Key (UserId)     |
| BookId          | INT          | Not Null, Foreign Key (BookId)     |
| PurchaseDate    | DATETIME     | Not Null, Default Getdate()        |

---

## License
This project is open-source and available under the MIT License.
