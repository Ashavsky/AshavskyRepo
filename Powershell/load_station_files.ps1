#Function to send error email
$errorMessage = "The following .zip files are either damaged or empty: `n"
$errorCheck = $false

function sendMail([string] $body)
{    
	 Write-Host "Sending Error Email"

     #SMTP server name
     $smtpServer = "sendmail.katz-media.com"

     #Creating a Mail object
     $msg = new-object Net.Mail.MailMessage

     #Creating SMTP server object
     $smtp = new-object Net.Mail.SmtpClient($smtpServer)

     #Email structure 
     $msg.From = "noreply@katz-media.com"
     # $msg.ReplyTo = "replyto@xxxx.com"
     $msg.To.Add("ALEXANDER.ASHAVSKY@katz-media.com")
     $msg.subject = "LAN Parser Corrupted File Email"
     $msg.body = $body

     #Sending email 
     $smtp.Send($msg)
}

#Variables for paths (TEST)
# $ftpRoot = "C:\Powershell\LAN_Parser\MEDIASTAR\" #Will be "D:/webservices/FTProot/EDI/MEDIASTAR/" in real app
# $destinationRoot = "C:\Powershell\LAN_Parser\Affidavits\" #Will be "D:/Affidavits" in real app

#Variables for paths (REAL)
$ftpRoot = "D:/webservices/FTProot/EDI/MEDIASTAR/" #Will be "D:/webservices/FTProot/EDI/MEDIASTAR/" in real app
$destinationRoot = " D:/affidavits/" #Will be "D:/Affidavits" in real app

#Test if files exist
if(-Not (Test-Path -Path C:\Powershell\LAN_Parser\MEDIASTAR\*)) {break}


#Open instance of application
$shell = new-object -com shell.application

#Find All stations_*.zip files
$stationZips = gci -Path $ftpRoot -filter stations_*.zip
# echo $stationZips

#Extract text from zips to folder - confirm silent + overwrite is option they want
foreach($file in $stationZips)
{
	$fileName = $ftpRoot + $file.Name
	$destination = $destinationRoot + "national_inbox"
	$newFolder = $destinationRoot + "temp"
	$zip = $shell.NameSpace($fileName)
	#Check if file is corrupted or damaged by seeing if you can access the .zip file contents
	if($zip.items().count -eq 0)
	{
		$errorCheck = $true
		$damageFile = "`n" + $file.Name
		$errorMessage += $damageFile
		# Write-Host "File" $file.Name "is either damaged or empty"
	}
	foreach($item in $zip.items())
	{
		New-Item -ItemType Directory -Force -Path $newFolder
		$shell.Namespace($destinationRoot + "temp").copyhere($item, 0x14)
		Get-ChildItem -Path $newFolder -filter *.txt -recurse | Copy-Item -destination $destination
		$test = Get-ChildItem -Path $newFolder -filter *.txt -recurse
		Remove-Item -Force -Recurse -Path $newFolder
	}
}

#copy and move items
copy-item ($ftproot + "stations_*.zip") ($destinationroot + "local_inbox") -Force
move-item ($ftproot + "stations_*.zip") ($destinationroot + "national_outbox") -Force

#Send error email if corrupted .zips exist
if ($errorCheck)
{
	sendMail $errorMessage
}

# D:\applications\LAN_Parser\Bin\KatzLANParser.exe
