import { createApp } from 'vue'
import { createPinia } from 'pinia'
import { autoAnimatePlugin } from '@formkit/auto-animate/vue'
import {ChatHub} from './assets/javascript/Chat'

import App from './App.vue'
import router from './router'

import 'bootstrap/dist/css/bootstrap.min.css'
import './assets/styles/main.scss'
import 'bootstrap'

const app = createApp(App)

var chat = new ChatHub()
app.config.globalProperties.$chat = chat
app.use(createPinia())
app.use(autoAnimatePlugin)
app.use(router)

app.mount('#app')