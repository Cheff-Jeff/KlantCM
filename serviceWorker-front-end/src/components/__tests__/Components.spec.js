import { describe, it, expect } from 'vitest'
import { mount, shallowMount } from '@vue/test-utils'
/*
  Test Login form component mount
*/
import Login from '../LoginForm.vue'
// describe('login form', () => {
//   it('email renders properly', () => {
//     const wrapper = mount(Login)
//     const inputEmail = wrapper.find('input[name="email"]')
//     const testMail = 'admin@adminmail.com';

//     inputEmail.setValue(testMail)
//     expect(wrapper.find('input[name="email"]').element.value).toBe(testMail)
//   })
// })

// describe('login form email validation', () => {
//   it('validates email', ()=>{
//     const wrapper = mount(Login)
//     const testMail = 'admin@adminmail.com';
//     const badEmail = "Test";

//     expect(wrapper.vm.validateEmail(testMail)).toBe(true)
//     expect(wrapper.vm.validateEmail(badEmail)).toBe(false)
//   })
// })
/*
  End login form test

  Test converzation bubbels
*/
import ConverzationSend from '../ConverzationSend.vue'
describe('blue bubble', () => {
  it('mount properly', () => {
    const txt  = 'Test text'
    const time = '12:10'
    const wrapper = mount(ConverzationSend, { 
      props: { 
        Time: time, 
        Text: txt 
      } 
    })

    expect(wrapper.text()).toContain(txt)
    expect(wrapper.text()).toContain(time)
  })
})

import ConverzationHelp from '../ConverzationHelp.vue'
describe('white bubble', () => {
  it('renders properly', () => {
    const time = '00:00'
    const txt  = 'Test converzation.'
    const wrapper = mount(ConverzationHelp, {
      props: {
        Time: time,
        Text: txt
      }
    })

    expect(wrapper.text()).toContain(txt)
    expect(wrapper.text()).toContain(time)
  })
})
/*
  End converzation bubbles test

  Test chat input
*/
import ChatInput from '../ChatInput.vue'
describe('validation', () => {
  it('validates length good', () => {
    const value = 'test'
    const wrapper = mount(ChatInput)
    wrapper.find('#sendBox').setValue(value)
    wrapper.vm.checkKeyEnter()

    expect(wrapper.vm.inputError).toBe('')
  })
})

describe('validation', () => {
  it('validates length error', () => {
    const value = 'Test'
    const wrapper = mount(ChatInput)
    wrapper.find('#sendBox').setValue(value)
    wrapper.vm.checkInput()

    expect(wrapper.vm.inputError).toBe('')
  })
})

describe('validation', () => {
  it('validates length error', () => {
    const value = ''
    const wrapper = mount(ChatInput)
    wrapper.find('#sendBox').setValue(value)
    wrapper.vm.checkInput()

    expect(wrapper.vm.inputError).toBe('Message can not be empty.')
  })
})

describe('form emit', () => {
  it('emits value good', () => {
    const value = 'test'
    const wrapper = mount(ChatInput)
    wrapper.find('#sendBox').setValue(value)
    wrapper.vm.submit()

    console.log(wrapper.emitted())
    expect(wrapper.emitted().text[0][0]).toBe(value)
  })
})