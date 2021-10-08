# LuckyFightCs

This app let's you play a small clicker game in your browser.

This app was made for a project during our degree in Efficom Lille.

This was made by :
- Amaury (amaurydelassus) ; 
- Mara (Lenaraa) 

It's encouraged to use Visual Studio Code to run the app.

The API and the database is hosted on alwaysdata.

## Project setup
You may use a local API and database to run the app.
For this, you first need to create a MySQL database named luckyfightcs_database on your computer. Then add a user admin with an admin password.
Next add a terminal to your app then type
```
cd API
dotnet ef migrations InitialCreate
dotnet ef database update
dotnet run
```
This will create a database and start the API. 
Instead of doing 
```dotnet ef migrations InitialCreate
dotnet ef database update
``` 
you may use the script in API/Database/create.sql to create the tables and fill them.

You will have to change every call to the API on the APP folder from https://luckyfightcs.alwaysdata.net/ to https://localhost:5001/

## Run Project
```
cd APP
dotnet watch run
```
This will open the app. From there, you will be asked to create an account to be able to play.

### Enjoy !
