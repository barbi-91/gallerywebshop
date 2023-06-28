# gallerywebshop
WEB SHOP APPLICATION FOR SELL ARTS WITH PUBLIC AND PRIVATE USER INTERFACE USING ASP.NET MVC 5 AND ENTITY FRAMEWORK

INTRODUCTION  
This application is an MVC Web application implementing onlinle shop for artwork. It consists of public portal available to logged in and   
non-logged-in users, as well as the administrative portal avilable only to administrators of the Web site. 

HOW IT WORKS  
The division bussines logic into three parts (model, view and controller) enables layered expansion applications.  The app is secure, which 
is enabled by using the Identity system  provided by ASP.NET Core. Entity Framework Core was used to access and manipulate the database. Due 
to the use of Entity Framework Core and a local database it was not necessary manually configure the database and it was immediately available 
for use. 
The system has navigation on the page in the form of categories and products. On the home page there is a list of 10 randomly displayed
products from the database.  Clicking on an individual product of the user leads to the product page on which contains all the necessary 
information about that product. There is a category in the navigation. By clicking on a category, the user is guided to a page that displays 
a list of products in that category. 
With the help of the built-in REST WEB API application, it is possible to use endpoints in XML or JSON format, it is possible to access all 
products or individual product by code from the database (HTTP GET protocol). By right-clicking on the application, we click on the set as a 
startup project option so that we can start it.
Functional requirements are related to functionality of the web store itself:
• The customer have an overview of the product description and specifications, including the gallery products,
• Products is grouped by category, and they are accessible using search engines,
• The admin is provide the basic features for managing the web store. Such features must derive from the following functional requirements
• The admin have insight into the users and all their information necessary for the shipment ordered products,
• The admin can add/remove categories and products as well the possibility of changing them.
• The admin can add/remove users as well the possibility of changing them.
• The customer can add a specific product to the cart, increase its quantity or delete it from the cart, as well as fill in the information for 
purchasing that product.
  
TECHNICAL FEATURES AND DEVELOPMENT TOOLS  
ASP.NET Core Framework Version 4.8.04084  was used in the creation of the Web Shop application technologies through the MVC 6 form and Microsoft
Visual Studio Community 2022 Version 17.4.3 as an integrated development environment from Microsoft. HTML, CSS and Bootstrap were used to create
the user interface. To create of dynamic Web pages with C#, the Razor -Wiew engine was used.

POINTS OF INTEREST
* A proposal to upgrade the application to improve the user experience is the ability to log in each employee in order to have insight into his
order history.  
* The possibility of changing profile data, and that can be implemented Identity system.  
* In order to further improve the user experience, more is needed introduce validation for all forms where the user enters data, also using
javascript, ajax calls or AngularJS, it is possible to improve the accessibility of the application.  
* It is necessary to improve the shopping cart to make it more visually attractive, and to add a section with discounts.

HOW TOP RUN LOCALLY  
- 1 - download locally from git and open in Visual studio 
- 2 - set connection string in appsettings.Development file as well in Program.cs set Service for creating context class object resources to get connection
- 3 - start migration in Packager Manager Console--add migration CreateDatabase to set data base and seed data
- 4 - use update-database to create database if migration was secesfully
- 5 - run the App

MAINTENANCE AND HISTORY  
Maintenance by Barbara Erdec Golović 2023  
Version - 1.0.0.0
