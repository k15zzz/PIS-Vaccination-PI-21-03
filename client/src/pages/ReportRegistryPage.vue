<script setup>
import Block from "../components/ui/Block.vue";
import ModelRegistry from "../components/ModelRegistry.vue";
import {onBeforeMount, reactive} from "vue";
import {VaccinationModel} from "../models/VaccinationModel.js";
import {ReportRepository} from "../repositorys/ReportRepository.js";
import {ReportModel} from "../models/ReportModel.js";

let models = reactive([])

onBeforeMount(async () => {
  Object.assign(models, await ReportRepository.list());
});
</script>

<template>
  <block class="registry">
    <model-registry
        :models="models"
        :model="ReportModel"
        router-create="reportCreate"
        title="Реестр отчетов"
    />
  </block>
</template>

<style scoped lang="less"></style>