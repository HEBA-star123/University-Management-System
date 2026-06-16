# University-Management-System
A lightweight, robust University Management System built using C# and Windows Forms. This project demonstrates core Software Engineering concepts including Object-Oriented Programming (OOP), File Handling, and Data Structures without relying on heavy database engines.

##  Features
- **Authentication & Security:** Secure login screen transitioning to a centralized admin dashboard.
- **Student Management:** Full CRUD operations (Add, Update, Delete, Search) for student profiles, custom GPA validations, and live data binding.
- **Course Management:** Add, search, and modify university courses and credit hours.
- **Course Enrollment:** Business-logic module to enroll students into specific courses with strict prevention of duplicate entries.
- **Business Intelligence & Reports:** A dedicated dashboard component that reads flat files synchronously to calculate dynamic stats (Total Students, Total Courses, Total Enrollments, and overall University Average GPA).
- **Data Persistence:** Custom File Handling mechanisms using `StreamWriter` and `StreamReader` to save and load system states into flat text files.
