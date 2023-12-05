<template>

<!-- SECTION TOP OF HOME PAGE -->
<div class="container-fluid">
  <div class="row align-items-center justify-content-center text-center cult-bg">
    <div class="col-3">
      <button @click="scrollTo" class="btn btn-danger w-100">Join a Cult?</button>
    </div>
    <div class="col-3">
      <button data-bs-toggle="modal" data-bs-target="#createCultModal" class="btn btn-danger w-100">Start a Cult?</button>
    </div>
  </div>
</div>

<!-- SECTION CULTS -->
<div class="container">
  <div class="row mt-5">
    <div id="cults" class="col-4 text-center">
      <p class="fs-1 text-white border-top">Cults near you!</p>
    </div>
    <div v-for="cult in cults" :key="cult.id" class="col-12 col-md-6 offset-md-3 my-3 p-3">
      <Cult :cultProp="cult" />
    </div>
  </div>
</div>

</template>

<script>
import { computed, onMounted } from 'vue';
import Pop from '../utils/Pop.js';
import { logger } from '../utils/Logger.js';
import {cultsService} from '../services/CultsService.js'
import {AppState} from '../AppState.js'
import Cult from '../components/Cult.vue';

export default {
    setup() {
        onMounted(() => {
            getCults();
        });
        async function getCults() {
            try {
                await cultsService.getCults();
            }
            catch (error) {
                logger.error('[ERROR]', error);
                Pop.error(('[ERROR]'), error.message);
            }
        }
        return {
            cults: computed(() => AppState.cults),

            scrollTo() {
              const cultElem = document.getElementById('cults')
              const cult = cultElem.offsetTop
              window.scrollTo(0,cult)
            }
        };
    },
    components: { Cult }
}
</script>

<style scoped lang="scss">

.cult-bg {
  background-image: url(../assets/img/forest.png);
  height: 100dvh;
  background-size: cover;
  background-position: center;
}

.border-top {
  border-top: 2px white solid;
}



</style>
