set startPremiere=%time%
"c:\program files\qlikview\qv.exe" /r "Premiere\Premiere QVD Creator.qvw"
set endPremiere=%time%
echo Premiere, Date: %date%, Start Time: %startPremiere%, End Time: %endPremiere% ^ >> "QVD Reload Log.txt"
PING 1.1.1.1 -n 1 -w 6000 >NUL

set startCC=%time%
"c:\program files\qlikview\qv.exe" /r "CC Dashboard\CC Dashboard QVD Creator.QVW"
set endCC=%time%
echo Clear Channel, Date: %date%, Start Time: %startCC%, End Time: %endCC% ^ >> "QVD Reload Log.txt"
PING 1.1.1.1 -n 1 -w 6000 >NUL

set startRER=%time%
"c:\program files\qlikview\qv.exe" /r "RER\RER QVD Creator.QVW"
set endRER=%time%
echo RER, Date: %date%, Start Time: %startRER%, End Time: %endRER% ^ >> "QVD Reload Log.txt"
PING 1.1.1.1 -n 1 -w 6000 >NUL

set startKRG=%time%
"c:\program files\qlikview\qv.exe" /r "KRG Dashboard\KRG QVD Creator.qvw"
set endKRG=%time%
echo KRG, Date: %date%, Start Time: %startKRG%, End Time: %endKRG% ^ >> "QVD Reload Log.txt"
PING 1.1.1.1 -n 1 -w 6000 >NUL

set startRBA=%time%
"c:\program files\qlikview\qv.exe" /r "RBA\RBA QVD Creator.qvw"
set endRBA=%time%
echo RBA, Date: %date%, Start Time: %startRBA%, End Time: %endRBA% ^ >> "QVD Reload Log.txt"
PING 1.1.1.1 -n 1 -w 6000 >NUL

EXIT