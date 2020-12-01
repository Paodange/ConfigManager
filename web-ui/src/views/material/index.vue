<!--物料-->
<template>
  <div>
    <GenericList
      visibleButtons="RES"
      :totalRecords="totalRows"
      @export-file="exportToFile"
      @search="search"
      @refresh="getData"
      @pagesize-change="handlePageSizeChange"
      @pageindex-change="handlePageIndexChange"
    >
      <el-dropdown-item
        slot="exportDropdown"
        @click.native="exportToFile('offLine',null)"
      >{{$t('material.materialList.exportOfflineVersion')}}</el-dropdown-item>
      <el-tabs tab-position="top" style="margin-left: 10px" v-model="currentCategoryCode">
        <el-tab-pane
          v-for="item in categories"
          :name="item.Code"
          :label="item.Code+'/'+item.Name"
          :key="item.Id"
        ></el-tab-pane>
      </el-tabs>
      <el-table
        v-loading="listLoading"
        :data="list"
        element-loading-text="Loading"
        border
        stripe
        highlight-current-row
        id="table-main"
        height="50"
        v-el-height-adaptive-table="{table: $refs.table}"
      >
        <el-table-column align="center" :label="$t('genericList.no')" width="80px">
          <template slot-scope="scope">{{ scope.$index+1 }}</template>
        </el-table-column>
        <el-table-column align="center" :label="$t('material.materialList.name')">
          <template slot-scope="scope">{{ scope.row.Name }}</template>
        </el-table-column>
        <el-table-column align="center" :label="$t('material.materialList.brand')">
          <template slot-scope="scope">{{ scope.row.BrandName }}</template>
        </el-table-column>
        <el-table-column align="center" :label="$t('material.materialList.category')">
          <template slot-scope="scope">{{ scope.row.CategoryName }}</template>
        </el-table-column>
        <el-table-column align="center" :label="$t('material.materialList.type')">
          <template slot-scope="scope">{{ scope.row.TypeName }}</template>
        </el-table-column>
        <el-table-column align="center" :label="$t('material.materialList.partNumber')">
          <template slot-scope="scope">{{ scope.row.PartNumber }}</template>
        </el-table-column>
        <el-table-column
          align="center"
          :label="$t('material.materialList.containerPartNumber')"
          v-if="currentCategory&&(currentCategory.Code==='Reagent'||currentCategory.Code.indexOf('Sample')!=-1)"
        >
          <template slot-scope="scope">{{ scope.row.ContainerPartNumber }}</template>
        </el-table-column>
        <el-table-column
          align="center"
          :label="$t('material.materialList.rack')"
          v-if="currentCategory&&currentCategory.RequireRack"
        >
          <template slot-scope="scope">{{ scope.row.RackPn }}</template>
        </el-table-column>
        <template v-if="currentCategory">
          <el-table-column :label="$t('material.materialList.paramters')" align="center">
            <el-table-column
              align="center"
              v-for="item in currentCategory.Configs"
              :key="item.ConfigKey"
              :label="item.ConfigKeyDesc"
            >
              <template slot-scope="scope">{{ scope.row[item.ConfigKey] }}</template>
            </el-table-column>
          </el-table-column>
        </template>
        <el-table-column align="center" :label="$t('material.materialList.desc')">
          <template slot-scope="scope">{{ scope.row.Desc }}</template>
        </el-table-column>
        <el-table-column align="center" :label="$t('material.materialList.modifyTime')">
          <template slot-scope="scope">{{ scope.row.ModifyTime|dateformat('YYYY-MM-DD HH:mm:ss') }}</template>
        </el-table-column>
      </el-table>
    </GenericList>
  </div>
</template>


<script>
import GenericList from "@/components/GenericList";
import ToolBar from "@/components/ToolBar";
import * as api from "@/api/material.js";
import { search as searchBrand } from "@/api/materialBrand.js";
import * as categoryApi from "@/api/materialCategory.js";
import { generateTitle } from "@/utils/i18n";
import { exportTableToFile } from "@/utils/exportUtil";
import { downloadFile } from "@/api/file-downloader";

export default {
  components: { GenericList, ToolBar },
  data() {
    return {
      categories: [],
      materialTypes: [],
      brands: [],
      containerMaterials: [],
      list: null,
      totalRows: 0,
      pageSize: 50,
      pageIndex: 1,
      listLoading: false,
      containerMaterialLoading: false,
      editDialogVisible: false,
      currentRow: null,
      currentCategory: null,
      currentCategoryCode: "",
      pnEnable: false,
      containerEnable: false,
      editMode: false
    };
  },
  created() {
    this.$nextTick(() => {
      //this.getData();
      this.searchBrand({}).then(resp => (this.brands = resp.Data.Items));
      categoryApi.search({}).then(resp => {
        this.categories = resp.Data.Items;
        if (this.categories && this.categories.length > 0) {
          this.currentCategoryCode = this.categories[0].Code;
        }
      });
    });
  },
  watch: {
    currentCategoryCode: {
      handler: function(val) {
        this.currentCategory = this.categories.filter(x => x.Code == val)[0];
        if (this.currentCategory) {
          this.getData({
            pageSize: this.pageSize,
            pageIndex: this.pageIndex,
            model: { categoryId: this.currentCategory.Id }
          });
        }
      },
      deep: true
    },
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
  methods: {
    handlePageSizeChange(pageSize) {
      if (this.currentCategory) {
        this.pageSize = pageSize;
        this.$nextTick(() => {
          this.getData({
            pageSize: pageSize,
            pageIndex: this.pageIndex,
            model: { categoryId: this.currentCategory.Id }
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
            model: { categoryId: this.currentCategory.Id }
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
          model: { categoryId: this.currentCategory.Id }
        };
        api
          .search(arg)
          .then(resp => {
            this.list = resp.Data.Items;
            this.totalRows = resp.Data.TotalRows;
            this.listLoading = false;
          })
          .catch(err => (this.listLoading = false));
      }
    },

    search(keyword) {
      if (this.currentCategory) {
        this.getData({
          pageSize: this.pageSize,
          pageIndex: this.pageIndex,
          keyword: keyword,
          model: { categoryId: this.currentCategory.Id }
        });
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
      if (type === "offLine") {
        api.exportOfflinePackage().then(resp => {
          downloadFile(resp.Data).catch(err => {
            console.log(err);
          });
        });
        return;
      }
      var params = {};
      if (type === "page") {
        params = {
          pageSize: this.pageSize,
          pageIndex: this.pageIndex,
          keyword: keyword,
          model: { categoryId: this.currentCategory.Id }
        };
      } else if (type === "all") {
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


