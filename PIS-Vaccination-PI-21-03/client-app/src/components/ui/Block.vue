<script setup lang="ts">

</script>

<template>
    <section>
        <slot/>
    </section>
</template>

<style scoped lang="less">
section {
  margin-top: 30px;
  padding: 20px;
  border-radius: 8px;
  background: var(--bg-default);
  box-shadow: 0 0 30px 0 rgba(0, 0, 0, 0.10);
  backdrop-filter: blur(5px);
  animation: zoomIn 1s ease-in-out;
}
</style>
