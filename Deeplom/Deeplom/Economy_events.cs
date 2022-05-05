using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deeplom
{
    static class Economy_events//класс для хранения возможных событий
    {
        public static int day = 0;//счетчик дней

        //итоговая строка событий
        public static string result = "                         Початок моделювання\n";

        //возможные предприятия
        public static string material = "Виробник сировини";
        public static string manufacturer = "Виробник засобів виробництва";
        public static string consumer = "Виробник споживчих товарів";
        public static string trade = "Торгівля та Послуги";
        public static string budget = "Бюджет";
        public static string commercial = "Комерційні банки";
        public static string buyers = "Покупці споживчих товарі";
        public static string bank = "Нацбанк";

        //возможные действия
        public static string ev1 = "розрахувати податки та зарплати та виробництво сировини";
        public static string ev2 = "виплатити податки та зарплати";
        public static string ev3 = "взяти позику";
        public static string ev4 = "розрахувати повернення за позиками";
        public static string ev5 = "сплатити борг за позиками";
        public static string ev6 = "виробити товар";
        public static string ev7 = "розрахувати виплати";
        public static string ev8 = "купити товар";
        public static string ev9 = "виплатити пенсії та зарплати бюджетникам";
        public static string ev10 = "розширити виробництво";
    }
}
