<script setup>
import {AuthorizeController} from "../controller/AuthorizeController.js";
</script>

<template>
  <header>
    <img src="./../assets/logos/main-logo.svg" alt="" width="30" height="30">
    <div>
      <a href="#">Реестр животных</a>
    </div>
    <div>
      <a href="#">Реестр организаций</a>
    </div>
    <div>
      <a href="#">Реестр пользователей</a>
    </div>
    <div>
      <a href="#">Реестр реестров</a>
    </div>
    <div>
      <a @click="AuthorizeController.out()" href="#">Выйти</a>
    </div>
  </header>
</template>

<style lang="less" scoped>
header {
  padding: 20px;
  border-radius: 8px;
  background: var(--bg-default);
  box-shadow: 0 0 30px 0 rgba(0, 0, 0, 0.10);
  backdrop-filter: blur(5px);
  display: flex;
  flex-direction: row;
  gap: 30px;
  justify-content: center;
  align-items: center;
  div {
    a {
      &:hover {
        color: var(--color-primary);
      }
    }
  }
}
</style>