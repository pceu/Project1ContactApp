# Project: Contact App (Project1)
Name: Phiar Ceu Hnin
SID: 217281975

Information About the app
	This is a Project 1 for SIT313 - Developing Client Server Web Application. Contact App is specifically built for devices runing Android Operating System. Just like
any other contact app, it lets users store contact informatoin (about their friends, family and so on); therefore, anyone who has used a contact app can easily navigate around
the app.

Device/s:
 - Nexus 5x (phone): perfectly run on both portrait and landscape mode. As the screen size is normal it can also be run on other devices; however, it is mainly built
	     and tested on Nexus 5X.
 - Nexus 7 (tablet): The layouts are also built for tablet version to support multiple screen sizes. User can also run on any large-layout device. The app is
		     mainly tested on Nexus 7 and 9.

Functionality/Feature
 - login: User must successfully login in order to access the main page (where contact lists are displayed). Due to limited duration and the scope covered in this project, 
	  users are not allowed to create any login credentials but use the pre-programed/hardcoded credentials to login. The login details will be provided below. 
	  As maintaining a login capability, any invalid login credentials will prompt an alert message that user has provided an invalid information.

 - Display Contact List – Contact (a class) objects are displayed in the main page which basically shows an image of the contact person, name and the company name. 
			  Pressing any of the list will trigger to open another activity called Login Details which will have a more details about the person. 
			  During the transition, a ‘Contact object’ of the list displayed on the main page is passed (as project requirement).

 - Contact Details – as discussed in the above this activity/page displayed the details about the Contact Object shown in the main page.

 - Call, message, email – In Contact Details page, user can perform phone calling, sending SMS and email to the contact person.

 - Create new contact – In the bottom right corner, there is a button with a plus sign which allow user to create or add more Contact information. Pressing it will 
			bring user to a ‘Create New Contact’ activity/page. From here, user can fill the given edit text and radio button to create the new contact information.