import axios from "axios";

export const PostFormdata = async (Image) => {
    console.log(Image)
    let Form = {
        file: Image,
    }
    await axios({
        headers: { 'Content-type': 'multipart/form-data'},
        method: 'post',
        url:`${import.meta.env.VITE_API}api/ChatHub`,
        data: Form
    }).then((res)=>{
        console.log(res)
    })
}