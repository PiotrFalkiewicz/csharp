from flask import Flask,request
import os
import cv2
import numpy as np
import json
app = Flask(__name__)

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

def decodeColors(img):
    if img.ndim == 2:
        print("I don't understand grayscale images. Goodbye")
    elif img.ndim == 3:
        h, w, _ = img.shape
        # rgb
        # init thresholds
        thresholds = [
            ["Red", (255, 0, 0), 0],
            ["Green", (0, 255, 0), 0],
            ["Blue", (0, 0, 255), 0],
            ["Black", (0, 0, 0), 0],
            ["Yellow", (255, 255, 0), 0],
            ["Cyan", (0, 255, 255), 0],
            ["White", (255, 255, 255), 0],
            ["Magenta", (255, 0, 255), 0]]
        for i in range(h):
            for j in range(w):
                incrementColor(img[i][j], thresholds)
        return [x[0]+" ~"+str(x[2]*100/(h*w)//1)+"%" for x in sorted(thresholds, key=lambda x: x[2])][-3:]



@app.route('/find_colors.json', methods=['GET','POST'])
def find_color():
    if request.method == 'POST':
        file = request.files['file']
        img = cv2.imdecode(np.fromstring(file.read(),np.uint8), 1)
        print("img received\n")
        colors = decodeColors(img)
        #color == ['color3','color2','color1']
        data = {}
        data['1st color'] = colors[2]
        data['2nd color'] = colors[1]
        data['3rd color'] = colors[0]
    return json.dumps(data, sort_keys=True)

if __name__ == '__main__':
    app.run(host='0.0.0.0')
