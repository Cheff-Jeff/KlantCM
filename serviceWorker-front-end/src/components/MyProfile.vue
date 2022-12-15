<script setup>
import { UpdateUser } from '../assets/javascript/User';

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
    <div class="editBtn"><button @click="openEdit()"><img src="../assets/Images/editIcon.png" alt=""></button></div>
  </div>
  <div class="formPopup" id="editForm" style="display: none;">
    <h3>Edit my account</h3>
    <form @submit="editUser()">
      <input type="text" name="name" id="name" placeholder="Name" :value="user.userName">
      <input type="email" name="email" id="email" placeholder="Email" :value="user.email">
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
    console.log(this.user)
  },
  methods: {
    openEdit() {
    var formDisplay = document.getElementById("editForm").style.display
    if(formDisplay == "none") {
      document.getElementById("editForm").style.display = "block"
    }
    else {
      document.getElementById("editForm").style.display = "none"
    }
      // document.getElementById("editForm").style.display = "block"
    },
    editUser() {
      this.user.userName = document.getElementById("name").value
      this.user.email = document.getElementById("email").value
      UpdateUser(this.user)
    }
  }
}
</script>

<style lang="scss" >
@import "../assets/styles/components/MyProfile.scss";
</style>