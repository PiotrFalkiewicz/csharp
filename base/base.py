import os
import cv2
import numpy as np
path = "images/"
files = os.listdir(path)

def incrementColor(pixel,collection):
	it_max = len(collection)
	distance = [0 for x in range(it_max)]
	closestColor,closestDistance = 0,1000000
	for i in range(it_max):
		diff = pixel-collection[i][1]
		distance[i] = np.sqrt(diff[0]*diff[0]+diff[1]*diff[1]+diff[2]*diff[2])
		if distance[i] < closestDistance:
			closestColor = i
			closestDistance = distance[i]
	collection[closestColor][2]+=1
	
print(files)

for image in files:
	name = image[:-4]
	img = cv2.imread(path+image,1)
	if img.ndim==3:
		h,w,_ = img.shape
		thresholds = [
		["Red",(0,0,255),0],
		["Green",(0,255,0),0],
		["Blue",(255,0,),0],
		["Black",(0,0,0),0],
		["Yellow",(0,255,255),0],
		["Cyan",(255,255,0),0],
		["White",(255,255,255),0],
		["Magenta",(255,0,255),0]]
		for i in range(h):
			for j in range(w):
					incrementColor(img[i][j],thresholds)
		
		print("3 dominating colors in image "+name+": ")
		for x in sorted(thresholds,key=lambda x:x[2])[-3:]:
			print(x[0]+": "+str(x[2]*100/(h*w)//1)+"%")
