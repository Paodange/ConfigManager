import Vue from 'vue'

import 'normalize.css/normalize.css' // a modern alternative to CSS resets

import Element from 'element-ui'
import './styles/element-variables.scss'

import '@/styles/index.scss' // global css

import App from './App'
import store from './store'
import router from './router'

import i18n from './lang' // internationalization
import './icons' // icon
import './permission' // permission control
import '@/components/DragDialog'
import moment from 'moment'
import { getLanguage } from '@/lang/index'
/**
 * If you don't want to use mock-server
 * you want to use MockJs for mock api
 * you can execute: mockXHR()
 *
 * Currently MockJs will be used in the production environment,
 * please remove it before going online! ! !
 */
// import { mockXHR } from '../mock'
// if (process.env.NODE_ENV === 'production') {
//   mockXHR()
// }

Vue.use(Element, {
  size: 'small', // set element-ui default size
  i18n: (key, value) => i18n.t(key, value)
})
Vue.filter('dateformat', function(dataStr, pattern = 'YYYY-MM-DD HH:mm:ss') {
  return moment(dataStr).format(pattern)
})
Vue.filter('formatBoolean', function(value) {
  if (getLanguage() === 'en') {
    return value ? 'Yes' : 'No'
  } else {
    return value ? '是' : '否'
  }
})
const doResize = (el, binding, vnode) => {
  const { componentInstance: $table } = vnode
  const { value } = binding
  if (!$table.height) {
    throw new Error(`el-$table must set the height. Such as height='100px'`)
  }
  const bottomOffset = (value && value.bottomOffset) || 50

  if (!$table) return

  const height = window.innerHeight - el.getBoundingClientRect().top - bottomOffset
  $table.layout.setHeight(height)
  $table.doLayout()
}

Vue.directive('el-height-adaptive-table', {
  bind(el, binding, vnode) {
    el.resizeListener = () => {
      doResize(el, binding, vnode)
    }
    // addResizeListener(el, el.resizeListener)
    window.addEventListener('resize', el.resizeListener)
  },
  update(el, binding, vnode) {
    doResize(el, binding, vnode)
  },
  unbind(el) {
    // removeResizeListener(el, el.resizeListener)
    window.removeEventListener('resize', el.resizeListener)
  }
})

Vue.config.productionTip = false

new Vue({
  el: '#app',
  router,
  store,
  i18n,
  mounted: function() {
    console.log(store)
  },
  render: h => h(App)
})
