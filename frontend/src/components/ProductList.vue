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
      <new-product @save-product="addProduct"></new-product>
    </div>
</template>

<script>
import NewProduct from '@/components/NewProduct.vue'
export default {
  name: 'ProductList',
  async created () {
    this.products = (await this.axios.get('https://localhost:5001/api/products')).data
    this.pollServer()
  },
  data () {
    return {
      fields: ['name', 'description', 'price', 'quantity'],
      products: null
    }
  },
  methods: {
    addProduct (newProduct) {
      this.products.push(newProduct)
    },
    async pollServer () {
      this.products = (await this.axios.get('https://localhost:5001/api/products')).data
      setTimeout(this.pollServer, 3000)
    }
  },
  components: { NewProduct }
}
</script>

<style>
.productList{
  text-align:left;
}

</style>
