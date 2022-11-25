import axios from 'axios'

export const UpdateUser = async (user) => {
    try {
        const response = await axios.put(``)
    } catch (error) {
        console.log(error)
    }
}

export const GetAllUsers = async () => {
    try{
        let response = await axios.get('https://localhost:7117/User/getallusers')
        return response.data
    }
    catch(error){
        console.log(error)
    }
  }

export const DeleteUser = async (id) => {
    try {
        let response = await axios.delete(`https://localhost:7117/User/deleteuser?id=${id}`)
        return response
    } catch (error) {
        console.log(error)
    }
}