import axios from "axios"

export const ratingUpload = (ratingUser)=>{
    let roomid = sessionStorage.getItem ('roomId')
    axios.post('https://i492404.luna.fhict.nl/Rating/giveRating',{
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