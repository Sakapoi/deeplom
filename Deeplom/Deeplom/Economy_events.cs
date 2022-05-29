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
        public static string material = "Виробник сировини - ";
        public static string manufacturer = "Виробник засобів виробництва - ";
        public static string consumer = "Виробник споживчих товарів - ";
        public static string trade = "Торгівля та Послуги - ";
        public static string budget = "Бюджет - ";
        public static string commercial = "Комерційні банки - ";
        public static string buyers = "Покупці споживчих товарі - ";
        public static string bank = "Нацбанк - ";

        //возможные действия
        public static string ev1 = "розрахувати податки та зарплати та виробництво сировини\n";//+
        public static string ev2 = "виплатити податки та зарплати\n";//+
        public static string ev3 = "взяти позику\n";//+
        public static string ev4 = "підвищити емісію\n";//+
        public static string ev5 = "ліквідувати наслідки НС\n";//+
        public static string ev6 = "виробити товар\n";//+
        public static string ev7 = "розрахувати виплати\n";//+
        public static string ev8 = "купити товар\n";//+
        public static string ev9 = "виплатити пенсії та зарплати бюджетникам\n";//+
        public static string ev10 = "продати товар\n";//+
    }
}
