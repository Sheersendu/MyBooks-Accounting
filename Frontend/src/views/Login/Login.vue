<template>
  <div class="text-center m-top">
    <main class="form-signin w-100 m-auto">
      <form>
        <h1 class="h3 mb-3 fw-normal">Please sign in</h1>

        <div class="form-floating">
          <input type="text" class="form-control" id="floatingInput">
          <label for="floatingInput">Username</label>
        </div>

        <div>
          <label>
          </label>
        </div>
        <button class="w-100 btn btn-lg btn-primary" type="submit" @click="onSignIn()">Sign in/Login in</button>
        <p class="mt-5 mb-3 text-muted">© 2023–2024</p>
      </form>
    </main>
  </div>
</template>
<script>
export default {
  methods: {
    onSignIn(){
      this.$store.dispatch('authenticateUser');
      this.$router.push('dashboard');
    }
  }

}
</script>
<style>
.form-signin {
  max-width: 330px;
  padding: 15px;
}

.w-100 {
  width: 100% !important;
}

.m-auto {
  margin: auto !important;
}

.m-top {
  margin-top: 10% !important;
}

</style>