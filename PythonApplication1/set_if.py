import random
## if 
#from random import random   


foods = ["kimchi", "cheese", "mala"]
food = random.choice(foods)
if food == "mala":
    print("extra spice please.")
else:
    print("just regular please")

print("food is here.")

#foods = ["kimchi", "cheese", "mala"]
#foods_set = set(foods)     # same: foods_set2 = set(["kimchi", "cheese", "mala"])
#print(foods)
#print(foods_set)


menu1 = set(["mala", "kimchi", "bisket"])
menu2 = set(["mala", "dumpling", "noddle"])
print(menu1)
print(menu2)

# union 
menu3 = menu1 | menu2
print(menu3)

#intersection
menu4 = menu1 & menu2
print(menu4)

#diiference of sets
menu5 = menu1-menu2
print(menu5)

