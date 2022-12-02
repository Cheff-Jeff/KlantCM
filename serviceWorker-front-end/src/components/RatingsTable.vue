<script setup>
defineProps({
    Lists: {
        required: true
    }
});
</script>

<template>
    <div class="container">
        <table class="table table-striped table-hover">
            <thead>
                <tr>
                    <th>Room ID</th>
                    <th>Rating</th>
                    <th>Date</th>
                    <th>Time</th>
                    <th/>
                    <th/>
                    <th/>
                </tr>
            </thead>
            <tbody>
                <tr v-for="rating in Lists">
                    <td>{{rating.roomId}}</td>
                    <td name="RatingTd">{{rating.rate}}</td>
                    <td name="DateTd">{{rating.timeOfRating}}</td>
                    <td name="TimeTd">{{rating.timeOfRating}}</td>
                    <td><a href="#"><svg class="icon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512"><!--! Font Awesome Pro 6.2.1 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2022 Fonticons, Inc. --><path d="M256 512c141.4 0 256-114.6 256-256S397.4 0 256 0S0 114.6 0 256S114.6 512 256 512zM216 336h24V272H216c-13.3 0-24-10.7-24-24s10.7-24 24-24h48c13.3 0 24 10.7 24 24v88h8c13.3 0 24 10.7 24 24s-10.7 24-24 24H216c-13.3 0-24-10.7-24-24s10.7-24 24-24zm40-144c-17.7 0-32-14.3-32-32s14.3-32 32-32s32 14.3 32 32s-14.3 32-32 32z"/></svg></a></td>
                    <td><a href="#"><svg class="icon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512"><!--! Font Awesome Pro 6.2.1 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2022 Fonticons, Inc. --><path d="M471.6 21.7c-21.9-21.9-57.3-21.9-79.2 0L362.3 51.7l97.9 97.9 30.1-30.1c21.9-21.9 21.9-57.3 0-79.2L471.6 21.7zm-299.2 220c-6.1 6.1-10.8 13.6-13.5 21.9l-29.6 88.8c-2.9 8.6-.6 18.1 5.8 24.6s15.9 8.7 24.6 5.8l88.8-29.6c8.2-2.8 15.7-7.4 21.9-13.5L437.7 172.3 339.7 74.3 172.4 241.7zM96 64C43 64 0 107 0 160V416c0 53 43 96 96 96H352c53 0 96-43 96-96V320c0-17.7-14.3-32-32-32s-32 14.3-32 32v96c0 17.7-14.3 32-32 32H96c-17.7 0-32-14.3-32-32V160c0-17.7 14.3-32 32-32h96c17.7 0 32-14.3 32-32s-14.3-32-32-32H96z"/></svg></a></td>
                    <td><a href="#"><svg class="icon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 448 512"><!--! Font Awesome Pro 6.2.1 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2022 Fonticons, Inc. --><path d="M135.2 17.7L128 32H32C14.3 32 0 46.3 0 64S14.3 96 32 96H416c17.7 0 32-14.3 32-32s-14.3-32-32-32H320l-7.2-14.3C307.4 6.8 296.3 0 284.2 0H163.8c-12.1 0-23.2 6.8-28.6 17.7zM416 128H32L53.2 467c1.6 25.3 22.6 45 47.9 45H346.9c25.3 0 46.3-19.7 47.9-45L416 128z"/></svg></a></td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
    export default {
        updated() {
            this.PutDataInTable();
        },
        methods: {
            PutDataInTable() {
                const TdRating = document.getElementsByName("RatingTd");
                const TdDate = document.getElementsByName("DateTd");
                const TdTime = document.getElementsByName("TimeTd");

                console.log(TdRating);
                console.log(TdDate);
                console.log(TdTime);
                
                TdRating.forEach(element => {
                    if(element.innerHTML == "true") element.innerHTML = "Positive";
                    else if(element.innerHTML == "false") element.innerHTML = "Negative";
                    else return(error);
                });

                TdDate.forEach(element => {
                    const oldDate = element.innerHTML;
                    const newDate = new Date(Date.parse(oldDate));
                    element.innerHTML = newDate.getUTCDate() + "/" + newDate.getMonth() + "/" + newDate.getFullYear();
                })

                TdTime.forEach(element => {
                    const oldDate = element.innerHTML;
                    const newDate = new Date(Date.parse(oldDate));
                    var hours = newDate.getHours();
                    if(hours < 10) hours = "0" + hours;
                    var minutes = newDate.getMinutes();
                    if(minutes < 10) minutes = "0" + minutes;
                    element.innerHTML = hours + ":" + minutes;
                    
                })
            }
        }
    }
</script>

<style>
    @import '../assets/styles/pages/usermanagement.css';
</style>