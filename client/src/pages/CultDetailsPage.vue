<template>

<div class="container-fluid text-light" v-if="cult">
  <div class="row cult-bg align-items-center align-content-center">
    <button v-if="isMember" @click.prevent="leaveCult(isMember.cultMemberId)" class="mdi mdi-close">Drink the Kool-Aid</button>
    <p class="fs-1">{{ cult.name }}</p>
    <div class="ps-2">
      <button v-if="!isMember" @click="joinCult" class="btn btn-danger w-auto p-3">Join Cult...</button>
    </div>
  </div>
  <div class="row justify-content-between mt-5">
    <div class="col-12 col-md-4 order-2 order-md-1 mt-md-0 mt-5">
      <p class="p-3">{{ cult.description }}</p>
    </div>
    <div class="col-12 col-md-5 order-1 order-md-2">
      <div class="row">
        <div class="col-12">
          <p class="fs-2">Cult Leader</p>
          <img class="img-fluid rounded-circle" :src="cult.leader.picture" title="Cult Leader" alt="">
        </div>
        <div class="col-12 mt-3">
          <p class="fs-3">Members: {{ cult.memberCount }}</p>
        </div>
        <div v-for="c in cultist" :key="c.id" class="col-3 col-md-2">
          <img class="rounded-circle img-fluid" :src="c.picture" :title="c.name" alt="">
        </div>
      </div>
    </div>
  </div>
</div>

</template>

<script>
import { useRoute } from 'vue-router';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { computed, onMounted } from 'vue';
import { cultsService } from '../services/CultsService.js';
import {AppState} from '../AppState.js'


export default {



setup() {
const route = useRoute()
onMounted(() => {
  getCultById();
  getCultist();
})

async function getCultById() {
  try {
    const cultId = route.params.cultId
    logger.log('[CULT ID]', cultId )
    await cultsService.getCultById(cultId)
  } catch (error) {
    logger.error('[ERROR]',error)
    Pop.error(('[ERROR]'), error.message)
  }
}

async function getCultist() {
  try {
    const cultId = route.params.cultId
    await cultsService.getCultist(cultId)
  } catch (error) {
    logger.error('[ERROR]',error)
    Pop.error(('[ERROR]'), error.message)
  }
}



  return {
    cult: computed(() => AppState.activeCult),
    cultist: computed(() => AppState.cultist),
    cultCoverImage: computed(() => `url(${AppState.activeCult?.coverImg})`),
    isMember: computed(() => AppState.cultist.find((cultist) => cultist.id == AppState.account.id)),

    async joinCult() {
      try {
        const cultId = route.params.cultId
        await cultsService.joinCult(cultId)
      } catch (error) {
        logger.error('[ERROR]',error)
        Pop.error(('[ERROR]'), error.message)
      }
    },

    async leaveCult(cultMemberId) {
      try {
        logger.log('[CULT MEMBER ID]', cultMemberId)
        await cultsService.leaveCult(cultMemberId)
      } catch (error) {
        logger.error('[ERROR]',error)
        Pop.error(('[ERROR]'), error.message)
      }
    }

}}}
</script>

<style>

.cult-bg {
  background-image: v-bind(cultCoverImage);
  height: 35dvh;
  background-position: center;
  background-size: cover;
  box-shadow: 0px 7.5px 5px black;
}

</style>
