   M S B A M L   `   `   `  ����  amHealth0    *amHealth.View.practitioner.AddPractitioner   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � SizeToContent$ WidthAndHeight=�5   	    � Title$ Add user��5   	   $��440.865��6   $��327.677��6+    � WindowStyle$
 None=�6<   .��5	      �  J� IsHitTestVisible . $��0,0,2,0q�6#   .+�5
   
   �� -   5        $��
groupBox10��5
   X   $��Capture image��6   $
��Left=�6*   $��	138,0,0,0q�6E   $	��170��6j   ���	#FFE7E8EC$	��146��6�   $	��Top=�6�   .��5      � $��0,0,-2,0q�6   .+�5      �� -   5        $��imgVideo��5   S   $��86��6   $��Right=�6$   $��	0,10,50,0q�6@   $-��'/amHealth;component/image/temp_face.png��6c   $
��Fill=�6�   $	��Top=�6�   $��83��6�   �� 5      -   5        $��
bntCapture��5   Z   $��0q�6   $��
0,101,50,0q�6F   $��Right=�6l   $��24��6�    J� RenderTransformOrigin$ 3.443,0.722&�6�   $��24��6�   $	��Top=�6�   ��5      �� 5       �� ImageSource$, &/amHealth;component/image/Save-256.png��6%   5      �� 5      -   5        $��bntStart��5   t   $��0q�6   $��Right=�6D   $��
0,101,98,0q�6`   $��31��6�   $��24��6�   $	��Top=�6�   ��5      �� 5      $5 //amHealth;component/image/Media-Play-02-256.png��6%    j� Stretch$
 Fill=�6c    j� TileMode$
 None=�6r   5      �� 5      -   5        $��bntStop��5   W   $��0q�6   $��
0,101,74,0q�6C   $��Right=�6f   $��19��6�   $��24��6�   $	��Top=�6�   ��5      �� 5      $, &/amHealth;component/image/Stop-256.png��6%   5      �� 5      -   5        $��bntContinue��5   [   $��0q�6   $��
0,101,22,0q�6G   $��Right=�6n   $��23��6�   $��24��6�   $	��Top=�6�   ��5      �� 5      $9 3/amHealth;component/image/Media-Play-02-256 (1).png��6%   5!      5"      5#      �� 5%   
   $
��Name��6   $
��Left=�6   $	��Top=�6:   $��
10,183,0,0q�6R   �� 5&   
   -   5        	 ��Name$	 lblQuestion��5&      $��20,9,298,391q�6%   5(      � 5*   
   $��Right=�6   $��0,-140,166,155q�60   �� 5+   
   -   5        
 ��Name$
 btnDialogOk��5+   F    �� 	IsDefault .    
SaveButton#��[  6"   $��60��6u   $��0,305,122,0q�6�   $��Create��6�   $��Right=�6�   $��83��6�   ���	#FF2799F0
�������$��30��6�   $	��Top=�6  �� 5,   
    �� IsCancel .   CancelButton#��[ 6!   $��60��6G   $��_Cancel��6U   $��
0,306,39,0q�6g   $��29��6{   $	��Top=�6�   $��Right=�6�   $��76��6�   �� 5-   
   -	   5         ��Name$
 name��5-   -   $
��Left=�6   $��114,183,0,224q�6;    �� TextWrapping$
 Wrap=�6R   $	��164��6�   $ -1.893,1.016&�6�   ��6f   �� *CurrentUser.Email+6�   �� 5.   
   $��Practice��6   $
��Left=�6#   $��
10,278,0,0q�6>   $	��Top=�6R   $��64��6j   �� 5/   
   -
   5         ��Name$ practice��5/   /   $
��Left=�6    �� SelectedValuePath$ Content��6p   $��113,278,0,0q�6�   $	��Top=�6�   $	��166��6�   $ 0.302,-0.056&�6�    �� SelectedValue 6B   �� *CurrentUser.Station+.@�50      �� $��Cardiologist��6   �� 51      $��	Counselor��6   �� 52      $��Dermatologist��6   �� 53      $��Dental surgeon��6   �� 54      $��Ent Surgeon��6   56      �� 57   
   -   5        $ phone��57   -   $
��Left=�6   $��113,214,0,0q�6<   $
 Wrap=�6Q   $	��164��6�   $ -1.893,1.016&�6�   $��23��6�   $	��Top=�6�   ��6e   �� *CurrentUser.Name+6�   �� 58   
   $��Phone��6   $
��Left=�6    $��
10,209,0,0q�6;   $	��Top=�6O   $��48��6g   �� 59   
   $��Email��6   $
��Left=�6    $��
10,240,0,0q�6;   $	��Top=�6O   $��48��6g   $ 0.625,-1.731&�6r   �� 5:   
   -   5        $ email��5:   -   $
��Left=�6   $��114,242,0,0q�6<   $
 Wrap=�6Q   $	��164��6�   $ -1.893,1.016&�6�   $��23��6�   $	��Top=�6�   ��6e   �� *CurrentUser.Name+6�   �� 5;   
   -   5        $��button8��5;   ]   $��Browse��6   $��24��6"   $
��Left=�6.   $��
20,115,0,0q�6I   $	��Top=�6l   $��94��6�   ���	#FFC3DE99���	#FFC3DE99$��0,0,0,3q�6�   $
��Bold"�6  ��6�   Z� 6  �� 5=   
   -   5         ��Name$ 
imgCapture��5=   #   $��	20,28,0,0q�6   $-��'/amHealth;component/image/temp_face.png��67   $
��Left=�6h   $��94��6�   $��82��6�   $	��Top=�6�   5>      5@      