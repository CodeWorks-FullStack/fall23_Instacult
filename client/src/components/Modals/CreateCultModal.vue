<template>

<!-- Modal -->
<div class="modal fade" id="createCultModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h1 class="modal-title fs-5" id="exampleModalLabel">Create Cult</h1>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div @submit.prevent="createCult" class="modal-body">
        <form class="row justify-content-center">
          <div class="col-10">
            <label for="name" class="form-control">Name</label>
            <input required v-model="editable.name" type="text" id="name" class="form-control">
          </div>
          <div class="col-10">
            <label for="offering" class="form-control">Offering</label>
            <input v-model="editable.fee" type="number" id="offering" class="form-control">
          </div>
          <div class="col-10">
            <label for="cult-image" class="form-control">Cult Image</label>
            <input required v-model="editable.coverImg" type="url"  id="cult-image" class="form-control">
          </div>
          <div class="col-10">
            <label for="description" class="form-control">Cult Description</label>
            <textarea required v-model="editable.description" type="text" id="description" class="form-control"> </textarea>
          </div>
          <div class="col-10 text-end">
            <div class="modal-footer">
              <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
              <button type="submit" class="btn btn-primary">Save changes</button>
            </div>
          </div>
        </form>
      </div>
    </div>
  </div>
</div>

</template>

<script>
import { ref } from 'vue';
import Pop from '../../utils/Pop.js';
import { logger } from '../../utils/Logger.js';
import {cultsService} from '../../services/CultsService.js'
import {Modal} from 'bootstrap'

export default {




  setup() {
  const editable = ref({})



  return {
    editable,

    async createCult() {
      try {
        const cultData = editable.value
        await cultsService.createCult(cultData)
        editable.value = {}
        Modal.getOrCreateInstance('#createCultModal').hide()
      } catch (error) {
        logger.error('[ERROR]',error)
        Pop.error(('[ERROR]'), error.message)
      }
    }

}}}
</script>

<style>



</style>
