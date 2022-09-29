
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
print(myDic)
