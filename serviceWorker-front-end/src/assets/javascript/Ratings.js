import axios from 'axios'
import { ref } from 'vue'

export const GetAllRatings = async() => {
    const result = ref(null)
    try {
        await axios.get(`${import.meta.env.VITE_API}Rating/getallratings`).then((res) => {
            result.value = res.data
        })

        return result.value

    } catch (error) {
        console.log(error)
    }
}