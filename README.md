# StockManager
Manage your stock saved in a file. Keep track of the history of your changes. Manage projects and their versions.

## Install (Windows)
You can download the Clickonce installer here : https://esseivan.github.io/StockManager/StockManagerDB.application

## Abstract
I once used Excel for managing my personnal stock but VBA programming is not my thing. I still made some stuff but wanted to do more.
I looked for already existing applications but they were too complicated to install/use or were paid applications...
So I looked into doing a C# application, which I know more how to code it. I initially wanted to use a database saved into a file, but due to the restrictions of file-based DB i abandonned this and used my own file format (Json zipped file).

## Preview
Main window:

![image](https://github.com/esseivan/StockManager/assets/14168019/4b3f4144-001b-482c-9917-b59308a3135b)


Advanced search:

![image](https://github.com/esseivan/StockManager/assets/14168019/4b7ec2d2-5080-4806-b629-2169cbc237a5)


Projects:

![image](https://github.com/esseivan/StockManager/assets/14168019/31a1b7a2-e855-400f-be17-4e46137f9156)


History:

![image](https://github.com/esseivan/StockManager/assets/14168019/379625d5-65fc-4d10-aa6d-f38b5cc7d81d)


Order:

![image](https://github.com/esseivan/StockManager/assets/14168019/409c9f1d-76d7-436d-85f1-e9c4e76f07e3)


## Description

This is an app made for windows (using C# .NET framework 4.7.2).
It is used to keep track of your personnal stock. The data is saved in a ".smd" zip file and the history of the changes in a ".smdh" zip file.
No file is deleted, the old saves are moved into a backup location which you can open in Help->See backups.
My reasoning for doing this is that I wanted in no condition the file to be lost because of a crash/bug.
The downside is that the backups will build up and take more and more space. You may regularly delete some old backups. Maybe automatic cleanup will be made in future updates.


It features :
- The management of project and their versions. A project BOM can be substracted from the current stock, or you can generate a bulk add text for the BOM.
Currently, Digikey is the main supplier used, so the format is according to theirs.

- Change history of your stock (not projects nor orders) saved in a separate file.

- Generate bulk add text for the parts in your stock that are below their set amount (LowStock).




## What's next
- Plan to implement Digikey API to update part informations, retrieve pictures
- Add direct links to the part
- Add selected parts from the stock to a specific project.
- Have (expected) project part and real project part (e.g. is you use only 2 out of the 5 parts because the others were not populated)

### What's far away
What is idealy to be implemented but probably won't be :
- Automatic backup cleanup (or better backup solution)
- Multiple suppliers support

## Contribution

Feel free to add issues, fork and contribute to the project.

## Build

I) Open the solution in Visual Studio, have .NET Framework 4.7.2.

II) Restore nuget packages

III) Build


## Infos

Using "ObjectListView" .NET library from https://github.com/jessejohnston/ObjectListView licensed with MIT
See https://objectlistview.sourceforge.net/cs/index.html for documentation
Some changes to this library have been made (such as bug fixes or feature added).

Using "ExcelDataReader" from https://github.com/ExcelDataReader/ExcelDataReader licensed with MIT

Icon downloaded from https://www.flaticon.com/free-icons/in-stock

## License
This project is licensed with GPL-3.0 License
