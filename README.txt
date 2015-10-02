I decided to go with the implementation that reads from the generated .csv files from the sensor simulator.

To ensure the program works correctly, you must first start the sensor simulator and setup the simulation and export the data.

You must also be sure to change the email address and password in the EmailSender.cs to the correct one you will be testing with as the contest email.
Or you can just uncomment the Console.WriteLine in the Send method of this class to test the output without sending emails.

After all that, run Racer.exe and you'll have your working program.