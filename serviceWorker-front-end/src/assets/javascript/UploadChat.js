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
    let mesText = imgOrtext(message)
    console.log(mesText)
   await axios.post(`${import.meta.env.VITE_API}Messages`,{
        text: mesText,
        chatId: chatid,
        worker: !message.White
    }).then((res)=>{
        console.log(res)
    }).catch((err)=>{
        console.log(err)
    })
  }

  function imgOrtext(message){
    let mesText = ''
    if(message.hasOwnProperty('Img')){
        console.log('avg')
        return mesText = message.Img
    }else{
        return mesText = message.Text
    }
  }

  export const deleteImg = async (connection) => {
    axios.delete("https://localhost:44302/api/ChatHub").then((res)=>{
        console.log(res)
    })
  }