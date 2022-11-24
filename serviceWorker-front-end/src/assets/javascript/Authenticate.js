import axios from 'axios'

export const Login = async (email, password) => {
  try{
    let response = await axios.post(`${import.meta.env.VITE_API}Auth/login` ,{
    Email: email,
    Password: password
  })

    localStorage.setItem('user', JSON.stringify((await response).data))
    return true
  }
  catch(error){
    console.log(error)
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
  console.log(user)
  if(user !== null){
    return true
  }
  else{
    return false
  }
}

export const RouteGaurdAdmin = async () =>{
  const userid = JSON.parse(localStorage.getItem('user'));
  if(userid == null){
    return false;
  }
  
  const user = await GetUserById(userid)
  if(user[0].isAdmin){
    return true
  }
  else{
    return false
  }
}

export const Register = async (username, email, password) => {
  const isadmin = false;
  await axios.post(`${import.meta.env.VITE_API}Auth/register` ,{
    userName: username,
    Email: email,
    isAdmin: isadmin,
    Password: password
  })
}

export const DoubleEmail = async (email) => {
  let response = await axios.post(`${import.meta.env.VITE_API}doubleemail?email=${email}`) //, {
  return response.data;
  //   Email: email,
  // })
}

export const GetUserById = async (id) => {
  try{
      let response = await axios.get(`${import.meta.env.VITE_API}Auth/getuser?id=${id}`)
      return response.data
  }
  catch(error){
      console.log(error)
  }
}