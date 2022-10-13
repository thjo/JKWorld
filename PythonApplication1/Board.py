

## dictionary
#dic_pair = {}

#while True : 
#    question = input("Please input a question: ")
#    if question == "q" or question == "Q" or question == "" :
#        break;
#    else :
#        # add a question
#        dic_pair[question] = "";

## answer
#for ans in list_dic:
#    answer = input("Please answer the question '" + ans + "': ")
#    dic_pair[ans] = answer;

#print(dic_pair)


# round 2. 
list_pair = []

while True : 
    question = input("Please input a question: ")
    if question == "q" or question == "Q" or question == "" :
        break;
    else:
        list_pair.append({"Question": question, "Answer": ""})

for item in list_pair:
    answer = input("Please answer the question '" + item["Question"] + "': ")
    item["Answer"] = answer;


print(list_pair)
