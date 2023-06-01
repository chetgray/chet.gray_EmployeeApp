EmployeeApp
===========

User Story #212022: Update Employee Console App to implement Dependency
Inversion
------------------------------------------------------------------------

> Update your version of "Employee Console App with DAL" (US #211889) to
> implement Dependency Inversion.
>
> - I recommend making a separate copy.
> - [x] Use Interfaces for all of your classes.
> - [ ] Create a Factory.
> - [ ] There should be no "newing" except for the Factory (and SQL
>   Parameters :) )
> - [ ] Pass everything the class needs in via the Constructor and use
>   it within the Class (or inject directly into the methods).
> - Your app should work exactly the same as far as what the user sees.
> - Note that you WILL break things as you go - your Interfaces, your
>   classes, etc. - that's okay!  It can guide you on what to fix next!
> - Note also that some of the base types, like `Dictionary`, come
>   out-of-the-box with Interfaces!  (`IDictionary`)
>   - If they don't, that's okay - just declare the class itself.  For
>     example, `DataTable` doesn't have an Interface.  We're unlikely to
>     be changing Microsoft's classes anyway, so it's okay.
> - You will have to make frequent updates to your Factory to create new
>   versions of the stuff you need to pass down.

User Story #211889: Create Employee Console App with DAL
--------------------------------------------------------

> Create a console app with a DAL, using the Repository pattern.
>
> - [x] The app will use the Employee database we created earlier
> - [x] The app should allow the user to choose from a menu of options
>   - [x] Option 1:  See a list of all employees and their Addresses and
>     Start Dates
>   - [x] Option 2:  See all employees who live in a certain state
>   - [x] Option 3:  See all employees who started after a certain date
> - [x] Be sure to use Business Logic, Models, Repositories, a DAL, an
>   Interface for your DAL, DTOs, and Stored Procedures
