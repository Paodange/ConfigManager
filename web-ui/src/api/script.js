import request from '@/utils/request'
import { getLanguage } from '@/lang/index'

export function search(params) {
  return request({
    url: '/script/search',
    method: 'post',
    data: params
  })
}

export function create(params) {
  return request({
    url: '/script',
    method: 'post',
    data: params
  })
}

export function detail(id) {
  return request({
    url: '/script/' + id,
    method: 'get'
  })
}

export function update(params) {
  return request({
    url: '/script',
    method: 'put',
    data: params
  })
}

export function del(id) {
  return request({
    url: '/script/' + id,
    method: 'delete'
  })
}

export function exportXls(params) {
  var locale = getLanguage() === 'zh' ? 'zh-cn' : 'en-us'
  return request({
    url: `/script/export/${locale}`,
    method: 'post',
    data: params
  })
}

export function file(params) {
  return request({
    url: '/script/file',
    method: 'post',
    data: params
  })
}