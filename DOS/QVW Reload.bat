set startPremiere=%time%
"c:\program files\qlikview\qv.exe" /r "Premiere\Premiere_Reporting.qvw"
set endPremiere=%time%
echo Premiere, Date: %date%, Start Time: %startPremiere%, End Time: %endPremiere% ^ >> "QVW Reload Log.txt"
PING 1.1.1.1 -n 1 -w 6000 >NUL

set startCC=%time%
"c:\program files\qlikview\qv.exe" /r "CC Dashboard\Clear Channel Reporting Dashboard.QVW"
set endCC=%time%
echo Clear Channel, Date: %date%, Start Time: %startCC%, End Time: %endCC% ^ >> "QVW Reload Log.txt"
PING 1.1.1.1 -n 1 -w 6000 >NUL

set startRER=%time%
"c:\program files\qlikview\qv.exe" /r "RER\RER Radio Billing Report.QVW"
set endRER=%time%
echo RER, Date: %date%, Start Time: %startRER%, End Time: %endRER% ^ >> "QVW Reload Log.txt"
PING 1.1.1.1 -n 1 -w 6000 >NUL

set startKRG=%time%
"c:\program files\qlikview\qv.exe" /r "KRG Dashboard\KRG Dashboard.QVW"
set endKRG=%time%
echo KRG, Date: %date%, Start Time: %startKRG%, End Time: %endKRG% ^ >> "QVW Reload Log.txt"
PING 1.1.1.1 -n 1 -w 6000 >NUL

set startRBA=%time%
"c:\program files\qlikview\qv.exe" /r "RBA\Radio Billing Report.QVW"
set endRBA=%time%
echo RBA, Date: %date%, Start Time: %startRBA%, End Time: %endRBA% ^ >> "QVW Reload Log.txt"
PING 1.1.1.1 -n 1 -w 6000 >NUL

EXIT