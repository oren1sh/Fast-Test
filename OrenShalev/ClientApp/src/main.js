import Vue from 'vue'
import './plugins/vuetify'
import App from './App.vue'
import './registerServiceWorker'
import Home from './views/Home.vue'

Vue.config.productionTip = false

Vue.component("f-home", Home)


new Vue({

  render: h => h(App)
}).$mount('#app')
