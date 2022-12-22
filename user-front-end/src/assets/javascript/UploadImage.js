// Create a new FormData instance
let formData = new FormData();

// Read the image file into a Blob
let imageBlob = new Blob(['image data'], {type: 'image/jpeg'});

// Add the image file to the FormData instance
formData.append('image', imageBlob, 'image.jpg');
