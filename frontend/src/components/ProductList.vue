<template>
    <div>
      <div v-if="lineItems && lineItems.length > 0">
        Total: {{lineItems.length}}
        <div v-for="lineItem of lineItems" v-bind:key="lineItem.id">
          <line-item :item=lineItem></line-item>
        </div>
      </div>
      <div v-else>
        Sorry, there aren't any products to show at this time.
      </div>

    </div>
</template>

<script>
import LineItem from '@/components/LineItem.vue'
export default {
  name: 'ProductList',
  data () {
    return {
      lineItems: [
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
  components: { LineItem }
}
</script>

<style>

</style>
