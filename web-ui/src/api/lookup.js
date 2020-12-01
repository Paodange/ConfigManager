import request from '@/utils/request'

export function search(params) {
  return request({
    url: '/lookup/search',
    method: 'post',
    data: params
  })
}

export function create(params) {
  return request({
    url: '/lookup',
    method: 'post',
    data: params
  })
}

export function detail(id) {
  return request({
    url: '/lookup/' + id,
    method: 'get'
  })
}

export function update(params) {
  return request({
    url: '/lookup',
    method: 'put',
    data: params
  })
}

export function del(id) {
  return request({
    url: '/lookup/' + id,
    method: 'delete'
  })
}

export function findLookup(lookUpCode) {
  return request({
    url: '/lookup/category/' + lookUpCode,
    method: 'get'
  })
}

