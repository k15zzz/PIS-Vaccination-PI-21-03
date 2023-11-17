<script setup>
import CheckBox from "./ui/CheckBox.vue";
import {ref} from "vue";
import AppButton from "./ui/AppButton.vue";

const city = ref([])
</script>

<template>
  <div class="build-statistic">
    <h3 class="build-stat__title">
      Статистика
    </h3>
    <div class="build-stat__wrap">
      <label class="build-stat-wrap__title"> Города </label>
      <div class="build-stat-wrap__items">
        <div class="build-stat-items__item">
          <check-box label="Тюмень" value="1" v-model="city" />
        </div>
        <div class="build-stat-items__item">
          <check-box label="Новосибирск" value="2" v-model="city" />
        </div>
      </div>
    </div>
    <div class="build-stat__wrap">
      <label class="build-stat-wrap__title">
        Период
      </label>
      <div class="build-stat-wrap__items">
        <div class="build-stat-items__item">
          <label>Дата начала</label>
          <input type="date" name="date-start">
        </div>
        <div class="build-stat-items__item">
          <label>Дата конца</label>
          <input type="date" name="date-end">
        </div>
      </div>
    </div>
    <app-button class="build-stat__action">
      Рассчитать
    </app-button>
  </div>
</template>

<style scoped lang="less">
.build-statistic {
  display: grid;
  .build-stat__title {}
  .build-stat__wrap {
    .build-stat-wrap__title {

    }
    .build-stat-wrap__items {
      border: solid 1px var(--color-light-gray);
      padding: 10px;
      border-radius: 10px;
      margin-top: 10px ;
      display: grid;
      gap: 10px;
      overflow-y: auto;
      .build-stat-items__item {
        display: grid;
        align-items: center;
        input[type=date] {
          margin-top: 10px;
        }
      }
    }
  }
  .build-stat__wrap + .build-stat__wrap {
    margin-top: 10px;
  }
  .build-stat__action {
    margin-top: 10px;
    background: var(--color-primary);
    color: white;
  }
}
</style>