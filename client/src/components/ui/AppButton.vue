<template>
    <button :style="{
        backgroundColor: disabled ?  backgroundColor : '#FFFFFF',
        color: disabled ?  color : '#52616B',
        cursor: !disabled ? 'default' : 'pointer'
    }">
        <slot></slot>
    </button>
</template>

<script setup>
defineProps({
    backgroundColor: String,
    color: String,
    disabled: {
        type: Boolean,
        default: true
    }
});
</script>

<style>
button {
    padding: 10px;
    cursor: pointer;
    border: 0;
    border-radius: 5px;
    text-align: center;
    display: flex;
    justify-content: center;
    align-items: center;
    font-weight: 400;
    font-size: 16px;
    color: #FFFFFF;
    transition: 0.3s all;
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
