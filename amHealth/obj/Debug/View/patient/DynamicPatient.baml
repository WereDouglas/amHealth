   M S B A M L   `   `   `  ����  amHealth*    $amHealth.View.patient.DynamicPatient   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Add user��5   	   $	��600��6   $	��800��6*    � WindowStyle$
 None=�6:   $��526.866��6M   $	��695��6^   .��5	      �  J� IsHitTestVisible . $��0,0,2,0q�6#   $	��590��64   $	��Top=�6A   .+�5
   
   �� -   5         ��Name$ btnExport_Copy��5
   l   $��Delete selected��6    �� IsCancel . $��0,8,14,0q�6Z   $	��Top=�6�   $��23��6�   $��Right=�6�   $��97��6�   ��6;   �� *
AddCommand+��5      �� 5      .R�5      � 
������ .+�5      ��    
HeaderText#��[  6$   �� 6I   $�Close��6M   6]   �� 5      $��Uniform=�6!   $-��'/amHealth;component/image/Cancel-48.png��63   $
��Left=�6d   5      5      5      �� 5   
   $��Message patients��6     HeaderLabel#��[ 6+   $
��Left=�6P   $��	10,10,0,0q�6k   $	��Top=�6~   $	��171��6�   $
��Bold"�6�   $��34��6�   �� 5   
   -   5        $��txtFilePath��5      $y�Hidden=�6%   $��	0,10,42,0q�69   $��15(�6L    J� Opacity$ 1Q�6Z   $��21��6f   $	��Top=�6r   $��Right=�6�   $	��207��6�   �� 5   
   -   5         ��Name$ 	txtFilter��5      $��28��6I   $	��Top=�6U   $
��Left=�6m   $	��700��6�   $��
76,193,0,0q�6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dtGrid��5      $
��Left=�6!   $��
10,226,0,0q�6<   $	��Top=�6P   $	��354��6h   $	��766��6u      CanUserReorderColumns . 	   CanUserResizeColumns	 . 
   CanUserResizeRows
 .     CanUserSortColumns .    AutoGenerateColumns .     HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush �	#FFE7E8EC   Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header 5      �� 5      -   5        $��chkSelectAll��5   $   $��check/uncheck��68   6P      CellTemplate 5       �� 5!      .R�5"      ��  ��Name$ cbSelectRow��6(    d� 	IsChecked 6=   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType" �� �� Path$ 
IsSelected�5$      5'      0  *System.Windows.Controls.DataGridTextColumn  5)      $ 
First name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Fname+  5*      $ 	Last name��6%    68   �� *Lname+  5+      $ Contact��6%    66   �� *Phone+  5,      $ Email��6%    64   �� *Email+  5-      $	 Age��6%    62   �� *Age+  5.      $ Gender��6%    65   �� *Gender+  5/      $ Height��6%    65   �� *Height+  50      $ Weight��6%    65   �� *Weight+  51      $ Region��6%    65   �� *Region+54      �� 55   
   $��Message��6   $��Right=�6$   $��	0,44,10,0q�6@   $	��Top=�6S   $	��144��6k   $	��770��6x   .��56      � $��10,0,-2,-12q�6   .+�57      �� -   5         ��Name$ message��57   9   $
��Left=�6   $��49��6J   $��	10,10,0,0q�6V   $	��Top=�6i   $	��730��6�   . �58      /� .T�59      J� .*�6$   .*�5:      �� $� ��6"   5;      5<      5=      �� 5>      -   5        $ btnDialogOk��5>   N    �� 	IsDefault .   
SaveButton#��[ 6*   $��60��6}   $��
648,64,0,0q�6�   $��Send message��6�   $��42��6�   $	��Top=�6�   $
��Left=�6�   $��92��6�   5?      5@      �� 5A   
   $��Search��6   $
��Left=�6!   $��
10,193,0,0q�6<   $	��Top=�6P   $��61��6h   $
��Bold"�6s   5C      5E      