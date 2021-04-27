# xkcd-comics
## Features completed
• browse through the comics,  
• see the comic details, including its description,  
• search for comics by the comic number as well as text,  
• get the comic explanation,  
• support multiple form factors  
• favorite the comics, which would be available offline too,  
• send comics to others,  
• get notifications when a new comic is published  

# How it works
## Downloader class
Handles everything with downloading and internet.
GetImageByUrl() downloads the given image and saves it by the given name and returns a boolean that signifies an (un)successful operation.
GetImageDataByID() takes an image ID as input and finds all nessecary information. Returns an Xkcd_data object with said data. 
HasConnection() was unstable and has been deleted.
Query() queries https://relevantxkcd.appspot.com for the most relevant comics to a search term, and returns the ID of the best match.
GetLatest() retrieves the ID of the latest comic.

## Email classes
Core and support classes for sending emails. Everything should be self explanatory. Classes are copied from another project of mine.

## Form_comics class
Where everything happens.
Event handlers should be self-explanatory.
GetAndPresentImageForID() retrieves the image with ID id, and all relevant information (if online), and presents both in the relevant showcase.
UpdateThreadFunction() and UpdateLatest() uses the Downloader class to check for and notify the user of the latest comic.

## Form_share class
Form for sharing comics by email. Email account might need configuring to let unknown apps handle emails. 

## LocalFiles class
Handles everything to do with files on the local sysyem, (un)favoriting, etc.
Favorite(), Unfavorite(), and GetFavorites() should all be self-explanatory.
GetNonFavorites() returns an array of the IDs of all temporarily stored images.

## Xkcd_data class
Just a place to store data about a specific comic.

## Other information
Non-favorited images are deleted on application exit to not use unnessecary space










