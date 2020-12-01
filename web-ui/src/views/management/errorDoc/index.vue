<template>
  <div>
    <GenericList
      visibleButtons="SR"
      :totalRecords="totalRows"
      @export-file="exportToFile"
      @search="search"
      @refresh="getData"
      @pagesize-change="handlePageSizeChange"
      @pageindex-change="handlePageIndexChange"
    >
      <el-table
        v-loading="listLoading"
        :data="list"
        element-loading-text="Loading"
        fit
        stripe
        highlight-current-row
        ref="table"
        id="table-main"
        tooltip-effect="dark"
        height="50"
        v-el-height-adaptive-table="{table: $refs.table}"
      >
        <el-table-column type="expand">
          <template slot-scope="props">
            <el-form label-position="left" inline class="table-expand">
              <el-form-item :label="$t('aplError.code')">
                <span>{{ props.row.Code }}</span>
              </el-form-item>
              <el-form-item :label="$t('aplError.explain')">
                <span>{{ props.row.ErrorRange.Message }}</span>
              </el-form-item>
              <el-form-item :label="$t('aplError.typeName')">
                <span>{{ props.row.TypeName }}</span>
              </el-form-item>
              <el-form-item :label="$t('aplError.fileName')">
                <span>{{ props.row.FileName}}</span>
              </el-form-item>
              <el-form-item :label="$t('aplError.filePath')">
                <span>{{ props.row.ErrorRange.FilePath}}</span>
              </el-form-item>
              <el-form-item :label="$t('aplError.line')">
                <span>{{ props.row.Line }}</span>
              </el-form-item>
              <el-form-item :label="$t('aplError.source')">
                <span>{{ props.row.Source }}</span>
              </el-form-item>
              <el-form-item :label="$t('aplError.comment')">
                <span>{{ props.row.Comment }}</span>
              </el-form-item>
              <!-- <el-form-item :label="$t('device.lastOnlineTime')">
                <span>{{ props.row.LastOnlineTime|dateformat('YYYY-MM-DD HH:mm:ss') }}</span>
              </el-form-item>
              <el-form-item :label="$t('device.modifyTime')">
                <span>{{ props.row.ModifyTime|dateformat('YYYY-MM-DD HH:mm:ss') }}</span>
              </el-form-item>
              <el-form-item :label="$t('device.desc')">
                <span>{{ props.row.Desc }}</span>
              </el-form-item>-->
            </el-form>
          </template>
        </el-table-column>
        <el-table-column align="left" width="55" :label="$t('genericList.no')">
          <template slot-scope="scope">{{ scope.$index+1 }}</template>
        </el-table-column>
        <el-table-column
          align="center"
          width="90"
          :label="$t('aplError.code')"
          prop="Code"
          sortable
        >
          <template slot-scope="scope">{{ scope.row.Code }}</template>
        </el-table-column>
        <el-table-column align="left" width="160" :label="$t('aplError.explain')">
          <template slot-scope="scope">{{ scope.row.ErrorRange.Message}}</template>
        </el-table-column>
        <el-table-column
          align="left"
          width="200"
          :label="$t('aplError.typeName')"
          prop="TypeName"
          sortable
        >
          <template slot-scope="scope">{{scope.row.TypeName}}</template>
        </el-table-column>
        <el-table-column
          align="left"
          width="200"
          :label="$t('aplError.fileName')"
          prop="FileName"
          sortable
        >
          <template slot-scope="scope">{{scope.row.FileName}}</template>
        </el-table-column>

        <el-table-column
          align="left"
          width="200"
          :label="$t('aplError.filePath')"
          show-overflow-tooltip
        >
          <template slot-scope="scope">{{ scope.row.ErrorRange.FilePath}}</template>
        </el-table-column>
        <el-table-column align="left" width="120" :label="$t('aplError.line')" prop="Line" sortable>
          <template slot-scope="scope">{{scope.row.Line}}</template>
        </el-table-column>
        <el-table-column
          align="left"
          width="auto"
          :label="$t('aplError.source')"
          prop="Source"
          sortable
          show-overflow-tooltip
        >
          <template slot-scope="scope">{{ scope.row.Source}}</template>
        </el-table-column>
        <el-table-column
          align="left"
          width="auto"
          :label="$t('aplError.comment')"
          show-overflow-tooltip
        >
          <template slot-scope="scope">{{ scope.row.Comment}}</template>
        </el-table-column>

        <el-table-column fixed="right" align="center" :label="$t('device.operation')" width="120">
          <template slot-scope="scope">
            <el-button
              type="primary"
              size="small"
              icon="el-icon-edit"
              circle
              @click="edit(scope.row)"
            ></el-button>
            <el-button
              type="success"
              size="small"
              icon="el-icon-view"
              circle
              @click="detail(scope.row)"
            ></el-button>
          </template>
        </el-table-column>
      </el-table>
    </GenericList>
    <GenericEdit
      :visible="editDialogVisible"
      :title="$t('aplError.editTitle')"
      width="45%"
      @ok="edit_ok"
      @cancel="edit_cancel"
    >
      <!-- <tool-bar class="border:0px">
        <el-button type="primary" icon="el-icon-d-arrow-left">上一条</el-button>
        <el-button type="primary" icon="el-icon-d-arrow-right">下一条</el-button>
      </tool-bar>-->
      <el-form
        :model="form"
        ref="form"
        prop="form"
        label-position="left"
        label-width="80px"
        size="mini"
      >
        <el-row>
          <el-col :span="12">
            <el-form-item :label="$t('aplError.code')" prop="Code">
              <template>{{form.Code}}</template>
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item :label="$t('aplError.fileName')" prop="FileName">
              <template>{{form.FileName}}</template>
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="12">
            <el-form-item :label="$t('aplError.filePath')" prop="FilePath">
              <template>{{form.ErrorRange.FilePath}}</template>
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item :label="$t('aplError.line')" prop="Line">
              <template>{{form.Line}}</template>
            </el-form-item>
          </el-col>
        </el-row>

        <el-form-item :label="$t('aplError.cnDescription')" prop="CnDescription">
          <el-input type="textarea" :rows="3" v-model="form.CnDescription"></el-input>
        </el-form-item>
        <el-form-item :label="$t('aplError.enDescription')" prop="EnDescription">
          <el-input type="textarea" :rows="3" v-model="form.EnDescription"></el-input>
        </el-form-item>
        <el-form-item :label="$t('aplError.cnSolution')" prop="CnSolution">
          <el-input type="textarea" :rows="3" v-model="form.CnSolution "></el-input>
        </el-form-item>
        <el-form-item :label="$t('aplError.enSolution')" prop="EnSolution">
          <el-input type="textarea" :rows="3" v-model="form.EnSolution"></el-input>
        </el-form-item>
      </el-form>
    </GenericEdit>
  </div>
</template>
<script>
import GenericList from "@/components/GenericList";
import GenericEdit from "@/components/GenericEdit";
import * as api from "@/api/aplError.js";
import { generateTitle } from "@/utils/i18n";
import { getLanguage } from "@/lang/index";
// import { exportTableToFile } from "@/utils/exportUtil";
import { downloadFile } from "@/api/file-downloader";
import ToolBar from "@/components/ToolBar";
import store from "@/store";
export default {
  components: { GenericList, GenericEdit, ToolBar },
  data() {
    return {
      form: {
        Id: null,
        Code: null,
        ErrorRange: { FilePath: "", Message: "" },
        FileName: "",
        Line: null,
        CnDescription: "",
        EnDescription: "",
        EnSolution: "",
        CnSolution: ""
      },
      list: null,
      listLoading: false,
      totalRows: 0,
      pageSize: 50,
      pageIndex: 1,
      editDialogVisible: false,
      currentRow: null,
      editMode: false
    };
  },
  watch:{
    totalRows: {
      handler: function(val) {
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
      deep: true
    }
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
    },

    edit(row) {
      this.currentRow = row;
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
    detail(row) {
      //  store.dispatch('aplErrorStorage/setError',row)
      window.open(`#/errorDoc/${getLanguage()}/detail/${row.Code}`);
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
.el-table__body {
  height: 100%;
}
.tbody {
  height: 100%;
}
</style>
