<script setup>
import {GetUserById} from '../assets/javascript/User';
import {GetAverageRatingByUserID} from '../assets/javascript/User';
import Chart from 'chart.js/auto';
import { getLang } from '@/assets/javascript/translate';
import { ref } from 'vue';
const text = ref(null);
  text.value = getLang();
  defineExpose({text})
  defineProps({
    id: {
      required: true,
    },
  });
</script>


<template>
  <section class="graph-view">
    <div class="container">
      <div class="row">
        <div class="col-md-12">
          <span @click="turnBack" class="bread-crum">
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 320 512"><!--! Font Awesome Pro 6.2.1 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2022 Fonticons, Inc. --><path d="M41.4 233.4c-12.5 12.5-12.5 32.8 0 45.3l160 160c12.5 12.5 32.8 12.5 45.3 0s12.5-32.8 0-45.3L109.3 256 246.6 118.6c12.5-12.5 12.5-32.8 0-45.3s-32.8-12.5-45.3 0l-160 160z"/></svg> Back
          </span>
        </div>
      </div>
        <h1 class="title">UserStats: {{ userName }}</h1>

        <br/><br/>
        <div class="custom-progress progress">
          <div role="progressbar" id="rating" aria-valuenow="70" aria-valuemin="0" aria-valuemax="100" style="width:" class="animated custom-bar progress-bar slideInLeft bg-orange"></div>
            </div>
              <div class="progress-text">
                <div class="row">
                <div class="col-7"><p>Average thumbs up rating</p></div>
            <div class="col-5 text-right"><p>{{averageRating}}% </p></div>
          </div>
        </div>
        <br/><br/>

      <div class="chartitem">
        <canvas id="chart"></canvas>
      </div>
    </div>
  </section>
</template>


<script>
import axios from 'axios'
export default{
  data(){
        return{
          User: [],
          userName: '',
          averageRating: '',
        }
    },
    async mounted(){
      var userid = this.id

      this.User = await GetUserById(userid)
      this.userName = this.User[0].userName

      this.averageRating = await GetAverageRatingByUserID(userid)
      document.getElementById('rating').style.width = this.averageRating + "%";

      var days = [];
      var percentage = [];

      const ctx = document.getElementById('chart');

      await axios.get(`https://localhost:7117/GetAverageFromLast30DaysRatingById?id=${userid}`)
      .then(res => {
        for(const obj of res.data){
          days.push(obj.date)
          percentage.push(obj.per)
        }
        const myChart = new Chart(ctx, {
          type: 'bar',
          data: {
            labels: days,
            datasets: [
              {
                label: 'Rating in %',
                data: percentage,
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
      })
      .catch(error => {
        console.log(error)
      });
    },
    methods: {
      turnBack(){
        this.$emit('switchBack')
      },
    },
}
</script>

<style lang="scss">
@import "../assets/styles/components/graph.scss";
</style>