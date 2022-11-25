import axios from 'axios'

export const UploadChat = async (connection,chat) => {
    const RoomId = localStorage.getItem('roomId')
    try{
        let response = await axios.post(`${import.meta.env.VITE_API}Chats`,{
            roomId: RoomId
        })
        UploadMessages( response.data,chat)
    }
    catch(error){
        console.log(error)
    }
  }

  async function UploadMessages(chat,messages){
    console.log(chat)
    console.log(messages)
  }

