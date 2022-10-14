import { describe, it, expect } from 'vitest'
import { shallowMount } from '@vue/test-utils'
import ChatInput from '../ChatInput.vue'


describe('ChatInput.vue Test', () => {
    it('renders message when component is created', () => {
        // render the component
        const wrapper = shallowMount(ChatInput, {
            propsData: {
                title: 'Vue Project'
            }
        })

        // check that the title is rendered
        expect(wrapper.text()).toMatch('Vue Project')
    })
})