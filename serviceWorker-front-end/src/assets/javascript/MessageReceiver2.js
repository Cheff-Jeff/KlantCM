import axios from "axios";
import * as signalR from '@microsoft/signalr'


export const createPost = function(Id, message){
    const Post = {Id, message}
    const Json = JSON.stringify(Post)
    console.log(Json);
        // .post('', Json)
}
