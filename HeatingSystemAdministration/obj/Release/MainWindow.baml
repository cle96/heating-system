   M S B A M L   `   `   `  ���� V  RHeatingSystemAdministration, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:HeatingSystemAdministrationHeatingSystemAdministration  ,    &HeatingSystemAdministration.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ;local)clr-namespace:HeatingSystemAdministration       � Title$  
MainWindow��$	��382��$	��880��.��� -   $��grid1�� J� RenderTransformOrigin$ 0.487,0.499&� � ColumnDefinitions �� $
��257* ��� $
��158* ��� $
��457* �.+��� $��0��$��5,5,2,5q�.+��� .��	Customers�� -   $��CustomersListBox��$
��Left=�$��Stretch=�$	��200��$��5,5,0,10q�$	��240��� .+��� -    ��Name$ BtnCreateCustomer��$��Create Customer��$	��100��$
��Left=�$��5,0,0,10q��� -   $ BtnEditCustomer��$��Edit Customer��$��87��$��Right=�$��	0,0,42,10q�� .+��� -   $ BtnDeleteCustomer��$��Delete Customer��$	��100��$��Center=�$��
55,-6,92,6q��� $��1��$��5q�.+��� .��Meters�� -   $��MetersListBox��$
��Left=�$��Stretch=�$	��127��$��5,5,0,5q�$	��240��� .+��� -   $ BtnCreateMeter��$��Create new Meter��$	��127��$
��Left=�$��5,5,0,5q��� $��2��$��5q�.+��� .��
Readings�� -   $��MetersReadingsListBox��$
��Left=�$��Stretch=�$	��413��$��5,5,0,5q�$	��239��� .+��� .��Year:�� -	    ��Name$ YearForEnabling��$
��Left=�$��38,5,0,5q�$��52���� -
   $ BtnEnableReadings��$#��Enable readings for this year��$��Right=�$��	0,5,191,5q��� -   $ BtnDisplayStatistics��$&�� Display statistics for this year��$��Right=�$��0,5,30,5q�