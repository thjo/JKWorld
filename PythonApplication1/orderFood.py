import random
import time

lunch = ["pizza", "black noodle", "mala tang"]
# input data from user
while True:
    newItem = input("Please input additional food: ")
    if(newItem != "" and newItem != "q" and newItem != "Q") :
        lunch.append(newItem)
    else:
        break

print(lunch)

##convert string to array & array to hashset
#item = "black noodle"
#set_item = set([item]);

#print(set_lunch)
#set_lunch = set_lunch - set_item
#print(set_lunch)


# convert an array to hashset
set_lunch = set(lunch);
while True : 
    print(set_lunch)
    delItem = input("Please input to delete a menu: ")
    if(delItem != "" and delItem != "q" and delItem != "Q") :
        set_lunch = set_lunch - set([delItem])
    else:
        break


print("Please select a menu among", set_lunch)
#for <variable> in range(start index, stop index, step) :: start index is inclusive and stop index is exclusive
for t in range(5, 0, -1):
    print(t)
    time.sleep(1)

#convert set to array
print(random.choice(list(set_lunch)))