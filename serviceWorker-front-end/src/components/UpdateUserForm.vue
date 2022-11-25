<script setup>
  import {UpdateUser} from "@/assets/javascript/User";
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
    <div class="row">
      <div class="col-m-12">
        <h2>Edit {{User.userName}}</h2>
      </div>
    </div>
    <div class="user-form">
      <form @submit.prevent="submit">
        <input 
          type="hidden" 
          v-model="user.id"
          @blur="checkName"
          @keyup="checkName"
        >
        <input type="hidden" v-model="user.isAdmin">
        <input type="text" v-model="user.userName" placeholder="Name">
        <input type="email" v-model="user.email" placeholder="Email">
        <input type="password" placeholder="New password">
        <input type="password" placeholder="Repeat new password">
        <cm-button
          @click.prevent="Test"
          data-label="Cancel"
          data-button-style="primary"
          data-button-size="medium">
        </cm-button>
        <cm-button
          data-label="Save"
          data-button-style="cta"
          data-button-size="medium">
        </cm-button>
      </form>
    </div>
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
      nameError: '',
      emailError: '',
      idError: '',
    }
  },
  methods: {
    checkName(){
      this.nameError = this.user.userName == '' ? errNameEmp() : (
        validateName(this.user.userName) ? '' : errName(this.user.userName)
      )
    },
    checkEmail(){
      this.emailError = this.user.email == '' ? errEmailEmp() : (
        validateEmail(this.user.email) ? '' : errEmail(this.user.email)
      )
    },
    checkId(){
      this.idError = this.user.id == '' ? errId() : (
        validateId(this.user.id) ? '' : errId()
      )
    },
    async submit(){
      // let res = await UpdateUser(this.user)
      // console.log(this.user)
    },
    Test(){
      this.$emit('switch')
    },
  },
}
</script>