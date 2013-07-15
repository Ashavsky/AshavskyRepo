import nltk, re, string

#Rule 1: Remove leading + trailing spaces
#Rule 2: Make all sentences lowercase

def clean(sentence):
	new_sentence = sentence.lower().strip()
	return new_sentence

#Rule 3: Transform symbols to English

def symbol_transform(sentence):
	symbol_map =  {"&":"and", "'s":"", "-":"", ",":""}
	token = nltk.word_tokenize(sentence)
	counter = 0
	removecount = 0
	for word in token:
		for key in symbol_map:
			if word == key and key == "'s":
				token[counter-1] += "s"
				removecount += 1
			elif word == key:
				token[token.index(word)] = symbol_map[key]	
		counter +=1
	for i in range(0,removecount): 
		token.remove("'s")
	new_sentence = " ".join(token)
	return new_sentence

#Rule 4: Remove extra info such as Inc, Corp, etc. (will use wildcard search later?)

def remove_extra(sentence):
	word_list = ['inc.','inc','incorporated','l.l.c.','11c','company','co.','co','group','services','corp','corporation', 'holding', 'holdings',
	             'motor company', 'assoc', 'association', 'and', 'department', 'dept']
	sentence = sentence.lower()
	split_sentence = sentence.split(" ")
	new_sentence = []
	for word in split_sentence:
		if word not in word_list:
				new_sentence.append(word)
	new_sentence = " ".join(new_sentence)
	return new_sentence

#Rule 5: Remove punctuation that will be created from earlier step (as well as other stray punctuation)

def normalize(sentence):
	for p in string.punctuation:
		sentence = sentence.replace(p,"")
	return sentence
	
#Rule 6: Remove an extra spaces (either error in entering or created through earlier rules)

def remove_spaces(sentence):
	new_sentence = re.sub('\s+', ' ', sentence)
	return new_sentence
	
#Create "Master Cleanse" function

def cleanse(sentence):
	new_sentence = remove_spaces(normalize(remove_extra(symbol_transform(clean(sentence)))))
	return new_sentence

#Perform the fuzzy search using rules + Levenshtein Distance

def fuzzy_search(s1,s2):
	stringOne = cleanse(s1)
	stringTwo = cleanse(s2)
#	print stringOne
#	print stringTwo
	return nltk.metrics.edit_distance(stringOne,stringTwo)

#Rule 7: Check if string has unique words, if match on unique words it is a match (ex. Geico vs Geico Direct)

def unique_test(sentence):
	clean_sentence = remove_spaces(normalize(remove_extra(symbol_transform(clean(sentence)))))
	break_sentence = nltk.word_tokenize(clean_sentence)
	unique_wordlist = []
	exception_list = ['our', 'of', 'and', '&', 'for', 'the', 'llc', 'your']
	checklist = ['ford', 'subway', 'deere', 'paramount', 'chase', 'sears', ]
	for word in break_sentence:
		if (not nltk.corpus.wordnet.synsets(word) and word not in exception_list) or word in checklist:
			unique_wordlist.append(word)
	return unique_wordlist

#Define Fuzzy Threshold: My rule = 1 point per word allowed, 2 point per word for each word with length greater 10 units

def fuzzy_threshold(sentence):
	sentence_new = remove_spaces(normalize(remove_extra(symbol_transform(clean(sentence)))))
	sentence_list = " ".split(sentence_new)
	threshold = 0
	for i in sentence_list:
		if len(i) > 10:
			threshold += 2
		else:
			threshold +=1
	return threshold
	
	
	
	
	
	
	
	
	