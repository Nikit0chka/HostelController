   M S B A M L   `   `   `  ����  HostelController(    "HostelController.Pages.HistoryPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5      $	��650��5      $	��750��6     N� 
Background
  ����� � 	Resources 5      *  $System.Windows.Controls.DataGridCell �� 
TargetType   FirstColumnStyle �� Triggers P� Property P� Value �� Property �� Value��%l  &	        '      �� 5	   
   "  6    5
      P� 5       �@J�IsMouseOver$
 True��61   . �5      ��  �@ 	IsEditing$
 True��62   5      P� 5       �@J�IsMouseOver$ False��61   . �5      ��  �@ 	IsEditing$ False��62   5      5      �� 5   
   "  6   .�5      ��  � ��$ Center=�64   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $	��523 �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��ClientsHistoryDataGrid��5      	   AutoGenerateColumns$	 False��61   $
��auto��6M   $��Center=�6Z   
   Columns
 5      4  .System.Windows.Controls.DataGridCheckBoxColumn  5         MetroDataGridCheckBox1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# �  6)      EditingElementStyle# �  5!   %   ,  &System.Windows.Controls.DataGridColumn   Header$ Выбрать��5"   %      	CellStyle# [  66   0  *System.Windows.Controls.DataGridTextColumn  5$      $ Имя��6%      
IsReadOnly$
 True��6K    �� 
IsSelected$ False��6]      Binding 62   �� *Name+6]     5%      $ Фамилия��6%   $
 True��6R   $ False��6d    66   �� *	Surname+6d     5&      $ Номер кровати��6%   $
 True��6V   $ False��6h    6<   �� *BedId+6h     5'      $ Дата въезда��6%   $
 True��6~   $ False��6�    6:   �� *DateOfEntry+ �� StringFormat$ dd.MM.yyyy HH:mm:ss��6�     5(      $ Дата выезда��6%   $
 True��6}   $ False��6�    6:   �� *DateOfLeave+$ dd.MM.yyyy HH:mm:ss��6�   5*      �� 5,   
   $��1��6   $��Center=�6"   $��Center=�6?   .+�5-      �� -   5        $��DeleteHistoryButt��5-       ' #MahApps.Styles.Button.Square.Accent#��[ 6.   $��50��6k   $	��100��6w   $��Удалить��6�   $��16(�6�   $��0q�6�   5.      5/      50      