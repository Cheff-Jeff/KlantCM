import axios from "axios";

export async function GetMaxRoomId() {
    let Roomid = null;
    await axios.get('https://localhost:7117/Room/Max').then((res)=>{
        console.log(res)
        Roomid = res.data
    })
    return Roomid
}

export async function UploadRoom(roomId){
    const u = localStorage.getItem('user')
    console.log(u)
    if(u == null){
        return
    }
    const user = await Getuser(u) 
    console.log(user)
    console.log(user[0])
    if(user == null){
        return
    }

    await axios.post('https://localhost:7117/Room',{
        RoomId: roomId,
        UserID: u,
        User: user[0]
    }).then((res)=>{
        console.log(res)
    })
}

async function Getuser(UserId){
    let User = null
    await axios.get('https://localhost:7117/User/getuser', {params:{id:UserId}}).then((res)=>{
        User =  res.data
    })
    return User 
}