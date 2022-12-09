const input = document.getElementById("selectAvatar");


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

export const uploadImage = async (event) => {
    const NewChat = new Event('NewChat')

    const file = event.target.files[0];
    const base64 = await convertBase64(file);
    
    return base64
};



export const  dataURLtoFile = (dataurl) =>{
    var img = new Image()
    img.src = dataurl
    document.getElementById('main').appendChild(img)
    return img
}

// export const fileToBase64 = async(file) =>{
//     const file = file.target.files[0];
//     const base64 = await convertBase64(file);
    
//     return base64
// }
