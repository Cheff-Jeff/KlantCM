import { HubConnectionBuilder } from "@microsoft/signalr"
import { GetMaxRoomId } from "./Room";
import { UploadRoom } from "./Room";
import axios, { Axios } from "axios";
// import {createPost} from './MessageReceiver2';

export class ChatHub {
    constructor(){
        //signalr runnen met docker = http://localhost:8000/signalr
        // https://i483908.luna.fhict.nl/signalr
        this.connection = new HubConnectionBuilder().withUrl(`${import.meta.env.VITE_SIGNALR}signalr`).build()
    
        this.connection.onclose(async () => {
            await this.connect();
        })

        this.connect().then(()=>{
            if(localStorage.getItem('roomId') != null){
                this.connection.invoke("ConnectEmployee",Number(localStorage.getItem('roomId'))).catch((err)=>{
                    console.log(err)
                })
            }
        })



        this.connection.on("ReceiveMessageWorker", function (message, connection) {
            //Here we have to input revieved message in correct chat

            localStorage.setItem('NewChat',message)
            localStorage.setItem('FromUser',connection)
            window.dispatchEvent(NewChat)
        });

        this.connection.on("ReceiveRoomId", function (message) {
                console.log(message)
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

        this.connection.on("GetQueue", function(message) {
            console.log(message)
            sessionStorage.setItem('Queue', message)
            window.dispatchEvent(NewQueue)
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

         this.connection.on("ReceiveMediaWorker", function (message,index) {
            sessionStorage.setItem('MediaFrom',message)
            sessionStorage.setItem('imgIndex',index)
            window.dispatchEvent(NewMedia)
         });


        const NewMedia = new Event("NewMedia")
        const NewChat = new Event('NewChat')    
        const NewUser = new Event('NewUser')
        const DisconnectUser = new Event('DisconnectUser')
        const StopRoom = new Event('StopRoom')
        const NewQueue = new Event('NewQueue')
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
    async StartRoom(id,FirstName){
        const roomid = await GetMaxRoomId()
        this.connection.invoke("StartRoom",id, FirstName,99999).catch(function (err) {
            return console.error(err)
        }).then(UploadRoom())
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

    SendMedia(base64){
        let RoomId = localStorage.getItem('roomId')
        this.connection.invoke("SendMedia",base64,RoomId, null).catch((err)=>{
            return console.error(err.toString())
        })
    }
}