import AAFuzzy, xlrd

xl = xlrd.open_workbook('Top100CCRS.xlsx')
CCRS = xl.sheet_by_name(u'outputCCRS')
x2 = xlrd.open_workbook('Top100PRN.xlsx')
PRN = x2.sheet_by_name(u'outputPRN')

#for rownum in range(prn.nrows):

file = open('master.txt', 'w')
file.write('MasterID'+';'+'MasterName'+';'+'CCRSID'+';'+'PRNID'+'\n')

masterID = 1
for rownum in range(1,PRN.nrows):
	file.write(str(masterID)+';'+PRN.row_values(rownum)[1].strip()+';'+str(PRN.row_values(rownum)[2])+';'+str(PRN.row_values(rownum)[0])+'\n')
	masterID += 1

for rownum in range(1,CCRS.nrows):
	write = True
	s1 = CCRS.row_values(rownum)[1]
	for rownum2 in range(PRN.nrows):
		s2 = PRN.row_values(rownum2)[3]
		if s1 == s2:
			write = False
	if write:	
		if not CCRS.row_values(rownum)[3]:
			file.write(str(masterID)+';'+CCRS.row_values(rownum)[1].strip()+';'+str(CCRS.row_values(rownum)[0])+';'+str(CCRS.row_values(rownum)[2])+'\n')
		else:
			file.write(str(masterID)+';'+CCRS.row_values(rownum)[3].strip()+';'+str(CCRS.row_values(rownum)[0])+';'+str(CCRS.row_values(rownum)[2])+'\n')
		masterID += 1


