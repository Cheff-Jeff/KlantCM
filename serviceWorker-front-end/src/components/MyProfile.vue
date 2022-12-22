<script setup>
  import { UpdateUser } from '../assets/javascript/User';
  import {
    validateName, validateEmail, validateId, 
    errNameEmp, errName, errEmailEmp, errEmail, errId
  } from "@/assets/javascript/validate";

  defineProps({
    User: {
      required: true,
    },
  });
</script>

<template>
  <div class="container">
    <h1>My account</h1>              
    <div class="color-black">
      <div id="myname"></div>
      <div id="myemail"></div>
    </div>
    <div class="editBtn"><button @click="openEdit()"><img src="../assets/Images/editIcon.png" alt=""></button></div>
  </div>
  <div class="formPopup" id="editForm" style="display: none;">
    <h3>Edit my account</h3>
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
      <button type="submit">Confirm</button>
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
      document.getElementById("myname").innerHTML = "Name: <b>" + this.user.userName + "</b>"
      document.getElementById("myemail").innerHTML = "Email: <b>" + this.user.email + "</b>"
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
        this.user.password.length < 8 ? 'Password must be at least 8 characters long.': ''
      ) : ''
    },
    checkRePass(){
      this.matchPassErr = this.repass == this.user.password ? '' : 'Password must match.'
    },
    async editUser(){
      console.log('submit')
      this.checkName(); this.checkPass; this.checkRePass;
      if(this.nameError == '' && this.passwordError == '' && this.matchPassErr == '')
      {
        const result = await UpdateUser(this.user)
        if(result.status == 200){
          this.submitError = 'Your account has been updated!'
        }
        else{
          submitError = 'One or more fields have an error. Please check and try again.'
        }
      }
    }
  }
}
</script>

<style lang="scss" >
@import "../assets/styles/components/MyProfile.scss";
</style>