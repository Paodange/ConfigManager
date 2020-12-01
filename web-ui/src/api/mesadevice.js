import request from '@/utils/request'
import { getLanguage } from '@/lang/index'

export function getDeviceByArea(params) {
  return request({
    url:'/device/deviceByArea',
    method: 'post',
    data: params
  })
}

export function search(params) {
  return request({
    url: '/mesa/mesaDeviceById',
    method: 'post',
    data: params
  })
}

export function clear(params){
  return request({
    url:'/mesa/clearMesa',
    method:'post',
    data:params
    })
}

export function synMesa(params){
  return request({
    url:'/mesa/synMesa',
    method:'post',
    data:params
    })
}


