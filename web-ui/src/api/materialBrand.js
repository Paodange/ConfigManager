import request from '@/utils/request'
import { getLanguage } from '@/lang/index'

export function search(params) {
  return request({
    url: '/material_brand/search',
    method: 'post',
    data: params
  })
}

export function create(params) {
  return request({
    url: '/material_brand',
    method: 'post',
    data: params
  })
}

export function detail(id) {
  return request({
    url: '/material_brand/' + id,
    method: 'get'
  })
}

export function update(params) {
  return request({
    url: '/material_brand',
    method: 'put',
    data: params
  })
}

export function del(id) {
  return request({
    url: '/material_brand/' + id,
    method: 'delete'
  })
}

export function exportXls(params) {
  var locale = getLanguage() === 'zh' ? 'zh-cn' : 'en-us'
  return request({
    url: `/material_brand/export/${locale}`,
    method: 'post',
    data: params
  })
}
