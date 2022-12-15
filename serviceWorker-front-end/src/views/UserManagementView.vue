<script setup>
import Header from '@/components/Header.vue';
import UserList from '@/components/UserList.vue'
import UpdateUserForm from '@/components/UpdateUserForm.vue'
import {GetAllUsers} from '@/assets/javascript/User'
import { getLang } from '@/assets/javascript/translate';
import { ref } from 'vue';
  const text = ref(null);
  text.value = getLang();
  defineExpose({text})
</script>

<template>
    <Header
        CompanyName="MasterChef"
        :Text="text.header"
    />
    <div v-auto-animate>
        <UserList 
            v-if="manager"
            :userlist="userlist"
            @edit="switchEdit"
        />
        <UpdateUserForm
            v-if="edit"
            :User="user"
            @switch="switchmanager"
        />
    </div>
</template>

<script>
export default{
    data(){
        return{
            manager: 'open',
            edit: '',
            user: '',
            userlist: [],
        }
    },
    mounted(){
        this.FillUserList()
        console.log(this.userlist)
    },
    methods:{
        switchEdit(user){
            this.user = user
            this.manager = ''
            this.edit = 'open'
        },
        switchmanager(){
            this.user = ''
            this.edit = ''
            this.manager = 'open'
        },
        async FillUserList(){
            this.userlist = await GetAllUsers();
        }
    }
}
</script>