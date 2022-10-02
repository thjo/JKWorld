
import random

#Iteration Statement
#import time
#while True:
    #time.sleep(1)
    #break
for x in range(3):
    print(x)
    print(random.choice(["beef intestine","chicken","black noodle","curry", "instant noodle"]))
    if x == 10: 
        break
    
print("I'm so hungry now.")

#Variable
lunch = random.choice(["hala", "salad", "juice"])
lunch = "Refrigerator"
dinner = random.choice(["korean bbq", "sushi", "sasimi"])
print(lunch)
print(dinner)

#Dictionary
myDic = {"color":"red", "food":"kimchi", "movie":"action"}
foods = ["kimch","egg","mala"]
#get
print(myDic.get("color"))
#add
myDic["country"] = "Korea"
#delete
del myDic["color"]
print(myDic)
#clear
myDic.clear();
print(len(myDic))
#array
#add
foods.append("juice")
#del
print(foods)
del foods[1]
#get
print(foods[0])
print(foods[-1])
print(foods[-2])
print(foods[-3])

for i in range(len(foods)):
    print(foods[i])
for f in foods:
    print(f)


information = {"country":"seoul", "hobby":"movie", "favorite food":"kimchi"}
for x, y in information.items():
    print(x + " " + y)
