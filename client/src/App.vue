<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>

  <CreateCultModal />
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'
import CreateCultModal from './components/Modals/CreateCultModal.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar, CreateCultModal }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root{
  --main-height: calc(100vh - 32px - 64px);
}

main {
  background-color: #1a1919;
}
</style>
