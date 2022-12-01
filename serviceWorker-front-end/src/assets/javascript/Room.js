import axios from "axios";

export async function GetMaxRoomId() {
    let Roomid = null;
    await axios.get('https://localhost:7117/Room/Max').then((res)=>{
        console.log(res)
        Roomid = res.data + 1
    })
    return Roomid
}

export async function UploadRoom(){
    const u = localStorage.getItem('user')
    console.log(u)
    if(u == null){
        return
    }

    await axios.post('https://localhost:7117/Room',{
        UserID: u,
        User: null
    }).then((res)=>{
        console.log(res)
    })
}
