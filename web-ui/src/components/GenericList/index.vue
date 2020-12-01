<template>
  <div>
    <tool-bar v-if="visibleButtons&&visibleButtons.length>0">
      <el-button
        type="primary"
        icon="el-icon-plus"
        size="small"
        @click="$emit('add')"
        v-if="visibleButtons.indexOf('N')!==-1"
      >{{$t('genericList.add')}}</el-button>
      <el-button
        type="success"
        icon="el-icon-edit"
        size="small"
        @click="$emit('edit')"
        v-if="visibleButtons.indexOf('M')!==-1"
      >{{$t('genericList.edit')}}</el-button>
      <el-button
        type="primary"
        icon="el-icon-delete"
        size="small"
        @click="$emit('delete')"
        v-if="visibleButtons.indexOf('D')!==-1"
      >{{$t('genericList.delete')}}</el-button>
      <el-button
        type="primary"
        icon="el-icon-refresh"
        size="small"
        @click="handleRefresh"
        v-if="visibleButtons.indexOf('R')!==-1"
      >{{$t('genericList.refresh')}}</el-button>
      <el-dropdown trigger="click" v-if="visibleButtons.indexOf('E')!==-1">
        <el-button style="margin-left:10px" type="primary" size="small">
          {{$t('genericList.export')}}
          <i class="el-icon-caret-bottom el-icon--right"></i>
        </el-button>
        <el-dropdown-menu slot="dropdown">
          <el-dropdown-item
            @click.native="$emit('export-file','page',toolbar.keyword)"
          >{{$t('genericList.exportThisPage')}}</el-dropdown-item>
          <el-dropdown-item
            @click.native="$emit('export-file','all',toolbar.keyword)"
          >{{$t('genericList.exportAll')}}</el-dropdown-item>
          <slot name="exportDropdown"></slot>
          <!-- <el-dropdown-item
            @click.native="$emit('export-file','xlsx')"
          >{{$t('genericList.exportToXLSX')}}</el-dropdown-item>
          <el-dropdown-item
            @click.native="$emit('export-file','xls')"
          >{{$t('genericList.exportToXLS')}}</el-dropdown-item>
          <el-dropdown-item
            @click.native="$emit('export-file','csv')"
          >{{$t('genericList.exportToCSV')}}</el-dropdown-item>
          <el-dropdown-item
            @click.native="$emit('export-file','txt')"
          >{{$t('genericList.exportToTXT')}}</el-dropdown-item>-->
        </el-dropdown-menu>
      </el-dropdown>
      <slot name="toolbar"></slot>
      <div style="float: right" v-if="visibleButtons.indexOf('S')!==-1">
        <el-input
          :placeholder="$t('genericList.keyword')"
          size="small"
          style="width: 140px"
          v-model="toolbar.keyword"
          clearable
          @keyup.enter.native="handleSearch"
        ></el-input>
        <el-button @click="handleSearch" type="primary" icon="el-icon-search" size="small"></el-button>
      </div>
    </tool-bar>
    <slot></slot>
    <div>
      <el-pagination
        background
        @size-change="handleSizeChange"
        @current-change="handleCurrentChange"
        :current-page.sync="currentPage"
        :page-sizes="[50, 100, 500]"
        :page-size="pageSize"
        :total="totalRecords"
        layout="total, sizes, prev, pager, next, jumper"
      ></el-pagination>
    </div>
  </div>
</template>
<script>
import ToolBar from "@/components/ToolBar";
import Pagination from "@/components/Pagination";
export default {
  name: "GenericList",
  props: {
    visibleButtons: {
      type: String,
      required: true
    },
    totalRecords: {
      type: Number,
      required: true
    }
  },
  components: { ToolBar, Pagination },
  data() {
    return {
      toolbar: {
        keyword: ""
      },
      pageSize: 50,
      currentPage: 1
    };
  },
  watch: {
    currentPage: {
      immediate: true,
      handler: function(val, oldVal) {},
      deep: true
    }
  },
  methods: {
    handleSizeChange(pageSize) {
      this.pageSize = pageSize;
      this.$emit("pagesize-change", pageSize);
    },
    handleCurrentChange(pageIndex) {
      this.currentPage = pageIndex;
      this.$emit("pageindex-change", pageIndex);
    },
    handleSearch() {
      this.$emit("search", this.toolbar.keyword);
    },
    handleRefresh() {
      this.$emit("refresh");
      this.toolbar.keyword = "";
    }
  }
};
</script>


