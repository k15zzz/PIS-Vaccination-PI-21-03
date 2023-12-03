<script setup>
import Block from "../components/ui/Block.vue";
import {onBeforeMount} from "vue";
import InputText from "../components/ui/InputText.vue";
import Multiselect from "vue-multiselect";
import Datepicker from "../components/ui/datepicker/Datepicker.vue";
import AppButton from "../components/ui/AppButton.vue";
import AppTextarea from "../components/ui/AppTextarea.vue";
import CheckBox from "../components/ui/CheckBox.vue";
import InputCheckbox from "../components/ui/InputCheckbox.vue";
import {useRoute} from "vue-router";
import {LogReaderController} from "../controller/LogReaderController.js";

const route = useRoute()

const controller = new LogReaderController(route.meta.mode, route.params.id);
onBeforeMount(async () => {
  await controller.load();
});
</script>

<template>
  <block class="registry">
    <router-link :to="controller.backLink"> Вернуться назад </router-link>
    <div>
      <h3>ФИО пользователя</h3>
        <label>Фамилия</label>>
      <input-text
          label="Фамилия"
          v-model="controller.value.surname"
          :disabled="controller.disableStatus()"
      />
      <div>
        <label>Имя</label>
        <input-text
          label="Имя"
          v-model="controller.value.name"
          :disabled="controller.disableStatus()"
      />
      </div>
      <div>
        <label>Отчество</label>
        <input-text
            label="Отчество"
            v-model="controller.value.patronymic"
            :disabled="controller.disableStatus()"
        />
      </div>
    </div>
    <div>
      <h3>Контактная информация</h3>
      <div>
        <input-text
            label="Телефон"
            type="number"
            v-model="controller.value.phone"
            :disabled="controller.disableStatus()"
        />
      </div>
      <input-text
          label="Электронная почта"
          :disabled="controller.disableStatus()"
          v-model="controller.value.email"
      />
    </div>
    <div>
      <label>Место работы, должность</label>
    <input-text
        label="Организация"
        :disabled="controller.disableStatus()"
        v-model="controller.value.organization"
    />
    <app-textarea
        label="Должность"
        :disabled="controller.disableStatus()"
        v-model="controller.value.position"
    />
      <input-text
          label="Рабочий телефон"
          type="number"
          v-model="controller.value.work_phone"
          :disabled="controller.disableStatus()"
      />
      <input-text
          label="Рабочий email"
          type="number"
          v-model="controller.value.work_email"
          :disabled="controller.disableStatus()"
      />
      <input-text
          label="Логин"
          v-model="controller.value.login"
          :disabled="controller.disableStatus()"
      />
      <input-text
          label="Дата и время"
          type="datetime-local"
          v-model="controller.value.date_time"
          :disabled="controller.disableStatus()"
      />
      <input-text
          label="ID экземпляра объекта"
          type="number"
          v-model="controller.value.object_instance_id"
          :disabled="controller.disableStatus()"
      />
      <input-text
          label="Описание объекта после изменений"
          v-model="controller.value.object_description_after_action"
          :disabled="controller.disableStatus()"
      />
      
    </div>
   
  </block>
</template>

<style scoped lang="less">

</style>