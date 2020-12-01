<template>
  <div>
    <el-dialog
      :title="title"
      :visible.sync="dialogFormVisible"
      :width="width"
      top="12vh"
      @close="onDialogClose"
    >
      <slot></slot>
      <div slot="footer" class="dialog-footer">
        <el-button @click="$emit('cancel')">{{$t('genericEdit.cancel')}}</el-button>
        <el-button
          type="primary"
          :loading="btnLoading"
          @click="$emit('ok')"
        >{{$t('genericEdit.ok')}}</el-button>
      </div>
    </el-dialog>
  </div>
</template>
<script>
import ToolBar from "@/components/ToolBar";
export default {
  name: "GenericEdit",
  props: {
    title: String,
    visible: Boolean,
    width: String,
    btnLoading: Boolean,
    currentRow: [Object, Boolean]
  },
  data() {
    return {
      dialogFormVisible: this.visible
    };
  },
  watch: {
    visible(val) {
      this.dialogFormVisible = val;
    }
  },
  methods: {
    onDialogClose() {
      this.$emit("cancel");
    }
  },
  components: { ToolBar }
};
</script>
<style lang="scss" scoped>
</style>


