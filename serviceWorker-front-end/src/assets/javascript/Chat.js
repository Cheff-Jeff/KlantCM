import { HubConnectionBuilder } from "@microsoft/signalr"
import {createPost} from './MessageReceiver2';

export class ChatHub {
    constructor(){
        console.log("in hub")
        this.connection = new HubConnectionBuilder().withUrl("https://localhost:44302/signalr").build()
        

        this.connection.onclose(async () => {
            await this.connect();
        })

        this.connect()

        this.connection.on("ReceiveMessageWorker", function (message, connection) {
            //Here we have to input revieved message in correct chat

            localStorage.setItem('NewChat',message)
            localStorage.setItem('FormUser',connection)
            window.dispatchEvent(NewChat)
        });

        this.connection.on("ReceiveRoomId", function (message) {
                this.RoomId = message
                localStorage.setItem('roomId', this.RoomId)
                console.log(message)
        });

        this.connection.on("RecieveEndUserId", function (message) {
            ///Event to get message 
            ///here you get the connection id of the end user
            localStorage.setItem('User', message) // here for demostation 
            console.log(message)
            window.dispatchEvent(NewUser)
        });

        const NewChat = new Event('NewChat')
        const NewUser = new Event('NewUser')
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
        if(this.connection.state != 'Connected'){
            this.connect()
        }
        this.connection.invoke("StartRoom",id, FirstName).catch(function (err) {
            return console.error(err)
        }
    )
    }


}