<!--物料品牌-->
<template>
  <div>
    <GenericList
      visibleButtons="NMSRDE"
      :totalRecords="totalRows"
      @add="add"
      @edit="edit"
      @delete="del"
      @export-file="exportToFile"
      @search="search"
      @refresh="getData"
      @pagesize-change="handlePageSizeChange"
      @pageindex-change="handlePageIndexChange"
    >
      <el-table
        v-loading="listLoading"
        :data="list"
        @row-click="handleSelectionChange"
        @row-dblclick="edit"
        element-loading-text="Loading"
        border
        fit
        stripe
        highlight-current-row
        id="table-main"
      >
        <el-table-column align="center" :label="$t('common.id')">
          <template slot-scope="scope">{{ scope.$index+1 }}</template>
        </el-table-column>
        <el-table-column align="center" :label="$t('common.name')">
          <template slot-scope="scope">{{ scope.row.name }}</template>
        </el-table-column>
        <el-table-column align="center" :label="$t('material.code')">
          <template slot-scope="scope">{{ scope.row.code }}</template>
        </el-table-column>
        <el-table-column align="center" :label="$t('material.desc')">
          <template slot-scope="scope">{{ scope.row.desc }}</template>
        </el-table-column>
      </el-table>
    </GenericList>
    <GenericEdit
      :visible="editDialogVisible"
      :title="$t('material.brandEdit')"
      width="45%"
      @ok="edit_ok"
      @cancel="edit_cancel"
    >
      <el-form :model="form" ref="form" :rules="rules" prop="form">
        <el-form-item :label="$t('material.name')" prop="name">
          <el-input v-model="form.name" ref="name" name="name"></el-input>
        </el-form-item>
        <el-form-item :label="$t('material.code')" prop="code">
          <el-input v-model="form.code" ref="code" name="code" :disabled="this.editMode===true"></el-input>
        </el-form-item>
        <el-form-item :label="$t('material.desc')" prop="desc">
          <el-input v-model="form.desc" ref="desc" namee="desc"></el-input>
        </el-form-item>
      </el-form>
    </GenericEdit>
  </div>
</template>

<script>
import GenericList from "@/components/GenericList";
import GenericEdit from "@/components/GenericEdit";
import * as api from "@/api/materialBrand.js";
import { generateTitle } from "@/utils/i18n";
import { exportTableToFile } from "@/utils/exportUtil";

export default {
  components: { GenericList, GenericEdit },
  data() {
    return {
      form: {
        id: "",
        name: "",
        code: "",
        desc: ""
      },
      list: null,
      totalRows: 0,
      pageSize: 50,
      pageIndex: 1,
      listLoading: true,
      editDialogVisible: false,
      currentRow: null,
      editMode: false,
      rules: {
        name: [
          { required: true, trigger: "blur" },
          { min: 1, max: 20, trigger: "blur" }
        ],
        code: [
          { required: true, trigger: "blur" },
          { min: 2, max: 2, trigger: "blur" }
        ]
      }
    };
  },
  created() {
    this.$nextTick(() => {
      this.getData({ pageSize: this.pageSize, pageIndex: this.pageIndex });
    });
  },
  watch: {
    currentRow: {
      handler: function() {
        if (this.currentRow) {
          for (let k in this.form) {
            this.form[k] = this.currentRow[k];
          }
        }
      },
      deep: true
    }
  },
  methods: {
    handleSelectionChange(row) {
      this.currentRow = row;
    },
    handlePageSizeChange(pageSize) {
      this.pageSize = pageSize;
      this.$nextTick(() => {
        this.getData({ pageSize: pageSize, pageIndex: this.pageIndex });
      });
    },
    handlePageIndexChange(pageIndex) {
      this.pageIndex = pageIndex;
      this.$nextTick(() => {
        this.getData({ pageSize: this.pageSize, pageIndex: pageIndex });
      });
    },
    getData(params) {
      this.listLoading = true;
      const arg = params || {
        pageSize: this.pageSize,
        pageIndex: this.pageIndex
      };
      api
        .search(arg)
        .then(resp => {
          this.totalRows = resp.data.totalRows;
          this.list = resp.data.items;
          this.listLoading = false;
        })
        .catch(err => (this.listLoading = false));
    },
    add() {
      this.editMode = false;
      this.editDialogVisible = true;
      for (let k in this.form) {
        this.form[k] = "";
      }
      this.$nextTick(function() {
        this.$refs.form.clearValidate();
        this.$refs.name.focus();
      });
    },
    edit() {
      if (this.currentRow) {
        this.editMode = true;
        this.editDialogVisible = true;
        this.editMode = true;
        for (let k in this.form) {
          this.form[k] = this.currentRow[k];
        }
        this.$nextTick(function() {
          this.$refs.form.clearValidate();
        });
      }
    },
    del() {
      if (this.currentRow) {
        this.$confirm(this.$t("common.deleteConfirm")).then(() =>
          api.del(this.currentRow.id).then(resp => {
            if (resp.code === 200) {
              this.getData();
            }
          })
        );
      }
    },

    exportToFile(bookType) {
      var fileName = this.$route.meta.title + "." + bookType;
      exportTableToFile(
        fileName,
        document.querySelector("#table-main"),
        bookType
      );
    },

    search(keyword) {
      this.getData({
        pageSize: this.pageSize,
        pageIndex: this.pageIndex,
        keyword: keyword
      });
    },
    edit_cancel() {
      this.$refs.form.clearValidate();
      this.editDialogVisible = false;
    },
    edit_ok() {
      this.$refs.form.validate(valid => {
        if (valid) {
          if (this.editMode) {
            api.update(this.form).then(resp => {
              if (resp.code === 200) {
                this.editDialogVisible = false;
                this.getData();
              }
            });
          } else {
            api.create(this.form).then(resp => {
              if (resp.code === 200) {
                this.editDialogVisible = false;
                this.getData();
              }
            });
          }
        } else {
          console.log("error submit!!");
          return false;
        }
      });
    },
    generateTitle
  }
};
</script>

