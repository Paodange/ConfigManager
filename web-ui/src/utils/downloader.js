/* eslint-disable no-empty */
import axios from 'axios'
import store from '@/store'
// import { MessageBox, Message } from 'element-ui'
import { getToken } from '@/utils/auth'
import { Promise } from 'q'

// create an axios instance
const service = axios.create({
  baseURL: process.env.VUE_APP_BASE_API, // url = base url + request url
  withCredentials: false, // send cookies when cross-domain requests
  timeout: 5000 // request timeout
})

// request interceptor
service.interceptors.request.use(
  config => {
    // do something before request is sent

    if (store.getters.token) {
      // let each request carry token
      // ['X-Token'] is a custom headers key
      // please modify it according to the actual situation
      config.headers['token'] = getToken()
    }
    return config
  },
  error => {
    // do something with request error
    console.log(error) // for debug
    return Promise.reject(error)
  }
)

// // response interceptor
// service.interceptors.response.use(
// /**
// * If you want to get http information such as headers or status
// * Please return  response => response
// */

//   /**
// * Determine the request status by custom code
// * Here is just an example
// * You can also judge the status by HTTP Status Code
// */
//   response => {
//     const res = response
//     if (res.status !== 200) {
//       Message({
//         message: res.message || 'error',
//         type: 'error',
//         duration: 5 * 1000
//       })
//     } else { // if the custom code is not 20000, it is judged as an error.
//       // 50008: Illegal token; 50012: Other clients logged in; 50014: Token expired;
//       debugger
//       if (res.data.type === 'application/json') {
//         if (res.data.Code === 401 || res.data.Code === 402) {
//           // to re-login
//           MessageBox.confirm('You have been logged out, you can cancel to stay on this page, or log in again', 'Confirm logout', {
//             confirmButtonText: 'Re-Login',
//             cancelButtonText: 'Cancel',
//             type: 'warning'
//           }).then(() => {
//             store.dispatch('user/resetToken').then(() => {
//               location.reload()
//             })
//           })
//           return Promise.reject(res.data.Message || 'error')
//         } else {
//           if (res.data.Code !== 200) {
//             Message({
//               message: res.data.Message || 'error',
//               type: 'error',
//               duration: 5 * 1000
//             })
//             return Promise.reject(res.data.Message || 'error')
//           } else {
//             return res.data
//           }
//         }
//       } else {
//         return res
//       }
//     }
//   },
//   error => {
//     console.log('err' + error) // for debug
//     Message({
//       message: error.message,
//       type: 'error',
//       duration: 5 * 1000
//     })
//     return Promise.reject(error)
//   }
// )

export function download(url, fileName) {
  // axios下载  中文文件名会变成 下滑线 暂时用打开新窗口的方式下载
  window.open(url, '_parent ')

  // service.request({
  //   url: url,
  //   method: 'GET',
  //   responseType: 'blob' // important
  // }).then((resp) => {
  //   const headers = resp.headers
  //   const blob = new Blob([resp.data], {
  //     type: headers['content-type']
  //   })
  //   debugger
  //   if (!fileName) {
  //     fileName = extractFilenameFromResponseHeader(resp)
  //   }
  //   if (typeof window.navigator.msSaveBlob !== 'undefined') {
  //     // IE workaround for "HTML7007: One or more blob URLs were
  //     // revoked by closing the blob for which they were created.
  //     // These URLs will no longer resolve as the data backing
  //     // the URL has been freed."
  //     window.navigator.msSaveBlob(blob, fileName)
  //   } else {
  //     const link = document.createElement('a')
  //     link.href = window.URL.createObjectURL(blob)
  //     link.download = fileName
  //     link.click()
  //     link.remove()
  //   }
  // })
}

// const extractFilenameFromResponseHeader = (response) => {
//   // content-disposition: "attachment; filename=xxxx.docx;"
//   const contentDisposition = response.headers['content-disposition']
//   const patt = new RegExp('filename=([^;]+\\.[^\\.;]+);*')
//   const result = patt.exec(contentDisposition)
//   let filename = ''
//   if (result) {
//     filename = result.length > 0 ? result[1] : ''
//   }
//   // 解码之前尝试去除空格和双引号
//   // content-disposition: "attachment; filename=\"xxxx.docx\";"
//   return decodeURIComponent(filename.trim().replace(new RegExp('"', 'g'), ''))
// }

