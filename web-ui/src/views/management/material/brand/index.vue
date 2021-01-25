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
        @row-dblclick="edit"
        @current-change="handleCurrentChange"
        element-loading-text="Loading"
        border
        fit
        stripe
        highlight-current-row
        id="table-main"
        ref="table"
        height="50"
        v-el-height-adaptive-table="{ table: $refs.table }"
      >
        <el-table-column
          align="center"
          :label="$t('genericList.no')"
          type="index"
        >
        </el-table-column>
        <el-table-column align="center" :label="$t('material.brand.code')">
          <template slot-scope="scope">{{ scope.row.code }}</template>
        </el-table-column>
        <el-table-column align="center" :label="$t('material.brand.name')">
          <template slot-scope="scope">{{ scope.row.name }}</template>
        </el-table-column>
        <el-table-column align="center" :label="$t('material.brand.desc')">
          <template slot-scope="scope">{{ scope.row.desc }}</template>
        </el-table-column>
        <el-table-column
          align="center"
          :label="$t('material.brand.modifyTime')"
        >
          <template slot-scope="scope">{{
            scope.row.modifyTime | dateformat("YYYY-MM-DD HH:mm:ss")
          }}</template>
        </el-table-column>
      </el-table>
    </GenericList>
    <GenericEdit
      :visible="editDialogVisible"
      :title="$t('material.brand.editTitle')"
      width="45%"
      @ok="edit_ok"
      @cancel="edit_cancel"
    >
      <el-form :model="form" ref="form" :rules="rules" prop="form">
        <el-form-item :label="$t('material.brand.code')" prop="code">
          <el-input
            v-model="form.code"
            ref="code"
            name="code"
            :maxlength="50"
            :disabled="this.editMode === true"
            :placeholder="$t('material.brand.codePlaceHolder')"
          ></el-input>
        </el-form-item>
        <el-form-item :label="$t('material.brand.name')" prop="name">
          <el-input
            v-model="form.name"
            ref="name"
            name="name"
            :maxlength="50"
            :placeholder="$t('material.brand.namePlaceHolder')"
          ></el-input>
        </el-form-item>
        <el-form-item :label="$t('material.brand.desc')" prop="desc">
          <el-input
            v-model="form.desc"
            ref="desc"
            name="desc"
            :maxlength="1000"
            :placeholder="$t('material.brand.descPlaceHolder')"
          ></el-input>
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
// import { exportTableToFile } from "@/utils/exportUtil";
import { downloadFile } from "@/api/file-downloader";
export default {
  components: { GenericList, GenericEdit },
  data() {
    return {
      form: {
        id: 0,
        name: "",
        code: "",
        desc: "",
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
          {
            required: true,
            trigger: "blur",
            message: this.$t("material.brand.nameIsRequired"),
          },
          {
            min: 1,
            max: 50,
            trigger: "blur",
            message: this.$t("material.brand.nameLength"),
          },
        ],
        code: [
          {
            required: true,
            trigger: "blur",
            message: this.$t("material.brand.codeIsRequired"),
          },
          {
            pattern: /^[A-Z0-9]{2,2}$/,
            message: this.$t("material.brand.codeRule"),
          },
        ],
        desc: [
          {
            min: 0,
            max: 1000,
            trigger: "blur",
            message: this.$t("material.brand.descLength"),
          },
        ],
      },
    };
  },
  watch: {
    totalRows: {
      handler: function (val) {
        debugger;
        let pageCount =
          val <= this.pageSize
            ? 1
            : val % this.pageSize === 0
            ? val / this.pageSize
            : Math.floor(val / this.pageSize) + 1;
        if (this.pageIndex > pageCount) {
          this.pageIndex = pageCount;
        }
      },
      deep: true,
    },
  },
  created() {
    this.$nextTick(() => {
      this.getData({ pageSize: this.pageSize, pageIndex: this.pageIndex });
    });
  },
  methods: {
    handleCurrentChange(current, old) {
      this.currentRow = current;
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
        pageIndex: this.pageIndex,
      };
      api
        .search(arg)
        .then((resp) => {
          this.totalRows = resp.data.totalRows;
          this.list = resp.data.items;
          this.listLoading = false;
        })
        .catch((err) => (this.listLoading = false));
    },
    add() {
      this.editMode = false;
      this.editDialogVisible = true;
      for (let k in this.form) {
        this.form[k] = "";
      }
      this.$nextTick(function () {
        this.$refs.form.clearValidate();
        this.$refs.code.focus();
      });
    },
    edit() {
      if (this.currentRow) {
        this.editMode = true;
        this.editDialogVisible = true;
        for (let k in this.form) {
          this.form[k] = this.currentRow[k];
        }
        this.$nextTick(function () {
          this.$refs.form.clearValidate();
          api.detail(this.currentRow.Id).then((resp) => {
            this.currentRow = resp.data;
          });
        });
      }
    },
    del() {
      if (this.currentRow) {
        this.$confirm(this.$t("genericList.deleteConfirm")).then(() =>
          api.del(this.currentRow.Id).then((resp) => {
            if (resp.code === 200) {
              this.getData();
            }
          })
        );
      }
    },

    exportToFile(type, keyword) {
      ////前端导出
      // var fileName = this.$route.meta.title + "." + bookType;
      // exportTableToFile(
      //   fileName,
      //   document.querySelector("#table-main"),
      //   bookType
      // );
      //后台导出
      debugger;
      var params = {};
      if (type === "page") {
        params = {
          pageSize: this.pageSize,
          pageIndex: this.pageIndex,
          keyword: keyword,
        };
      } else {
        params = {
          pagination: false,
        };
      }
      api
        .exportXls(params)
        .then((resp) => {
          downloadFile(resp.data);
        })
        .catch((err) => {
          console.log(err);
        });
    },

    search(keyword) {
      this.getData({
        pageSize: this.pageSize,
        pageIndex: this.pageIndex,
        keyword: keyword,
      });
    },
    edit_cancel() {
      this.$refs.form.clearValidate();
      this.editDialogVisible = false;
    },
    edit_ok() {
      this.$refs.form.validate((valid) => {
        if (valid) {
          if (this.editMode) {
            api.update(this.form).then((resp) => {
              if (resp.code === 200) {
                this.editDialogVisible = false;
                this.getData();
              }
            });
          } else {
            api.create(this.form).then((resp) => {
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
    generateTitle,
    downloadFile,
  },
};
</script>

