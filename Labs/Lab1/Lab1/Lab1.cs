// Подключение необходимых библиотек. Для работы необходима только одна библиотека NXOpen
using NXOpen;

namespace Lab1
{
    public class Lab1
    {
        // Входной точкой программы NXOpen является метод Main(string[] args)
        public static void Main(string[] args)
        {
            // Используем блок try-catch для обработки ошибок
            try
            {
                // Функция отображения диалогового окна
                // "Message" - заголовок окна
                // NXMessageBox.DialogType.Information - тип окна, в данном случае информационный
                // "Изучаем NXOPEN/API" - тескт сообщения
                UI.GetUI().NXMessageBox.Show("Message", NXMessageBox.DialogType.Information, "Изучаем NXOPEN/API");
            }
            catch (NXException ex)
            {
                // Функция отображения диалогового окна, аналогична той, что выше
                UI.GetUI().NXMessageBox.Show("Error", NXMessageBox.DialogType.Information, ex.Message);
            }
        }
    }
}
