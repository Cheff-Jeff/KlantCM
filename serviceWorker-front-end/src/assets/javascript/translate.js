import { useLink } from "vue-router";
import * as english from "../../languages/english.json"
import * as dutch from "../../languages/dutch.json"
import * as turkish from "../../languages/turkish.json"


export const ChangeLanguage = async() => {
    console.log("Check 1 - translate.js");

    const langEl = document.querySelector('.langWrap');
    const link = document.querySelectorAll('a');
    const QueueText = document.querySelector('.WaitingInLine');
    const StartRoomText = document.querySelector('.StartRoomBtn');
    const CmBtnList = document.getElementsByTagName('cm-button');
    const MyProfile = CmBtnList[0];
    const LogOut = CmBtnList[1];
    const ChooseLanguage = CmBtnList[2];
    const EndChat = CmBtnList[3];
    const UsersEmpty = document.querySelector('.NoUsers');
    const Day = document.querySelector('.title');
    const Input = document.querySelector('.form-control');

    link.forEach(el => {

        console.log("Check 2 - link.forEach");

        el.addEventListener('click', () => {

            console.log("Check 3 - el.EventListener")

            langEl.querySelector('.active').classList.remove('active');

            el.classList.add('active');

            const attr = el.getAttribute('language');

            console.log(attr)

            var lang = null

            if (attr == "english") lang = english
            else if (attr == "dutch") lang = dutch
            else if (attr == "turkish") {
                lang = turkish
                console.log("Check 4 - lang = turkish")
            }

            QueueText.textContent = lang["PeopleInQueue"]
            StartRoomText.textContent = lang["StartRoom"]
            MyProfile.dataset.label = lang["Profile"]
            LogOut.dataset.label = lang["LoggingOut"]
            ChooseLanguage.dataset.label = lang["ChangeLang"]
            EndChat.dataset.label = lang["EndChat"]
            Day.dataset.label = lang["Today"]
            Input.ariaPlaceholder = lang["InputPlaceholder"]
            UsersEmpty.textContent = lang["NoUsers"]
        });
    })

}