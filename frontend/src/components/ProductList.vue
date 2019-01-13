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
  data () {
    return {
      fields: ['name', 'description', 'price', 'quantity'],
      products: [
        {
          name: 'Panko Bread Crumbs',
          description: 'Japanese style bread crumbs',
          price: '5.33',
          quantity: 20,
          id: 1
        },
        {
          name: 'Fuji Apples',
          description: '',
          price: '3.50',
          quantity: 520,
          id: 2
        },
        {
          name: 'Chickpeas (Canned)',
          description: '12oz unsalted',
          price: '1.20',
          quantity: 10,
          id: 3
        }
      ]
    }
  },
  methods: {
    addProduct (newProduct) {
      this.products.push(newProduct)
    }
  },
  components: { Product, NewProduct }
}
</script>

<style>
.productList{
  text-align:left;
}

</style>
