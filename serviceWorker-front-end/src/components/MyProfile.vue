<script setup>
  import { UpdateUser } from '../assets/javascript/User';
  import {
    validateName, validateEmail, validateId, 
    errNameEmp, errName, errEmailEmp, errEmail, errId
  } from "@/assets/javascript/validate";
import { getLang } from '@/assets/javascript/translate';
import { ref } from 'vue';
const text = ref(null);
text.value = getLang();
defineExpose({text})

  defineProps({
    User: {
      required: true,
    },
  });
</script>

<template>
  <div class="container">
    <h1>{{text.MyProfile.MyAcc}}</h1>              
    <div class="color-black">
      <div id="myname">{{text.MyProfile.Name}}:</div>
      <div id="myemail">{{text.MyProfile.Email}}:</div>
    </div>
    <div class="editBtn"><button @click="openEdit()"><img src="../assets/Images/editIcon.png" alt=""></button></div>
  </div>
  <div class="formPopup" id="editForm" style="display: none;">
    <h3>{{text.Edit.Heading}}</h3>
    <form @submit="editUser()">
      <input type="text" name="name" id="name" :placeholder="text.Edit.form.name" v-model="user.userName" @blur="checkName" @keyup="checkName">
      <div class="error">
        <span class="small">{{nameError}}</span>
      </div>
      <input type="password" name="password" id="password" :placeholder="text.Edit.form.pass" v-model="user.password" @blur="checkPass" @keyup="checkPass">
      <div class="error">
        <span class="small">
          {{passwordError}}
        </span>
      </div>
      <input type="password" name="repassword" id="repassword" :placeholder="text.Edit.form.rePass" v-model="this.repass" @blur="checkRePass" @keyup="checkRePass">
      <div class="error">
        <span class="small">
          {{matchPassErr}}
        </span>
      </div>
      <button type="submit">{{text.Edit.form.btn}}</button>
    </form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      user: {
        id: this.User.userId,
        userName: this.User.userName,
        email: this.User.email,
        password: '',
        isAdmin: this.User.isAdmin
      },
      repass: '',
      nameError: '',
      emailError: '',
      idError: '',
      passwordError: '',
      matchPassErr: '',
      submitError: ''
    }
  },
  mounted() {
    this.fillDetails()
  },
  methods: {
    fillDetails() {
      document.getElementById("myname").innerHTML += " <b>" + this.user.userName + "</b>"
      document.getElementById("myemail").innerHTML += " <b>" + this.user.email + "</b>"
    },
    openEdit() {
      // this.nameError = "hallo"

      var formDisplay = document.getElementById("editForm").style.display
      if(formDisplay == "none") {
        document.getElementById("editForm").style.display = "block"
      }
      else {
        document.getElementById("editForm").style.display = "none"


      }
    },
    checkName(){
      this.nameError = this.user.userName == '' ? errNameEmp() : (
        validateName(this.user.userName) ? '' : errName(this.user.userName)
      )
    },
    checkPass(){
      this.passwordError = this.user.password != '' ? (
        this.user.password.length < 8 ? this.text.Edit.form.errors.errPass: ''
      ) : ''
    },
    checkRePass(){
      this.matchPassErr = this.repass == this.user.password ? '' : this.text.Edit.form.errors.errRePass
    },
    async editUser(){
      console.log('submit')
      this.checkName(); this.checkPass; this.checkRePass;
      if(this.nameError == '' && this.passwordError == '' && this.matchPassErr == '')
      {
        const result = await UpdateUser(this.user)
        if(result.status == 200){
          this.submitError = this.text.Edit.form.errors.success
        }
        else{
          submitError = this.text.Edit.form.errors.err
        }
      }
    }
  }
}
</script>

<style lang="scss" >
@import "../assets/styles/components/MyProfile.scss";
</style>