   M S B A M L   `   `   `  ����I  EBrume_Launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Brume_LauncherBrume_Launcher  5   	       Brume_Launcher.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Brume_Launcher     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5   	    � WindowStyle$
 None=�5
   
    � 
ResizeMode$ NoResize=�5   	    � Title$ Launcher��5   	   $	��545��6   $	��898��6'   .��5      � .+�5   
   �� $��UniformToFill=�6   $#��images/LauncherBackground.png��6(   �� 5   
   $��UniformToFill=�6   $��images/TitreFinal.png��6(   $��181,57,181,178q�6G   �� 5   
   -   5         ��Name$ VersionText��5   '   
�������$
��Left=�6<   $��
10,482,0,0q�6W   $
��Wrap=�5      $�� ��6(   $	��Top=�60   $��25��6H   $	��262��6T   $��Bahnschrift)�6`   $��Italic$�6y   �� 5   
   -   5        $��
PlayButton��5   $   
�������$
��Left=�66   $��678,445,0,0q�6Q   $	��Top=�6f   $	��206��6~   $��64��6�    J� RenderTransformOrigin$ 0.538,-0.599&�6�   ���	#00C3141D���	#00000000��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value
 ��ح�63   �� 5       � �� 5      �� 5      	 �� 
TargetType"	 ��6.   .R�5   "   �� 
 ��Name$
 Border��6)   #��z��69   ._�5   &   �� $��Center=�67   $��Center=�6T   5   #    �� Triggers 5   "   P� 5    &    P� Property �@J�IsMouseOver P� Value$
 True��6E   . �5!   *   ��  �� 
TargetName$ Border��6Y    � �� �	#FFC3141D5"   '   5$      5&      5'      5)      �� 5*   
   -   5        $��PlayText��5*   '   
�������$
��PLAY��67   $
��Wrap=�6C   $��48(�6W    �� TextAlignment$ Center=�6e   $��678,445,14,36q�6|   $��./#COCOGOOSE LETTERPRESS)�6�   $
��Bold"�6�   $��Normal$�6�    J� IsHitTestVisible$ false��6�   5+      �� 5,   
   -   5        $��
StatusText��5,   '   
�������$�� ��69   $
��Wrap=�6A   $ Center=�6U   $��678,509,14,13q�6l   � 5-   
   -   5        $��ProgressBar��5-   -   ���	#FFC3141D � Minimum$ 0Q�6A    � Maximum$	 100Q�6M   $��	0,537,0,0q�6[   $��8��6n   $	��Top=�6y   $y�Hidden=�6�   �� 5.   
   -   5         ��Name$ 
QuitButton��5.   $   
�������$
��Left=�69   $��	869,0,0,0q�6T   $	��Top=�6g   $��29��6   $��25��6�   $ 0.538,-0.599&�6�   ���	#00C3141D���	#00000000��5/      �� 50      " ��6   .�51      ��  � ��
 ��ح�63   �� 52       � �� 53      �� 54      "	 ��6.   .R�55   "   �� $
 Border��6)   #��z��69   ._�56   &   �� $��Center=�67   $��Center=�6T   57   #    58   "   P� 59   &    �@J�IsMouseOver$
 True��6E   . �5:   *   �� $ Border��6Y    � �� �	#FFC3141D5;   '   5=      5?      5@      .��5B      �� $��X��6   $
��Wrap=�6!   $
��Bold"�65   5C      �� 5D   
   -   5        $ 	MinButton��5D   $   
�������$
��Left=�68   $��	835,0,0,0q�6S   $	��Top=�6f   $��29��6~   $��25��6�   $ 0.538,-0.599&�6�   ���	#00C3141D���	#00000000$��18(�6  ��5E      �� 5F      " ��6   .�5G      ��  � ��
 ��ح�63   �� 5H       � �� 5I      �� 5J      "	 ��6.   .R�5K   "   �� $
 Border��6)   #��z��69   ._�5L   &   �� $��Center=�67   $��Center=�6T   5M   #    5N   "   P� 5O   &    �@J�IsMouseOver$
 True��6E   . �5P   *   �� $ Border��6Y    � �� �	#FFC3141D5Q   '   5S      5U      5V      .��5X      �� $��-��6   $
��Wrap=�6!   $
��Bold"�65   $��24(�6G   $��34��6U   $ Justify=�6a   $	 1,1&�6y   $��Center=�6�   $��Center=�6�   z�5Y      V� 5Z      .~�5[      �� �� 5\      �� 5]      T� 5^       T� Y$ -2Q�6-   5_      5a      5b      5d      5g      