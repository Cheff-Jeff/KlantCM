import { describe, it, expect } from 'vitest'

import { mount } from '@vue/test-utils'
// import Header from '../Header.vue'
import HelloWorld from '../HelloWorld.vue'

describe('HelloWorld', () => {
  it('renders properly', () => {
    const wrapper = mount(HelloWorld, { props: { msg: 'Hello Vitest' } })
    expect(wrapper.text()).toContain('Hello Vitest')
  })
})

// describe('Header', () => {
//   it('renders properly', () => {
//     const wrapper = mount(Header, { props: { CompanyName: 'Hello Vitest' } })
//     expect(wrapper.text()).toContain('Hello Vitest')
//   })
// })
