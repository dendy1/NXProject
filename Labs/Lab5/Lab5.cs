using NXOpen;
using NXOpen.UF;

namespace Lab5
{
    public class Lab5
    {
        // Входной точкой программы NXOpen является метод Main(string[] args)
        public static void Main(string[] args)
        {
            var ufSession = UFSession.GetUFSession();

            try
            {
                // Описание модели с помощью тэга
                Tag UFPart1;
                // Задаём название файла модели
                string name1 = "model_lab_5";
                // Задаём тип системы мер (1-метрическая, 2-английская)
                int units1 = 1;

                // Создание новой модели в сессии
                // Входные параметры: name1 - название, units1 - система мер
                // Выходные параметры: UFPart1 - модель
                ufSession.Part.New(name1, units1, out UFPart1);

                // Описываем конечные точки отрезков эскиза
                double[] l1_endpt1 = { 0, 2.5, 0.00 };
                double[] l1_endpt2 = { 200, 2.5, 0.00 };
                double[] l2_endpt1 = { 200, 2.5, 0.00 };
                double[] l2_endpt2 = { 200, 30.5, 0.00 };
                double[] l3_endpt1 = { 200, 30.5, 0.00 };
                double[] l3_endpt2 = { 0, 30.5, 0.00 };
                double[] l4_endpt1 = { 0, 30.5, 0.00 };
                double[] l4_endpt2 = { 0, 2.5, 0.00 };

                // Создаём 4 новые структуры - отрезки
                UFCurve.Line line1 = new UFCurve.Line();
                UFCurve.Line line2 = new UFCurve.Line();
                UFCurve.Line line3 = new UFCurve.Line();
                UFCurve.Line line4 = new UFCurve.Line();

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

                // Создание отрезков в 3D пространстве
                // Создаём массив тэгов из 7 элементов, в которых будем хранить отрезки, созданные ниже
                // Входные параметры: lineN - координаты конечных точек отрезка
                // Выходные параметры: objarray1[N] - тэг, описывающий созданный отрезок
                Tag[] objarray1 = new Tag[7];
                ufSession.Curve.CreateLine(ref line1, out objarray1[0]);
                ufSession.Curve.CreateLine(ref line2, out objarray1[1]);
                ufSession.Curve.CreateLine(ref line3, out objarray1[2]);
                ufSession.Curve.CreateLine(ref line4, out objarray1[3]);

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

                // Осуществление выдавливания

                // Переменная задающая значения направления выдавливания ось CZ
                double[] direction4 = { 0.0, 0.0, 1.0 };
                // Требуемая, но не используемая переменная
                double[] ref_pt4 = new double[3];
                // Переменная, определяющая значение уклона при выдавливании
                string taper_angle4 = "0.0";
                // Переменная, определяющая параметры начала и конца операции выдавливания
                string[] limit4 = { "-10", "3" };
                // Переменная счетчик и число объектов в эскизе
                int i4, count4 = 6;

                // Массив объектов из 7 элементов. Заполняется указателями на элементы эскиза выдавливания при их построении(линии и дуги)
                Tag[] objarray4 = new Tag[7];
                // Переменные wcs_tag1 – для записи указателя на текущую систему координат; matrix_tag1 – для записи идентификатора матрицысвязанного с объектом и т.д.
                Tag wcs_tag1, matrix_tag1, wcs_tag2, matrix_tag2, wcs_tag3, matrix_tag3, wcs_tag4, matrix_tag4;
                // features4 – переменная для записи указателя на объект, получившийся в результате операции выдавливания
                Tag[] features4;

                // Переменная содержащая значения координат центра дуги 1{x,y,z}
                double[] arc1_centerpt1 = { 35, -50, 30.5 };
                // Переменная содержащая значение угла начала дуги 1 (в радианах)
                double arc1_start_ang1 = 0;
                // Переменная содержащая значение угла конца дуги 1 (в радианах)
                double arc1_end_ang1 = 3.14159265358979324 * 2;
                // Переменная содержащая значение радиуса дуги 1 (в радианах)
                double arc1_rad1 = 5;
                // Создание структуры NX соответствующей дуге 1
                UFCurve.Arc arc1 = new UFCurve.Arc();
                // Установка параметров дуги 1
                // Начальный угол
                arc1.start_angle = arc1_start_ang1;
                // Конечный угол
                arc1.end_angle = arc1_end_ang1;
                // Центр дуги 1
                arc1.arc_center = new double[3];
                // Координата центра дуги 1 по X
                arc1.arc_center[0] = arc1_centerpt1[0];
                // Координата центра дуги 1 по Y
                arc1.arc_center[1] = arc1_centerpt1[1];
                // Координата центра дуги 1 по Z
                arc1.arc_center[2] = arc1_centerpt1[2];
                // Радиус дуги 1
                arc1.radius = arc1_rad1;
                // Получения указателя на активную систему координат
                ufSession.Csys.AskWcs(out wcs_tag1);
                // Получение идентификатора матрицы, связанного с объектом,указатель на который содержится в wcs_tag1
                ufSession.Csys.AskMatrixOfObject(wcs_tag1, out matrix_tag1);
                // Определение указателя матрицы дуги 1
                arc1.matrix_tag = matrix_tag1;
                /*----------------------------------------------------------*/

                /***********************Аналогично дуге 1********************/
                double[] arc2_centerpt2 = { 35, 50, 30.5 };
                double arc2_start_ang2 = 0;
                double arc2_end_ang2 = 3.14159265358979324 * 2;
                double arc2_rad2 = 5;
                UFCurve.Arc arc2 = new UFCurve.Arc();
                arc2.start_angle = arc2_start_ang2;
                arc2.end_angle = arc2_end_ang2;
                arc2.arc_center = new double[3];
                arc2.arc_center[0] = arc2_centerpt2[0];
                arc2.arc_center[1] = arc2_centerpt2[1];
                arc2.arc_center[2] = arc2_centerpt2[2];
                arc2.radius = arc2_rad2;
                ufSession.Csys.AskWcs(out wcs_tag2);
                ufSession.Csys.AskMatrixOfObject(wcs_tag2, out matrix_tag2);
                arc2.matrix_tag = matrix_tag2;
                /*----------------------------------------------------------*/

                /***********************Аналогично дуге 1********************/
                double[] arc3_centerpt3 = { 35, -50, 30.5 };
                double arc3_start_ang3 = -3.14159265358979324;
                double arc3_end_ang3 = 0;
                double arc3_rad3 = 15;
                UFCurve.Arc arc3 = new UFCurve.Arc();
                arc3.start_angle = arc3_start_ang3;
                arc3.end_angle = arc3_end_ang3;
                arc3.arc_center = new double[3];
                arc3.arc_center[0] = arc3_centerpt3[0];
                arc3.arc_center[1] = arc3_centerpt3[1];
                arc3.arc_center[2] = arc3_centerpt3[2];
                arc3.radius = arc3_rad3;
                ufSession.Csys.AskWcs(out wcs_tag3);
                ufSession.Csys.AskMatrixOfObject(wcs_tag3, out matrix_tag3);
                arc3.matrix_tag = matrix_tag3;
                /*----------------------------------------------------------*/

                /***********************Аналогично дуге 1********************/
                double[] arc4_centerpt4 = { 35, 50, 30.5 };
                double arc4_start_ang4 = 0;
                double arc4_end_ang4 = 3.14159265358979324;
                double arc4_rad4 = 15;
                UFCurve.Arc arc4 = new UFCurve.Arc();
                arc4.start_angle = arc4_start_ang4;
                arc4.end_angle = arc4_end_ang4;
                arc4.arc_center = new double[3];
                arc4.arc_center[0] = arc4_centerpt4[0];
                arc4.arc_center[1] = arc4_centerpt4[1];
                arc4.arc_center[2] = arc4_centerpt4[2];
                arc4.radius = arc4_rad4;
                ufSession.Csys.AskWcs(out wcs_tag4);
                ufSession.Csys.AskMatrixOfObject(wcs_tag4, out matrix_tag4);
                arc4.matrix_tag = matrix_tag4;
                /*----------------------------------------------------------*/

                // Определение переменных содержащих координаты начальной и конечной точек отрезков 1 и 2
                // Координаты начальной точки отрезка 1
                double[] l1_endpt1_1 = { 20, -50, 30.5 };
                // Координаты конечной точки отрезка 1
                double[] l1_endpt2_1 = { 20, 50, 30.5 };

                // Координаты начальной точки отрезка 2
                double[] l2_endpt1_1 = { 50, 50, 30.5 };
                // Координаты конечной точки отрезка 2
                double[] l2_endpt2_1 = { 50, -50, 30.5 };

                // Создание переменной объекта отрезок 1
                UFCurve.Line line1_1 = new UFCurve.Line();
                // Создание переменной объекта отрезок 2
                UFCurve.Line line2_1 = new UFCurve.Line();

                // Задание параметров отрезков
                line1_1.start_point = new double[3];
                // Координата Х начальной точки отрезка 1
                line1_1.start_point[0] = l1_endpt1_1[0];
                // Координата Y начальной точки отрезка 1
                line1_1.start_point[1] = l1_endpt1_1[1];
                // Координата Z начальной точки отрезка 1
                line1_1.start_point[2] = l1_endpt1_1[2];

                line1_1.end_point = new double[3];
                // Координата Х конечной точки отрезка 1
                line1_1.end_point[0] = l1_endpt2_1[0];
                // Координата Y конечной точки отрезка 1
                line1_1.end_point[1] = l1_endpt2_1[1];
                // Координата Z конечной точки отрезка 1
                line1_1.end_point[2] = l1_endpt2_1[2];

                line2_1.start_point = new double[3];
                // Координата Х начальной точки отрезка 2
                line2_1.start_point[0] = l2_endpt1_1[0];
                // Координата Y начальной точки отрезка 2
                line2_1.start_point[1] = l2_endpt1_1[1];
                // Координата Z начальной точки отрезка 2
                line2_1.start_point[2] = l2_endpt1_1[2];

                line2_1.end_point = new double[3];
                // Координата Х конечной точки отрезка 2
                line2_1.end_point[0] = l2_endpt2_1[0];
                // Координата Y конечной точки отрезка 2
                line2_1.end_point[1] = l2_endpt2_1[1];
                // Координата Z конечной точки отрезка 2
                line2_1.end_point[2] = l2_endpt2_1[2];

                // Построение дуги 1
                ufSession.Curve.CreateArc(ref arc1 /* объект дуга 1 */, out objarray4[0] /* указатель на созданный объект дуга 1 – 0-й элемент массива объектов выдавливания */);
                // Построение отрезка 1
                ufSession.Curve.CreateLine(ref line1_1, out objarray4[1]);
                // Построение отрезка 2
                ufSession.Curve.CreateLine(ref line2_1, out objarray4[2]);
                // Построение дуги 2
                ufSession.Curve.CreateArc(ref arc2, out objarray4[3]);
                // Построение дуги 3
                ufSession.Curve.CreateArc(ref arc3, out objarray4[4]);
                // Построение дуги 4
                ufSession.Curve.CreateArc(ref arc4, out objarray4[5]);

                // Создание операции выдавливания
                ufSession.Modl.CreateExtruded(
                objarray4 /* Массив объектов выдавливания */,
                taper_angle4 /* Угол уклона */,
                limit4 /* Начало и конец выдавливания */,
                ref_pt4 /* Пустой параметр */,
                direction4 /* Направление выдавливания */,
                FeatureSigns.Positive /* Буревая операция (ОБЕДИНЕНИЕ) */,
                out features4 /* Выходной параметр - указатель на результат операции */);

                // Вторая опора
                // Переменная задающая значения направления выдавливания ось CZ
                double[] direction5 = { 0.0, 0.0, 1.0 };

                // Требуемая, но не используемая переменная
                double[] ref_pt5 = new double[3];
                // Переменная, определяющая значение уклона при выдавливании
                string taper_angle5 = "0.0";
                // Переменная, определяющая параметры начала и конца операции выдавливания
                string[] limit5 = { "-10", "3" };
                // Переменная счетчик и число объектов в эскизе
                int i5, count5 = 6;

                // Массив объектов из 7 элементов. Заполняется указателями на элементы эскиза выдавливания при их построении(линии и дуги)
                Tag[] objarray5 = new Tag[7];
                // Переменные wcs_tag1 – для записи указателя на текущую систему координат; matrix_tag1 – для записи идентификатора матрицысвязанного с объектом и т.д.
                Tag wcs_tag1_1, matrix_tag1_1, wcs_tag2_1, matrix_tag2_1, wcs_tag3_1, matrix_tag3_1, wcs_tag4_1, matrix_tag4_1;
                // features5 – переменная для записи указателя на объект, получившийся в результате операции выдавливания
                Tag[] features5;

                // Переменная содержащая значения координат центра дуги 1 {x, y, z}
                double[] arc1_centerpt1_1 = { 165, -50, 30.5 };
                // Переменная содержащая значение угла начала дуги 1 (в радианах)
                double arc1_start_ang1_1 = 0;
                // Переменная содержащая значение угла конца дуги 1 (в радианах)
                double arc1_end_ang1_1 = 3.14159265358979324 * 2;
                // Переменная содержащая значение радиуса дуги 1 (в радианах)
                double arc1_rad1_1 = 5;

                // Создание структуры NX соответствующей дуге 1
                UFCurve.Arc arc1_1 = new UFCurve.Arc();

                // Установка параметров дуги 1
                // Начальный угол
                arc1_1.start_angle = arc1_start_ang1_1;
                // Конечный угол
                arc1_1.end_angle = arc1_end_ang1_1;
                // Центр дуги 1
                arc1_1.arc_center = new double[3];
                // Координата центра дуги 1 по X
                arc1_1.arc_center[0] = arc1_centerpt1_1[0];
                // Координата центра дуги 1 по Y
                arc1_1.arc_center[1] = arc1_centerpt1_1[1];
                // Координата центра дуги 1 по Z
                arc1_1.arc_center[2] = arc1_centerpt1_1[2];
                // Радиус дуги 1
                arc1_1.radius = arc1_rad1_1;
                // Получения указателя на активную систему координат
                ufSession.Csys.AskWcs(out wcs_tag1_1);
                // Получение идентификатора матрицы, связанного с объектом,указатель на который содержится в wcs_tag1
                ufSession.Csys.AskMatrixOfObject(wcs_tag1_1, out matrix_tag1_1);
                // Определение указателя матрицы дуги 1
                arc1_1.matrix_tag = matrix_tag1_1;
                /*----------------------------------------------------------*/

                /***********************Аналогично дуге 1********************/
                double[] arc2_centerpt2_1 = { 165, 50, 30.5 };
                double arc2_start_ang2_1 = 0;
                double arc2_end_ang2_1 = 3.14159265358979324 * 2;
                double arc2_rad2_1 = 5;
                UFCurve.Arc arc2_1 = new UFCurve.Arc();
                arc2_1.start_angle = arc2_start_ang2_1;
                arc2_1.end_angle = arc2_end_ang2_1;
                arc2_1.arc_center = new double[3];
                arc2_1.arc_center[0] = arc2_centerpt2_1[0];
                arc2_1.arc_center[1] = arc2_centerpt2_1[1];
                arc2_1.arc_center[2] = arc2_centerpt2_1[2];
                arc2_1.radius = arc2_rad2_1;
                ufSession.Csys.AskWcs(out wcs_tag2_1);
                ufSession.Csys.AskMatrixOfObject(wcs_tag2_1, out matrix_tag2_1);
                arc2_1.matrix_tag = matrix_tag2_1;
                /*----------------------------------------------------------*/

                /***********************Аналогично дуге 1********************/
                double[] arc3_centerpt3_1 = { 165, -50, 30.5 };
                double arc3_start_ang3_1 = -3.14159265358979324;
                double arc3_end_ang3_1 = 0;
                double arc3_rad3_1 = 15;
                UFCurve.Arc arc3_1 = new UFCurve.Arc();
                arc3_1.start_angle = arc3_start_ang3_1;
                arc3_1.end_angle = arc3_end_ang3_1;
                arc3_1.arc_center = new double[3];
                arc3_1.arc_center[0] = arc3_centerpt3_1[0];
                arc3_1.arc_center[1] = arc3_centerpt3_1[1];
                arc3_1.arc_center[2] = arc3_centerpt3_1[2];
                arc3_1.radius = arc3_rad3_1;
                ufSession.Csys.AskWcs(out wcs_tag3_1);
                ufSession.Csys.AskMatrixOfObject(wcs_tag3_1, out matrix_tag3_1);
                arc3_1.matrix_tag = matrix_tag3_1;
                /*----------------------------------------------------------*/

                /***********************Аналогично дуге 1********************/
                double[] arc4_centerpt4_1 = { 165, 50, 30.5 };
                double arc4_start_ang4_1 = 0;
                double arc4_end_ang4_1 = 3.14159265358979324;
                double arc4_rad4_1 = 15;
                UFCurve.Arc arc4_1 = new UFCurve.Arc();
                arc4_1.start_angle = arc4_start_ang4_1;
                arc4_1.end_angle = arc4_end_ang4_1;
                arc4_1.arc_center = new double[3];
                arc4_1.arc_center[0] = arc4_centerpt4_1[0];
                arc4_1.arc_center[1] = arc4_centerpt4_1[1];
                arc4_1.arc_center[2] = arc4_centerpt4_1[2];
                arc4_1.radius = arc4_rad4_1;
                ufSession.Csys.AskWcs(out wcs_tag4_1);
                ufSession.Csys.AskMatrixOfObject(wcs_tag4_1, out matrix_tag4_1);
                arc4_1.matrix_tag = matrix_tag4_1;
                /*----------------------------------------------------------*/

                // Определение переменных содержащих координаты начальной и конечной точек отрезков 1 и 2
                // Координаты начальной точки отрезка 1
                double[] l1_endpt1_12 = { 150, -50, 30.5 };
                // Координаты конечной точки отрезка 1
                double[] l1_endpt2_12 = { 150, 50, 30.5 };
                // Координаты начальной точки отрезка 2
                double[] l2_endpt1_12 = { 180, 50, 30.5 };
                // Координаты конечной точки отрезка 2
                double[] l2_endpt2_12 = { 180, -50, 30.5 };

                // Создание переменной объекта отрезок 1
                UFCurve.Line line1_12 = new UFCurve.Line();
                // Создание переменной объекта отрезок 2
                UFCurve.Line line2_12 = new UFCurve.Line();

                // Задание параметров отрезков
                line1_12.start_point = new double[3];
                // Координата Х начальной точки отрезка 1
                line1_12.start_point[0] = l1_endpt1_12[0];
                // Координата Y начальной точки отрезка 1
                line1_12.start_point[1] = l1_endpt1_12[1];
                // Координата Z начальной точки отрезка 1
                line1_12.start_point[2] = l1_endpt1_12[2];

                line1_12.end_point = new double[3];
                // Координата Х конечной точки отрезка 1
                line1_12.end_point[0] = l1_endpt2_12[0];
                // Координата Y конечной точки отрезка 1
                line1_12.end_point[1] = l1_endpt2_12[1];
                // Координата Z конечной точки отрезка 1
                line1_12.end_point[2] = l1_endpt2_12[2];

                line2_12.start_point = new double[3];
                // Координата Х начальной точки отрезка 2
                line2_12.start_point[0] = l2_endpt1_12[0];
                // Координата Y начальной точки отрезка 2
                line2_12.start_point[1] = l2_endpt1_12[1];
                // Координата Z начальной точки отрезка 2
                line2_12.start_point[2] = l2_endpt1_12[2];

                line2_12.end_point = new double[3];
                // Координата Х конечной точки отрезка 2
                line2_12.end_point[0] = l2_endpt2_12[0];
                // Координата Y конечной точки отрезка 2
                line2_12.end_point[1] = l2_endpt2_12[1];
                // Координата Z конечной точки отрезка 2
                line2_12.end_point[2] = l2_endpt2_12[2];

                // Построение дуги 1
                ufSession.Curve.CreateArc(ref arc1_1 /* объект дуга 1 */, out objarray5[0] /* указатель на созданный объект дуга 1 – 0-й элемент массива объектов выдавливания */);
                // Построение отрезка 1
                ufSession.Curve.CreateLine(ref line1_12, out objarray5[1]);
                // Построение отрезка 2
                ufSession.Curve.CreateLine(ref line2_12, out objarray5[2]);
                // Построение дуги 2
                ufSession.Curve.CreateArc(ref arc2_1, out objarray5[3]);
                // Построение дуги 3
                ufSession.Curve.CreateArc(ref arc3_1, out objarray5[4]);
                // Построение дуги 4
                ufSession.Curve.CreateArc(ref arc4_1, out objarray5[5]);

                // Создание операции выдавливания
                ufSession.Modl.CreateExtruded(
                objarray5 /* Массив объектов выдавливания */,
                taper_angle5 /* Угол уклона */,
                limit5 /* Начало и конец выдавливания */,
                ref_pt5 /* Пустой параметр */,
                direction5 /* Направление выдавливания */,
                FeatureSigns.Positive /* Буревая операция (ОБЕДИНЕНИЕ) */,
                out features5 /* Выходной параметр - указатель на результат операции */);

                //Переменная задающая значения направления выдавливания ось CX
                double[] direction6 = { 1.00, 0.00, 0.00 };

                //Задание координат начальной точки вращения
                double[] ref_pt6 = new double[3];
                ref_pt6[0] = 0.00;
                ref_pt6[1] = 0.00;
                ref_pt6[2] = 0.00;

                //Задание пределов вращения
                string[] limit6 = { "0", "360" };

                //объявление массива объектов вращения
                Tag[] objarray6 = new Tag[5];

                //Объявление и определение переменны содержащих координаты точек отрезков эскиза
                double[] l1_endpt1_2 = { 5, 0, 0.00 };
                double[] l1_endpt2_2 = { 200, 0, 0.00 };
                double[] l2_endpt1_2 = { 200, 0, 0.00 };
                double[] l2_endpt2_2 = { 200, 22.85, 0.00 };
                double[] l3_endpt1_2 = { 200, 22.85, 0.00 };
                double[] l3_endpt2_2 = { 20, 22.85, 0.00 };
                double[] l4_endpt1_2 = { 20, 22.85, 0.00 };
                double[] l4_endpt2_2 = { 5, 0, 0.00 };

                // Переменная для записи указателя на объект, получившийся в результате операции вырезания вращением
                Tag[] features6;

                //Создание структур NX соответствующих отрезкам эскиза
                UFCurve.Line line1_2 = new UFCurve.Line();
                UFCurve.Line line2_2 = new UFCurve.Line();
                UFCurve.Line line3_2 = new UFCurve.Line();
                UFCurve.Line line4_2 = new UFCurve.Line();

                //-----------Задаются конечные точки отрезков----------------
                line1_2.start_point = new double[3];
                line1_2.start_point[0] = l1_endpt1_2[0];
                line1_2.start_point[1] = l1_endpt1_2[1];
                line1_2.start_point[2] = l1_endpt1_2[2];
                line1_2.end_point = new double[3];
                line1_2.end_point[0] = l1_endpt2_2[0];
                line1_2.end_point[1] = l1_endpt2_2[1];
                line1_2.end_point[2] = l1_endpt2_2[2];

                line2_2.start_point = new double[3];
                line2_2.start_point[0] = l2_endpt1_2[0];
                line2_2.start_point[1] = l2_endpt1_2[1];
                line2_2.start_point[2] = l2_endpt1_2[2];
                line2_2.end_point = new double[3];
                line2_2.end_point[0] = l2_endpt2_2[0];
                line2_2.end_point[1] = l2_endpt2_2[1];
                line2_2.end_point[2] = l2_endpt2_2[2];

                line3_2.start_point = new double[3];
                line3_2.start_point[0] = l3_endpt1_2[0];
                line3_2.start_point[1] = l3_endpt1_2[1];
                line3_2.start_point[2] = l3_endpt1_2[2];
                line3_2.end_point = new double[3];
                line3_2.end_point[0] = l3_endpt2_2[0];
                line3_2.end_point[1] = l3_endpt2_2[1];
                line3_2.end_point[2] = l3_endpt2_2[2];

                line4_2.start_point = new double[3];
                line4_2.start_point[0] = l4_endpt1_2[0];
                line4_2.start_point[1] = l4_endpt1_2[1];
                line4_2.start_point[2] = l4_endpt1_2[2];
                line4_2.end_point = new double[3];
                line4_2.end_point[0] = l4_endpt2_2[0];
                line4_2.end_point[1] = l4_endpt2_2[1];
                line4_2.end_point[2] = l4_endpt2_2[2];
                //---------------------------------------------------

                //Построение отрезков в 3D пространстве
                ufSession.Curve.CreateLine(ref line1_2, out objarray6[0]);
                ufSession.Curve.CreateLine(ref line2_2, out objarray6[1]);
                ufSession.Curve.CreateLine(ref line3_2, out objarray6[2]);
                ufSession.Curve.CreateLine(ref line4_2, out objarray6[3]);

                //Создание операции вырезания вращением
                ufSession.Modl.CreateRevolved(objarray6, limit6, ref_pt6, direction6, FeatureSigns.Negative, out features6);
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
