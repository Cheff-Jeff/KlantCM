export const Login = (email, password) => {
  const user = {
    id: 1,
    isAdmin: true
  }

  if(email == 'admin@adminmail.com' && password == 'adminadmin'){
    localStorage.setItem('user', JSON.stringify(user))
    return true
  }
  else{
    console.log('Test')

    return false
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