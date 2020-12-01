<template>
  <div class="container">
    <el-container>
      <el-header>
        <h1 style="text-align:center">{{errorCode}}</h1>
      </el-header>
      <el-divider></el-divider>
      <el-main>
        <el-form
          :model="form"
          ref="form"
          prop="form"
          label-position="left"
          label-width="120px"
          size="mini"
        >
          <el-form-item :label="translate('aplError.code')">
            <template>{{ form.Code }}</template>
          </el-form-item>
          <el-form-item :label="translate('aplError.explain')">
            <template>{{ form.ErrorRange.Message }}</template>
          </el-form-item>
          <el-form-item :label="translate('aplError.typeName')">
            <template>{{ form.TypeName }}</template>
          </el-form-item>
          <el-form-item :label="translate('aplError.fileName')">
            <template>{{ form.FileName}}</template>
          </el-form-item>
          <el-form-item :label="translate('aplError.filePath')">
            <template>{{ form.ErrorRange.FilePath}}</template>
          </el-form-item>
          <el-form-item :label="translate('aplError.line')">
            <template>{{ form.Line }}</template>
          </el-form-item>
          <el-form-item :label="translate('aplError.source')">
            <template>{{ form.Source }}</template>
          </el-form-item>
          <el-form-item :label="translate('aplError.comment')">
            <template>{{ form.Comment }}</template>
          </el-form-item>

          <el-collapse v-model="activeNames">
            <el-collapse-item
              :title="translate('aplError.description')"
              name="1"
              v-if="locale==='zh'"
            >{{form.CnDescription}}</el-collapse-item>
            <el-collapse-item
              :title="translate('aplError.solution')"
              name="2"
              v-if="locale==='zh'"
            >{{form.CnSolution}}</el-collapse-item>
            <el-collapse-item
              :title="translate('aplError.description')"
              name="3"
              v-if="locale==='en'"
            >{{form.EnDescription}}</el-collapse-item>
            <el-collapse-item
              :title="translate('aplError.solution')"
              name="4"
              v-if="locale==='en'"
            >{{form.EnSolution}}</el-collapse-item>
          </el-collapse>
        </el-form>
      </el-main>
    </el-container>
  </div>
</template>
<script>
import { getErrorByCode } from "@/api/aplError.js";
export default {
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
      resource: null,
      activeNames: ["1", "2", "3", "4"]
    };
  },
  computed: {
    errorCode() {
      return this.$route.params.code;
    },
    locale() {
      return this.$route.params.locale;
    },
    description() {
      return this.locale === "zh"
        ? this.form.CnDescription
        : this.form.EnDescription;
    },
    solution() {
      return this.locale === "zh" ? this.form.CnSolution : this.form.EnSolution;
    }
  },
  mounted() {
    this.$nextTick(() => {
      getErrorByCode(this.errorCode).then(res => (this.form = res.Data));
    });
  },
  methods: {
    translate(key) {
      if (!this.resource) {
        this.resource = this._i18n.getLocaleMessage(this.locale);
      }
      if (key.indexOf(".") == -1) {
        return this.resource.hasOwnProperty(key) ? this.resource[key] : key;
      }
      let arr = key.split(".");
      let resource = this.resource;
      for (let s of arr) {
        resource = resource[s];
        if (!resource) return key;
      }
      return resource;
    }
  }
};
</script>
<style scoped>
.demo-block {
  border: 1px solid #ebebeb;
  border-radius: 3px;
  transition: 0.2s;
}
.page-container .warning {
  padding: 8px 16px;
  background-color: #fff6f7;
  border-radius: 4px;
  border-left: 5px solid #fe6c6f;
  margin: 20px 0;
}
.text {
  font-size: 14px;
}

.item {
  margin-bottom: 18px;
}

.clearfix:before,
.clearfix:after {
  display: table;
  content: "";
}
.clearfix:after {
  clear: both;
}

.box-card {
  display: flex;
  justify-content: center;
}
.container {
  margin: 0 auto;
  width: 80%;
  height: 100%;
}
</style>

