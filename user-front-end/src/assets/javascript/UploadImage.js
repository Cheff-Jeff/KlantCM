import axios from "axios";

export const PostFormdata = async (Image) => {
    let connectionid = sessionStorage.getItem('connectionId')
    if (connectionid != null){
        let Form = {
            file: Image,
        }
        await axios({
            headers: { 'Content-type': 'multipart/form-data'},
            method: 'post',
            url:`${import.meta.env.VITE_API}api/ChatHub?connectionid=`+ connectionid,
            data: Form
        }).then((res)=>{
            console.log(res)
        })
}
return true
}