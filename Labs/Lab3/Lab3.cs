// Подключение библиотек
using NXOpen;
using NXOpen.UF;
using System.Collections;

namespace Lab3
{
    public class Lab3
    {
        // Входной точкой программы NXOpen является метод Main(string[] args)
        public static void Main(string[] args)
        {
            var ufSession = UFSession.GetUFSession();

            // Используем блок try-catch для обработки ошибок
            try
            {
                // Описание модели с помощью тэга
                Tag UFPart1;
                // Задаём название файла модели
                string name1 = "model_lab_3";
                // Задаём тип системы мер (1-метрическая, 2-английская)
                int units1 = 1;

                // Создание новой модели в сессии
                // Входные параметры: name1 - название, units1 - система мер
                // Выходные параметры: UFPart1 - модель
                ufSession.Part.New(name1, units1, out UFPart1);

                // Описываем конечные точки отрезков эскиза
                double[] l1_endpt1 = { 0, 5, 0.00 };
                double[] l1_endpt2 = { 2, 5, 0.00 };
                double[] l2_endpt1 = { 2, 5, 0.00 };
                double[] l2_endpt2 = { 2, 32.5, 0.00 };
                double[] l3_endpt1 = { 2, 32.5, 0.00 };
                double[] l3_endpt2 = { -18, 32.5, 0.00 };
                double[] l4_endpt1 = { -18, 32.5, 0.00 };
                double[] l4_endpt2 = { -18, 30.5, 0.00 };
                double[] l5_endpt1 = { -18, 30.5, 0.00 };
                double[] l5_endpt2 = { 0, 30.5, 0.00 };
                double[] l6_endpt1 = { 0, 30.5, 0.00 };
                double[] l6_endpt2 = { 0, 5, 0.00 };

                // Создаём 6 новых структур - отрезков
                UFCurve.Line line1 = new UFCurve.Line();
                UFCurve.Line line2 = new UFCurve.Line();
                UFCurve.Line line3 = new UFCurve.Line();
                UFCurve.Line line4 = new UFCurve.Line();
                UFCurve.Line line5 = new UFCurve.Line();
                UFCurve.Line line6 = new UFCurve.Line();

                // Задаём конечные точки для отрезков
                // Для каждого отрезка задаются координаты X,Y,Z начала и конца
                line1.start_point = new double[3];
                line1.start_point[0] = l1_endpt1[0];
                line1.start_point[1] = l1_endpt1[1];
                line1.start_point[2] = l1_endpt1[2];
                line1.end_point = new double[3];
                line1.end_point[0] = l1_endpt2[0];
                line1.end_point[1] = l1_endpt2[1];
                line1.end_point[2] = l1_endpt2[2];

                line2.start_point = new double[3];
                line2.start_point[0] = l2_endpt1[0];
                line2.start_point[1] = l2_endpt1[1];
                line2.start_point[2] = l2_endpt1[2];
                line2.end_point = new double[3];
                line2.end_point[0] = l2_endpt2[0];
                line2.end_point[1] = l2_endpt2[1];
                line2.end_point[2] = l2_endpt2[2];

                line3.start_point = new double[3];
                line3.start_point[0] = l3_endpt1[0];
                line3.start_point[1] = l3_endpt1[1];
                line3.start_point[2] = l3_endpt1[2];
                line3.end_point = new double[3];
                line3.end_point[0] = l3_endpt2[0];
                line3.end_point[1] = l3_endpt2[1];
                line3.end_point[2] = l3_endpt2[2];

                line4.start_point = new double[3];
                line4.start_point[0] = l4_endpt1[0];
                line4.start_point[1] = l4_endpt1[1];
                line4.start_point[2] = l4_endpt1[2];
                line4.end_point = new double[3];
                line4.end_point[0] = l4_endpt2[0];
                line4.end_point[1] = l4_endpt2[1];
                line4.end_point[2] = l4_endpt2[2];

                line5.start_point = new double[3];
                line5.start_point[0] = l5_endpt1[0];
                line5.start_point[1] = l5_endpt1[1];
                line5.start_point[2] = l5_endpt1[2];
                line5.end_point = new double[3];
                line5.end_point[0] = l5_endpt2[0];
                line5.end_point[1] = l5_endpt2[1];
                line5.end_point[2] = l5_endpt2[2];

                line6.start_point = new double[3];
                line6.start_point[0] = l6_endpt1[0];
                line6.start_point[1] = l6_endpt1[1];
                line6.start_point[2] = l6_endpt1[2];
                line6.end_point = new double[3];
                line6.end_point[0] = l6_endpt2[0];
                line6.end_point[1] = l6_endpt2[1];
                line6.end_point[2] = l6_endpt2[2];

                // Создание отрезков в 3D пространстве
                // Создаём массив тэгов из 7 элементов, в которых будем хранить отрезки, созданные ниже
                // Входные параметры: lineN - координаты конечных точек отрезка
                // Выходные параметры: objarray1[N] - тэг, описывающий созданный отрезок
                Tag[] objarray1 = new Tag[7];
                ufSession.Curve.CreateLine(ref line1, out objarray1[0]);
                ufSession.Curve.CreateLine(ref line2, out objarray1[1]);
                ufSession.Curve.CreateLine(ref line3, out objarray1[2]);
                ufSession.Curve.CreateLine(ref line4, out objarray1[3]);
                ufSession.Curve.CreateLine(ref line5, out objarray1[4]);
                ufSession.Curve.CreateLine(ref line6, out objarray1[5]);

                // Создаём массив, описывающий точку с нулевыми координатами
                // Относительно этой точки будем осуществлять вращение
                double[] ref_pt1 = new double[3];
                ref_pt1[0] = 0.00;
                ref_pt1[1] = 0.00;
                ref_pt1[2] = 0.00;

                // Создаём массив, описывающий вектор, относитеольно которого будет осуществляться вращение
                double[] direction1 = { 1.00, 0.00, 0.00 };

                // Создаём массив, описывающий начальный и конечный угол для операции вращения
                string[] limit1 = { "0", "360" };

                // Создаём массив тэгов для храения выходной информации операции "Вращение"
                Tag[] features1;

                // Осуществляем вращение
                // Входные параметры: 
                //      objarray1 - массив элементов эскиза операции
                //      limit1 - начальный и конечный угол вращения
                //      ref_pt1 - базовая точка
                //      direction1 - вектор, относительно которого осуществляется вращение
                //      FeatureSigns.Nullsign - задает булеву операцию, вданном случае операция отсутствует
                // Выходные параметры: features1 - массив тэгов для храения выходной информации операции "Вращение"
                ufSession.Modl.CreateRevolved(objarray1, limit1, ref_pt1, direction1, FeatureSigns.Nullsign, out features1);

                // Начало 3 лабораторной работы
                // Выбираем из массива созданных деталей features1 первый и единственный элемент
                Tag feat = features1[0];
                Tag cyl_tag, obj_id_camf, blend1;
                Tag[] Edge_array_cyl, list1, list2;
                int ecount;

                // Анализируем рёбра рассматриваемой модели
                // Входные параметры: feat - тэг построенной нами модели
                // Выходные параметры: cyl_tag - тэг, описывающий тэг объектов модели
                ufSession.Modl.AskFeatBody(feat, out cyl_tag);

                // Входные параметры: cyl_tag - тэг, описывающий тэг объектов модели
                // Выходные параметры: Edge_array_cyl - массив тэгов рёбер объекта, используемый в качестве аргумента в строке ниже
                ufSession.Modl.AskBodyEdges(cyl_tag, out Edge_array_cyl);

                // Входные параметры: Edge_array_cyl - массив тэгов рёбер объекта
                // Выходные параметры: ecount - количество объектов в модели (в нашем случае число рёбер модели)
                ufSession.Modl.AskListCount(Edge_array_cyl, out ecount);

                // Массив, используемый для сохранения в него рёбер, на которых будут выполнены фаски
                ArrayList arr_list1 = new ArrayList();

                // Массив, используемый для сохранения в него рёбер, на которых будут выполнено скругление
                ArrayList arr_list2 = new ArrayList();

                for (int ii = 0; ii < ecount; ii++)
                {
                    // Выбираем из массива рёбер каждое отдельное ребро с номером ii
                    Tag edge;
                    ufSession.Modl.AskListItem(Edge_array_cyl, ii, out edge);

                    // Для текущего ребра будет создана фаска => добавляем ребро в первый массив
                    if ((ii == 1) || (ii == 2))
                    {
                        arr_list1.Add(edge);
                    }

                    // Для текущего ребра будет выполнено скругление => добавляем ребро во второй массив
                    if (ii == 0) 
                    { 
                        arr_list2.Add(edge); 
                    }
                }

                // Конвертируем список в массив
                list1 = (Tag[])arr_list1.ToArray(typeof(Tag));
                list2 = (Tag[])arr_list2.ToArray(typeof(Tag));

                // Выполняем скругление
                // Описываем параметры для функции скругления
                int allow_smooth = 0;
                int allow_cliff = 0;
                int allow_notch = 0;
                double vrb_tol = 0.0;

                // Функция скругления
                // Входные параметры: 
                //      "3" - радиус
                //      list2 - массив ребер, на которых необходимо выполнить скругление
                //      allow_smooth - Smooth overflow/prevent flag: 0 = Allow this type of blend; 1 = Prevent this type of blend
                //      allow_cliff - Cliffedge overflow/prevent flag: 0 = Allow this type of blend; 1 = Prevent this type of blend
                //      allow_notch - Notch overflow/prevent flag: 0 = Allow this type of blend; 1 = Prevent this type of blend;
                //      vrb_tol - Variable radius blend tolerance
                // Выходные параметры: blend1 - тэг, для описания фасок
                ufSession.Modl.CreateBlend("3", list2, allow_smooth, allow_cliff, allow_notch, vrb_tol, out blend1);

                // Выполняем фаску
                // Описываем параметры для функции фаски
                string offset1 = "1";
                string offset2 = "1";
                string ang = "45";

                // Функция скругления
                // Входные параметры: 
                //      3 - тип входных данных (в данном случае по стороне и углу)
                //      offset1, offset2 - стороны фаски
                //      ang – угол фаски в градусах
                //      list1 – массив ребер, на которых необходимо выполнить фаски
                // Выходные параметры: obj_id_camf - тэг, для описания скругления
                ufSession.Modl.CreateChamfer(3, offset1, offset2, ang, list1, out obj_id_camf);

                // Сохранение детали в файл с именем, заданным переменной name1
                ufSession.Part.Save();

            }
            catch (NXException ex)
            {
                // Функция отображения диалогового окна с описанием ошибки
                UI.GetUI().NXMessageBox.Show("Error", NXMessageBox.DialogType.Information, ex.Message);
            }
        }
    }
}