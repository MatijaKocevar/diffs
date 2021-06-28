<template>
  <PairList />
</template>

<script>
import PairList from "./components/PairList.vue";
export default {
  name: "App",
  components: {
    PairList,
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #ffffff;
  margin-top: 60px;
}
html,
body {
  padding: 1rem;
  background-color: #303030;
  color: rgb(0, 0, 0);
}
</style>
