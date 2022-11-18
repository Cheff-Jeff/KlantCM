import axios from 'axios'

export const GetAllUsers = async () => {
    try{
        let response = await axios.get(`${import.meta.env.VITE_API}User/getallusers`)
        return response.data
    }
    catch(error){
        console.log(error)
    }
  }