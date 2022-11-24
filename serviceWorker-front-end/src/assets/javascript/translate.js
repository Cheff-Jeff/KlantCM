import { useLink } from "vue-router";
import * as english from "../../languages/english.json"
import * as dutch from "../../languages/dutch.json"
import * as turkish from "../../languages/turkish.json"


export const ChangeLanguage = async() => {
    // console.log(data);

    const langEl = document.querySelector('.langWrap');
    const link = document.querySelectorAll('a');
    const QueueText = document.querySelector('.WaitingInLine');
    const StartRoomText = document.querySelector('.StartRoomBtn');
    const CmBtnList = document.getElementsByTagName('cm-button');
    const MyProfile = CmBtnList[0];
    const LogOut = CmBtnList[1];
    const EndChat = CmBtnList[2];
    const UsersEmpty = document.querySelector('.NoUsers');
    const Day = document.querySelector('.title');
    const Input = document.querySelector('.form-control');
    // console.log(data["Profile"]);

    link.forEach(el => {
            el.addEventListener('click', () => {

                langEl.querySelector('.active').classList.remove('active');

                el.classList.add('active');

                const attr = el.getAttribute('language');

                console.log(attr)

                var lang = null

                if (attr == "english") lang = english
                else if (attr == "dutch") lang = dutch
                else if (attr == "turkish") lang = turkish

                QueueText.textContent = lang["PeopleInQueue"]
                StartRoomText.textContent = lang["StartRoom"]
                MyProfile.dataset.label = lang["Profile"]
                LogOut.dataset.label = lang["LoggingOut"]
                EndChat.dataset.label = lang["EndChat"]
                Day.dataset.label = lang["Today"]
                Input.ariaPlaceholder = lang["InputPlaceholder"]
                UsersEmpty.textContent = lang["NoUsers"]
            });
        }

    )

}