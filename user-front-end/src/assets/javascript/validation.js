const reName = /^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]*$/;
const reEmail = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
const reTitle = /^[a-zA-Z0-9_ #--():]*$/;
const reDescription = /^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-?!"()#&+—’”“]*$/;
const reId = /^[0-9]*$/;
const extentions = ["png","jpg","jpeg","webp"]

//validation
export const validateName = (name) => {
  return reName.test(name);
}
export const validateTitle = (title) => {
  return reTitle.test(title);
}
export const validateEmail = (email) => {
  return reEmail.test(email);
}
export const validateDescription = (description) => {
  return reDescription.test(description);
}
export const validateId = (id) => {
  return reId.test(id);
}
export const validateFile = (file) => {
  for(let ext of extentions){
    if(file == ext)
    {
      return true
      break;
    }
  }
  return false
}
//errors
export const errNameEmp = () => { return 'Name can not be empty.' }
export const errName = (e) => { return `${e} is not a name.` }
export const errTitleEmp = () => { return 'Title can not be empty.' }
export const errTitle = (e) => { return `${e} is not a proper title.` }
export const errEmailEmp = () => { return 'Email can not be empty.' }
export const errEmail = (e) => { return `${e} is not an email.` }
export const errDescriptionEmp = () => { return 'Description can not be empty.' }
export const errDescription = (e) => { return `${e} is not a description.` }
export const errPublicherEmp = () => { return 'Publicher can not be empty.' }
export const errPublicher = (e) => { return `${e} is not a publicher.` }
export const errWriterIdEmp = () => { return 'Please select a writer.' }
export const errWriterId = () => { return `That is not a writer.` }
export const errArtistIdEmp = () => { return 'Please select an artist.' }
export const errArtistId = () => { return `That is not an artist.` }
export const errCoverArtistIdEmp = () => { return 'Please select a cover artist.' }
export const errCoverArtistId = () => { return `That is not a cover artist.` }
export const errPublicherIdEmp = () => { return 'Please select a publicher.' }
export const errPublicherId = () => { return `That is not a publicher.` }
export const errImageEmp = () => { return `Image can not be empty.` }
export const errImage = () => { return `This is not an image.` }