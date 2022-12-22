import { getLang } from '@/assets/javascript/translate';
import { ref } from 'vue';
import { defineExpose } from 'vue';

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
export const errNameEmp = () => {
    const text = ref(null);
    text.value = getLang();
    defineExpose({ text })
    return text._value.Edit.form.errors.emptyName
}
export const errName = (e) => {
    const text = ref(null);
    text.value = getLang();
    defineExpose({ text })
    return text._value.Edit.form.errors.errName
}
export const errEmailEmp = () => {
    const text = ref(null);
    text.value = getLang();
    defineExpose({ text })
    return text._value.Edit.form.errors.emptyEmail
}
export const errEmail = (e) => {
    const text = ref(null);
    text.value = getLang();
    defineExpose({ text })
    return text._value.Edit.form.errors.errEmail
}
export const errId = () => {
    const text = ref(null);
    text.value = getLang();
    defineExpose({ text })
    return text._value.Edit.form.errors.errId
}