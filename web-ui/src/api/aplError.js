import request from '@/utils/request'
import { getLanguage } from '@/lang/index'

export function search(params) {
  return request({
    url: '/aplError/search',
    method: 'post',
    data: params
  })
}

// export function create(params) {
//   return request({
//     url: '/aplError',
//     method: 'post',
//     data: params
//   })
// }

export function detail(id) {
  return request({
    url: '/aplError/' + id,
    method: 'get'
  })
}

export function getErrorByCode(code) {
  return request({
    url: '/aplError/detail/' + code,
    method: 'get'
  })
}
export function update(params) {
  return request({
    url: '/aplError',
    method: 'put',
    data: params
  })
}

export function exportXls(params) {
  var locale = getLanguage() === 'zh' ? 'zh-cn' : 'en-us'
  return request({
    url: `/aplError/export/${locale}`,
    method: 'post',
    data: params
  })
}
