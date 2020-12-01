import request from '@/utils/request'

export function search(params) {
    return request({
      url: '/material/search',
      method: 'post',
      data: params
    })
  }

  