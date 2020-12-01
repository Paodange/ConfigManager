import { constantRoutes } from '@/router'

const state = {
  routes: []
}
const mutations = {
  SET_ROUTES: (state) => {
    state.routes = constantRoutes
  }
}

const actions = {
  generateRoutes({ commit }) {
    return new Promise(resolve => {
      commit('SET_ROUTES', constantRoutes)
      resolve(constantRoutes)
    })
  }
}
export default {
  namespaced: true,
  state,
  mutations,
  actions
}
