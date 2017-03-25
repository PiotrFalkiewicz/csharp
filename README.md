# Base
* "base" is directory for basic version of excersice. 
* User have to create new directory called 'images' and upload there his images.

How script works?
-for every image in directory it reads it into ndarray
-for every pixel of every image, classifier choose closest color (from 'thresholds' list)
-script returns 3 most popular colors with %

# Rest
"rest" is directory for enhanced version of excersice.
User can connect to api and upload his image with function:
curl -F "file=@image.png" http://localhost:5000/find_colors.json 
User can also connect to local device.
Scipt returns .json data with 3 most popular colors on the image.
