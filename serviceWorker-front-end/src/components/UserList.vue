<script setup>
import { remove } from '@vue/shared';
import { DeleteUser } from '../assets/javascript/User';
import { getLang } from '@/assets/javascript/translate';
import { ref } from 'vue';
const text = ref(null);
text.value = getLang();
defineExpose({text})
</script>

<template>
<div class="container">
    <table class="table table-striped table-hover pt-5">
        <thead>
            <tr>
                <th>{{text.UserList.Username}}</th>
                <th>{{text.UserList.Email}}</th>
                <th>{{text.UserList.Administrator}}</th>
                <th/>
                <th/>
                <th/>
            </tr>
        </thead>
        <tbody>
            <tr v-for="user in userlist" :key="user.userId">
                <td>{{user.userName}}</td>
                <td>{{user.email}}</td>
                <td>{{user.isAdmin}}</td>
                <td><a href="#"><svg class="icon info" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512"><!--! Font Awesome Pro 6.2.1 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2022 Fonticons, Inc. --><path d="M256 512c141.4 0 256-114.6 256-256S397.4 0 256 0S0 114.6 0 256S114.6 512 256 512zM216 336h24V272H216c-13.3 0-24-10.7-24-24s10.7-24 24-24h48c13.3 0 24 10.7 24 24v88h8c13.3 0 24 10.7 24 24s-10.7 24-24 24H216c-13.3 0-24-10.7-24-24s10.7-24 24-24zm40-144c-17.7 0-32-14.3-32-32s14.3-32 32-32s32 14.3 32 32s-14.3 32-32 32z"/></svg></a></td>
                <td><a @click="EditUser(user)"><svg class="icon edit" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512"><!--! Font Awesome Pro 6.2.1 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2022 Fonticons, Inc. --><path d="M471.6 21.7c-21.9-21.9-57.3-21.9-79.2 0L362.3 51.7l97.9 97.9 30.1-30.1c21.9-21.9 21.9-57.3 0-79.2L471.6 21.7zm-299.2 220c-6.1 6.1-10.8 13.6-13.5 21.9l-29.6 88.8c-2.9 8.6-.6 18.1 5.8 24.6s15.9 8.7 24.6 5.8l88.8-29.6c8.2-2.8 15.7-7.4 21.9-13.5L437.7 172.3 339.7 74.3 172.4 241.7zM96 64C43 64 0 107 0 160V416c0 53 43 96 96 96H352c53 0 96-43 96-96V320c0-17.7-14.3-32-32-32s-32 14.3-32 32v96c0 17.7-14.3 32-32 32H96c-17.7 0-32-14.3-32-32V160c0-17.7 14.3-32 32-32h96c17.7 0 32-14.3 32-32s-14.3-32-32-32H96z"/></svg></a></td>
                <td><a @click="openModal(user.userId, user.userName)"><svg class="icon trash" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 448 512"><!--! Font Awesome Pro 6.2.1 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2022 Fonticons, Inc. --><path d="M135.2 17.7L128 32H32C14.3 32 0 46.3 0 64S14.3 96 32 96H416c17.7 0 32-14.3 32-32s-14.3-32-32-32H320l-7.2-14.3C307.4 6.8 296.3 0 284.2 0H163.8c-12.1 0-23.2 6.8-28.6 17.7zM416 128H32L53.2 467c1.6 25.3 22.6 45 47.9 45H346.9c25.3 0 46.3-19.7 47.9-45L416 128z"/></svg></a></td>
            </tr>
        </tbody>
    </table>
</div>

<div @click="closeModal" :class="modalToggle" class="modal" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div @click.stop class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">{{text.UserList.Delete.head}}</h5>
        <button @click="closeModal" type="button" class="close" data-dismiss="modal" aria-label="Close">
          <svg cm-icon-name="cm-icon-close" viewBox="0 0 24 24" fill="currentColor">
            <path d="M13.4261944,11.9997479 L17.7050296,7.72091264 C17.9016765,7.52426573 18.0005042,7.26610362 18.0005042,7.00794151 C18.0005042,6.7497794 17.9016765,6.49262574 17.7050296,6.29497038 C17.3107273,5.90167654 16.6723812,5.90167654 16.2790874,6.29497038 L12.0002521,10.5738056 L7.72141687,6.29497038 C7.32812303,5.90167654 6.68977688,5.90167654 6.2954746,6.29497038 C6.09882768,6.49262574 6,6.7497794 6,7.00794151 C6,7.26610362 6.09882768,7.52426573 6.2954746,7.72091264 L10.5743098,11.9997479 L6.2954746,16.2785831 C6.09882768,16.4752301 6,16.7333922 6,16.9915543 C6,17.2497164 6.09882768,17.50687 6.2954746,17.7045254 C6.49312996,17.9011723 6.75028363,18 7.00844573,18 C7.26660784,18 7.52476995,17.9011723 7.72141687,17.7045254 L12.0002521,13.4256902 L16.2790874,17.7045254 C16.4757343,17.9011723 16.7338964,18 16.9920585,18 C17.2502206,18 17.5073743,17.9011723 17.7050296,17.7045254 C17.9016765,17.50687 18.0005042,17.2497164 18.0005042,16.9915543 C18.0005042,16.7333922 17.9016765,16.4752301 17.7050296,16.2785831 L13.4261944,11.9997479 Z"></path>
          </svg>
        </button>
      </div>
      <div class="modal-body">
        <p>{{text.UserList.Delete.confirm}} {{modelBody}}?</p>
      </div>
      <div class="modal-footer">
        <button @click="closeModal" type="button" class="btn btn-secondary btn-close" data-dismiss="modal">{{text.UserList.Delete.btnClose}}</button>
        <button @click="removeUser" type="button" class="btn btn-primary btn-save">{{text.UserList.Delete.btnSave}}</button>
      </div>
    </div>
  </div>
</div>
</template>

<script>
export default{
    props: [
        'userlist'
    ],
    data() {
        return {
            modalToggle: 'hide',
            userId: '',
            modelBody: ''
        }
    },
    methods: {
        openModal(id, name){
            this.userId = id;
            this.modelBody = name;
            this.modalToggle = 'open'
        },
        register(){
          this.$router.push('register');
        },
        closeModal(){
            this.userId = ''
            this.modelBody = ''
            this.modalToggle = 'hide'
        },
        EditUser(user){
          this.$emit('edit', user)
        },
        async removeUser(){
          console.log('init')
          if(this.userId){
            const result = await DeleteUser(this.userId);
            result.status == 200 ? this.$router.go() : 'DisplayError'
          }
        }
    },
}
</script>

<style lang="scss">
    @import '@/assets/styles/components/userList.scss';
</style>