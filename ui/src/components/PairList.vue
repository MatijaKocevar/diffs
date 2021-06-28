<template>
  <div>
    <h1>Database</h1>
    <table class="OffsetTable middle">
      <tr>
        <th>ID</th>
        <th>LEFT</th>
        <th>RIGHT</th>
      </tr>
      <!-- looping through items -->
      <tr v-for="pair of pairs" :key="pair.id">
        <td>{{ pair.id }}</td>
        <td>{{ pair.left }}</td>
        <td>{{ pair.right }}</td>
      </tr>
    </table>

    <!-- PUT LEFT -->
    <form onsubmit="return false" name="myForm" class="left">
      <h1>Input LEFT</h1>
      <input class="putID" placeholder="ID" v-model="id_left" type="text" />
      <input placeholder="base64 string" v-model="left" type="text" />
      <input type="submit" @click="putLeft(id_left, left)" />
    </form>

    <!-- gets diffs -->
    <form onsubmit="return false" class="getDiffs">
      <h1>Input ID of pair</h1>
      <input
        class="putID"
        placeholder="ID"
        v-model="id"
        type="text"
        @keypress.enter="getDiffs(id)"
      />
      <input type="submit" @click="getDiffs(id)" />
    </form>

    <!-- PUT RIGHT -->
    <form onsubmit="return false" class="right">
      <h1>Input RIGHT</h1>
      <input class="putID" placeholder="ID" v-model="id_right" type="text" />
      <input placeholder="base64 string" v-model="right" type="text" />
      <input type="submit" @click="putRight(id_right, right)" />
    </form>

    <table class="middle">
      <tr>
        <th>Result type</th>
      </tr>
      <tr>
        <td>{{ result.diffResultType }}</td>
      </tr>
    </table>
    <table class="middle">
      <tr>
        <th>Offset</th>
        <th>Length</th>
      </tr>
      <tr v-for="diff of result.diffs" :key="diff.offset">
        <td>{{ diff.offset }}</td>
        <td>{{ diff.length }}</td>
      </tr>
    </table>
  </div>
</template>

<script>
export default {
  name: "PairList",
  data() {
    return {
      id_left: "",
      id_right: "",
      data_left: "",
      data_right: "",
      id: "",
      left: "",
      right: "",
      result: [],
      pairs: [],
    };
  },
  methods: {
    async getPairs() {
      const res = await fetch(`https://localhost:5001/v1/diff`)
        .then((response) => response.json())
        .catch((error) => {
          console.log(error);
        });
      return (this.pairs = res);
    },

    async getDiffs(id) {
      const res = await fetch(`https://localhost:5001/v1/diff/${id}`)
        .then((response) => response.json())
        .catch((error) => {
          console.log(error);
        });
      return (this.result = res);
    },

    async putLeft(id_left, data_left) {
      const requestOptions = {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ data: data_left }),
      };
      const res = await fetch(
        `https://localhost:5001/v1/diff/${id_left}/left`,
        requestOptions
      );
      this.id_left = "";
      this.left = "";
      console.log(res);
      this.getPairs();
      return (this.result = res);
    },

    async putRight(id_right, data_right) {
      const requestOptions = {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ data: data_right }),
      };
      const res = await fetch(
        `https://localhost:5001/v1/diff/${id_right}/right`,
        requestOptions
      );
      this.id_right = "";
      this.right = "";
      console.log(res);
      this.getPairs();
      return (this.result = res);
    },
  },
};
</script>

<style lang="postcss" scoped>
.left {
  display: inline-block;
  position: absolute;
  left: 10%;
}

.right {
  display: inline-block;
  position: absolute;
  right: 10%;
}

.putID {
  width: 50px;
}

.getDiffs {
  display: inline-block;
  margin-bottom: 5rem;
}

.middle {
  margin-left: auto;
  margin-right: auto;
  margin-bottom: 0.5rem;
}

.OffsetTable {
  margin-bottom: 5rem;
}

.OffsetTable td {
  margin-bottom: 5rem;
  border: 1px solid rgb(255, 255, 255);
  padding: 1rem;
}
</style>