   M S B A M L   `   `   `  ����  amHealth    amHealth.View.CheckDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � WindowStartupLocation$  CenterScreen=�5   
    � Title$ Prompt��5   	   $��233.323��6   $��250.376��6)    � WindowStyle$ 
ToolWindow=�6:    J� Opacity$ 0.925Q�6S    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5   
      Color$ 	#FF007ACC��6   .��5	      � $
��Left=�6   $	��239��6&   .+�5
   
   �� -   5        $��	CHECK OUT��5
         
SaveButton#��[  6%   $��
10,140,0,0q�6`   $
��Left=�6t   $��81��6�   $��31��6�   $	��Top=�6�    J� RenderTransformOrigin$ 0.514,0.935&�6�   �� 5   
    �� IsCancel . $��60��6!     CancelButton#��[ 6/   $��_Cancel��6U   $��162,141,0,0q�6g   $��31��6|   $	��Top=�6�   $
��Left=�6�   $��58��6�   �� 5   
   $��Amount��6   $
��Left=�6!   $��	10,87,0,0q�6<   $	��Top=�6O   $��57��6g   �� 5   
   -   5         ��Name$ amount��5   9   $
��Left=�6   $��23��6-   $��
10,113,0,0q�6I   	 �� TextWrapping$
	 Wrap=�6]   $	��Top=�6�   $	��212��6�   $ -1.893,1.016&�6�   ��6q   �� *CurrentUser.Name+6�   �� 5   
   -   5        
 ��Name$
 payment��5       �� SelectedValuePath$ Content��6&   $	��212��6D   $��
10,56,17,0q�6�   $��26��6�   $	��Top=�6�   .@�5      �� $�� ��6   �� 5      $
��CASH��6   �� 5      $��	INSURANCE��6   �� 5      $��CREDIT CARD��6   5      �� 5   
   $��Payment method��6   $
��Left=�6)   $��	10,25,0,0q�6D   $	��Top=�6W   $ 1.214,0.731&�6o   $	��144��6�   $��15(�6�   $��31��6�   �� 5   
   $��Check Out Patient��6   $
��Left=�6,   $��48,0,0,0q�6G   $	��Top=�6Y   $ 1.214,0.731&�6q   $	��144��6�   $��15(�6�   $��31��6�   5      5      