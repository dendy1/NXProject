// Подключение необходимых библиотек. Для работы необходима только одна библиотека NXOpen
using NXOpen;
using NXOpen.UF;

namespace Lab2
{
    public class Lab2
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
                string name1 = "model_k";
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

                // Сохранение детали в файл с именем, заданным переменной name1 в папку по адресу F:/Projects/NX/UGII/
                ufSession.Part.SaveAs("F:/Projects/NX/UGII/" + name1);

            }
            catch (NXException ex)
            {
                // Функция отображения диалогового окна, аналогична той, что выше
                UI.GetUI().NXMessageBox.Show("Error", NXMessageBox.DialogType.Information, ex.Message);
            }
        }
    }
}
