import AAFuzzy, xlrd, pyExcelerator

xl = xlrd.open_workbook('Map Data.xlsx')
katz = xl.sheet_by_name(u'CCRS - Agency')
prn = xl.sheet_by_name(u'PRN - Agency')

#for rownum in range(katz.nrows):

file = open('outputCCRSAdgency.txt', 'w')
file.write('CCRS ID'+';'+'CCRS Core Agency'+';'+'PRN ID'+';'+'PRN Agency'+'; '+'CCRS Dollar Change'+'; '+'PRN Final Dollar'+'\n')

for rownum in range(1,101):
	found_match = False
	found_match_two = False
	list = []
	s1 = katz.row_values(rownum)[1]
	unique_s1 = AAFuzzy.unique_test(s1)
	#SET THRESHOLD
	if len(AAFuzzy.cleanse(s1)) < 4:
		threshold = 1
	elif len(AAFuzzy.cleanse(s1)) < 5:
		threshold = 2
	else:
		threshold = 3
	#****************************
	#Run Fuzzy Match Test
	for rownum2 in range(prn.nrows):
		s2 = prn.row_values(rownum2)[1]
		#created exception list for problematic compared against names (usually short + similar to other short names)
		except_list = ['mars', 'mozy', 'pepco']
		if AAFuzzy.remove_extra(s2).strip() in except_list:
			s2 = 'Will not be compared against'
		list.append(AAFuzzy.fuzzy_search(s1,s2))
	for i in range(len(list)):
		if list[i]<threshold:
			file.write(str(int(katz.row_values(rownum)[0]))+';'+AAFuzzy.remove_spaces(katz.row_values(rownum)[1])+';'+str(int(prn.row_values(i)[0]))+';'+AAFuzzy.remove_spaces(prn.row_values(i)[1])+'; '+
					   str(katz.row_values(rownum)[2])+'; '+str(prn.row_values(i)[2])+'\n')
			found_match = True
	#Run Unique Word Test
	if not found_match:
		for rownum2 in range(prn.nrows):
			s2 = prn.row_values(rownum2)[1]
			unique_s2 = AAFuzzy.unique_test(s2)
			for check in unique_s1:
				if check in unique_s2:
					#print AAFuzzy.remove_spaces(s1), AAFuzzy.remove_spaces(s2)
					file.write(str(int(katz.row_values(rownum)[0]))+';'+AAFuzzy.remove_spaces(s1)+';'+str(int(prn.row_values(rownum2)[0]))+';'+AAFuzzy.remove_spaces(s2)+'; '+
							   str(katz.row_values(rownum)[2])+'; '+str(prn.row_values(rownum2)[2])+'\n')
					found_match_two = True
	if not found_match and not found_match_two:
		file.write(str(int(katz.row_values(rownum)[0]))+';'+AAFuzzy.remove_spaces(s1)+';'+';'+'; '+str(katz.row_values(rownum)[2])+'; '+'\n')
file.close()

		
#s1 = raw_input("Input first string: ")
#s2 = raw_input("Input second string: ")

#print AAFuzzy.fuzzy_search(s1,s2)