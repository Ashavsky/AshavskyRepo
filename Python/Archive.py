import os
import shutil
import datetime


directoryList = os.listdir('C:\PythonWork\ArchiveTest')
Directory = 'C:\PythonWork\ArchiveTest'
newDirectory = 'C:\PythonWork\ArchiveTest\Archive'
log = open("C:\PythonWork\ArchiveTest\Archive\log.txt",'a')
directoryListChanging = os.listdir('C:\PythonWork\ArchiveTest')

for x in directoryListChanging:
	if os.path.isdir(x):
		directoryListChanging.remove(x)

for x in directoryList:
	if os.path.isdir(x):
		directoryList.remove(x)		

for file in directoryList:
	name = file[0:file.index(".",file.index(".")+1)]
	version = file[name.index("_v")+2:file.index(".",file.index(".")+1)]
	base1 = file[0:file.index("_v")]
	for fileCheck in directoryListChanging:
		nameCheck = file[0:fileCheck.index(".",fileCheck.index(".")+1)]
		versionCheck = fileCheck[nameCheck.index("_v")+2:fileCheck.index(".",fileCheck.index(".")+1)]
		base2 = fileCheck[0:fileCheck.index("_v")]
		if base1 == base2 and float(versionCheck)<float(version):
			moveFile = Directory+"\\"+fileCheck
			shutil.move(moveFile,newDirectory)
			directoryListChanging.remove(fileCheck)
			message = "File = "+base2+"; Version= "+versionCheck+"; Archived on "+str(datetime.date.today())+"\n"
			log.write(message)


			
		
			