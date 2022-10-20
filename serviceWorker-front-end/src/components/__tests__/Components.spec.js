import { describe, it, expect } from 'vitest'
import { mount } from '@vue/test-utils'
/*
  Test Login form component mount
*/
import Login from '../LoginForm.vue'
describe('login form', () => {
  it('email renders properly', () => {
    const wrapper = mount(Login)
    const inputEmail = wrapper.find('input[name="email"]')
    const testMail = 'admin@adminmail.com';

    inputEmail.setValue(testMail)
    expect(wrapper.find('input[name="email"]').element.value).toBe(testMail)
  })
})

describe('login form email validation', () => {
  it('validates email', ()=>{
    const wrapper = mount(Login)
    const testMail = 'admin@adminmail.com';
    const badEmail = "Test";

    expect(wrapper.vm.validateEmail(testMail)).toBe(true)
    expect(wrapper.vm.validateEmail(badEmail)).toBe(false)
  })
})