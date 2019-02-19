<template>
    <Select
        v-model="contracts"
        multiple
        filterable
        remote
        :remote-method="remoteMethod"
        :loading="loading">
        <Option v-for="(option, index) in contracts" :value="option.value" :key="index">{{option.label}}</Option>
    </Select>    
</template>

<script>
export default {
    data() {
        return {
            selected: [],
            contracts: [],
            loading: false
        }
    },
    methods: {
        remoteMethod(query) {
            if (query !== '') {
                this.loading = true;
                
            } else {
                this.options = [];
            }            
        }
    }
}
</script>

<style>

</style>
