<template>
  <div class="container-fluid pad">
    <nav class="navbar navbar-expand-lg bg-info navbar-dark" v-if="isAuthenticated">
    <div class="container-fluid">
        <a class="navbar-brand" href="/">MyBooks-Accounting</a>
        <ul class="navbar-nav d-flex flex-row me-1">
            <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle text-white" href="/" id="navbarDropdown" role="button" data-bs-toggle="dropdown"
                data-mdb-toggle="dropdown" aria-expanded="false"> <i class="fas fa-user mx-1"></i> Profile </a>
                <ul class="dropdown-menu dropdown-menu-end" aria-labelledby="navbarDropdown">
                    <li>
                        <a class="dropdown-item" href="/">My account</a>
                    </li>
                    <li>
                        <a class="dropdown-item" href="/">Log out</a>
                    </li>
                </ul>
            </li>
        </ul>
    </div>
</nav>
    <div class="container mt-3">
      <router-view />
    </div>
  </div>
</template>
<script>
export default {
  name: 'App',
  computed: {
    isAuthenticated() {
      return this.$store.getters.isAuthenticated
    },
  },
}
</script>
<style>
.pad {
  padding-left: 0px !important;
  padding-right: 0px !important;
}
</style>