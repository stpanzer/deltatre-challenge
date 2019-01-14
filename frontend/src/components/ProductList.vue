<template>
    <div class="productList">
      <h1>Products</h1>
      <div v-if="products && products.length > 0">
        Total: {{products.length}}
        <b-table :items="products" :fields="fields"></b-table>
      </div>
      <div v-else>
        Sorry, there aren't any products to show at this time.
      </div>
    </div>
</template>

<script>
export default {
  name: 'ProductList',
  async created () {
    this.products = (await this.axios.get('https://localhost:5001/api/products')).data
    this.pollServer()
  },
  data () {
    return {
      fields: ['name', 'description', 'price', 'quantity'],
      products: null,
      timer: null
    }
  },
  methods: {
    addProduct (newProduct) {
      this.products.push(newProduct)
    },
    async pollServer () {
      this.products = (await this.axios.get('https://localhost:5001/api/products')).data
      this.timer = setTimeout(this.pollServer, 5000)
    }
  },
  beforeDestroy(){
    clearTimeout(this.timer)
  }
}
</script>

<style>
.productList{
  text-align:left;
}

</style>
