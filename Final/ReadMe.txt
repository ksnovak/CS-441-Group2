MATH DRILL GAME
Release 2.2.x
April 8, 2014

Programmers: Aurelio "Leo" Aurango, Stephanie Yao
Testers: Kevin Novak
Analyst: Jorge Torres 

Compatibility with Windows XP, 7, and 8
All data stored in C:\Users\Public\MathDrills

Source Control: 
Github, Sharepoint

New Features Added:
---------------------
*Visuals have been added to the application, though some place holders and tentative.

*Major XML Revisions in users.XML:
	*Revised to support student groups, and inactive students (alias for "deleted")
	*Addition of XMLHander.cs - this caused previous functionality to have to be broken, fixed, and re-written in the process.

*Both Students and Teachers user accounts require a password to access.
	*Students select a sequence of buttons as password entry.
	*Teachers type passwords into an entry field akin to conventional passwords.
	
*Student Progress through Problem Sets is now visually represented with a map.
	
*Teacher User Interface:
	*Added functionality for changing passwords, managing groups, assigning more arithmetic operation types.
	*Problems Sets are now assigned to groups, changed from individual assignment.
	*Functionality is now organized into tabs.

Bug Fixes
---------------------
	*[In compliance with REQ5] Students have a password system
		
	*[In compliance with REQ6] Administrators may properly logged in.
	*[In compliance with REQ6] Additional operations are supported, division and multiplication. 
	*[In compliance with REQ6 Edge 1] Entering a non-integer when the program expects is a handled exception.
	
	*[In compliance with REQ7] Problems are properly generated on a per group basis properly.

	*[In compliance with REQ20] Users.XML is properly read to populate the User log in screen. 
	
	*[In compliance with REQ22] Correct last log-in date and time is displayed as a welcome message for both teacher and student user accounts.
	
	*[In compliance with REQ26 Edge 1] Users properly show up in the users list on creation.
	
	*[In compliance with REQ27] The date and time are displayed properly.
	
	*[In compliance with REQ28] The Student Form now displays the correct name.




MATH DRILL GAME
Release 3.3.x
May 6, 2014

Programmers: Jorge Torres 
Testers: Stephanie Yao
Analyst:  Aurelio "Leo" Aurango,  Kevin Novak

Compatibility with Windows XP, 7, and 8
All data stored in C:\Users\Public\MathDrills

Source Control: 
Github, Sharepoint

New Features Added:
---------------------
* More Comprehensive visual have been updated. Application now has a theme, and title screen.
	* Implementation of a map that fills up according to the users performance
	* Parrot that displays a message when the user gets a right or wrong answer

*Major XML Revisions in users.XML:
	*XML now stores more information, and records the students progress
	*XML is used to print out the student records


Bug Fixes
---------------------
	* Interface fixes
		*students can now properly load to different classes and display
		*added graphs to display the data of the students
		*remvoed unecessary styles, tags, and elements
	* Login fixes
		*students can log with or without password
		*students can load their problem sets
	*XML fixes
		*student reports can be written to xml
	*General
		*most unhandled exceptions are handled and are commented in the code
	*