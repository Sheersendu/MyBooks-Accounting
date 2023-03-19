<template>
  <div class="container-fluid pad">
    <!--<div id="nav">
      <router-link to="/dashboard">Dashboard</router-link>
  </div> -->
    <nav class="navbar navbar-expand navbar-dark bg-primary" aria-label="Second navbar example"
      v-if="!['login'].includes(this.$route.name)">
      <div class="container-fluid">
        <div class="navbar-brand">MyBooks-Accounting</div>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarsExample02"
          aria-controls="navbarsExample02" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarsExample02">
          <ul class="navbar-nav me-auto">
          </ul>
          <div class="avatar"> avatar </div>
        </div>
      </div>
    </nav>
    <div class="container mt-3">
      <router-view />
    </div>
  </div>
</template>
<style>
.pad {
  padding-left: 0px !important;
  padding-right: 0px !important;
}
</style>