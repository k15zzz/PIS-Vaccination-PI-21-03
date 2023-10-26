<template>
    <button :class="classes" :style="{ color: color, backgroundColor: backgroundColor }">
        <component v-if="icon" :is="icon" :color="iconColor"></component>
        <slot></slot>
    </button>
</template>

<script setup>
defineProps({
    classes: {
        type: String,
        default: "btn-primary"
    },
    color: String,
    backgroundColor: String,
    icon: String,
    iconColor: String,
});
</script>

<style lang="less" scoped>
button {
    padding: 10px;
    cursor: pointer;
    border: 0;
    display: grid;
    grid-template-columns: auto 1fr;
    align-items: center;
    gap: 5px;
    font-weight: 400;
    font-size: 16px;
    color: #FFFFFF;
    border-radius: 6px;
    &.btn-primary {
        background: var(--color-primary);
    }
    &.btn-secondary {
        background: var(--color-secondary);
    }
    &.btn-danger {
        background: var(--color-danger);
    }
    &:hover {
        filter: brightness(90%);
    }
}
</style>
