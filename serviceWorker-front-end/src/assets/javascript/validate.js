const reName = /^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]*$/;
const reEmail = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
const reId = /^[0-9]*$/;

//validation
export const validateName = (name) => {
  return reName.test(name);
}
export const validateEmail = (email) => {
  return reEmail.test(email);
}
export const validateId = (id) => {
  return reId.test(id);
}

//errors
export const errNameEmp = () => { return 'Name can not be empty.' }
export const errName = (e) => { return `${e} is not a name.` }
export const errEmailEmp = () => { return 'Email can not be empty.' }
export const errEmail = (e) => { return `${e} is not an email.` }
export const errId = () => { return 'There was a problem with 1 of the values.'}