<script setup>
import {GetUserById} from '../assets/javascript/User';
import Chart from 'chart.js/auto';
import Header from '@/components/Header.vue';
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

    <div class="container">
      <h1 class="title">UserDetails: {{ userName }}</h1>

      <div class="custom-progress progress">
        <div role="progressbar" id="rating" aria-valuenow="70" aria-valuemin="0" aria-valuemax="100" style="width:" class="animated custom-bar progress-bar slideInLeft bg-orange"></div>
          </div>
            <div class="progress-text">
              <div class="row">
              <div class="col-7">Averige rating</div>
          <div class="col-5 text-right">{{averigeRating}}%</div>
        </div>
      </div>


      <div class="chartitem">
        <canvas id="chart"></canvas>
      </div>
    </div>
    
    
</template>

<script>
export default{
    data(){
        return{
          User: [],
          userName: '',
          averigeRating: '',
          datapoints: []
        }
    },
    async mounted(){
      var userid = sessionStorage.getItem('uDetails')

      this.averigeRating = 20;
      document.getElementById('rating').style.width = this.averigeRating + "%";

      this.User = await GetUserById(userid)
      this.userName = this.User[0].userName

        var dayarray = ["20-12-2022","21-12-2022","22-12-2022", "23-12-2022", "24-12-2022"]
        var ratingarray = [20, 80, 40, 60, 10]

        const ctx = document.getElementById('chart');
        const myChart = new Chart(ctx, {
          type: 'bar',
          data: {
            labels: dayarray,
            datasets: [
              {
                label: 'Rating in %',
                data: ratingarray,
                fill: false,
                borderColor: 'RGB(7,84, 156)',
                backgroundColor: 'RGB(0,116, 232)',
                borderWidth: 1
              }
            ]
          },
          options: {          
            scales: {
                y: {
                    min: 0,
                    max: 100,
                }
            }
        }
      })
    }
}
</script>

<style scoped>
.container{
  width: 100%;
  height: 100%;
}
.chartitem{
    width: 75%;
}
</style>