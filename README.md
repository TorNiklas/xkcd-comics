# xkcd-comics

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
Files are deleted on application exit to not use unnessecary space










