import * as en from "../../../public/languages/english.json"
import * as nl from "../../../public/languages/dutch.json"
import * as tr from "../../../public/languages/turkish.json"

const arrLang = {
    'en': en,
    'nl': nl,
    'tr': tr
}

export const getLang = () => {
    if(localStorage.getItem('lang'))
    {
        const langCode = localStorage.getItem('lang')
        return switchLang(langCode)
    }
    else
    {
        localStorage.setItem('lang', 'en')
        const pref = arrLang['en']
        return Object.create(pref["data"]);
    }
}

export const switchLang = (lang) => {
    const langPref = arrLang[lang]
    if(langPref != null)
    {
        localStorage.setItem('lang', lang)
        return Object.create(langPref["data"]);
    }else{
        localStorage.setItem('lang', 'en')
        const pref = arrLang['en']
        return Object.create(pref["data"]);
    }
}