   M S B A M L   `   `   `  ����  amHealth!    amHealth.View.patient.Excel   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Add user��5   	   $	��600��6   $	��800��6*    � WindowStyle$
 None=�6:   $��526.866��6M   $	��695��6^   .��5	      �  J� IsHitTestVisible . $��0,0,2,0q�6#   $	��590��64   $	��Top=�6A   .+�5
   
   �� $��Import excel list��6   $
��Left=�6,   $��28,5,0,0q�6G   $	��Top=�6Y   $	��110��6q   $
��Bold"�6}   �� 5   
   -   5        $��txtFilePath��5      $y�Hidden=�6%   $��	0,10,42,0q�69   $��15(�6L    J� Opacity$ 1Q�6Z   $��21��6f   $	��Top=�6r   $��Right=�6�   $	��207��6�   �� 5   
   -   5         ��Name$ 	txtFilter��5      $��28��6I   $	��Top=�6U   $
��Left=�6m   $	��503��6�   $��273,186,0,0q�6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dtGrid��5      $
��Left=�6!   $��
10,219,0,0q�6<   $	��Top=�6P   $	��361��6h   $	��766��6u      CanUserReorderColumns .    CanUserResizeColumns .    CanUserResizeRows .  	   CanUserSortColumns	 . 
   AutoGenerateColumns
 .     HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush �	#FFE7E8EC   Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header 5      �� 5      -   5        $��chkSelectAll��5   $   $��check/uncheck��68   6P      CellTemplate 5      �� 5      .R�5      �� $��chkDiscontinue��6'    d� 	IsChecked 6=   �� *values+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5      5"      0  *System.Windows.Controls.DataGridTextColumn  5$      $ Group��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *
Uploadname+  5%      $
 Name��6%    63   �� *Name+  5&      $ Contact��6%    66   �� *	Contact+  5'      $
 Sync��6%    63   �� *Sync+5)      �� 5*   
   -   5         ��Name$ btnAdd_Copy��5*   y   $��Delete selected��6   $
��Left=�6+   $��
10,190,0,0q�6e   $	��Top=�6�   $	��106��6�   $��24��6�    J� RenderTransformOrigin$ 0.802,-0.479&�6�   ��6F   �� *
AddCommand+��5+      �� 5,      .R�5-      � 
������ .+�5.      �� �� 6%   $�Delete selected��6)   6C   �� 5/      $��Uniform=�6!   $+��%/amHealth;component/image/Deletes.png��63   $��Right=�6b   50      51      53      �� 54   
   $��New list��6   $
��Left=�6%   $��	10,36,0,0q�6@   $	��Top=�6S   $	��144��6k   $	��258��6x   .��55      � $��
0,0,-2,-12q�6   .+�56      �� -   5        $ 	groupname��56   A   $
��Left=�6   $��20��65   $��	39,32,0,0q�6T    �� TextWrapping$
 Wrap=�6g   $	��Top=�6|   $	��180��6�   $ -1.893,1.016&�6�   �� 57      -   5        $ browse��57   *    �� 	IsDefault . $��60��6R   $��	39,57,0,0q�6`   $��Browse / import��6s   $
��Left=�6�   $	��180��6�   ���	#FF3C8DBC$��30��6�   $	��Top=�6�   ���	#FF3C8DBC$��0,0,0,3q�6  ��6�   Z� 6  �� 58      $��Grouping Name��6   $
��Left=�60   $��24,0,0,0q�6K   $	��Top=�6]   $	��100��6u   $��27��6�   59      5:      �� 5;   
   $��Message��6   $��Right=�6$   $��
0,37,256,0q�6@   $	��Top=�6T   $	��144��6l   $	��261��6y   .��5<      � $��10,0,-2,-12q�6   .+�5=      �� -   5         ��Name$ message��5=   9   $
��Left=�6   $��64��6J   $��	10,10,0,0q�6V   $	��Top=�6i   $	��199��6�   . �5>      /� .T�5?      J� .*�6$   .*�5@      �� $� ��6"   5A      5B      5C      �� 5D      -	   5        $ btnDialogOk��5D   N    .    
SaveButton#��[  6*   $��60��6}   $��	10,79,0,0q�6�   $��Send message��6�   $��30��6�   $	��Top=�6�   $
��Left=�6�   $	��199��6�   5E      5F      �� 5G   
   $��Search��6   $
��Left=�6!   $��207,190,0,0q�6<   $	��Top=�6Q   $��61��6i   $
��Bold"�6t   �� 5H   
   -
   5        $ btnExport_Copy��5H   l   $��Delete selected��6    �� IsCancel . $��0,5,10,0q�6Z   $	��Top=�6�   $��23��6�   $��Right=�6�   $��97��6�   ��6;   �� *
AddCommand+��5I      �� 5J      .R�5K      � 
������ .+�5L      ��   
HeaderText#��[ 6$   �� 6U   $�Close��6Y   6i   �� 5M      $��Uniform=�6!   $-��'/amHealth;component/image/Cancel-48.png��63   $
��Left=�6d   5N      5O      5Q      5S      5U      