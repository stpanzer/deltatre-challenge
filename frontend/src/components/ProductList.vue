<template>
    <div>
      <div v-if="lineItems && lineItems.length > 0">
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
          name: 'Rose Bouquet',
          description: 'An simple bouquet',
          price: '14.99',
          quantity: 20
        }
      ]
    }
  },
  components: { LineItem }
}
</script>

<style>

</style>
