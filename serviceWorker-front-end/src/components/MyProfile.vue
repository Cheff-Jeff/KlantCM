<script setup>
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
      Name: {{user.userName}}
      <br>
      Email: {{user.email}}
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
  mounted() {
    console.log(this.user)
  },
  methods: {
    
  },
}
</script>

<style lang="scss" >
@import "../assets/styles/components/MyProfile.scss";
</style>