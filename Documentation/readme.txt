

Example no.1 : From a gitlab URL: 

DevopsAnalyser.exe https://gitlab.com/api/v4/projects/3472737/merge_requests/1573/commits -url -c

where 3472737 is the PROJECT ID
where 1573 is the MERGE REQUEST ID

flags: 
-url means : Use the url
-c means : calculate commit creation deltas.

----------------------------------------------

Example no.2 : From a file on your computer : 

NOTE : the file must be a valid JSON file.

usage : 

DevopsAnalyser.exe C:\Users\chapo\Desktop\toolpres\commitdata.txt -file -c

flags:
-file means use a file
-c means calculate commit creation deltas.


For now the tool only supports the -c flag, but we could implement any sort of analysis we want. 
the -c flag also shows first and last commits, those options could be separated into different flags (for example)

