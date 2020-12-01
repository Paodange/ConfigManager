<!--物料-->
<template>
  <div>
    <el-container>
      <el-aside width="200px">
        <div>
          <div class="sideTitle">{{$t('material.categoryEdit')}}</div>
          <div>
            <el-tree :data="categories" :props="treeProps" @node-click="handleNodeClick"></el-tree>
          </div>
        </div>
      </el-aside>
      <el-main>
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
            <el-table-column align="center" :label="$t('material.shortName')">
              <template slot-scope="scope">{{ scope.row.shortName }}</template>
            </el-table-column>
            <el-table-column align="center" :label="$t('material.brandName')">
              <template slot-scope="scope">{{ scope.row.brandName }}</template>
            </el-table-column>
            <el-table-column align="center" :label="$t('material.categoryName')">
              <template slot-scope="scope">{{ scope.row.categoryName }}</template>
            </el-table-column>
            <el-table-column align="center" :label="$t('material.partNumber')">
              <template slot-scope="scope">{{ scope.row.partNumber }}</template>
            </el-table-column>
            <template v-if="currentCategory">
              <el-table-column :label="$t('material.paramters')" align="center">
                <el-table-column
                  align="center"
                  v-for="item in currentCategory.configs"
                  :key="item.configKey"
                  :label="item.configKeyDesc"
                >
                  <template slot-scope="scope">{{ scope.row[item.configKey] }}</template>
                </el-table-column>
              </el-table-column>
            </template>
            <el-table-column align="center" :label="$t('material.desc')">
              <template slot-scope="scope">{{ scope.row.desc }}</template>
            </el-table-column>
          </el-table>
        </GenericList>
      </el-main>
    </el-container>
    <GenericEdit
      :visible="editDialogVisible"
      :title="$t('material.materialEdit')"
      width="45%"
      @ok="edit_ok"
      @cancel="edit_cancel"
    >
      <el-form :model="form" ref="form" label-position="right" label-width="80px">
        <el-row>
          <el-col :span="12">
            <el-form-item :label="$t('material.name')" prop="name" :rules="rules.name">
              <el-input v-model="form.name" ref="name"></el-input>
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item :label="$t('material.shortName')">
              <el-input v-model="form.shortName" ref="shortName"></el-input>
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="12">
            <el-form-item :label="$t('material.brandName')" prop="brandId" :rules="rules.brandId">
              <el-select size="small" v-model="form.brandId" :disabled="this.editMode===true">
                <el-option
                  v-for="item in brands"
                  :key="item.id"
                  :label="item.name"
                  :value="item.id"
                ></el-option>
              </el-select>
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item
              :label="$t('material.categoryName')"
              prop="categoryId"
              :rules="rules.categoryId"
            >
              <el-select size="small" v-model="form.categoryId" :disabled="this.editMode===true">
                <el-option
                  v-for="item in categories"
                  :key="item.id"
                  :label="item.name"
                  :value="item.id"
                ></el-option>
              </el-select>
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
        </div>
        <el-table
          :data="form.configs"
          :height="300"
          element-loading-text="Loading"
          border
          fit
          highlight-current-row
          id="table-main"
        >
          <el-table-column align="center" :label="$t('material.category.config.key')">
            <template slot-scope="scope">{{scope.row.configKey}}</template>
          </el-table-column>
          <el-table-column align="center" :label="$t('material.category.config.desc')">
            <template slot-scope="scope">{{scope.row.configKeyDesc}}</template>
          </el-table-column>
          <el-table-column align="center" :label="$t('material.category.config.type')">
            <template slot-scope="scope">{{scope.row.configValueType|formatValueType}}</template>
          </el-table-column>
          <!-- <el-table-column align="center" :label="$t('material.category.config.required')">
            <template slot-scope="scope">
              <el-checkbox :disabled="true" size="small" v-model="scope.row.required"></el-checkbox>
            </template>
          </el-table-column>-->
          <el-table-column align="center" :label="$t('material.category.config.value')">
            <template slot-scope="scope">
              <el-input size="small" v-model="scope.row.configValue"></el-input>
            </template>
          </el-table-column>
        </el-table>
      </el-card>
    </GenericEdit>
  </div>
</template>


<script>
import GenericList from "@/components/GenericList";
import GenericEdit from "@/components/GenericEdit";
import ToolBar from "@/components/ToolBar";
import * as api from "@/api/material.js";
import { search as searchBrand } from "@/api/materialBrand.js";
import * as categoryApi from "@/api/materialCategory.js";
import { generateTitle } from "@/utils/i18n";
import { exportTableToFile } from "@/utils/exportUtil";
//import { get } from "http";

export default {
  components: { GenericList, GenericEdit, ToolBar },
  data() {
    return {
      form: {
        id: "",
        name: "",
        shortName: "",
        categoryId: null,
        categoryName: null,
        brandId: null,
        brandName: null,
        desc: "",
        configs: []
      },
      categories: [],
      brands: [],
      list: null,
      totalRows: 0,
      pageSize: 50,
      pageIndex: 1,
      listLoading: false,
      editDialogVisible: false,
      currentRow: null,
      currentCategory: null,
      editMode: false,
      treeProps: {
        label: "name"
      },
      rules: {
        name: [
          { required: true, trigger: "blur" },
          { min: 1, max: 20, trigger: "blur" }
        ],
        brandId: [{ required: true, trigger: "change" }],
        categoryId: [{ required: true, trigger: "change" }]
      }
    };
  },
  computed: {
    brand() {
      return this.form.brandId;
    },
    category() {
      return this.form.categoryId;
    }
  },
  created() {
    this.$nextTick(() => {
      //this.getData();
      this.searchBrand({}).then(resp => (this.brands = resp.data.items));
      categoryApi.search({}).then(resp => {
        this.categories = resp.data.items;
      });
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
    },
    brand: {
      handler: function(val) {
        if (val) {
          this.form.brandName = this.brands.filter(
            x => x.id === this.brand
          )[0].name;
        }
      },
      deep: true
    },
    category: {
      handler: function(val) {
        if (val) {
          let category = this.categories.filter(x => x.id === this.category)[0];
          console.log(val);
          console.log(category);
          this.form.categoryName = category.name;
          this.form.configs = [];
          //加载 对应类型的配置参数
          for (let c of category.configs) {
            this.form.configs.push({
              configKey: c.configKey,
              configKeyDesc: c.configKeyDesc,
              configValueType: c.configValueType,
              required: c.required,
              configValue: c.configDefaultValue
            });
          }
          console.log(this.form.configs);
        }
      },
      deep: true
    }
  },
  methods: {
    handleSelectionChange(row) {
      this.currentRow = row;
    },
    handleNodeClick(data) {
      this.currentCategory = data;
      if (this.currentCategory) {
        this.getData({
          pageSize: this.pageSize,
          pageIndex: this.pageIndex,
          model: { categoryId: this.currentCategory.id }
        });
      }
    },
    handlePageSizeChange(pageSize) {
      if (this.currentCategory) {
        this.pageSize = pageSize;
        this.$nextTick(() => {
          this.getData({
            pageSize: pageSize,
            pageIndex: this.pageIndex,
            model: { categoryId: this.currentCategory.id }
          });
        });
      }
    },
    handlePageIndexChange(pageIndex) {
      if (this.currentCategory) {
        this.pageIndex = pageIndex;
        this.$nextTick(() => {
          this.getData({
            pageSize: this.pageSize,
            pageIndex: pageIndex,
            model: { categoryId: this.currentCategory.id }
          });
        });
      }
    },
    getData(params) {
      if (this.currentCategory) {
        this.listLoading = true;
        var arg = params || {
          pageSize: this.pageSize,
          pageIndex: this.pageIndex,
          model: { categoryId: this.currentCategory.id }
        };
        api
          .search(arg)
          .then(resp => {
            this.list = resp.data.items;
            this.totalRows = resp.data.totalRows;
            this.listLoading = false;
          })
          .catch(err => (this.listLoading = false));
      }
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
    search(keyword) {
      if (this.currentCategory) {
        this.getData({
          pageSize: this.pageSize,
          pageIndex: this.pageIndex,
          keyword: keyword
        });
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
    edit_cancel() {
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
    generateTitle,
    searchBrand
  },
  filters: {
    formatValueType: function(value) {
      if (!value) return "";
      return value === "10" ? "Text" : "Number";
    }
  }
};
</script>
<style scoped>
.sideTitle {
  width: 100%;
  padding: 8px;
  background-color: #ffffff;
  overflow: hidden;
  line-height: 32px;
  font-size: large;
  border-bottom: 1px solid #e6ebf5;
  /*border: 1px solid #e6ebf5;*/
}
</style>


