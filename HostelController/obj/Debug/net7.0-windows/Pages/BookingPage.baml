   M S B A M L   `   `   `  ����  HostelController(    "HostelController.Pages.BookingPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5      $	��650��5      $	��750��6      MahApps.Styles.Page#���   5        N� 
Background
  �����.��5	      � .+�5
   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��Center=�6K   .+�5      �� $ Vertical=�6   $��0 0 25 0q�60   $	��160��6B   .+�5      �� -   5        $��	NameTxtBx��5   �     MahApps.Styles.TextBox#���  6�   -  'MahApps.Metro.Controls.ValidationHelper%   ShowValidationErrorOnMouseOver$
 True��6�   *  $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Имя��6  $��0 0 0 25q�69  $��16(�6K  ��6   �� *Name+ �� ValidatesOnDataErrors$
 True�� �� NotifyOnValidationError$
 True�� �� UpdateSourceTrigger$ PropertyChanged=�6K  �� 5      -   5        $��	RoomCmbBx��5   �     MahApps.Styles.ComboBox#���  6�   $
 True��6�   $ Номер комнаты��6  $��0 0 0 25q�6K  $��16(�6]   �� 
IsEditable$ False��6k   �� Text 6   �� *
RoomNumber+$
 True��$
 True��$ PropertyChanged=�6~  (  "System.Windows.Controls.DatePicker  5      -   5        $��DateOfEntry��5      $
 True��6�   $ Дата въезда��6�   $��0 0 0 25q�6  $��16(�6.  	   Text	 60   �� *DateOfEntry+$
 True��$
 True��$ PropertyChanged=�6.  5      �� 5      $ Vertical=�6   $	��160��60   .+�5      �� -   5        $��SurnameTxtBx��5   �   #���  6�   $
 True��6�   $ Фамилия��6  $��0 0 0 25q�6B  $��16(�6T  ��6   �� *	Surname+$
 True��$
 True��$ PropertyChanged=�6T  �� 5      -   5        $��BedCmbBx��5   �   #���  6�   $
 True��6�   $ Номер кровати��6  $��0 0 0 25q�6H  $��16(�6Z  $ False��6h   6   �� *	BedNumber+$
 True��$
 True��$ PropertyChanged=�6h  '  !MahApps.Metro.Controls.TimePicker  5      -   5        $��TimeOfEntry��5   &   $
 True��6�   $ Время въезда��6  $��0 0 0 25q�62  $��16(�6D  +  %MahApps.Metro.Controls.TimePickerBase
   SelectedDateTime
 69   �� *TimeOfEntry+$
 True��$
 True��$ PropertyChanged=�6D  5      5      *  $MahApps.Metro.Controls.NumericUpDown  5   
   -   5        $��ValueOfDays��5   �   $ Число суток��6�   $
 True��6�   $��16(�6   $
��auto��6.  $
��auto��6<  $��290,409,290,209q�6I     WatermarkAlignment$
 Left=�6b     Minimum$ 1Q�6�     Value 6!   �� *ValueOfDays+$
 True��$
 True��$ PropertyChanged=�6�  �� 5   
   -   5        $��BookButt��5       ' #MahApps.Styles.Button.Square.Accent#���  6!   
�������$ ��Забронировать��6s   $��
0,526,0,68q�6�   $��50��6�   $	��150��6�   $��16(�6�   6�   5      5      