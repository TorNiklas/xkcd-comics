# xkcd-comics
## Features completed
• browse through the comics,  
• see the comic details, including its description,  
• search for comics by the comic number as well as text,  
• get the comic explanation,  
• support multiple form factors  

## Features not completed
• favorite the comics, which would be available offline too,  
• send comics to others,  
• get notifications when a new comic is published

## Rationale
The reason I've only completed some of the tasks is that the assignment was to pick a subset of the requirements to make an MVP, 
and it is in my belief that favoriting, sending comics, and getting notificaitons is not required to make a minimally viable comic viewer application. 
The reason for completing the tasks I chose to complete is either because it was (in my opinion) required to make an MVP, or that it was an insignificant amount of extra work.

## More
I will, however, continue development in another branch in order to complete more features.



# How it works
## Downloader class
Handles everything with downloading and internet.
GetImageByUrl() downloads the given image and saves it by the given name and returns a boolean that signifies an (un)successful operation.
GetImageByID() is much the same. It finds the image url and calls GetImageByUrl. Returns the same boolean.
HasConnection() is self explanatory. Checks connection to https://xkcd.com.
Query() queries https://relevantxkcd.appspot.com for the most relevant comics to a search term, and returns the ID of the best match.

## Xkcd_data class
Just a place to store data about a specific comic.

## Form1 class
Where everything happens.
Event handlers should be self-explanatory.
GetAndPresentImageForCurrentID() retrieves the image with ID = currentID, and all relevant information, and presents both the image and the information in the relevant showcase.
FixFontSize() sets the font size of lb_details to fit within the window.

## Other information
Images are deleted on application exit to not use unnessecary space










