   M S B A M L   `   `   `  ����  CipherGenerator%    CipherGenerator.View.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  
Szyfrogram��5   	   $��466.288��6   $��724.133��6-    � WindowStartupLocation$ CenterScreen=�6=   $��Segoe UI Light)�6b   $��18(�6~    � Icon$0 */CipherGenerator;component/Images/icon.ico��6�    � 
ResizeMode$ NoResize=�6�   ��5      �� 5	   
    �� ImageSource$ /Images/btc.jpg��6   .��5      � .+�5   
   �� $��33��6   $��452,225,26.6,178.8q�6    �� TextWrapping$
 Wrap=�6:   $	��239��6N   ��6Z   �� *WordToCrypt+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   $
��Left=�6   $��
137,19,0,0q�6�   $	��Top=�6�   $	��127��6�   $��34��6�   
������� �� SelectedItem 6.   �� *
CihperType+$ TwoWay=�$ PropertyChanged=���6�   �� *CipherColletion+��5      �� 5      	 �� EndPoint$		 0,1&�6&   
 �� 
StartPoint$	
 0,0&�65   .��5      �  � Color$ 	#FFF0F0F0��6#    � Offset$ 0Q�65   � 5      $ White��6#   $ 1Q�61   5      5      �� 5   
   $�� ��6   $��452,338,192.6,34.8q�6�    J� RenderTransformOrigin$ -0.148,0.404&�6�   
������ {�6   �� *EnableButton+$ PropertyChanged=���6d   �� *EncryptCommand+��5      �� 5       6   �� *
EncryptImg+$ PropertyChanged=���5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value
 ���� 63   �� 5       � �� 5      �� 5       �� 
TargetType" ��6.   .R�5    "   �� #��z��6)   
���   �$��0q�6g   ._�5!   &   �� $��Center=�67   $��Center=�6T   5"   #   5#      5%      5&      5(      �� 5)   
   $��Słowo��6   $
��Left=�6    $��364,224,0,0q�6;   $	��Top=�6P   $ -2.04,0.397&�6h   
�������$
��Bold"�6�   �� 5*   
   $��Wynik��6   $
��Left=�6    $��367,277,0,0q�6;   $	��Top=�6P   $ -3.516,-0.099&�6h   
�������$
��Bold"�6�   �� 5+   
   $��33                  ��6e   $��452,174,26.6,229.8q�5,      $
 Wrap=�60   $	��239��6�   {�5+      �� *	EnableBox+$ TwoWay=�$ PropertyChanged=���5,   D   �� *	TextKey+$ PropertyChanged=�$ TwoWay=�6�   �� 5-   
   $��Klucz��6   $
��Left=�6    $��367,174,0,0q�6;   $	��Top=�6P   $ -2.04,0.397&�6h   
�������$
��Bold"�6�   �� 5.   
   $��617,338,26.6,34.8q�6�   $ 1.637,0.639&�6�   
������ ��6   �� *DecryptCommand+$ PropertyChanged=�{�6Y   �� *EnableButtonDet+$ PropertyChanged=���5/      �� 50       6   �� *
DecryptImg+$ PropertyChanged=�$ TwoWay=���52      �� 53      " ��6   .�54      ��  � ��
 ���� 63   �� 55       � �� 56      �� 57      " ��6.   .R�58   "   �� #��z��6)   
���   �$��0q�6g   ._�59   &   �� $��Center=�67   $��Center=�6T   5:   #   5;      5=      5>      5@      �� 5A   
   $��Wybierz szyfr��6   $
��Left=�6(   $��	20,19,0,0q�6C   $	��Top=�6V   $ -2.04,0.397&�6n   
�������$
��Bold"�6�   �� 5B   
   $��33��6   $��452,277,26.6,126.8q�6   $
 Wrap=�6:   $	��239��6N    �� 
IsReadOnly . ��6n   �� *
WordResult+$ TwoWay=�$ PropertyChanged=��� 5C   
   $��452,19,26.6,291.8q�6   $
��Wrap=�6/   $ 0.302,-0.77&�6�   $	��126��6�   $	��239��6�   $��18(�6�   
�������$
��Bold"�6�   ��6C   �� *	TextMsg+$ PropertyChanged=�$ TwoWay=�6�   �� 5D   
   $ ��Wykonał Krzysztof Papciak��6   $
��Left=�64   $��
35,357,0,0q�6O   $	��Top=�6c   $ -2.04,0.397&�6{   
�������$
��Bold"�6�   $��24(�6�   5F      5G      