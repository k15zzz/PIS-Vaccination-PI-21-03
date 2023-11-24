<script setup>
import Block from "../components/ui/Block.vue";
import InputText from "../components/ui/InputText.vue";
import {ContactController} from "../controller/ContactController.js";
import Datepicker from "../components/ui/datepicker/Datepicker.vue";
import {onBeforeMount} from "vue";
import Multiselect from 'vue-multiselect';
import AppButton from "../components/ui/AppButton.vue";
import {useRoute} from "vue-router";

const route = useRoute();

let controller = new ContactController(route.meta.mode, route.params.id);
onBeforeMount(async () => {
  await controller.load();
});
</script>

<template>
  <block class="registry">
    <router-link :to="controller.backLink"> Вернуться назад </router-link>
    <h3>Форма контракта</h3>
    <input-text 
        label="Номер"
        v-model="controller.value.number"
        :disabled="controller.disableStatus()"
    />
    <div class="registry__group-fields">
      <div>
        <label>Дата заключения</label>
        <input
            type="datetime-local"
            v-model="controller.value.startDate"
            :disabled="controller.disableStatus()"
        />
      </div>
      <div>
        <label>Дата действия</label>
        <input
            type="datetime-local"
            v-model="controller.value.endDate"
            :disabled="controller.disableStatus()"
        />
      </div>
    </div>
    <div>
      <label>Исполнитель</label>
      <multiselect
          v-if="controller.organizationList.length > 0"
          v-model="controller.value.executor"
          :options="controller.organizationList"
          :multiple="false"
          :close-on-select="true"
          placeholder="Выберите тип"
          :preselect-first="true"
          label="fullName"
          :disabled="controller.disableStatus()"
      >
        <template slot="selection" slot-scope="{ values, search, isOpen }">
                            <span class="multiselect__single" v-if="values.length" v-show="!isOpen">
                                {{ values.length }} options selected
                            </span>
        </template>
      </multiselect>
    </div>
    <div>
      <label>Заказчик</label>
      <multiselect
          v-if="controller.organizationList.length > 0"
          v-model="controller.value.client"
          :options="controller.organizationList"
          :multiple="false"
          :close-on-select="true"
          placeholder="Выберите тип"
          :preselect-first="true"
          label="fullName"
          :disabled="controller.disableStatus()"
      >
        <template slot="selection" slot-scope="{ values, search, isOpen }">
                            <span class="multiselect__single" v-if="values.length" v-show="!isOpen">
                                {{ values.length }} options selected
                            </span>
        </template>
      </multiselect>
    </div>
    <app-button
        @click="controller.sendData()" 
        v-if="!controller.disableStatus()"
        class="registry__button--green"
    >
      Отправить
    </app-button>
  </block>
</template>

<style lang="less">
.registry {
  display: grid;
  gap: 15px;
  
  .registry__group-fields {
    display: grid;
    grid-template-columns: 1fr 1fr;
  }
  .registry__button--green {
    background: var(--color-green);
  }
}
</style>