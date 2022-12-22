<script setup>
    import Header from '../components/Header.vue';
    import RatingsTable from '../components/RatingsTable.vue';
    import {GetAllRatings} from '../assets/javascript/Ratings';
</script>

<template>
    <Header/>

    <div class="heading-collection">
        <h1 class="heading"> Statistics </h1>
    </div>

    <RatingsTable v-if="ratingsList" :Lists="ratingsList"/>

</template>

<script>
    export default{
        data(){
            return{
                ratingsList: []
            }
        },
        components:{
            Header,
            RatingsTable
        },
        async mounted(){
            await this.FillRatingsTable()
        },
        methods:{
            async FillRatingsTable(){
                this.ratingsList = await GetAllRatings();
            }
        }
    }
</script>

<!-- Hier moet een style maar ik weet niet welke  er stond usermangemang.css maar die bestaat niet-->
<style scoped>
</style>