<script setup>
import Header from '@/components/Header.vue';
import UserList from '@/components/UserList.vue'
import {GetAllUsers} from '@/assets/javascript/User'
</script>

<template>
    <Header/>
    <div v-auto-animate>
        <UserList 
            v-if="manager"
            :userlist="userlist"
            @EditUser="switchEdit"
        />
    </div>
</template>

<script>
export default{
    data(){
        return{
            manager: '',
            edit: '',
            user: '',
            userlist: []
        }
    },
    components:{
        Header,
        UserList
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