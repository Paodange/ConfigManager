import request from '@/utils/request'
import { getLanguage } from '@/lang/index'

export function search(params) {
  return request({
    url: '/device/search',
    method: 'post',
    data: params
  })
}

export function create(params) {
  return request({
    url: '/device',
    method: 'post',
    data: params
  })
}

export function detail(id) {
  return request({
    url: '/device/' + id,
    method: 'get'
  })
}

export function update(params) {
  return request({
    url: '/device',
    method: 'put',
    data: params
  })
}

export function del(id) {
  return request({
    url: '/device/' + id,
    method: 'delete'
  })
}

export function exportXls(params) {
  var locale = getLanguage() === 'zh' ? 'zh-cn' : 'en-us'
  return request({
    url: `/device/export/${locale}`,
    method: 'post',
    data: params
  })
}

export function getDeviceTypes() {
  return [
    { id: 1, name: 'MGISP-96XLEX' },
    { id: 2, name: 'MGISP-100Plus' },
    { id: 3, name: 'Hotel' },
    { id: 4, name: 'Cytomat' },
    { id: 5, name: 'Centrifuge' },
    { id: 6, name: 'XPeel' },
    { id: 7, name: 'PlateLoc' },
    { id: 8, name: 'Robot' },
    { id: 9, name: 'Trans-window' },
    { id: 10, name: 'BMG' },
    { id: 11, name: 'STARlet' },
    { id: 12, name: 'STARlet-BMG' },
    { id: 13, name: 'Interaction' }
  ]
}

export function getRobotPaths(areaName) {
  return robotPath.filter(x => x.area === areaName)
}

const robotPath = [
  { id: 1, area: 'A', name: 'A-DX-TransWindow' },
  { id: 2, area: 'A', name: 'A-MGISP-96XLEX-01' },
  { id: 3, area: 'A', name: 'A-MGISP-96XLEX-02' },
  { id: 4, area: 'A', name: 'A-MGISP-96XLEX-03' },
  { id: 5, area: 'A', name: 'MGISP-100Plus' },
  { id: 6, area: 'A', name: 'A-STARlet-01' },
  { id: 7, area: 'A', name: 'A-STARlet-02' },
  { id: 8, area: 'A', name: 'A-DX-HotelA' },
  { id: 9, area: 'A', name: 'A-DX-HotelB' },
  { id: 10, area: 'A', name: 'A-DX-CytomatA' },
  { id: 11, area: 'A', name: 'A-DX-PlateLocA' },
  { id: 12, area: 'A', name: 'A-DX-HMInteraction' },
  { id: 23, area: 'A', name: 'A-BMG' },
  { id: 24, area: 'A', name: 'A-BMG-1' },
  { id: 25, area: 'A', name: 'A-DX-Station-P' },
  { id: 26, area: 'A', name: 'A-DX-Station-N' },
  { id: 27, area: 'A', name: 'A-DX-Centrifuge' },
  { id: 28, area: 'A', name: 'A-DX-XpeelA' },
  { id: 100, area: 'B', name: 'B-DX-TransWindow' },
  { id: 101, area: 'B', name: 'B-MGISP-96XLEX-01' },
  { id: 102, area: 'B', name: 'B-MGISP-96XLEX-02' },
  { id: 103, area: 'B', name: 'B-MGISP-96XLEX-03' },
  { id: 104, area: 'B', name: 'B-MGISP-100Plus-01' },
  { id: 105, area: 'B', name: 'B-STARlet-01' },
  { id: 106, area: 'B', name: 'B-STARlet-02' },
  { id: 107, area: 'B', name: 'B-DX-HotelA' },
  { id: 108, area: 'B', name: 'B-DX-HotelB' },
  { id: 109, area: 'B', name: 'B-DX-CytomatA' },
  { id: 110, area: 'B', name: 'B-DX-PlateLocA' },
  { id: 111, area: 'B', name: 'B-DX-XpeelA' },
  { id: 112, area: 'B', name: 'B-DX-HMInteraction' },
  { id: 122, area: 'B', name: 'B-BMG' },
  { id: 123, area: 'B', name: 'B-BMG-1' },
  { id: 124, area: 'B', name: 'B-DX-Station-P' },
  { id: 125, area: 'B', name: 'B-DX-Station-N' },
  { id: 126, area: 'B', name: 'B-DX-Centrifuge' },
]

//根据区域获取存储设备的信息
export function getHotelByArea(params) {
  return request({
    url:'/device/hotelDeviceByArea',
    method: 'post',
    data: params
  })
}

export function getSourceByArea(params) {
  return request({
    url:'/device/sourceDeviceByArea',
    method: 'post',
    data: params
  })
}


export function getDeviceByArea(params) {
  return request({
    url:'/device/deviceByArea',
    method: 'post',
    data: params
  })
}

export function getStarletByArea(params) {
  return request({
    url:'/device/starletByArea',
    method: 'post',
    data: params
  })
}

export function getBmgByArea(params) {
  return request({
    url:'/device/bmgByArea',
    method: 'post',
    data: params
  })
}