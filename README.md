# xkcd-comics

# How it works
## Downloader class
Handles everything with downloading and internet.
The GetImageByUrl downloads the given image and saves it by the given name and returns a boolean that signifies an (un)successful operation.
GetImageByID is much the same. It finds the image url and calls GetImageByUrl. Returns the same boolean.
HasConnection is self explanatory. Checks connection to https://xkcd.com.

Files are deleted on application exit to not use unnessecary space










