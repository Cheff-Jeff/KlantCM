import { useLink } from "vue-router";

export const ChangeLanguage = async() => {

    const langEl = document.querySelector('.langWrap');
    const link = document.querySelectorAll('a');
    const QueueText = document.querySelector('.WaitingInLine');
    const StartRoomText = document.querySelector('.StartRoomBtn');
    const CmBtnList = document.getElementsByTagName('cm-button');
    const MyProfile = CmBtnList[0];
    const LogOut = CmBtnList[1];
    const EndChat = CmBtnList[2];
    const UsersEmpty = document.querySelector('.NoUsers');

    // console.log(CmBtnList);
    // console.log(CmBtnList[1])
    // console.log(CmBtnList[1].__label)
    // CmBtnList[1].dataset.label = 'hoi'
    // CmBtnList[0].dataset.label = 'doe'

    // for (let i = 0; i < CmBtnList.length; i++) {
    //     const el = CmBtnList[i]
    //     console.log(el)
    //     el.addEventListener('click', () => {
    //         langEl.querySelector('.active').classList.remove('active');

    //         console.log(querySelector('.active').classList.remove('active'))

    //         el.classList.add('active');

    //         const attr = el.getAttribute('language');

    //         CmBtnList[1].__label = "hoi"
    //     });
    // }

    link.forEach(el => {
            el.addEventListener('click', () => {
                langEl.querySelector('.active').classList.remove('active');

                el.classList.add('active');

                const attr = el.getAttribute('language');

                console.log(attr)

                QueueText.textContent = data[attr].PeopleInQueue
                StartRoomText.textContent = data[attr].StartRoom
                MyProfile.dataset.label = data[attr].Profile
                LogOut.dataset.label = data[attr].LoggingOut
                EndChat.dataset.label = data[attr].EndChat
                UsersEmpty.textContent = data[attr].NoUsers
            });
        }

    )

    var data = {
        "english": {
            "PeopleInQueue": "20 people are waiting in line.",
            "StartRoom": "Start chat",
            "Profile": "My profile",
            "LoggingOut": "Log out",
            "EndChat": "End active chat",
            "NoUsers": "NO USERS"
        },
        "dutch": {
            "PeopleInQueue": "Er wachten 20 mensen in de rij.",
            "StartRoom": "Start gesprek",
            "Profile": "Mijn profiel",
            "LoggingOut": "Uitloggen",
            "EndChat": "Beëindig gesprek",
            "NoUsers": "GEEN GEBRUIKERS"
        }
    }
}