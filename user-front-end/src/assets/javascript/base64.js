const convertBase64 = (file) => {
    return new Promise((resolve, reject) => {
        const fileReader = new FileReader();
        fileReader.readAsDataURL(file);

        fileReader.onload = () => {
            resolve(fileReader.result);
        };

        fileReader.onerror = (error) => {
            reject(error);
        };
    });
};

export const uploadImage = async (file) => {
    const NewChat = new Event('NewChat')
    console.log(file)
    const base64 = await convertBase64(file);
    
    return base64
};



export const  dataURLtoFile = (dataurl) =>{
    var img = new Image()
    img.src = dataurl
    document.getElementById('main').appendChild(img)
    return img
}
