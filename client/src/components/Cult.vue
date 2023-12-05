<template>
      <div class="row cult-card-bg">
        <div class="col-2">
          <img class="img-fluid rounded-circle" :src="cultProp.leader.picture" alt="">
        </div>
        <div class="col-10 d-flex align-items-center">
          <p class="fs-4 m-0">
            {{ cultProp.leader.name }}
          </p>
        </div>
        <div class="col-12 p-0">
          <img class="img-fluid" :src="cultProp.coverImg" alt="">
        </div>
        <div class="col-12">
          <p class="fs-2">{{ cultProp.name }}</p>
        </div>
        <div class="col-12">
          <p class="fs-5">{{ cultProp.description }}</p>
        </div>
        <div class="col-12 text-end">
          <router-link :to="{name:'CultDetails', params: {cultId: cultProp.id}}">
  <button class="btn btn-warning">
    See More...
  </button>
  </router-link>
        </div>
      </div>



</template>

<script>
import { Cult } from '../models/Cult.js';


export default {
props: {cultProp: {type: Cult, required: true}},


setup() {



  return {

}}}
</script>

<style>

.cult-card-bg {
  background-color: #3f3b3b;
  border-radius: 19px;
border: 1px solid #5F0202;
box-shadow: 5px 5px 10px 2px rgba(123, 0, 0, 0.48);
color: white;
}

</style>
