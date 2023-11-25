<script setup>
import {ReportController} from "../controller/ReportController.js";
import AppButton from "../components/ui/AppButton.vue";
import Block from "../components/ui/Block.vue";
import {onBeforeMount, reactive} from "vue";
import Multiselect from 'vue-multiselect';

const controller = new ReportController();
onBeforeMount(async () => {
  await controller.load();
});
</script>

<template>
  <block class="report_page">
    <h3 class="report-page__title">
      Статистика
    </h3>
    <div class="report-page__content">
      <div class="build-statistic">

        <div class="build-stat__wrap">
          <label class="build-stat-wrap__title">Исполнитель</label>
          <multiselect v-model="controller.value.towns" :options="controller.townList" :multiple="true"
                       :close-on-select="false" :clear-on-select="false" :preserve-search="true"
                       placeholder="Выберете города" label="name" track-by="id" :preselect-first="true">
            <template slot="selection" slot-scope="{ values, search, isOpen }"><span
                class="multiselect__single" v-if="values.length" v-show="!isOpen">{{ values.length }} options selected</span>
            </template>
          </multiselect>
        </div>
        <div class="build-stat__wrap">
          <label class="build-stat-wrap__title">
            Период
          </label>
          <div class="build-stat-wrap__items">
            <div class="build-stat-items__item">
              <label>Дата начала</label>
              <input v-model="controller.value.dateStart" type="datetime-local" name="date-start" >
            </div>
            <div class="build-stat-items__item">
              <label>Дата конца</label>
              <input v-model="controller.value.dateFinis" type="datetime-local" name="date-finis">
            </div>
          </div>
        </div>
        <app-button @click="controller.make()" class="build-stat__action">
          Рассчитать
        </app-button>
      </div>
      <div class="report">
        <div class="report__row">
          <div class="report__columns">
            <div class="report__column">
              Город
            </div>
            <div class="report__column">
              Количество
            </div>
            <div class="report__column">
              Стоимость
            </div>
          </div>
        </div>
        <div v-for="report in controller.report" class="report__row">
          <div class="report__columns">
            <div class="report__column">
              {{ report.name }}
            </div>
            <div class="report__column">
              {{ report.count }}
            </div>
            <div class="report__column">
              {{ report.cost }}
            </div>
          </div>
        </div>
      </div>
    </div>
  </block>
</template>

<style scoped lang="less">
.report_page {
  .report-page__content {
    display: grid;
    grid-template-columns: 0.5fr 1fr;
    gap: 20px;
    .build-statistic {
      display: grid;
      .build-stat__title {}
      .build-stat__wrap {
        .build-stat-wrap__title {
        }
        .build-stat-wrap__item {
          margin-top: 10px;
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
    .report {
      display: flex;
      flex-direction: column;
      gap: 15px;
      .report__row {
        .report__columns {
          display: grid;
          grid-template-columns: 1fr 1fr 1fr;
          .report__column {

          }
        }
      }
    }
  }
}
</style>