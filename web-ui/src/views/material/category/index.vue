<!--物料类型-->
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
      :title="$t('material.categoryEdit')"
      width="45%"
      @ok="edit_ok"
      @cancel="edit_cancel"
    >
      <el-form :model="form" ref="form" :rules="rules" label-position="right" label-width="80px">
        <el-row>
          <el-col :span="12">
            <el-form-item :label="$t('material.name')" prop="name">
              <el-input v-model="form.name" ref="name"></el-input>
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item :label="$t('material.code')" prop="code">
              <el-input v-model="form.code" ref="code" :disabled="this.editMode===true"></el-input>
            </el-form-item>
          </el-col>
        </el-row>
        <el-form-item :label="$t('material.desc')">
          <el-input v-model="form.desc" ref="desc"></el-input>
        </el-form-item>
      </el-form>
      <el-card class="box-card" shadow="never">
        <div slot="header" class="clearfix">
          <span>{{$t('material.category.config.title')}}</span>
          <el-button
            style="float: right; padding: 3px 0"
            type="text"
            @click="addConfig"
          >{{$t('material.category.config.add')}}</el-button>
        </div>
        <el-form ref="configForm" :rules="config.rules" :model="form">
          <el-table
            :data="form.configs"
            element-loading-text="Loading"
            border
            fit
            :height="300"
            highlight-current-row
            id="table-main"
          >
            <el-table-column align="center" :label="$t('material.category.config.key')">
              <template slot-scope="scope">
                <el-form-item
                  :prop="'configs.'+scope.$index+'.configKey'"
                  :rules="config.rules.notEmpty"
                >
                  <el-input size="small" v-model="scope.row.configKey">{{ scope.row.id }}</el-input>
                </el-form-item>
              </template>
            </el-table-column>
            <el-table-column align="center" :label="$t('material.category.config.desc')">
              <template slot-scope="scope">
                <el-form-item
                  :prop="'configs.'+scope.$index+'.configKeyDesc'"
                  :rules="config.rules.notEmpty"
                >
                  <el-input size="small" v-model="scope.row.configKeyDesc"></el-input>
                </el-form-item>
              </template>
            </el-table-column>
            <el-table-column align="center" :label="$t('material.category.config.type')">
              <template slot-scope="scope">
                <el-form-item :prop="'type'">
                  <el-select size="small" v-model="scope.row.configValueType" value-key="code">
                    <el-option
                      v-for="item in valueTypes"
                      :key="item.code"
                      :label="item.name"
                      :value="item.code"
                    ></el-option>
                  </el-select>
                </el-form-item>
              </template>
            </el-table-column>
            <el-table-column align="center" :label="$t('material.category.config.defaultValue')">
              <template slot-scope="scope">
                <el-form-item
                  :prop="'configs.'+scope.$index+'.configDefaultValue'"
                  :rules="config.rules.notEmpty"
                >
                  <el-input size="small" v-model="scope.row.configDefaultValue"></el-input>
                </el-form-item>
              </template>
            </el-table-column>
            <!-- <el-table-column align="center" :label="$t('material.category.config.required')">
              <template slot-scope="scope">
                <el-checkbox size="small" v-model="scope.row.required"></el-checkbox>
              </template>
            </el-table-column>-->
            <el-table-column align="center" :label="$t('material.category.config.operation')">
              <template slot-scope="scope">
                <!-- <el-button type="primary" icon="el-icon-edit" size="small" circle></el-button> -->
                <el-button
                  type="danger"
                  icon="el-icon-delete"
                  size="small"
                  circle
                  @click="delConfig(scope.$index)"
                ></el-button>
              </template>
            </el-table-column>
          </el-table>
        </el-form>
      </el-card>
    </GenericEdit>
  </div>
</template>

<script>
import GenericList from "@/components/GenericList";
import GenericEdit from "@/components/GenericEdit";
import * as api from "@/api/materialCategory.js";
import { generateTitle } from "@/utils/i18n";
import { findLookup } from "@/api/lookup.js";
import { exportTableToFile } from "@/utils/exportUtil";
export default {
  components: { GenericList, GenericEdit },
  data() {
    return {
      form: {
        id: "",
        name: "",
        code: "",
        desc: "",
        configs: []
      },
      list: null,
      totalRows: 0,
      pageSize: 50,
      pageIndex: 1,
      valueTypes: [],
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
      },
      config: {
        rules: {
          notEmpty: [
            {
              required: true,
              message: this.$t("common.fieldRequired"),
              trigger: "blur"
            }
          ]
        }
      }
    };
  },
  created() {
    this.$nextTick(() => {
      this.findLookup("config_value_type").then(resp => {
        this.valueTypes = resp.data;
        if (this.valueTypes && this.valueTypes.length > 0) {
          this.configValueType = this.valueTypes[0];
        }
      });
      this.getData();
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
    addConfig() {
      if (!this.form.configs) {
        this.form.configs = [];
      }
      this.form.configs.push({
        id: null,
        configKey: "",
        configKeyDesc: "",
        configValueType: "10",
        configDefaultValue: "",
        required: true
      });
    },
    delConfig(index) {
      this.form.configs.splice(index, 1);
    },
    handleSelectionChange(row) {
      this.currentRow = row;
    },
    getData(params) {
      this.listLoading = true;
      var arg = params || {
        pageSize: this.pageSize,
        pageIndex: this.pageIndex
      };
      api
        .search(arg)
        .then(resp => {
          this.list = resp.data.items;
          this.totalRows = resp.data.totalRows;
          this.listLoading = false;
        })
        .catch(err => (this.listLoading = false));
    },
    add() {
      this.editMode = false;
      this.editDialogVisible = true;
      this.form.configs = [];
      for (let k in this.form) {
        this.form[k] = null;
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
          this.$refs.configForm.validate(v => {
            if (v) {
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
            }
          });
        } else {
          console.log("error submit!!");
          return false;
        }
      });
    },
    generateTitle,
    findLookup
  }
};
</script>

<style scoped>
.tb-edit .el-input {
  display: none;
}
.tb-edit .current-row .el-input {
  display: block;
}
.tb-edit .current-row .el-input + span {
  display: none;
}
</style>
