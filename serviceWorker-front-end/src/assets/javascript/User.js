import axios from 'axios'

export const GetAllUsers = async () => {
    try{
        let response = await axios.get('https://localhost:7117/User/getallusers')
        return response.data
    }
    catch(error){
        console.log(error)
    }
  }