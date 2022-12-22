<script setup>
  import { UpdateUser } from '../assets/javascript/User';
  import { getLang } from '@/assets/javascript/translate';
  import { ref } from 'vue';
  import {
    validateName, validateEmail, validateId, 
    errNameEmp, errName, errEmailEmp, errEmail, errId
  } from "@/assets/javascript/validate";

  defineProps({
    User: {
      required: true,
    },
  });
  const text = ref(null);
  text.value = getLang();
  defineExpose({text})
</script>

<template>
  <div class="container">
    <h1>{{text.Account.Title}}</h1>              
    <div class="color-black">
      <div id="myname">{{text.Account.Name}}</div>
      <div id="myemail">{{text.Account.Email}}</div>
    </div>
    <div class="editBtn"><button @click="openEdit()"><img src="../assets/Images/editIcon.png" alt=""></button></div>
  </div>
  <div class="formPopup" id="editForm" style="display: none;">
    <div class="form-wrapper">
      <div class="row">
        <div class="col-m-12">
          <div class="title-wrap">
            <h2>{{text.Account.Edit}}</h2>
          </div>
        </div>
      </div>
      <div class="user-form">
        <form @submit.prevent="editUser()">
          <div class="input-wrap">
            <input type="text" name="name" id="name" placeholder="Name" v-model="user.userName" @blur="checkName" @keyup="checkName">
            <div class="error">
              <span class="small">{{nameError}}</span>
            </div>
          </div>
          <div class="input-wrap">
            <input type="password" name="password" id="password" placeholder="New password" v-model="user.password" @blur="checkPass" @keyup="checkPass">
            <div class="error">
              <span class="small">
                {{passwordError}}
              </span>
            </div>
          </div>
          <div class="input-wrap">
            <input type="password" name="repassword" id="repassword" placeholder="Repeat new password" v-model="this.repass" @blur="checkRePass" @keyup="checkRePass">

            <div class="error">
              <span class="small">
                {{matchPassErr}}
              </span>
            </div>
          </div>
          
          <div class="error">
            <span class="small">
              {{submitError}}
            </span>
          </div>
          <div class="btn-row">
            <div class="row justify-content-center">
              <div class="col-md-6">
                <div class="btn-save d-flex justify-content-center">
                  <button class="btn btn-cta medium" type="submit">
                    {{text.Account.Confirm}}
                  </button>
                </div>
              </div>
            </div>
          </div>
        </form>
      </div>
    </div>
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
      document.getElementById("myname").innerHTML += ": <b>" + this.user.userName + "</b>"
      document.getElementById("myemail").innerHTML += ": <b>" + this.user.email + "</b>"
    },
    openEdit() {
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
          document.getElementById("editForm").style.display = "none"
        }
        else{
          this.submitError = 'One or more fields have an error. Please check and try again.'
        }
      }
    }
  }
}
</script>

<style lang="scss" >
@import "../assets/styles/components/MyProfile.scss";
</style>