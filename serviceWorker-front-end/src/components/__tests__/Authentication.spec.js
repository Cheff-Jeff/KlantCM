import { describe, expect, test } from 'vitest'
/*
  Unit test for signing off
*/
import { Logout } from '../../assets/javascript/Authenticate'
describe('Logout', () => {
  test('Deletes the localStorage item properly.', () => {
    sessionStorage.setItem('user', JSON.stringify("Unit-Test"))
    expect(Logout()).toBe(true)
  })
})

describe('Logout', () => {
  test('Can not find user to logout.', () => {
    expect(Logout()).toBe(false)
  })
})
/*
  End unit test for signing off

  Unit Test RouteGaurd
*/
import { RouteGaurd } from '../../assets/javascript/Authenticate'
describe('RouteGaurd', () => {
  test('User is found', () => {
    sessionStorage.setItem('user', JSON.stringify("Unit-Test-New"))
    expect(RouteGaurd()).toBe(true)
    sessionStorage.removeItem('user')
  })
})

describe('RouteGaurd', () => {
  test('User is not found', () => { expect(RouteGaurd()).toBe(false) })
})
/*
  End unit test for RouteGaurd

  Unit Test Login
*/
// import { Login } from '../../assets/javascript/Authenticate'
// describe('Login', () => {
//   test('User sign in', () => {
//     expect(Login('admin@adminmail.com', 'adminadmin')).toBe(true)
//   })
// })
// describe('Login', () => {
//   test('User sign in faild', () => {
//     expect(Login('fail@mail.com', 'admin')).toBe(false)
//   })
// })
