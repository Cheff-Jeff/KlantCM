import Bots from "../../chatbot/bots"

Bots.push({
    "name": "bot_before",

    "precatch": function(text) {
        return text;
    },

    "actions": [{
            "catch": ["^hello^"],
            "response": "^Hello^!"
        },
        {
            "catch": ["*how are you*"],
            "response": [
                "I'm good thanks! What about you?",
                "Um.. alright, I guess.",
                "I don't feel well."
            ]
        },
        {
            "catch": ["what time is it*"],
            "response": ["It is {TIME}"]
        },
        {
            "catch": ["*name is {=NAME}"],
            "response": ["Hello, {NAME}"]
        }
    ],

    "postcatch": function(text) {
        return text;
    },

    "functions": {},

    "synonyms": [
        ["hello", "hi", "howdy"],
        ["goodbye", "bye", "see you"]
    ],

    "variables": {
        "TIME": function(bot) {
            return (new Date()).toString();
        },
        "MYVARIABLE": "myvalue"
    }
});