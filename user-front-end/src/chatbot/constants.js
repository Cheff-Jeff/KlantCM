// Options the user could type in
const prompts = [
    ["hi", "hey", "hallo", "goedemorgen", "goedemiddag", "hoi"],
    ["ik heb vraag"],
    ["weet ik niet", "geen idee"],
    ["geld"],
    ["sollicitatie", "baan", "vacature"]
]

// Possible responses, in corresponding order

const replies = [
    ["Hallo!", "Hoi!", "Hey!", "Hallo daar!", "Goedendag!"],
    ["Over welk onderwerp gaat uw vraag?", "Waar gaat uw vraag over?"],
    ["U wordt zo spoedig mogelijk geholpen.", "Dat is goed. Wij zoeken een beschikbare medewerker."],
    ["Bedankt, we proberen iemand van de financiële afdeling te vinden."],
    ["Leuk dat u hier over informeert! We zoeken direct een medewerker voor u."]
]

// Random for any other user input

const alternative = [
    "Ik begrijp u niet.",
    "Als u een vraag heeft, kunt u die hier stellen"
]