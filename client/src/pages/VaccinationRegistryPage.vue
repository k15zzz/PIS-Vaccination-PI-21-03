<script setup>
import Block from "../components/ui/Block.vue";
import ModelRegistry from "../components/ModelRegistry.vue";
import {onBeforeMount, reactive} from "vue";
import {VaccinationModel} from "../models/VaccinationModel.js";
import {VaccinationRepository} from "../repositorys/VaccinationRepository.js";

let models = reactive([])

onBeforeMount(async () => {
  Object.assign(models, await VaccinationRepository.list());
});
</script>

<template> 
  <block class="registry">
    <model-registry 
        :models="models"
        :model="VaccinationModel"
        router-create="vaccinationCreate"
        title="Реестр вакцинаций"
    />
  </block>
</template>

<style scoped lang="less"></style>