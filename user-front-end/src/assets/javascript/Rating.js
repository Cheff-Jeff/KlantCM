import axios from "axios";

export const GiveRating = async(Rating, roomID) =>{
    try{
         await axios.post('https://localhost:7117/Rating/giveRating', {
            rating: Rating,
            roomId: roomID

        })
    }
    catch(error){
        console.log(error)
    }
}