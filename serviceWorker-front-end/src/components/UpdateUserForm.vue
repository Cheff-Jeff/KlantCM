<script setup>
  import {UpdateUser} from "@/assets/javascript/User";
  import {
    validateName, validateEmail, validateId,
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
  <div class="spacer">
    <div class="container">
      <div class="form-wrapper">
        <div class="row">
          <div class="col-m-12">
            <div class="title-wrap">
              <h2>{{text.Edit.Heading}} {{User.userName}}</h2>
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
                :placeholder="text.Edit.form.name"
                v-model="user.userName"
                @blur="checkName"
                @keyup="checkName" 
              >
              <div class="error">
                <span class="small">{{nameError}}</span>
              </div>
            </div>
            <div class="input-wrap">
              <input 
                type="email" 
                :placeholder="text.Edit.form.email"
                v-model="user.email" 
                @blur="checkEmail"
                @keyup="checkEmail"
              >
              <div class="error">
                <span class="small">
                  {{emailError}}
                </span>
              </div>
            </div>
            <div class="input-wrap">
              <input 
                type="password" 
                :placeholder="text.Edit.form.pass" 
                v-model="user.password"
                @blur="checkPass"
                @keyup="checkPass"
              >
              <div class="error">
                <span class="small">
                  {{passwordError}}
                </span>
              </div>
            </div>
            <div class="input-wrap">
              <input 
                type="password" 
                :placeholder="text.Edit.form.rePass" 
                v-model="repass"
                @blur="checkRePass"
                @keyup="checkRePass"
              >
              <div class="error">
                <span class="small">
                  {{matchPassErr}}
                </span>
              </div>
            </div>
            <div class="btn-row">
              <div class="row">
                <div class="col-md-6">
                  <button class="btn btn-primary medium" @click.prevent="cancel">
                    {{text.Edit.form.cancel}}
                  </button>
                </div>
                <div class="col-md-6">
                  <div class="btn-save">
                    <button class="btn btn-cta medium">
                      {{text.Edit.form.btn}}
                    </button>
                  </div>
                </div>
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
      this.nameError = this.user.userName == '' ? text.Edit.form.errors.emptyName : (
        validateName(this.user.userName) ? '' : this.user.userName + text.Edit.form.errors.errName
      )
    },
    checkEmail(){
      this.emailError = this.user.email == '' ? text.Edit.form.errors.epmtyEmail : (
        validateEmail(this.user.email) ? '' : this.user.email + text.Edit.form.errors.errEmail
      )
    },
    checkId(){
      this.idError = this.user.id == '' ? text.Edit.form.errors.errId : (
        validateId(this.user.id) ? '' : text.Edit.form.errors.errId
      )
    },
    checkPass(){
      this.passwordError = this.user.password != '' ? (
        this.user.password.length < 8 ? text.Edit.form.errors.errPass: ''
      ) : ''
    },
    checkRePass(){
      this.matchPassErr = this.repass == this.user.password ? '' : text.Edit.form.errors.errRePass
    },
    cancel(){
      this.$emit('switch')
    },
    async submit(){
      this.checkName(); this.checkEmail; this.checkId; this.checkPass; this.checkRePass;
      if(this.nameError == '' && this.emailError == '' && this.idError == '' && 
      this.passwordError == ''&& this.matchPassErr == '')
      {
        const result = await UpdateUser(this.user)
        if(result.status == 200){
          this.$router.go()
        }
        else{
          submitError = text.Edit.form.errors.err
        }
      }
    },
  },
}
</script>

<style lang="scss" >
@import "../assets/styles/components/updateUser.scss";
</style>