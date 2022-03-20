# Meeting Manager
## MOM - Capture

### Business Requirements

This web application will provide employees with the ability to electronically record any safety discussions they have had with their colleagues.  The solution will let employees record that a safety discussion occurred and to enter the following information related to it:  

* The person who observed the discussion
* Date of discussion 
* Location of discussion 
* Colleague(s) the discussion was with 
* Subject of discussion  
* Outcomes

Applications will also allow the employee to view a list of previous discussions they have recorded.

### User flow diagram

![alt text](https://github.com/nayanarajur/safety_meeting_manager/blob/main/documents/user_flow.jpg)

## Getting Started
1. Clone the repository and open the Visual studio solution `Meeting.Manager.sln` inside folder `\src\Meeting.Manager`
2. Run the database migrator project
    * Set `Meeting.Manager.Database` as the startup project inside src/
    * Run the project
    * This should create a database `Meeting.Manager.Database` inside the server `(localdb)\ProjectsV13`
3. Run the web site project
    * Set `Meeting.Manager.Web` as the startup project
    * Run the project
    * Enter the data and save the details.