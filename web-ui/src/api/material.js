import request from '@/utils/request'
import { getLanguage } from '@/lang/index'

export function getContainerMaterials(pn) {
  return request({
    url: '/material/containers/' + pn,
    method: 'get'
  })
}

export function getAllRacks() {
  return request({
    url: '/material/racks',
    method: 'get'
  })
}

export function search(params) {
  return request({
    url: '/material/search',
    method: 'post',
    data: params
  })
}

export function create(params) {
  return request({
    url: '/material',
    method: 'post',
    data: params
  })
}

export function detail(id) {
  return request({
    url: '/material/' + id,
    method: 'get'
  })
}

export function update(params) {
  return request({
    url: '/material',
    method: 'put',
    data: params
  })
}

export function del(id) {
  return request({
    url: '/material/' + id,
    method: 'delete'
  })
}

export function backup() {
  return request({
    url: '/material/backup',
    method: 'get'
  })
}

/**
 * 文件上传
 */
export function restore(fileobj) {
  const param = new FormData()
  debugger
  param.append('file', fileobj.file)
  return request({
    url: '/material/restore',
    method: 'post',
    headers: { 'Content-Type': 'multipart/form-data' },
    data: param
  })
}

export function exportXls(params) {
  var locale = getLanguage() === 'zh' ? 'zh-cn' : 'en-us'
  return request({
    url: `/material/export/${locale}`,
    method: 'post',
    data: params
  })
}

export function exportOfflinePackage() {
  return request({
    url: '/material/offlinePackage',
    method: 'get'
  })
}
