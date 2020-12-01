<!--物料-->
<template>
  <div>
    <!-- <el-container>
      <el-aside width="200px">
        <div>
          <div class="sideTitle">{{$t('material.category.editTitle')}}</div>
          <div>
            <el-tree
              @node-click="handleNodeClick"
              ref="categoryTree"
              :data="categories"
              :props="treeProps"
              node-key="Id"
            ></el-tree>
          </div>
        </div>
      </el-aside>
    <el-main>-->
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
      <el-dropdown-item
        slot="exportDropdown"
        @click.native="exportToFile('offLine',null)"
      >{{$t('material.materialList.exportOfflineVersion')}}</el-dropdown-item>
      <template slot="toolbar">
        <el-button
          type="primary"
          :icon="backupIcon"
          size="small"
          @click="handleBackup"
          style="margin-left: 10px"
        >{{backupButtonText||$t("material.materialList.backUp")}}</el-button>

        <el-button
          type="danger"
          :icon="restoreIcon"
          size="small"
          @click="handleRestore"
          style="margin-left: 10px"
        >{{restoreButtonText||$t("material.materialList.restore")}}</el-button>
      </template>

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
        <el-table-column align="center" :label="$t('genericList.no')" width="80px" type="index">
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
          v-if="currentCategory&&currentCategory.RequireContainer"
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
    <!-- </el-main>
    </el-container>-->
    <GenericEdit
      :visible="editDialogVisible"
      :title="$t('material.materialList.editTitle')"
      width="45%"
      @ok="edit_ok"
      @cancel="edit_cancel"
    >
      <el-form :model="form" ref="form" label-position="right" label-width="80px">
        <el-row>
          <el-col :span="8">
            <el-form-item :label="$t('material.materialList.name')" prop="Name" :rules="rules.Name">
              <el-input
                v-model="form.Name"
                ref="Name"
                :placeholder="$t('material.materialList.namePlaceHolder')"
              ></el-input>
            </el-form-item>
          </el-col>
          <el-col :span="8">
            <el-form-item
              :label="$t('material.materialList.brand')"
              prop="BrandId"
              :rules="rules.BrandId"
            >
              <el-select size="small" v-model="form.BrandId" :disabled="this.editMode===true">
                <el-option
                  v-for="item in brands"
                  :key="item.Id"
                  :label="item.Name"
                  :value="item.Id"
                ></el-option>
              </el-select>
            </el-form-item>
          </el-col>
          <el-col :span="8">
            <el-form-item
              :label="$t('material.materialList.category')"
              prop="CategoryId"
              :rules="rules.CategoryId"
            >
              <el-select size="small" v-model="form.CategoryId" :disabled="this.editMode===true">
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
          <el-col :span="12">
            <el-form-item
              :label="$t('material.materialList.type')"
              prop="TypeId"
              :rules="rules.TypeId"
            >
              <el-select
                size="small"
                v-model="form.TypeId"
                :disabled="this.editMode===true"
                style="width:100%"
              >
                <el-option
                  v-for="item in materialTypes"
                  :key="item.Id"
                  :label="item.Name"
                  :value="item.Id"
                ></el-option>
              </el-select>
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item
              :label="$t('material.materialList.partNumber')"
              prop="PartNumber"
              :rules="partNumberRule"
            >
              <el-input v-model="form.PartNumber" ref="PartNumber" :disabled="!pnEnable"></el-input>
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="12">
            <el-form-item
              :label="$t('material.materialList.rack')"
              prop="RackId"
              :rules="this.rackEnable?rules.RackId:null"
            >
              <el-select
                size="small"
                v-model="form.RackId"
                :disabled="!rackEnable"
                style="width:100%"
              >
                <el-option
                  v-for="item in racks"
                  :key="item.Id"
                  :label="item.PartNumber+','+item.Name"
                  :value="item.Id"
                ></el-option>
              </el-select>
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item
              :label="$t('material.materialList.container')"
              prop="ContainerMaterialId"
              :rules="this.containerEnable?rules.ContainerMaterialId:null"
            >
              <el-select
                size="small"
                v-model="form.ContainerMaterialId"
                :disabled="!containerEnable"
                filterable
                remote
                :placeholder="$t('material.materialList.containerInputPlaceHolder')"
                :remote-method="searchContainer"
                :loading="containerMaterialLoading"
                style="width:100%"
              >
                <el-option
                  v-for="item in containerMaterials"
                  :key="item.Id"
                  :label="item.PartNumber+','+item.Name"
                  :value="item.Id"
                ></el-option>
              </el-select>
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-form-item
            :label="$t('material.materialList.detail')"
            prop="Detail"
            :rules="rules.Detail"
          >
            <el-input
              v-model="form.Detail"
              ref="Detail"
              :placeholder="$t('material.materialList.detailPlaceHolder')"
            ></el-input>
          </el-form-item>
        </el-row>
        <el-row>
          <el-form-item :label="$t('material.materialList.desc')" prop="Desc" :rules="rules.Desc">
            <el-input
              v-model="form.Desc"
              ref="Desc"
              :placeholder="$t('material.materialList.descPlaceHolder')"
            ></el-input>
          </el-form-item>
        </el-row>
      </el-form>
      <el-card class="box-card" shadow="never">
        <div slot="header" class="clearfix">
          <span>{{$t('material.category.config.title')}}</span>
        </div>
        <el-table
          :data="form.Configs"
          :height="280"
          element-loading-text="Loading"
          border
          fit
          highlight-current-row
          id="table-main"
          size="small"
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
          <el-table-column
            align="center"
            :label="$t('material.category.config.value')"
            header-align="center"
          >
            <template slot-scope="scope">
              <!-- <el-input size="small" v-model="scope.row.ConfigValue"></el-input> -->
              <el-input
                size="small"
                v-model="scope.row.ConfigValue"
                v-if="scope.row.ConfigValueType==='10'"
              ></el-input>
              <el-input-number
                size="small"
                v-model="scope.row.ConfigValue"
                controls-position="right"
                :precision="2"
                v-if="scope.row.ConfigValueType==='20'"
              ></el-input-number>
            </template>
          </el-table-column>
          <el-table-column align="center" :label="$t('material.materialList.desc')">
            <template slot-scope="scope">{{scope.row.Remark}}</template>
          </el-table-column>
        </el-table>
      </el-card>
    </GenericEdit>
    <GenericEdit
      :visible="showFileSelector"
      width="30%"
      :title="$t('material.materialList.restoreTitle')"
      @ok="fileSelectOk"
      @cancel="fileSelectCancel"
    >
      <el-alert
        :title="$t('material.materialList.warn')"
        type="warning"
        :description="$t('material.materialList.restoreWarn')"
        show-icon
        :closable="false"
      ></el-alert>
      <br />
      <div style="text-align:center">
        <el-upload
          ref="upload"
          action="/api/material/restore"
          :auto-upload="false"
          accept=".bak"
          drag
          :limit="1"
          :on-exceed="handleExceed"
          :http-request="customUpload"
          :before-upload="beforeUpload"
        >
          <i class="el-icon-upload"></i>
          <div class="el-upload__text">
            {{$t('material.materialList.dragFileHere')}}
            <em>{{$t('material.materialList.chooseBackupFile')}}</em>
          </div>
          <div slot="tip" class="el-upload__tip">{{$t('material.materialList.restoreUploadTips')}}</div>
        </el-upload>
      </div>
    </GenericEdit>
  </div>
</template>


<script>
import GenericList from "@/components/GenericList";
import GenericEdit from "@/components/GenericEdit";
import ToolBar from "@/components/ToolBar";
import * as api from "@/api/material.js";
import { search as searchBrand } from "@/api/materialBrand.js";
import * as materialTypeApi from "@/api/materialType.js";
import * as categoryApi from "@/api/materialCategory.js";
import { generateTitle } from "@/utils/i18n";
// import { exportTableToFile } from "@/utils/exportUtil";
import { MessageBox, Message } from "element-ui";
import { downloadFile } from "@/api/file-downloader";

export default {
  components: { GenericList, GenericEdit, ToolBar },
  data() {
    return {
      form: {
        Id: "",
        Name: "",
        CategoryId: null,
        TypeId: null,
        TypeName: null,
        BrandId: null,
        BrandName: null,
        ContainerMaterialId: null,
        RackId: null,
        Detail: "",
        Desc: "",
        PartNumber: "",
        Configs: []
      },
      categories: [],
      materialTypes: [],
      brands: [],
      racks: [],
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
      rackEnable: false,
      editMode: false,
      rules: {
        Name: [
          {
            required: true,
            trigger: "blur",
            message: this.$t("material.materialList.nameIsRequired")
          },
          {
            min: 1,
            max: 50,
            trigger: "blur",
            message: this.$t("material.materialList.nameLength")
          }
        ],
        BrandId: [
          {
            required: true,
            trigger: "change",
            message: this.$t("material.materialList.brandIsRequired")
          }
        ],
        TypeId: [
          {
            required: true,
            trigger: "change",
            message: this.$t("material.materialList.typeIsRequired")
          }
        ],
        CategoryId: [
          {
            required: true,
            trigger: "change",
            message: this.$t("material.materialList.categoryIsRequired")
          }
        ],
        ContainerMaterialId: [
          {
            required: true,
            trigger: "change",
            message: this.$t("material.materialList.containerRequired")
          }
        ],
        PartNumber: [
          {
            required: true,
            trigger: "blur",
            message: this.$t("material.materialList.partNumberIsRequired")
          },
          {
            min: 1,
            max: 50,
            trigger: "blur",
            message: this.$t("material.materialList.partNumberLength")
          }
        ],
        RackId: [
          {
            required: true,
            trigger: "change",
            message: this.$t("material.materialList.rackIsRequired")
          }
        ],
        Detail: [
          {
            min: 0,
            max: 1000,
            trigger: "blur",
            message: this.$t("material.materialList.detailLength")
          }
        ],
        Desc: [
          {
            min: 0,
            max: 1000,
            trigger: "blur",
            message: this.$t("material.materialList.descLength")
          }
        ]
      },
      showFileSelector: false,
      backupIcon: "el-icon-folder",
      backupButtonText: null,
      restoreIcon: "el-icon-folder-checked",
      restoreButtonText: null
    };
  },
  computed: {
    brand() {
      return this.form.BrandId;
    },
    type() {
      return this.form.TypeId;
    },
    category() {
      return this.form.CategoryId;
    },
    partNumberRule() {
      return this.pnEnable ? this.rules.PartNumber : [];
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
      api.getAllRacks().then(resp => {
        this.racks = resp.Data;
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
        if (this.$refs.form) this.$refs.form.clearValidate();
      },
      deep: true
    },
    brand: {
      handler: function(val) {
        if (val) {
          this.form.BrandName = this.brands.filter(x => x.Id === val)[0].Name;
        }
      },
      deep: true
    },
    type: {
      handler: function(val) {
        if (val) {
          let type = this.materialTypes.filter(x => x.Id === val)[0];
          if (type && !this.editMode) {
            this.form.TypeName = type.Name;
            this.form.Configs = [];
            //加载 对应类型的配置参数
            for (let c of type.Configs) {
              this.form.Configs.push({
                ConfigKey: c.ConfigKey,
                ConfigKeyDesc: c.ConfigKeyDesc,
                ConfigValueType: c.ConfigValueType,
                Required: c.Required,
                ConfigValue: c.ConfigDefaultValue,
                Remark: c.Remark
              });
            }
          }
          if (this.$refs.form) this.$refs.form.clearValidate();
        }
      },
      deep: true
    },
    category: {
      handler: function(val) {
        this.containerEnable = false;
        if (val) {
          materialTypeApi
            .search({
              model: {
                categoryId: val
              }
            })
            .then(resp => {
              this.materialTypes = resp.Data.Items;
              if (this.materialTypes && this.materialTypes.length > 0) {
                this.form.TypeId = this.materialTypes[0].Id;
              } else {
                this.form.TypeId = null;
                this.form.Configs = [];
              }
            });
          var c = this.categories.filter(x => x.Id === val)[0];
          if (c && c.RequireContainer === true) {
            this.containerEnable = true;
          } else {
            this.containerEnable = false;
            this.form.ContainerMaterialId = null;
          }
          if (c && c.ManualPartNumber) {
            this.pnEnable = true;
          } else {
            this.pnEnable = false;
            this.form.PartNumber = null;
          }
          if (c && c.RequireRack === true) {
            this.rackEnable = true;
          } else {
            this.rackEnable = false;
            this.form.RackId = null;
          }
        }
      },
      deep: true
    }
  },
  methods: {
    handleBackup() {
      this.backupIcon = "el-icon-loading";
      this.backupButtonText = this.$t("material.materialList.backuping");
      setTimeout(() => {
        api
          .backup()
          .then(resp => {
            this.backupIcon = "el-icon-folder";
            this.backupButtonText = this.$t("material.materialList.backUp");
            debugger;
            downloadFile(resp.Data);
          })
          .catch(err => {
            this.backupIcon = "el-icon-folder";
            this.backupButtonText = this.$t("material.materialList.backUp");
          });
      }, 2000);
    },
    handleRestore() {
      this.showFileSelector = true;
    },
    handleExceed(files, fileList) {
      Message({
        message: this.$t("material.materialList.onlyOnFileAllowed"),
        type: "error",
        duration: 5 * 1000
      });
    },
    searchContainer(pn) {
      if (pn !== "" && pn.length >= 2) {
        this.containerMaterialLoading = true;
        api
          .getContainerMaterials(pn)
          .then(resp => {
            this.containerMaterialLoading = false;
            this.containerMaterials = resp.Data;
          })
          .catch(() => (this.containerMaterialLoading = false));
      }
    },
    handleCurrentChange(current, old) {
      this.currentRow = current;
    },
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
    add() {
      this.editMode = false;
      this.editDialogVisible = true;
      //清除输入框已加载的数据
      this.form.CategoryId = null;
      this.form.TypeId = null;
      this.form.BrandId = null;
      this.pnEnable = false;
      this.containerEnable = false;
      this.rackEnable = false;
      this.form.Configs = [];
      for (let k in this.form) {
        this.form[k] = null;
      }
      this.$nextTick(function() {
        this.containerMaterials = [];
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
          if (this.form.ContainerMaterialId) {
            api.detail(this.form.ContainerMaterialId).then(resp => {
              this.containerMaterials = [];
              this.containerMaterials.push(resp.Data);
            });
          }
          this.$refs.form.clearValidate();
          api.detail(this.currentRow.Id).then(resp => {
            this.currentRow = resp.Data;
          });
        });
      }
    },

    del() {
      if (this.currentRow) {
        this.$confirm(this.$t("material.materialList.deleteConfirm")).then(() =>
          api.del(this.currentRow.Id).then(resp => {
            if (resp.Code === 200) {
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
    edit_cancel() {
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
    fileSelectCancel() {
      this.showFileSelector = false;
    },
    fileSelectOk() {
      this.$refs.upload.submit();
    },
    customUpload(file) {
      api
        .restore(file)
        .then(res => {
          Message({
            message: this.$t("material.materialList.retoreSuccess"),
            type: "success",
            duration: 5000
          });
          this.showFileSelector = false;
          categoryApi.search({}).then(resp => {
            this.categories = resp.Data.Items;
            if (this.categories && this.categories.length > 0) {
              this.currentCategoryCode = this.categories[0].Code;
            }
          });
          // this.getData();
          this.$refs.upload.clearFiles();
        })
        .catch(err => {
          console.log(err);
          this.$refs.upload.clearFiles();
        });
    },
    beforeUpload(file) {
      debugger;
      let extention =
        file.name.indexOf(".") == -1
          ? ""
          : file.name.substring(file.name.indexOf(".") + 1);
      if (extention.toUpperCase() !== "BAK") {
        this.$message({
          type: "warning",
          message: this.$t("material.materialList.restoreUploadTips")
        });
        return false;
      }
      return true;
    },
    generateTitle,
    searchBrand,
    downloadFile
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
.upload .el-upload-dragger {
  width: 100%;
}
.upload .el-upload {
  display: block;
}
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


