<template>
    <div id="tab-bar">
        <slot></slot>       
    </div>
</template>
<script>
export default {
    name:'toolbar'
}
</script>
<style scoped>
#tab-bar{
    display: flex;
    height: 49px;
    position: fixed;
    background-color:#f6f6f6;
    bottom:0;
    left:0;
    right:0;
    /* border-top:1px solid red; */
    box-shadow: 0 -3px 1px rgba(100, 100, 100,.05);
}

</style>