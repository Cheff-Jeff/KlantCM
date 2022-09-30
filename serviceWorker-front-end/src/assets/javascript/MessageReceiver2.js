import axios from "axios";

export const createPost = function(Id, message){
    const Post = {Id, message}
    const Json = JSON.stringify(Post)
    console.log(Json);
        // .post('', Json)
}
