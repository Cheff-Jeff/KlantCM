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
        messages.forEach(async message => {
            await Uploadmessage(chatobj.chatId,message)
        });
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

