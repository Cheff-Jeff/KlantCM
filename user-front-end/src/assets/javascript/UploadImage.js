import axios from "axios";

export const PostFormdata = (Image) => {
    const headers = {
        'Content-Type': 'multipart/form-data'
      }
    let formData = new FormData();
    console.log(Image)
    formData.append('image', Image);
    axios.post(`${import.meta.env.VITE_API}api/ChatHub`,formData,headers).then((res)=>{
        console.log(res)
      })
}