import axios from 'axios'

export const UpdateUser = async(user) => {
    try {
        let result
        await axios({
            headers: { 'Content-Type': 'application/json' },
            method: 'put',
            url: `${import.meta.env.VITE_API}User/edituser`,
            data: JSON.stringify(user)
        }).then((response) => {
            result = response;
        }).catch((error) => {
            console.log(error)
        })
        return result
    } catch (error) {
        console.log(error)
    }
}

export const GetAllUsers = async() => {
    try {
        let response = await axios.get(`${import.meta.env.VITE_API}User/getallusers`)
        return response.data
    } catch (error) {
        console.log(error)
    }
}

export const DeleteUser = async(id) => {
    try {
        let response = await axios.delete(`https://localhost:7117/User/deleteuser?id=${id}`)
        return response
    } catch (error) {
        console.log(error)
    }
}

export const GetUserById = async(id) => {
    try {
        let response = await axios.get(`${import.meta.env.VITE_API}User/getuser?id=${id}`)
        return response.data
    } catch (error) {
        console.log(error)
    }
}