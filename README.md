
1. Update the database connection string appSettings.Json
2. Update the log path in appSettings.Json
3. Entity framework Migration commands to be ran using the below commands, update the db and schema Package Console
   dotnet tool install --global dotnet-ef --version 6.*  

4. check if the command is working
   dotnet ef

5. Change to current directory use the command
   cd C:\Users\shett\OneDrive\Desktop\Altimetrik\Zip Candidate User API Challenge C#

6. Specify the context against which we want to run   

7. Manually check the specified database connection in appSetting.json, if it's working
8. update the script to database 
   dotnet ef database update --context ApplicationDataContext
   Check if build succeeded
   
  
