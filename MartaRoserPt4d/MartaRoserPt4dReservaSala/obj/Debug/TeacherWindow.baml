   M S B A M L   `   `   `  ����T  PMartaRoserPt4dReservaSala, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:MartaRoserPt4dReservaSalaMartaRoserPt4dReservaSala  5   	   -    'MartaRoserPt4dReservaSala.TeacherWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:MartaRoserPt4dReservaSala     5   	     � Title$  Menu de profesorado��5   	   $	��450��6%   $	��800��62    � WindowStartupLocation$ CenterScreen=�6>   .��5	      � .+�5
   
   �� .@�5      �� $��Listar aulas��6   $��16(�6,   .��5      � ���	#FFE5E5E5 � ColumnDefinitions 5      �� 5      $��* �6+   .+�5      �� -   5         ��Name$ 
btVerAulas��5      $��	Ver aulas��61   $
��Left=�6E   $��	21,23,0,0q�6`   $	��Top=�6s   $��75��6�   $��16(�6�   $��2��6�   $
��Bold"�6�   6�   �� 5      -   5         ��Name$ Tblock��5      $��0,71,0,0q�6/   $	��Top=�6A   $	��238��6Y   
���������. 5      �� 5      -   5        $ btBorrarAulas��5      $��Limpiar��64   $
��Left=�6F   $��
680,23,0,0q�6a   $	��Top=�6u   $��75��6�   $��16(�6�   6�   5      5      �� 5      $��Reservar aulas��6   $��16(�6.   .��5      � ���	#FFE5E5E5 5      �� 5      $	��74* �6+   �� 5      $	��64* �6+   �� 5      $
��107* �6+   �� 5      $
��541* �6+   .+�5      �� $
��Aula��6   $��center=�6+   $	��Top=�6H   $
��Bold"�6`   $��0��6r   $��31��6�   $��	13,0,17,0q�6�   $��44��6�   �� 5      $
��Día��6   $��center=�6*   $	��Top=�6G   $
��Bold"�6_   $��1��6q   $��31��6�   $��	15,0,13,0q�6�   $��36��6�   �� 5       $��
Disp. hora��6   $��center=�61   $	��Top=�6N   $
��Bold"�6f   $��2��6x   $��31��6�   $��12,0,9,0q�6�   $��86��6�   �� 5!      $��Descripción��6   $��center=�62   $	��Top=�6O   $
��Bold"�6g   $��3��6y   $��31��6�   $��
83,0,360,0q�6�   $��98��6�   (  "System.Windows.Controls.DatePicker  5#      -   5          Name$ dtPicker��5#   !   $
��Left=�63   $��
58,288,0,0q�6N   $	��Top=�6b   $��2��6z   $��29��6�   $	��156��6�      SelectedDateFormat$
 Long=�6�   $��2��6�   �� 5$      -   5        $ 
btReservar��5$      $��Reservar��61   $
��Left=�6D   $��Bottom=�6`   $��85��6{   $��39��6�   $��3��6�   $��
426,0,0,23q�6�   6�   �� 5%      -   5        $ btDisponibilidad��5%      $��Confirmar disponibilidad��67   $
��Left=�6Z   $��Bottom=�6u   $	��180��6�   $��3��6�   $��29��6�   $��
175,0,0,67q�6�   6�   �� 5&      -   5         ��Name$ LResultadoReserva��5&      $�� ��67   $��2��6B   $
��Left=�6R   $��
23,331,0,0q�6m   $	��Top=�6�   $��2��6�   $	��489��6�   $��31��6�   �� 5'      -   5         ��Name$ lbAulasReserva��5'      $��4��66   $
��Left=�6J   $	��243��6e   $��	10,36,0,0q�6r   $	��Top=�6�   $	��766��6�   5(      5)      5*      �� 5+   
   -	   5        $ btSalir��5+      $��Salir��6"   $
��Left=�62   $��
38,354,0,0q�6M   $	��Top=�6a   $��85��6y   $��39��6�   $��16(�6�   5,      5-      