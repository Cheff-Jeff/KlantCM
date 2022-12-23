import axios from "axios";

export const PostFormdata = (Image) => {
    const headers = {
        'Content-Type': 'image/png'
      }
    let formData = new FormData();
    console.log(Image)
    formData.append('image', Image);
    console.log(formData)
    axios.post(`${import.meta.env.VITE_API}api/ChatHub`,Image,headers).then((res)=>{
        console.log(res)
      })
}