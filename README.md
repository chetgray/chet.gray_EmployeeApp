EmployeeApp
===========

User Story #212023: Update Employee Console App to implement Dependency
Injection with Unity
------------------------------------------------------------------------

> Update the "Employee Console App with DAL" (US #211889) to use the
> Unity Engine for Dependency Injection.
>
> - Start with the original version - NOT the one you did all the
>   Factories in. Otherwise it's going to get real confusing real fast.
> - [x] Use the Unity Container for Dependency Injection.
> - [x] Create the Unity Bootstrapper class like I showed you.
> - [x] Remember, everything should be done via Interfaces to maintain
>   Abstraction. This means you're going to have to change several
>   places that pass the actual class to pass the Interface instead.
> - Don't worry about Interfaces for primary types like `List<>` - you
>   can just call our thing INSIDE the List by the Interface name. So
>   you don't need `IList<IEmployeeModel>`, but rather
>   `List<IEmployeeModel>`.
> - Don't worry about trying to use Unity to create native types like
>   `DataTable` or `SqlDataAdapter` - some of those don't have
>   Interfaces from Microsoft and we don't really need to worry about DI
>   for native stuff anyway.
> - Hints:
>   - When you go to do DI in the Repositories, you'll find that the
>     DataLibrary Class Library Project will need its own
>     `UnityBootstrapper` class, since it can't "see" the one in our
>     main program, and we don't want to add a reference to it (you
>     should be able to plug DataLibary into other projects as well, so
>     we don't want it dependent on any one project).
>   - Be sure to create your lists and whatnot first to be sure they are
>     coming from the Unity Container. Also be sure to `.Clear()` the
>     list to get rid of that Null entry.
>   - You shouldn't be making many changes to your DataAccess.cs class
>     as it shouldn’t contain any non-native types.
> - [x] Here's how to know if you're done: Go into each of your classes,
>   including the main Program.cs, and do a find on "new". If you find
>   yourself "newing" anything that's not a native type (i.e. if you're
>   "newing" any classes you created), you still have work to do!

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
