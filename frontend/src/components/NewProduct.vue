<template>
  <div>
    <label>
      <label>Name: <input v-model="item.name"/></label>
      <label>Description: <input v-model="item.description"/></label>
      <label>Quantity: <input v-model="item.quantity" type="number"/></label>
      <label>Price: <input v-model="item.price" type="number"></label>
      <div class="errors">{{errors}}</div>
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
      },
      errors: ''
    }
  },
  methods: {
    async save () {
      this.errors = ''
      if (!this.item.name) {
        this.errors = 'Product name required'
        return
      }
      try {
        var result = await this.axios.post('https://localhost:5001/api/products', this.item)
      } catch (err) {
        this.errors = err.response.data
        return
      }
      this.item.name = ''
      this.item.description = ''
      this.item.quantity = 0
      this.item.price = 0
      this.$emit('save-product', result.data)
    }
  }
}
</script>

<style>
label{
  display:block;
}

</style>
