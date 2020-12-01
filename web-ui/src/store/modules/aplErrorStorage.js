const state = {
  error: null
}

const mutations = {
  SET_ERRORID: (state, errorId) => {
    state.errorId = errorId
  },
  SET_ERROR: (state, error) => {
    state.error = error
  }
}

const actions = {
  setError({ commit }, error) {
    debugger
    commit('SET_ERROR', error)
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions
}
