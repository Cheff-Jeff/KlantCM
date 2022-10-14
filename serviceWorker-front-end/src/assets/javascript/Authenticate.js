import axios from 'axios'
import {HashPassword} from "./passwordHash";

export const Login = async (email, password) => {
  const result = await HashPassword(password);
  axios.post(`https://localhost:7117/login?userName=${email}&Password=${result}`)
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