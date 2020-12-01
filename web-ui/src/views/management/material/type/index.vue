<!--物料-->
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
        stripe
        highlight-current-row
        id="table-main"
        ref="table"
        height="50"
        v-el-height-adaptive-table="{table: $refs.table}"
      >
        <el-table-column align="center" :label="$t('genericList.no')">
          <template slot-scope="scope">{{ scope.$index+1 }}</template>
        </el-table-column>
        <el-table-column align="center" :label="$t('material.type.code')">
          <template slot-scope="scope">{{ scope.row.Code }}</template>
        </el-table-column>
        <el-table-column align="center" :label="$t('material.type.name')">
          <template slot-scope="scope">{{ scope.row.Name }}</template>
        </el-table-column>
        <el-table-column align="center" :label="$t('material.type.category')">
          <template slot-scope="scope">{{ scope.row.CategoryName }}</template>
        </el-table-column>
        <el-table-column align="center" :label="$t('material.type.desc')">
          <template slot-scope="scope">{{ scope.row.Desc }}</template>
        </el-table-column>
        <el-table-column align="center" :label="$t('material.type.modifyTime')">
          <template slot-scope="scope">{{ scope.row.ModifyTime|dateformat('YYYY-MM-DD HH:mm:ss') }}</template>
        </el-table-column>
      </el-table>
    </GenericList>

    <GenericEdit
      :visible="editDialogVisible"
      :title="$t('material.type.editTitle')"
      width="45%"
      @ok="edit_ok"
      @cancel="edit_cancel"
    >
      <el-form :model="form" ref="form" label-position="right" label-width="80px">
        <el-row>
          <el-col :span="8">
            <el-form-item :label="$t('material.type.code')" prop="Code" :rules="rules.Code">
              <el-input
                v-model="form.Code"
                ref="Code"
                :maxlength="50"
                :disabled="this.editMode===true"
                :placeholder="$t('material.type.codePlaceHolder')"
              ></el-input>
            </el-form-item>
          </el-col>
          <el-col :span="8">
            <el-form-item :label="$t('material.type.name')" prop="Name" :rules="rules.Name">
              <el-input
                v-model="form.Name"
                ref="Name"
                :maxlength="50"
                :placeholder="$t('material.type.namePlaceHolder')"
              ></el-input>
            </el-form-item>
          </el-col>
          <el-col :span="8">
            <el-form-item
              :label="$t('material.materialList.category')"
              prop="CategoryId"
              :rules="rules.CategoryId"
            >
              <el-select
                size="small"
                v-model="form.CategoryId"
                :disabled="this.editMode===true"
                style="width:100%"
                :placeholder="$t('material.type.categoryRequired')"
              >
                <el-option
                  v-for="item in categories"
                  :key="item.Id"
                  :label="item.Name"
                  :value="item.Id"
                ></el-option>
              </el-select>
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col>
            <el-form-item :label="$t('material.type.desc')">
              <el-input
                v-model="form.Desc"
                ref="desc"
                :maxlength="1000"
                :placeholder="$t('material.type.descPlaceHolder')"
              ></el-input>
            </el-form-item>
          </el-col>
        </el-row>
      </el-form>
      <el-card class="box-card" shadow="never">
        <div slot="header" class="clearfix">
          <div slot="header" class="clearfix">
            <span>{{$t('material.category.config.title')}}</span>
            <el-checkbox
              v-if="editMode"
              v-model="form.OverrideMaterialConfigs"
              style="float: right; padding: 0 0"
            >{{$t('material.category.config.overrideMaterialConfigs')}}</el-checkbox>
          </div>
        </div>
        <el-form ref="configForm" :rules="config.rules" :model="form">
          <el-table
            :data="form.Configs"
            :height="320"
            element-loading-text="Loading"
            border
            fit
            highlight-current-row
            id="table-main"
            size="small"
            :row-style="{height:'40px'}"
          >
            <el-table-column align="center" :label="$t('genericList.no')" type="index" width="50px"></el-table-column>
            <el-table-column align="center" :label="$t('material.category.config.key')">
              <template slot-scope="scope">{{scope.row.ConfigKey}}</template>
            </el-table-column>
            <el-table-column align="center" :label="$t('material.category.config.desc')">
              <template slot-scope="scope">{{scope.row.ConfigKeyDesc}}</template>
            </el-table-column>
            <el-table-column align="center" :label="$t('material.category.config.type')">
              <template slot-scope="scope">{{scope.row.ConfigValueType|formatValueType}}</template>
            </el-table-column>
            <!-- <el-table-column align="center" :label="$t('material.category.config.required')">
            <template slot-scope="scope">
              <el-checkbox :disabled="true" size="small" v-model="scope.row.required"></el-checkbox>
            </template>
            </el-table-column>-->
            <el-table-column align="center" :label="$t('material.category.config.defaultValue')">
              <template slot-scope="scope">
                <!-- <el-form-item
                  :prop="'Configs.'+scope.$index+'.ConfigDefaultValue'"
                  :rules="config.rules.notEmpty"
                  style="height:50px"
                >-->
                <el-input
                  size="small"
                  v-model="scope.row.ConfigDefaultValue"
                  v-if="scope.row.ConfigValueType==='10'"
                  :maxlength="50"
                ></el-input>
                <el-input-number
                  size="small"
                  v-model="scope.row.ConfigDefaultValue"
                  controls-position="right"
                  :precision="2"
                  v-if="scope.row.ConfigValueType==='20'"
                ></el-input-number>
                <!-- </el-form-item> -->
              </template>
            </el-table-column>
            <el-table-column align="center" :label="$t('material.type.desc')">
              <template slot-scope="scope">{{scope.row.Remark}}</template>
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
import * as api from "@/api/materialType.js";
import { generateTitle } from "@/utils/i18n";
// import { exportTableToFile } from "@/utils/exportUtil";
import { downloadFile } from "@/api/file-downloader";
import * as categoryApi from "@/api/materialCategory.js";
export default {
  components: { GenericList, GenericEdit },
  data() {
    return {
      form: {
        Id: "",
        Name: "",
        Code: "",
        Desc: "",
        CategoryId: -1,
        CategoryName: "",
        OverrideMaterialConfigs: false
      },
      categories: [],
      list: null,
      totalRows: 0,
      pageSize: 50,
      pageIndex: 1,
      listLoading: true,
      editDialogVisible: false,
      currentRow: null,
      editMode: false,
      rules: {
        Name: [
          {
            required: true,
            trigger: "blur",
            message: this.$t("material.category.nameIsRequired")
          },
          {
            min: 1,
            max: 50,
            trigger: "blur",
            message: this.$t("material.type.nameLength")
          }
        ],
        Code: [
          {
            required: true,
            trigger: "blur",
            message: this.$t("material.type.codeIsRequired")
          },
          {
            pattern: /^[A-Z0-9]{2,2}$/,
            message: this.$t("material.type.codeRule")
          }
        ],
        Desc: [
          {
            min: 0,
            max: 1000,
            trigger: "blur",
            message: this.$t("material.type.nameLength")
          }
        ],
        CategoryId: [
          {
            required: true,
            trigger: "change",
            message: this.$t("material.type.categoryRequired")
          }
        ]
      },
      config: {
        rules: {
          notEmpty: [
            {
              required: true,
              message: this.$t("genericEdit.fieldRequired"),
              trigger: "blur"
            }
          ]
        }
      }
      // tableHeight: 50
    };
  },
  computed: {
    category() {
      return this.form.CategoryId;
    }
  },
  watch: {
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
  // mounted: function() {
  //   this.$nextTick(function() {
  //     this.tableHeight =
  //       window.innerHeight - this.$refs.table.$el.offsetTop - 50;

  //     // 监听窗口大小变化
  //     let self = this;
  //     window.onresize = function() {
  //       self.tableHeight =
  //         window.innerHeight - self.$refs.table.$el.offsetTop - 50;
  //     };
  //   });
  //   //this.$refs.table.$el.offsetTop：表格距离浏览器的高度 //50表示你想要调整的表格距离底部的高度（你可以自己随意调整），因为我们一般都有放分页组件的，所以需要给它留一个高度
  // },
  created() {
    this.$nextTick(() => {
      categoryApi.search({}).then(resp => {
        this.categories = resp.Data.Items;
      });
      this.getData();
    });
  },
  watch: {
    category: {
      handler: function(val) {
        if (val) {
          let category = this.categories.filter(x => x.Id === val)[0];
          this.form.CategoryName = category.Name;
          if (!this.editMode) {
            this.form.Configs = [];
            //加载 对应类型的配置参数
            for (let c of category.Configs) {
              this.form.Configs.push(c);
            }
          }
        }
      },
      deep: true
    }
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
      var arg = params || {
        pageSize: this.pageSize,
        pageIndex: this.pageIndex
      };
      api
        .search(arg)
        .then(resp => {
          this.list = resp.Data.Items;
          this.totalRows = resp.Data.TotalRows;
          this.listLoading = false;
        })
        .catch(err => (this.listLoading = false));
    },
    add() {
      this.editMode = false;
      this.editDialogVisible = true;
      for (let k in this.form) {
        this.form[k] = null;
      }
      this.form.Configs = [];
      this.$nextTick(function() {
        this.$refs.form.clearValidate();
        this.$refs.Name.focus();
      });
    },
    edit() {
      if (this.currentRow) {
        this.editMode = true;
        this.editDialogVisible = true;
        for (let k in this.form) {
          this.form[k] = this.currentRow[k];
        }
        this.form.Configs = this.currentRow.Configs;
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
  filters: {
    formatValueType: function(value) {
      if (!value) return "";
      return value === "10" ? "Text" : "Number";
    }
  }
};
</script>

