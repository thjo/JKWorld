import random

lunch = ["pizza", "black noodle", "mala tang"]
# input data from user
while True:
    newItem = input("Please input additional food: ")
    if(newItem != ""):
        lunch.append(newItem)
    else:
        break

print(lunch)

