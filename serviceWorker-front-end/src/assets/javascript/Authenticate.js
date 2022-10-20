import axios from 'axios'
import {HashPassword} from "./passwordHash";

export const Login = async (email, password) => {
  axios.post(`https://localhost:7117/Auth/login` ,{
    Email: email,
    Password: password
  })
  //.then(response => {
  //  console.log(response);
  //})


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
  var username = "admin";
  var email = "admin@example.com"
  var password = "admin123";
  var isadmin = true;

  axios.post(`https://localhost:7117/Auth/register` ,{
    userName: username,
    Email: email,
    isAdmin: isadmin,
    Password: password
  })
  //.then(response => {
  //  console.log(response);
  //})
}