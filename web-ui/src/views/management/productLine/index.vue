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
        v-loading="listLoading" :data="list"
        element-loading-text="Loading"
        fit
        stripe
        highlight-current-row
        id="table-main"
        ref="table"
        height="50"
        v-el-height-adaptive-table="{table: $refs.table}">
        <el-table-column align="left" width="100" :label="$t('genericList.no')">
          <template slot-scope="scope">{{ scope.$index+1 }}</template>
        </el-table-column>
        <el-table-column align="center" width="250" :label="$t('productline.ProductLineCode')" prop="ProductLineCode">
            <template slot-scope="scope">{{ scope.row.ProductLineCode }}</template>
        </el-table-column>
        <el-table-column align="left" width="300" :label="$t('productline.ProductLineName')" prop="ProductLineName">
          <template slot-scope="scope">{{ scope.row.ProductLineName }}</template>
        </el-table-column>
        <el-table-column align="left" width="250" :label="$t('productline.LaboratoryCode')" prop="LaboratoryCode">
          <template slot-scope="scope">{{ scope.row.LaboratoryCode }}</template>
        </el-table-column>
        <el-table-column align="left" width="200" :label="$t('productline.ProductLineStatus')" prop="ProductLineStatus" sortable>
          <template slot-scope="scope">{{ scope.row.ProductLineStatus}}</template>
        </el-table-column>
        <el-table-column align="left" width="250" :label="$t('productline.ModifyUserName')" prop="ModifyUserName">
          <template slot-scope="scope">{{ scope.row.ModifyUserName }}</template>
        </el-table-column>
        <el-table-column align="left" width="200" :label="$t('productline.ModifyTime')" prop="ModifyTime" sortable>
          <template slot-scope="scope">{{ scope.row.ModifyTime|dateformat('YYYY-MM-DD HH:mm:ss')}}</template>
        </el-table-column>

         <el-table-column align="left" width="250" :label="$t('productline.CreateUserName')" prop="CreateUserName">
          <template slot-scope="scope">{{ scope.row.CreateUserName }}</template>
        </el-table-column>
        <el-table-column align="left" width="200" :label="$t('productline.CreateTime')" prop="CreateTime" sortable>
          <template slot-scope="scope">{{ scope.row.CreateTime|dateformat('YYYY-MM-DD HH:mm:ss')}}</template>
        </el-table-column>
        
        <el-table-column align="left" width="150" :label="$t('productline.Operation')">
        <template slot-scope="scope">
          <router-link :to="{path:'/details/index',query:{id:scope.row.Id},}">{{$t('productline.UpdateLine')}}</router-link>
        </template>
        </el-table-column>
      </el-table>
    </GenericList>
     <GenericEdit
      :visible="editDialogVisible"
      :title="$t('device.editTitle')"
      width="45%"
      @ok="edit_ok"
      @cancel="edit_cancel"
    >
      <el-form :model="form" ref="form" prop="form" :rules="rules">
        <el-form-item :label="$t('productline.ProductLineCode')" prop="ProductLineCode">
          <el-input
            v-model="form.ProductLineCode"
            ref="ProductLineCode"
            name="ProductLineCode"
            :maxlength="50"
            :placeholder="$t('productline.ProductLineCode')"
          ></el-input>
        </el-form-item>

        <el-form-item :label="$t('productline.ProductLineName')" prop="ProductLineName">
          <el-input
            v-model="form.ProductLineCode"
            ref="ProductLineName"
            name="ProductLineName"
            :maxlength="50"
            :placeholder="$t('productline.ProductLineName')"
          ></el-input>
        </el-form-item>

        <el-form-item :label="$t('productline.LaboratoryCode')" prop="LaboratoryCode">
          <el-input
            v-model="form.ProductLineCode"
            ref="LaboratoryCode"
            name="LaboratoryCode"
            :maxlength="50"
            :placeholder="$t('productline.LaboratoryCode')"
          ></el-input>
        </el-form-item>

        <el-form-item :label="$t('productline.LaboratoryName')" prop="LaboratoryName">
          <el-input
            v-model="form.ProductLineCode"
            ref="LaboratoryName"
            name="LaboratoryName"
            :maxlength="50"
            :placeholder="$t('productline.LaboratoryName')"
          ></el-input>
        </el-form-item>
        <el-form-item :label="$t('productline.ProductLineStatus')" prop="ProductLineStatus">
          <el-radio v-model="form.ProductLineStatus" :label="1">启用</el-radio>
          <el-radio v-model="form.ProductLineStatus" :label="0">禁用</el-radio>
        </el-form-item>

      </el-form>
    </GenericEdit>
  </div>
</template>
<script>
import GenericList from "@/components/GenericList";
import GenericEdit from "@/components/GenericEdit";
import * as api from "@/api/aplproductline.js";
import { generateTitle } from "@/utils/i18n";
import { downloadFile } from "@/api/file-downloader";
export default {
  components: { GenericList,GenericEdit},
  data() {
    return {
      form: {
        ProductLineCode:""
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
        filters:{
          formatDate(time){
            if(time)
            {
               let date = new Date(time)
               return formatDate(date, 'YYYY-MM-DD HH:mm:ss');
            }else
            {
              return '';
            }
          }
        }
      }
    };
  },
  created() {
    this.$nextTick(() => {
      this.getData({ pageSize: this.pageSize, pageIndex: this.pageIndex });
    });
  },
  methods: {
    handleSelectionChange(row) {
      api.detail(row.Id).then(resp => {
        this.currentRow = resp.Data;
      });
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
          this.totalRows = resp.Data.TotalRows;
          this.list = resp.Data.Items;
          this.listLoading = false;
        })
        .catch(err => (this.listLoading = false));
    },
    search(keyword) {
      this.getData({
        pageSize: this.pageSize,
        pageIndex: this.pageIndex,
        keyword: keyword
      });
    },
     add() {
      this.editMode = false;
      this.editDialogVisible = true;
      for (let k in this.form) {
        this.form[k] = "";
      }
      this.$nextTick(function() {
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
        this.$nextTick(function() {
          this.$refs.form.clearValidate();
          api.detail(this.currentRow.Id).then(resp => {
            this.currentRow = resp.Data;
          });
        });
      }
    },
    del() {
      if (this.currentRow) {
        this.$confirm(this.$t("genericList.deleteConfirm")).then(() =>
          api.del(this.currentRow.Id).then(resp => {
            if (resp.Code === 200) {
              this.getData();
            }
          })
        );
      }
    },
    exportToFile(type, keyword) {
      //后台导出
      var params = {};
      if (type === "page") {
        params = {
          pageSize: this.pageSize,
          pageIndex: this.pageIndex,
          keyword: keyword
        };
      } else {
        params = {
          pagination: false
        };
      }
      api
        .exportXls(params)
        .then(resp => {
          downloadFile(resp.Data);
        })
        .catch(err => {
          console.log(err);
        });
    }, edit(row) {
      this.currentRow = row;
      if (this.currentRow) {
        this.robotPaths = api.getRobotPaths(this.formatArea(row.Area));
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
    edit_cancel() {
      this.$refs.form.clearValidate();
      this.editDialogVisible = false;
    },
    edit_ok() {
      this.$refs.form.validate(valid => {
        if (valid) {
          if (this.editMode) {
            api.update(this.form).then(resp => {
              if (resp.Code === 200) {
                this.editDialogVisible = false;
                this.getData();
              }
            });
          } else {
            api.create(this.form).then(resp => {
              if (resp.Code === 200) {
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
  },
  filters:{
  }
};
</script>

<style>
.table-expand {
  font-size: 0;
}
.table-expand label {
  width: 100px;
  color: #99a9bf;
}
.table-expand .el-form-item {
  margin-right: 0;
  margin-bottom: 0;
  width: 50%;
}
</style>
