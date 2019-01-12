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
  name: 'LineItem',
  props: ['item']

}
</script>

<style>

</style>
