<template>
  <div class="form-group col-md-4">
    <h3>New Product</h3>
    <label>Name: <input class="form-control" v-model="item.name"/></label>
    <label>Description: <input class="form-control" v-model="item.description"/></label>
    <label>Quantity: <input class="form-control" v-model="item.quantity" type="number"/></label>
    <label>Price: <input class="form-control" v-model="item.price" type="number"></label>
    <div class="alert alert-danger" v-if="errors">{{errors}}</div>
    <button @click="save()" class="btn btn-primary" type="button">Save</button>
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
