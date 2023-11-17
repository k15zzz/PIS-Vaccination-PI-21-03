<script setup>
import Block from "../components/ui/Block.vue";
import ModelRegistry from "../components/ModelRegistry.vue";
import {onBeforeMount, reactive} from "vue";
import {OrganizationRepository} from "../repositorys/OrganizationRepository.js";
import {OrganizationModel} from "../models/OrganizationModel.js";

let models = reactive([])

onBeforeMount(async () => {
  Object.assign(models, await OrganizationRepository.list());
});
</script>

<template>
  <block class="registry">
    <model-registry
        :models="models"
        :model="OrganizationModel"
    />
  </block>
</template>

<style scoped lang="less"></style>