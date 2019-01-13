<template>
  <div>
    <label>
      <label>Name: <input v-model="item.name"/></label>
      <label>Description: <input v-model="item.description"/></label>
      <label>Quantity: <input v-model="item.quantity"/></label>
      <label>Price: <input v-model="item.price"/></label>
      <button @click="save()">Save</button>
    </label>
  </div>
</template>

<script>
export default {
  name: 'NewProduct',
  data () {
    return {
      item: {
        name: '',
        description: '',
        quantity: 0,
        price: 0
      }
    }
  },
  methods: {
    save () {
      console.log('saving')
      this.$emit('save-product', this.item)
    }
  }
}
</script>

<style>
label{
  display:block;
}

</style>
