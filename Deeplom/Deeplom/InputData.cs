using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deeplom
{
    static class InputData //класс для хранения входных данных программы
    {
        //загальні вхідні дані
        public static int speed = 7;//Швидкість покрокового моделювання
        public static int tax_money_percentage = 30;//Відсоток грошей на сплату податку
        public static int pay_wages_percentage = 25;//Відсоток грошей на виплату заробітної плати
        public static int interest_on_loans = 25;//Відсотки за кредитами та депозитами
        public static int national_Bank_rate = 25;//Ставка Національного банку
        public static int loan_repayment_period = 30;//Період часу повернення кредиту
        public static int simulation_period_interval = 365;//Інтервал періоду моделювання

        //Виробники сировини 
        public static int vs_initial_amount_of_money_min = 10;//Первісна мінімальна кількість грошей
        public static int vs_initial_amount_of_money_max = 100;//Первісна максимальна кількість грошей
        public static int vs_process_cycle_time_min = 1;//мінімальний Період циклу технологічного процесу
        public static int vs_process_cycle_time_max = 10;//максимальний Період циклу технологічного процесу
        public static int vs_markup_percentage_min = 10;//мінімальний Відсоток торгової націнки
        public static int vs_markup_percentage_max = 20;//максимальний Відсоток торгової націнки

        //Виробники засобів виробництва 
        public static int vzv_initial_amount_of_money_min = 10;//Первісна мінімальна кількість грошей
        public static int vzv_initial_amount_of_money_max = 100;//Первісна максимальна кількість грошей
        public static int vzv_process_cycle_time_min = 1;//мінімальний Період циклу технологічного процесу
        public static int vzv_process_cycle_time_max = 10;//максимальний Період циклу технологічного процесу
        public static int vzv_markup_percentage_min = 10;//мінімальний Відсоток торгової націнки
        public static int vzv_markup_percentage_max = 20;//максимальний Відсоток торгової націнки

        //Виробники споживчих товарів 
        public static int vst_initial_amount_of_money_min = 10;//Первісна мінімальна кількість грошей
        public static int vst_initial_amount_of_money_max = 100;//Первісна максимальна кількість грошей
        public static int vst_process_cycle_time_min = 1;//мінімальний Період циклу технологічного процесу
        public static int vst_process_cycle_time_max = 10;//максимальний Період циклу технологічного процесу
        public static int vst_markup_percentage_min = 10;//мінімальний Відсоток торгової націнки
        public static int vst_markup_percentage_max = 20;//максимальний Відсоток торгової націнки

        //Торгівля та послуги 
        public static int ttp_initial_amount_of_money_min = 10;//Первісна мінімальна кількість грошей
        public static int ttp_initial_amount_of_money_max = 100;//Первісна максимальна кількість грошей
        public static int ttp_percentage_of_purchases_goods = 50;//Відсоткове співвідношення купівлі товарів

        //Інші
        public static int money_spending_percentage = 10;//Відсотки витрати грошей на «Послуги та торгівлю»
        public static int percentage_of_spending_budget_money = 20;//Відсотки витрачання бюджетних грошей на «Послуги та торгівлю»
        public static int likelihood_of_an_emergency = 15;//Ймовірність настання Надзвичайної Ситуації
        public static int commercial_bank_amount = 100;//Кількість грошей комерційного банку
        public static int national_Bank_total_amount = 100;//Загальна кількість грошей у Нацбанку
    }
}
