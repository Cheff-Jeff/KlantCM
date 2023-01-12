import axios from 'axios'

export const UploadChat = async (connection,chat) => {
    console.log(chat)
    const RoomId = localStorage.getItem('roomId')
    try{
        let response = await axios.post(`${import.meta.env.VITE_API}Chats`,{
            roomId: RoomId
        })
        console.log(response)
        UploadMessages( response.data,chat)
    }
    catch(error){
        console.log(error)
    }
  }

  async function UploadMessages(chatobj,messages){
    console.log(messages)
        for (let index = 0; index < messages.length; index++) {
            await Uploadmessage(chatobj.chatId,messages[index])
        }
  }

  async function Uploadmessage(chatid,message){
   await axios.post(`${import.meta.env.VITE_API}Messages`,{
        text: message.Text,
        chatId: chatid,
        worker: !message.White
    }).then((res)=>{
        console.log(res)
    }).catch((err)=>{
        console.log(err)
    })
  }

  export const deleteImg = async (connection) => {
    axios.delete(`${import.meta.env.VITE_API}api/ChatHub?connection=`+connection).then((res)=>{
        console.log(res)
    })
  }