using System.Linq;
using System.ComponentModel;

namespace HostelController;

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
            string ErorInfo = string.Empty;

            switch (columnName)
            {
                case "Name":
                    if (string.IsNullOrWhiteSpace(Name))
                        ErorInfo = "Имя должно быть заполнено!";
                    else if (!Name.All(char.IsLetter))
                        ErorInfo = "Имя должно содержать только буквы";
                    break;
                case "Surname":
                    if (string.IsNullOrWhiteSpace(Surname))
                        ErorInfo = "Фамилия должна быть заполнена!";
                    else if (!Surname.All(char.IsLetter))
                        ErorInfo = "Фамилия должна содержать только буквы!";
                    break;
                case "RoomNumber":
                    if (string.IsNullOrWhiteSpace(RoomNumber))
                        ErorInfo = "Номер комнаты должен быть заполнен!";
                    break;
                case "BedNumber":
                    if (string.IsNullOrWhiteSpace(BedNumber))
                        ErorInfo = "Номер кровати должен быть заполнен!";
                    break;
                case "DateOfEntry":
                    if (string.IsNullOrWhiteSpace(DateOfEntry))
                        ErorInfo = "Дата въезда должна быть заполнена!";
                    break;
                case "TimeOfEntry":
                    if (string.IsNullOrWhiteSpace(TimeOfEntry))
                        ErorInfo = "Время въезда должно быть заполнено!";
                    break;
                case "ValueOfDays":
                    if (string.IsNullOrWhiteSpace(ValueOfDays))
                        ErorInfo = "Число дней должно быть заполнено!";
                    break;
            }
            return ErorInfo;
        }
    }

    public string Error => throw new System.NotImplementedException();
}