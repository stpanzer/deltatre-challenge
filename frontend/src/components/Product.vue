<template>
  <div>
    {{item.name}}
    {{item.description}}
    {{item.price | currency}}
    {{item.quantity}}
  </div>
</template>

<script>
export default {
  name: 'Product',
  props: ['item']

}
</script>

<style>

</style>
