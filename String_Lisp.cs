﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Xml.Linq;

namespace Autocad_Wpf_Autolip_Pipe_12_02_2024
{
    public static class String_Lisp
    {
        public static StringBuilder stringBuilder = new StringBuilder(
           "; Начало оптимизации прорисовки кабелей по трубам" + "\n" +
           "; 1) Добавление слоев 19.03.2019;" + "\n" +
           " (DEFUN c:F_u83(/ x1 y1 y2 y3 circl circl2 circl3 name3 last1" + "\n" +
           "dpat S1 S2 lay N_lay explanation" + "\n" +
           ")" + "\n" +
           "(vl-load-com); подключаем ActiveX для создания слоев и в последующем примечаний" + "\n" +
           "(command \"_OSMODE\" \"0\"); отключение режима 2D привязка" + "\n" +
           "(initget 133); ограничения ввода данных 1 пустой ввод +4 ввод отриц " + "\n" +
            "; чисел 128 произвольный ввод; разрешен 2 ввод нуля и полож знач" + "\n" +
            "(setq y1(getreal \"введите Y:\")); координата Y" + "\n" +
            "(setq x1 (getreal \"введите X:\")) ; координата X" + "\n" +
            "(setq radpat (getreal \"введите радиус патрубка:\")) ; радиус патрубка" + "\n" +
            "(setq megos (getreal \"введите межосевое расстояние:\"))" + "\n" +
            "; межосевое расстояние  отрисовка вверх потом доделаю отрисовка вправо с переносом вниз" + "\n" +
            "; межосевое расстояние" + "\n" +
            "(setq y2 0) ; вспомогательная" + "\n" +
            "(setq y3 0); вспомогательная" + "\n" +
            "(setq x2 0); вспомогательная" + "\n" +
            "(setq last1 0); вспомогательная" + "\n" +
            "(setq circl 0); вспомогательная радиусы" + "\n" +
            "(setq circl2 0) ; вспомогательная" + "\n" +
            "(setq circl3 0); вспомогательная список диаметров" + "\n" +
            "(setq name3 0); вспомогательная список названий кабеля" + "\n" +
            "(setq S1 0) ; площадь кабеля" + "\n" +
            "(setq S2 0) ; площадь трубы" + "\n" +
            "(setq N_lay 0) ; номер кабеля из списка слоев" + "\n" +
            "(setq lay 0); имя для создания текущего слоя(Обозначение кабеля.провода)" + "\n" +
            "(setq explanation 1); пояснение для слоя - а так номер трубы" + "\n" +
            "____________________________________________________________" + "\n" +
  "(foreach circl3" + "\n" +
   " '(; Список диаметров берем из кабельного журнала - впоследствии база данных" + "\n" +
    " 15.2 15.3 15.4 15.5" + "\n" +
    " )" + "\n" +
    "(setq lay(nth N_lay" + "\n" +
     "         '(" + "\n" +
      "        \"333\" \"444\" \"555\" \"666\" " + "\n" +
              ")" + "\n" +
              ")" + "\n" +
    ")" + "\n" +

    "(command \"_.-layer\" \"_m\" lay \"\") ; создаем слои на основе списка\"nth N_lay\" и делаем его текущим для именования кабеля" + "\n" +
    "(setq circl(/ circl3 2))" + "\n" +
    "; преобразуем диаметр в радиус ВНИМАНИЕ ПРОГРАММА РАБОТАЕТ С РАДИУСАМИ" + "\n" +
    "(setq S1 (* 3.14(* circl circl)))" + "\n" +
    "(setq x2 (+ last1 circl))" + "\n" +
    "; складываем настоящий и преведущий радиус" + "\n" +
    "        (setq x1 (+ x2 x1)); координата по X" + "\n" +
    "       (if (> last1 circl) " + "\n" +
    " ; last1 > circl; то y2 = last1 т.е преведущий диаметр.Отступаем по Y по максимальному диаметру" + "\n" +
    " (setq y2 (* 2 last1))" + "\n" +
    " ; при переборе радиусов из списка.Переменная circl" + "\n" +
    ")" + "\n" +
    "(if (> circl last1) " + "\n" +
    " ; last1 > circl; то y2 = last1 т.е преведущий диаметр.Отступаем по Y по максимальному диаметру" + "\n" +
    "(setq y2 (* 2 circl))" + "\n" +
    " ; при переборе радиусов из списка.Переменная circl" + "\n" +
    ")" + "\n" +
    "(if (>= x1 radpat) " + "\n" +
    " ; ограничение кабеля по X" + "\n" +
    "(progn" + "\n" +
    " (setq y1 (+ y2 y1))" + "\n" +
    "; увеличиваем Y на диаметр кабеля(*2 last1)" + "\n" +
    " (setq y3 (+ y2 y3))" + "\n" +
    " (setq x1 0)" + "\n" +
    ")" + "\n" +
    ")" + "\n" +
    "(if (>= circl 13.0) " + "\n" +
     " ; максимальный диаметр одного кабеля" + "\n" +
      "(progn" + "\n" +
       "(setq y3 circl)" + "\n" +
        "(setq y1(+ megos (- y1 y2)))" + "\n" +
        "(setq x1 0)" + "\n" +
       "; (setq explanation(+1 explanation))" + "\n" +
        "; пояснение для слоя - а так номер трубы увеличиваем на 1 при переходе в другой патрубок" + "\n" +
      ")" + "\n" +
    ")" + "\n" +
    "(if (>= y3 radpat) " + "\n" +
    "  ; переход по Y межосевое" + "\n" +
     " (progn" + "\n" +
      "  (setq y1 (+ megos(- y1 y3)))" + "\n" +
       " (setq y3 0)" + "\n" +
        "(setq x1 0)" + "\n" +
        "(setq explanation(+1 explanation))" + "\n" +
        "; пояснение для слоя - а так номер трубы увеличиваем на 1 при переходе в другой патрубок" + "\n" +
      ")" + "\n" +
    ")" + "\n" +
    "(print y1)" + "\n" +
    "(print y3)" + "\n" +
    "(print x1)" + "\n" +
    "(vla-put-description" + "\n" +
    "  (vlax-ename->vla-object(tblobjname \"LAYER\" lay))" + "\n" +
     " explanation" + "\n" +
    ") ; для создания примечаний** пока не используем" + "\n" +
    "; ; ; (command\"_point\"(list x1 y1))" + "\n" +
    "; ; ; ; Черчение точки; перебор 1 - 861" + "\n" +
    "; ; ; (command" + "\n" +
    "; ; ; \"_text\"" + "\n" +
    "; ; ; (list x1 y1)" + "\n" +
    "; ; ; \"1\"" + "\n" +
    "; ; ; \"0\"" + "\n" +
    "; ; ; (rtos circl3 2 2)" + "\n" +
    "; ; ; \"\"" + "\n" +
    "; ; ;    )" + "\n" +
    "; Черчение диаметра по списку; перебор 1 - 861" + "\n" +
    "(command \"_circle\"(list x1 y1) circl)" + "\n" +
    "; Черчение кабелей по списку; перебор 1 - 861" + "\n" +
    "(setq last1 circl)" + "\n" +
    "; присваемаем значение отрисованного круга для сложения с радиусом нового круга" + "\n" +
    "(setq N_lay (+ 1 N_lay)) ; следующий по списку слоев идем от нуля\"0\" нуль - это первый из списка" + "\n" +
    "(prin1 lay)" + "\n" +
  ")" + "\n" +

 " _________________________________________________________" + "\n" +
  "(alert \"Закончили\")" + "\n" +
  "(command \"_OSMODE\" \"5887\")" + "\n" +
  "; включение режима 2D привязка" + "\n" +
")" + "\n");
    }
}


