<script setup>
import {ReportController} from "../controller/ReportController.js";
import AppButton from "../components/ui/AppButton.vue";
import Block from "../components/ui/Block.vue";
import {onBeforeMount, reactive} from "vue";
import Multiselect from 'vue-multiselect';
import {useRoute} from "vue-router";

const route = useRoute();

const controller = new ReportController(route.meta.mode, route.params.id);
onBeforeMount(async () => {
  await controller.load();
});
</script>

<template>
  <block class="report_page">
    <router-link :to="controller.backLink"> Вернуться назад </router-link>
    <h3 class="report-page__title">
      Статистика
    </h3>
    <div class="report-page__content">
      <div class="build-statistic">
        <div class="build-stat__wrap">
          <label>Статус отчета</label>
          <multiselect
              v-if="controller.statusList.length > 0"
              v-model="controller.value.status"
              :options="controller.statusList"
              :multiple="false"
              :close-on-select="true"
              placeholder="Выберите тип"
              :preselect-first="true"
              label="name"
              :disabled="controller.disableStatus()"

          >
            <template slot="selection" slot-scope="{ values, search, isOpen }">
                            <span class="multiselect__single" v-if="values.length" v-show="!isOpen">
                                {{ values.length }} options selected
                            </span>
            </template>
          </multiselect>
        </div>
        <div class="build-stat__wrap">
          <label class="build-stat-wrap__title">Исполнитель</label>
          <multiselect v-model="controller.value.towns" :disabled="controller.disableStatus()" :options="controller.townList" :multiple="true"
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
              <input v-model="controller.value.dateStart" :disabled="controller.disableStatus()" type="datetime-local" name="date-start" > 
            </div>
            <div class="build-stat-items__item">
              <label>Дата конца</label>
              <input v-model="controller.value.dateFinis" :disabled="controller.disableStatus()" type="datetime-local" name="date-finis">
            </div>
          </div>
        </div>
        <app-button @click="controller.make()"  v-if="!controller.disableStatus()" class="build-stat__action">
          Рассчитать
        </app-button>
        <app-button @click="controller.sendData()"  v-if="!controller.disableStatus()" class="build-stat__action">
          Рассчитать и сохранить
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