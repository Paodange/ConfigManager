import request from '@/utils/request'

export function login(params) {
  return request({
    url: '/user/login',
    method: 'post',
    data: params
  })
}

export function logout() {
  return request({
    url: 'user/logout',
    method: 'post'
  })
}

export function search(params) {
  return request({
    url: '/user/search',
    method: 'post',
    data: params
  })
}

export function create(params) {
  return request({
    url: '/user',
    method: 'post',
    data: params
  })
}

export function detail(id) {
  return request({
    url: '/user/' + id,
    method: 'get'
  })
}

export function update(params) {
  return request({
    url: '/user',
    method: 'put',
    data: params
  })
}

export function del(id) {
  return request({
    url: '/user/' + id,
    method: 'delete'
  })
}

