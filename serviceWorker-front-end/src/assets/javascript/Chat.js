import { HubConnectionBuilder } from "@microsoft/signalr"
// import {createPost} from './MessageReceiver2';

export class ChatHub {
    constructor(){
        //signalr runnen met docker = http://localhost:8000/signalr
        this.connection = new HubConnectionBuilder().withUrl("https://localhost:44302/signalr").build()
        

        this.connection.onclose(async () => {
            await this.connect();
        })

        this.connect()

        this.connection.on("ReceiveMessageWorker", function (message, connection) {
            //Here we have to input revieved message in correct chat

            localStorage.setItem('NewChat',message)
            localStorage.setItem('FromUser',connection)
            window.dispatchEvent(NewChat)
        });

        this.connection.on("ReceiveRoomId", function (message) {
                this.RoomId = message
                localStorage.setItem('roomId', this.RoomId)
        });

        this.connection.on("RecieveEndUserId", function (message) {
            ///Event to get message 
            ///here you get the connection id of the end user
            localStorage.setItem('User', message)
            window.dispatchEvent(NewUser)
            window.AddSuccessNotification('Added new client')
        });

        this.connection.on("DisconnectUser", function (message) {
            // user has to get disconnected from the chatwindow  
            localStorage.setItem('DiscUser',message)
            window.dispatchEvent(DisconnectUser)
         });

         this.connection.on("StopRoom", function () {
            // user has to get disconnected from the chatwindow  
            window.dispatchEvent(StopRoom)
         });

        const NewChat = new Event('NewChat')
        const NewUser = new Event('NewUser')
        const DisconnectUser = new Event('DisconnectUser')
        const StopRoom = new Event('StopRoom')
    }

    async connect(){
        try {
            await this.connection.start();
            console.log("SignalR Connected.");
        } catch (err) {
            console.log(err);
        }  
    }

    SendMessage(message,connection){
        // this.connection.invoke("SendMessage", message,RoomId,EndUser).catch(function (err) {
        //     return console.error(err.toString())
        // })
            let roomid = localStorage.getItem('roomId')
            this.connection.invoke("SendMessage", message,roomid,connection).catch(function (err) {
            return console.error(err.toString())
         })
    }

    AddUser(){
        let RoomId = localStorage.getItem('roomId')
        this.connection.invoke("AddEndUserToRoom",RoomId).catch(function (err) {
            return console.error(err.toString())
        }
        )
    }
    StartRoom(id,FirstName){
        this.connection.invoke("StartRoom",id, FirstName).catch(function (err) {
            return console.error(err)
        })
    }
    StopRoom(UserConnection){
        let RoomId = localStorage.getItem('roomId')
        this.connection.invoke("StopChat",UserConnection,RoomId).catch((err)=>{
             return console.error(err.toString())
        })
    }
    OpenWorker(){
        let RoomId = localStorage.getItem('roomId')
        this.connection.invoke("OpenWorker",RoomId).catch((err)=>{
            return console.error(err.toString())
        })
    }
    CloseWorker(){
        let RoomId = localStorage.getItem('roomId')
        this.connection.invoke("CloseWorker",RoomId).catch((err)=>{
            return console.error(err.toString())
        })
    }
}