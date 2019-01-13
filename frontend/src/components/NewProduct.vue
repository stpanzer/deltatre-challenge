<template>
  <div>
    <label>
      <label>Name: <input v-model="item.name"/></label>
      <label>Description: <input v-model="item.description"/></label>
      <label>Quantity: <input v-model="item.quantity"/></label>
      <label>Price: <input v-model="item.price"/></label>
      <button @click="save()">Save</button>
      <div class="errors">{{errors}}</div>
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
      },
      errors: ''
    }
  },
  methods: {
    async save () {
      try {
        var result = this.axios.post('https://localhost:5001/api/products', this.item)
      } catch (err) {
        this.errors = err.errors
      }
      this.$emit('save-product', result)
    }
  }
}
</script>

<style>
label{
  display:block;
}

</style>
