<script setup lang="ts">
import { reactive } from "vue";

import Block from "./../components/ui/Block.vue";
import InputText from "./../components/ui/InputText.vue";
import AppButton from "./../components/ui/AppButton.vue";
import {AuthorizeController} from "../controller/AuthorizeController";

const controller = new AuthorizeController();
</script>

<template>
  <block class="main-block">
    <img class="logo" width="100" height="100" src="./../assets/logos/main-logo.svg">
    <h2> Авторизация </h2>
    <div v-if="controller.value.error" class="error" >
      {{ controller.value.error }}
    </div>
    <input-text
        v-model="controller.value.login"
        label="Логин"
        type="text"
    />
    <input-text
        v-model="controller.value.password"
        label="Пароль"
        type="password"
    />
    <app-button 
        @click="controller.auth()"
        backgroundColor="#1758FFFF"
    >
      Войти
    </app-button>
  </block>
</template>

<style lang="less" scoped>
.main-block {
  width: auto;
  height: auto;
  display: flex;
  flex-direction: column;
  gap: 20px;
  
  .error {
    color: var(--color-danger)
  }
  
  h2 {
    text-align: center;
    color: var(--color-primary)
  }
  
  .logo {
    margin: auto;
  }
}
</style>