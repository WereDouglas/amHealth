   M S B A M L   `   `   `  ����  amHealth    amHealth.MessagesPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  Daily weather records��5      $	��800��6    $	��600��6/    N� 
Background
 �����.��5	      � $��0,0,0,8q�6   .+�5
   
   �� -   5         ��Name$ internet��5
      $�� ��6   $��Right=�6-   $��	0,6,138,0q�6I   $	��Top=�6\   $��85��6t   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dtGrid��5      $��10,40,10,10q�6#      	smallGrid#��[  68      CanUserReorderColumns .    CanUserResizeColumns .    CanUserResizeRows .     CanUserSortColumns .    AutoGenerateColumns .  	   HorizontalGridLinesBrush
	 �����
   VerticalGridLinesBrush
 �	#FFE7E8EC   Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header 5      �� 5      -   5         ��Name$ chkSelectAll��5   $   $��check��6:   6J      CellTemplate 5      �� 5      .R�5      �� $ chkDiscontinue��6'    d� 	IsChecked 6?   �� *values+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5      5       0  *System.Windows.Controls.DataGridTextColumn  5"      $ Contact��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *	Contact+  5#      $ Message��6%    66   �� *	Content+  5$      $
 Date��6%    63   �� *Dor+  5%      $
 Sent��6%    63   �� *Sent+  5&      $
 Sync��6%    63   �� *Sync+  5'      $	 ID#��6%    62   �� *Id+5)      �� 5*   
   $
��Type��6   $��Right=�6   $��
0,10,418,0q�6;   $	��Top=�6O   $��48��6g   �� 5+   
   -   5         ��Name$ gender��5+   0   $��Right=�6    �� SelectedValuePath$ Content��6o   $��
0,12,247,0q�6�   $	��Top=�6�   $	��166��6�    J� RenderTransformOrigin$ 0.302,-0.056&�6�   $��23��6   �� SelectedValue 6A   �� *CurrentUser.Station+.@�5,      �� $�� ��6   �� 5-      $	��All��6   �� 5.      $
��Sent��6   �� 5/      $��Not sent��6   51      �� 52   
   $��Messages��6   $
��Left=�6#   $��10,5,0,0q�6>   $	��Top=�6P   $	��106��6h   $
��Bold"�6t   $��26��6�   �� 53   
   -   5         ��Name$ btnAdd_Copy��53   o   $��Delete��6   $
��Left=�6"   $��	98,11,0,0q�6\   $	��Top=�6�   $��66��6�   $��24��6�   $ 0.802,-0.479&�6�   ��6=   �� *
AddCommand+��54      �� 55      .R�56      � 
������ .+�57      �� �� 6%   $�Delete��6)   6:   �� 58      $��Uniform=�6!   $+��%/amHealth;component/image/Deletes.png��63   $��Right=�6b   59      5:      5<      5=      5>      