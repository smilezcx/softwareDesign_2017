   M S B A M L   `   `   `  ����N  JSoftwareDesign_2017, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SoftwareDesign_2017SoftwareDesign_2017  5   	   !    SoftwareDesign_2017.Graphic   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:SoftwareDesign_2017     5   	     � Title$  Graphic��5   	   $	��300��6   $	��480��6&    � 
ResizeMode$ 	CanResize=�62   .��5	      � .+�5
      �� -   5        $
��Left=�5
      $	��Top=�6(   $��0,0,0,0q�6@   $��30��6Q   $��20��6\   $
��save��6h   
�������
���   � K� ZIndex$ 1��6�   6�   (� 5      -   5         (�Name$ viewBox��5       (� Stretch$ UniformToFill=�6   .��5      �� -   5         ��Name$
 test��5      $��0q�6   .��5   
   � -   5         �Name$ graphic��5   "   
���   �.+�5      �� $��Center=�6   $��Center=�60   $	��430��6K   $	��255��6W   
�������$��1q�6x   $��
40,5,10,35q�6�    �� Padding$ 0,5,0,0q�6�   ._�5      '  !SoftwareDesign_2017.DrawingCanvas  -   5          Name$ drawingCanvas��5   "   $	��428��69   $	��248��6E   
���   �6R   5      �� 5      
�������$
��Left=�6G   $��
40,255,0,0q�6b   $	��Top=�6v   $��30��6�   $��45��6�   ��6   �� 	 �� Path$	 LabelX_0�6�   �� 5      
�������$
��Left=�6G   $��105,255,0,0q�6b   $	��Top=�6w   $��30��6�   $��45��6�   ��6   �� $	 LabelX_1�6�   �� 5      
�������$
��Left=�6G   $��183,255,0,0q�6b   $	��Top=�6w   $��30��6�   $��45��6�   ��6   �� $	 LabelX_2�6�   �� 5      
�������$
��Left=�6G   $��265,255,0,0q�6b   $	��Top=�6w   $��30��6�   $��45��6�   ��6   �� $	 LabelX_3�6�   �� 5      
�������$
��Left=�6G   $��338,255,0,0q�6b   $	��Top=�6w   $��30��6�   $��45��6�   ��6   �� $	 LabelX_4�6�   �� 5      
�������$
��Left=�6G   $��413,255,0,0q�6b   $	��Top=�6w   $��30��6�   $��45��6�   ��6   �� $	 LabelX_5�6�   �� 5      
�������$
��Left=�6G   $��475,255,0,0q�6b   $	��Top=�6w   $��30��6�   $��45��6�   ��6   �� $	 LabelX_6�6�   �� 5      
�������$
��Left=�6G   $��
20,241,0,0q�6b   $	��Top=�6v   $��30��6�   $��45��6�   ��6   �� $	 LabelY_0�6�   �� 5      
�������$
��Left=�6G   $��25,213.75,0,0q�6b   $	��Top=�6y   $��30��6�   $��45��6�   ��6   �� $	 LabelY_1�6�   �� 5      
�������$
��Left=�6G   $��25,183.5,0,0q�6b   $	��Top=�6x   $��30��6�   $��45��6�   ��6   �� $	 LabelY_2�6�   �� 5      
�������$
��Left=�6G   $��25,151.25,0,0q�6b   $	��Top=�6y   $��30��6�   $��45��6�   ��6   �� $	 LabelY_3�6�   �� 5      
�������$
��Left=�6G   $��
25,120,0,0q�6b   $	��Top=�6v   $��30��6�   $��45��6�   ��6   �� $	 LabelY_4�6�   �� 5      
�������$
��Left=�6G   $��25,88.75,0,0q�6b   $	��Top=�6x   $��30��6�   $��45��6�   ��6   �� $	 LabelY_5�6�   �� 5      
�������$
��Left=�6G   $��25,60.5,0,0q�6b   $	��Top=�6w   $��30��6�   $��45��6�   ��6   �� $	 LabelY_6�6�   �� 5       
�������$
��Left=�6G   $��25,28.25,0,0q�6b   $	��Top=�6x   $��30��6�   $��45��6�   ��6   �� $	 LabelY_7�6�   �� 5!      
�������$
��Left=�6G   $��	25,-2,0,0q�6b   $	��Top=�6u   $��30��6�   $��45��6�   ��6   �� $	 LabelY_8�6�   �� 5"      -   5        $ xLabel��5"      $
��Left=�6B   $��30��6]   $��155,264,0,-4q�6i   $	��Top=�6   $	��228��6�   ���	#FFA2FF00$��Center=�6�   $��16(�6�   ��6"   �� $	 xLabel�6�   �� 5#      -   5        $ yLabel��5#      $
��Left=�6B   $��30��6]   $��-105,112,0,0q�6i   $	��Top=�6   $	��242��6�   ���	#FFA2FF00$��Center=�6�   $��16(�6�   
 J� RenderTransformOrigin$
 0.5,0.5&�6�   ��6"   �� $	 yLabel�z�5$      V� 5%      .~�5&      ��  �� Angle$	 -90Q�6"   5'      5)      5*      5+   	   5,      5-      5.      