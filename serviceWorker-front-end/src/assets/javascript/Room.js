import axios from "axios";

export function GetMaxRoomId() {

    axios.get('https://localhost:7117/Room/Max').then((res)=>{
        return res.data
    })
}

export function UploadRoom(RoomId){
    
}