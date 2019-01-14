<template>
  <div class="form-group col-md-4">
    <h1>New Product</h1>
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
      if (!this.item.quantity && this.item.quantity !== 0) {
        this.errors = 'Quantity required'
        return false
      }
      try {
        await this.axios.post('https://localhost:5001/api/products', this.item)
      } catch (err) {
        this.errors = err.response.data
        return
      }
      this.$router.push('/')
    }
  }
}
</script>

<style>
label{
  display:block;
}
.form-group{
  text-align:left;
}

</style>
