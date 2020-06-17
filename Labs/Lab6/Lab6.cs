using NXOpen;
using NXOpen.UF;

namespace Lab6
{
    public class Lab6
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
                string name1 = "Cylinder";
                // Задаём тип системы мер (1-метрическая, 2-английская)
                int units1 = 1;

                // Создание новой модели в сессии
                // Входные параметры: name1 - название, units1 - система мер
                // Выходные параметры: UFPart1 - модель
                ufSession.Part.New(name1, units1, out UFPart1);

                // Тэг текущей модели
                Tag parent_part = ufSession.Part.AskDisplayPart();

                // Переменные для записи статуса загрузки моделей
                UFPart.LoadStatus error_status, error_status2, error_status3;

                // Тэги новых моделей
                Tag instance, instance1, instance2;

                // Origin содержат позиции каждой из модели
                // Matrix определяют ориентацию каждой из моделей в системе координат родительской сборочной модели
                double[] origin1 = { 200, 0, 0 };
                double[] matrix1 = { 1, 0, 0, 0, 1, 0 };
                double[] origin2 = { 5, 0, 0 };
                double[] matrix2 = { 1, 0, 0, 0, 1, 0 };
                double[] origin3 = { 0, 0, 0 };
                double[] matrix3 = { 1, 0, 0, 0, 1, 0 };

                // Функции для добавления модели в сборку
                // parent_part – tag модели для добавления деталей
                // part – имя добавляемой модели
                // refset_name – наименование множества частей модели для добавления
                // instance_name - Name of new instance
                // origin [ 3 ] – позиция в родительской модели
                // csys_matrix [ 6 ] – ориентация в родительской модели
                // layer – слой (0) – текущий слой
                // instance – tag новой детали в сборке
                // error_status – статус ошибки добавления
                ufSession.Assem.AddPartToAssembly(parent_part, "model1", null, null, origin1, matrix1, 0, out instance, out error_status);
                //ufSession.Assem.AddPartToAssembly(parent_part, "model2", null, null, origin2, matrix2, 0, out instance1, out error_status2);
                ufSession.Assem.AddPartToAssembly(parent_part, "model3", null, null, origin3, matrix3, 0, out instance2, out error_status3);
            }
            catch (NXException ex)
            {
                // Функция отображения диалогового окна с описанием ошибки
                UI.GetUI().NXMessageBox.Show("Error", NXMessageBox.DialogType.Information, ex.Message);
            }
        }
    }
}