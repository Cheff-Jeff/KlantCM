<template>
  <form @submit.prevent="submit">
    <div class="row">
        <div class="col-md-12" v-if="registerError">
        <span class="small text-danger">
            {{registerError}}
        </span>
        </div> 
    </div>
  </form>



</template>

<script>
export default {
data(){
    return{
        userName:'',
        email:'',
        password:'',
        repassword:'',
        registerError:'',
        emailError:'',
        passwordError:'',
        passwordValidationError:''

    }
},
methods:{
    checkEmail() {
      this.emailError = this.email.length == 0 ? 'Email can not be empty.' 
      : (this.validateEmail(this.email) ? '' : this.email + ' is not an email.')
    },
    validateEmail(email) {
      const re = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
      return re.test(email);
    },
    checkPassword() {
      this.passwordError = this.password.length == 0 ? 'Password can not be empty.' : ''
    },
    checkPasswordValidation(){
        this.loginError = this.loginError.length > 0 ? '' : ''
        this.passwordValidationError = this.password == this.repassword ? '' : 'Passwords do not match.'
    },
    submit(){
        this.checkEmail();
        this.checkPassword();
        this.checkPasswordValidation();
        if(this.emailError == '' && this.passwordError == '' && this.passwordValidationError == ''){

        }
        else{
            
        }
        
    }
}
}
</script>

<style>

</style>