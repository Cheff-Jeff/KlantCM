import axios from 'axios'
import {HashPassword} from "./passwordHash";

export const Login = async (email, password) => {
  axios.post(`https://localhost:7117/login?Email=${email}&Password=${password}`)
  .then(response => {
    console.log(response);
  })


  if(email == 'admin@adminmail.com' && password == 'adminadmin'){
    localStorage.setItem('user', JSON.stringify(user))
    return true
  }
  else{
    console.log('Test')

    return false
  }
}

export const Logout = () => {
  const user = JSON.parse(localStorage.getItem('user'))
  if(user !== null){
    localStorage.removeItem('user');
    return true;
  }
  else{
    return false;
  }
}

export const RouteGaurd = () =>{
  const user = JSON.parse(localStorage.getItem('user'));
  if(user !== null){
    return true
  }
  else{
    return false
  }
}

export const Register = async () => {
  
  var username = "Pietje";
  var email = "test6@example.com"
  var password = "test6";
  var isadmin = false;

  const result = await HashPassword(password);
  console.log("werktie?")
  console.log(result)

  axios.post(`https://localhost:7117/register?userName=${username}&Email=${email}&isAdmin=${isadmin}&passwordHash=${result}`)
  .then(response => {
    console.log(response);
  })
}