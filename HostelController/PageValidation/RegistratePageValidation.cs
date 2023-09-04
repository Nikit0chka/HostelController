using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace HostelController.PageValidation;

internal class RegistratePageValidation : IDataErrorInfo
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? RoomNumber { get; set; }
    public string? BedNumber { get; set; }
    public string? DateOfEntry { get; set; }
    public string? TimeOfEntry { get; set; }
    public string? ValueOfDays { get; set; }

    public string this[string columnName]
    {
        get
        {
            string errorInfo = string.Empty;

            switch (columnName)
            {
                case "Name":
                    if (string.IsNullOrWhiteSpace(Name))
                        errorInfo = "Имя должно быть заполнено!";
                    else if (!Name.All(char.IsLetter))
                        errorInfo = "Имя должно содержать только буквы";
                    break;

                case "Surname":
                    if (string.IsNullOrWhiteSpace(Surname))
                        errorInfo = "Фамилия должна быть заполнена!";
                    else if (!Surname.All(char.IsLetter))
                        errorInfo = "Фамилия должна содержать только буквы!";
                    break;

                case "RoomNumber":
                    if (string.IsNullOrWhiteSpace(RoomNumber))
                        errorInfo = "Номер комнаты должен быть заполнен!";
                    break;

                case "BedNumber":
                    if (string.IsNullOrWhiteSpace(BedNumber))
                        errorInfo = "Номер кровати должен быть заполнен!";
                    break;

                case "DateOfEntry":
                    DateTime.TryParseExact(DateOfEntry, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime DateOfEntryDtTime);

                    if (string.IsNullOrWhiteSpace(DateOfEntry))
                        errorInfo = "Дата въезда должна быть заполнена!";
                    else if (DateOfEntryDtTime.Date < DateTime.Now.Date)
                        errorInfo = "Дата въезда не может быть меньше текущей!";
                    break;

                case "TimeOfEntry":
                    DateTime.TryParseExact(TimeOfEntry, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime TimeOfEntryDtTime);

                    if (string.IsNullOrWhiteSpace(TimeOfEntry))
                        errorInfo = "Время въезда должно быть заполнено!";
                    else if (TimeSpan.Compare(DateTime.Now - TimeOfEntryDtTime, TimeSpan.FromMinutes(2)) > 0)
                        errorInfo = "Время въезда не может быть меньше текущего!";
                    break;

                case "ValueOfDays":
                    if (string.IsNullOrWhiteSpace(ValueOfDays))
                        errorInfo = "Число дней должно быть заполнено!";
                    break;
            }

            return errorInfo;
        }
    }

    public string Error => "Общая ошибка модели данных";
}