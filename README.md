# MKSChat

Service created using this guide:  
https://learn.microsoft.com/en-us/dotnet/core/extensions/windows-service

## Notes:
- First run elevated as administator, to let the service register a new event source.
[MSDN EventLog docs](http://msdn.microsoft.com/en-us/library/2awhba7a%28v=vs.110%29.aspx "EventLog.CreateEventSource Method (System.Diagnostics) | Microsoft Learn"):  
"To create an event source in Windows Vista and later or Windows Server 2003, you must have administrative privileges."
