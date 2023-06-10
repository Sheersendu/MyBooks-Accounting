<template>
  <div class="text-center m-top">
    <main class="form-signin w-100 m-auto">
      <form autocomplete="off">
        <h1 class="h3 mb-3 fw-normal">Welcome to MyBooks-Accounting</h1>
        <div class="card text-center">
        <div class="card-body">
          <h5 class="card-title">Start your Accounting Journey now!</h5>
          <!-- <p class="card-text">With supporting text below as a natural lead-in to additional content.</p> -->
          <div class="form-floating m-3 card-text">
          <input type="text" class="form-control mb-3" id="floatingInput">
          <label for="floatingInput">Username</label>
          <div>
            My role : 
                    <div class="btn-group btn-group-toggle" data-toggle="buttons">
          <label class="btn border-0">
            <input type="radio" name="options" id="option1" autocomplete="off" checked @click="onRole()"> Customer
          </label>
          <label class="btn border-0">
            <input type="radio" name="options" id="option2" autocomplete="off" @click="onRole()"> Expert
          </label>
        </div>
          </div>
          </div>
            <button class="w-100 btn btn-lg btn-primary mb-3" type="submit" @click="onSignIn()">Sign in/Login in</button>
          </div>
        </div>
        <!-- <button class="w-100 btn btn-lg btn-primary" type="submit" @click="onSignIn()">Sign in/Login in</button> -->
        <p class="mt-3 mb-3 text-muted">© 2023–2024</p>
      </form>
    </main>
  </div>
</template>
<script>
export default {
  data: () => ({
    isExpert : false
  }),
  methods: {
    onSignIn(){
      this.$store.dispatch('authenticateUser');
      this.$store.dispatch('isExpert', this.isExpert);
      this.$router.push('dashboard');
    },
    onRole(){
      this.isExpert = !this.isExpert;
    }
  }

}
</script>
<style>
.form-signin {
  max-width: 530px;
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