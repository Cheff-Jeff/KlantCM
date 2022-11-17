<script setup>
import Header from '../components/Header.vue';
import UserList from '../components/UserList.vue'
import {GetAllUsers} from '../assets/javascript/User'
</script>

<template>
    <Header/>

    <div class="heading-collection">
        <h1 class="heading"> User management </h1>
    </div>

    <UserList :userlist="userlist"/>
    
</template>

<script>
export default{
    data(){
        return{
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
        async FillUserList(){
            this.userlist = await GetAllUsers();
        }
    }
}
</script>

<style scoped>
@import '../assets/styles/pages/usermanagement.css';
</style>