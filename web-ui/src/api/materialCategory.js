import request from '@/utils/request'
import { getLanguage } from '@/lang/index'

export function search(params) {
  return request({
    url: '/material_category/search',
    method: 'post',
    data: params
  })
}

export function create(params) {
  return request({
    url: '/material_category',
    method: 'post',
    data: params
  })
}

export function detail(id) {
  return request({
    url: '/material_category/' + id,
    method: 'get'
  })
}

export function update(params) {
  return request({
    url: '/material_category',
    method: 'put',
    data: params
  })
}

export function del(id) {
  return request({
    url: '/material_category/' + id,
    method: 'delete'
  })
}

export function exportXls(params) {
  var locale = getLanguage() === 'zh' ? 'zh-cn' : 'en-us'
  return request({
    url: `/material_category/export/${locale}`,
    method: 'post',
    data: params
  })
}
