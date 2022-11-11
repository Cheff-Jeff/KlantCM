export const ChangeLanguage = async() => {

    const langEl = document.querySelector('.langWrap');
    const link = document.querySelectorAll('a');
    const QueueText = document.querySelector('.WaitingInLine');
    const StartRoomText = document.querySelector('.StartRoomBtn');
    const EndChatText = document.querySelector('.EndChatBtn');


    link.forEach(el => {
        el.addEventListener('click', () => {
            langEl.querySelector('.active').classList.remove('active');

            el.classList.add('active');

            const attr = el.getAttribute('language');

            QueueText.textContent = data[attr].PeopleInQueue
            StartRoomText.textContent = data[attr].StartRoom
            EndChatText.textContent = data[attr].EndChat
        });
    });

    var data = {
        "english": {
            "PeopleInQueue": "20 people are waiting in line.",
            "StartRoom": "Start chat",
            "EndChat": "End active chat"
        },
        "dutch": {
            "PeopleInQueue": "Er wachten 20 mensen in de rij.",
            "StartRoom": "Start gesprek",
            "EndChat": "Beëindig gesprek"
        }
    }
}