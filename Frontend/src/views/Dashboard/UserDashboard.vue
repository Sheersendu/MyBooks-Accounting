<template>
  <div class="container text-center mt-3">
    <div v-if="expert">
      <div class="row align-items-center">
        <div class="col-6">
          <div class="card text-center">
            <div class="card-body">
              <h5 class="card-title">All Requests</h5>
              <!-- <p class="card-text">List of all customer's requests</p> -->
              <button class="btn btn-primary"><router-link class="nav-link" to="/all-requests/">View</router-link></button>
            </div>
          </div>
        </div>
        <div class="col-6">
          <div class="card text-center">
            <div class="card-body">
              <h5 class="card-title">All queued Requests</h5>
              <!-- <p class="card-text">Mapping between all queued customer's request and Expert</p> -->
              <button class="btn btn-primary"><router-link class="nav-link" to="/all-queued-requests/">View</router-link></button>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div v-if="!expert">
      <div class="row align-items-center">
        <div class="col-6">
          <div class="card text-center">
            <div class="card-body">
              <h5 class="card-title">Raise a new Request</h5>
              <button class="btn btn-primary" @click="opendialog()">New</button>
            </div>
          </div>
        </div>
        <div class="col-6">
          <div class="card text-center">
            <div class="card-body">
              <h5 class="card-title">View my Requests</h5>
              <button class="btn btn-primary"><router-link class="nav-link" to="/requests/">View</router-link></button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      expert: this.$store.getters.getIsExpert
    }
  },
  methods : {
    opendialog() {
      alert("Request created!");
    }
  }
}
</script>