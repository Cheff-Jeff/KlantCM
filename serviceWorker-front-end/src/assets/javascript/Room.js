import axios from "axios";

export async function GetMaxRoomId() {
    let Roomid = null;
    await axios.get('https://i492404.luna.fhict.nl/Room/Max').then((res)=>{
        console.log(res)
        Roomid = res.data + 1
    })
    return Roomid
}

export async function UploadRoom(){
    const u = JSON.parse(sessionStorage.getItem('user'))
    if(u == null){
        return
    }

    await axios.post('https://i492404.luna.fhict.nl/Room',{
        UserID: u.userId,
        User: null
    }).then((res)=>{
        console.log(res)
    })
}
