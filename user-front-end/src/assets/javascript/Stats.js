import axios from "axios"

export const ratingUpload = (ratingUser)=>{
    let roomid = sessionStorage.getItem ('roomId')
    axios.post('https://localhost:7117/Rating/giveRating',{
        rating : ratingUser,
        roomId : roomid
    }).catch((err)=>{
        console.log(err)
    }).then((res)=>{
        console.log(res)
    })
    
}

export const queueTimer = (time)=>{
    
}