using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deeplom
{
    static class Сharacteristics//класс для хранения характеристик модели
    {
        //виробник сировини
        public static int material_coming = 0;//приход
        public static int material_consumption = 0;//расход
        public static int material_raw = 0;//сырье
        public static int material_remainder = 0;//остаток

        //Виробник засобів виробництва
        public static int manufacturer_coming = 0;//приход
        public static int manufacturer_consumption = 0;//расход
        public static int manufacturer_raw = 0;//сырье
        public static int manufacturer_remainder = 0;//остаток

        //Виробник споживчих товарів
        public static int consumer_coming = 0;//приход
        public static int consumer_consumption = 0;//расход
        public static int consumer_raw = 0;//сырье
        public static int consumer_remainder = 0;//остаток

        //Торгівля та Послуги
        public static int trade_coming = 0;//приход
        public static int trade_consumption = 0;//расход
        public static int trade_raw = 0;//сырье
        public static int trade_remainder = 0;//остаток

        //Бюджет
        public static int budget_coming = 0;//приход
        public static int budget_consumption = 0;//расход
        public static int budget_remainder = 0;//остаток

        //Комерційні банки
        public static int commercial_coming = 0;//приход
        public static int commercial_consumption = 0;//расход
        public static int commercial_remainder = 0;//остаток

        //Покупці споживчих товарі
        public static int buyers_coming = 0;//приход
        public static int buyers_consumption = 0;//расход
        public static int buyers_remainder = 0;//остаток

        //Нацбанк
        public static int bank_stock = 0;//запас
        public static int bank_consumption = 0;//расход
        public static int bank_emission = 0;//эмиссия
        public static int bank_remainder = 0;//остаток
    }
}
