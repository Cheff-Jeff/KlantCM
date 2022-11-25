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
  <div class="spacer">
    <div class="container">
      <div class="form-wrapper">
        <div class="row">
          <div class="col-m-12">
            <div class="title-wrap">
              <h2>Edit {{User.userName}}</h2>
            </div>
          </div>
        </div>
        <div class="user-form">
          <form @submit.prevent="submit">
            <input type="hidden" v-model="user.id">
            <input type="hidden" v-model="user.isAdmin">
            <div class="input-wrap">
              <input 
                type="text" 
                placeholder="Name"
                v-model="user.userName"
                @blur="checkName"
                @keyup="checkName" 
              >
              {{nameError}}
            </div>
            <div class="input-wrap">
              <input 
                type="email" 
                placeholder="Email"
                v-model="user.email" 
                @blur="checkEmail"
                @keyup="checkEmail"
              >
              {{emailError}}
            </div>
            <div class="input-wrap">
              <input 
                type="password" 
                placeholder="New password" 
                v-model="user.password"
                @blur="checkPass"
                @keyup="checkPass"
              >
              {{passwordError}}
            </div>
            <div class="input-wrap">
              <input 
                type="password" 
                placeholder="Repeat new password" 
                v-model="repass"
                @blur="checkRePass"
                @keyup="checkRePass"
              >
              {{matchPassErr}}
            </div>
            <div class="row">
              <div class="col-md-6">
                <cm-button
                  @click.prevent="cancel"
                  data-label="Cancel"
                  data-button-style="primary"
                  data-button-size="medium">
                </cm-button>
              </div>
              <div class="col-md-6">
                <cm-button
                  data-label="Save"
                  data-button-style="cta"
                  data-button-size="medium">
                </cm-button>
              </div>
            </div>
          </form>
        </div>
      </div>
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
      repass: '',
      nameError: '',
      emailError: '',
      idError: '',
      passwordError: '',
      matchPassErr: '',
      submitError: ''
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
    checkPass(){
      this.passwordError = this.user.password != '' ? (
        this.user.password.length < 8 ? 'Password must be at least 8 characters long.': ''
      ) : ''
    },
    checkRePass(){
      this.matchPassErr = this.repass == this.user.password ? '' : 'Password must match.'
    },
    cancel(){
      this.$emit('switch')
    },
    async submit(){
      this.checkName(); this.checkEmail; this.checkId; this.checkPass; this.checkRePass;
      if(this.nameError = '', this.emailError = '', this.idError = '', 
      this.passwordError, this.matchPassErr)
      {
        const result = await UpdateUser(this.user)
        if(result.status == 200){
          this.$router.go()
        }
        submitError = 'One or more fields have an error. Please check and try again.'
      }
    },
  },
}
</script>

<style lang="scss" scoped>
@import "../assets/styles/components/updateUser.scss";
</style>