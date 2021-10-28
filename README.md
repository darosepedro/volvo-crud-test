# CRUD - It is a test for a job position

# Main Purpose
As a user, I need a crud for:
1. Get a list of persisted Truck entities
2. Update Truck entities
3. Delete Truck entities
4. Add Truck entities
  - The Truck entity minimun properties must be:
    - Model (just accept FH and FM values)
    - Build Year (must be current year)
    - Model Year (must be current year or next year)

# Subordinate Purpose
Despite the CRUD allows just FH and FM as Model, the creation of unlimited number of Models must be accept dynamically

# Technical Requirements
- Use ASP.NET Core
- Local database
- ORM to map database tables
  - Migrations to create and update database dynamically
  - Unit Tests
  - Documentation

