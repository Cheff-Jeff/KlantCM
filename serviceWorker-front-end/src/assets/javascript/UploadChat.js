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

  async function UploadMessages(chatobj,messages){
    try{
        console.log(messages)
        messages.forEach(message => {
                axios.post(`${import.meta.env.VITE_API}Messages`,{
                text: message.Text,
                chatId: chatobj.chatId
            })
        });
    }
    catch(err){
        console.log(err)
    }
  }

