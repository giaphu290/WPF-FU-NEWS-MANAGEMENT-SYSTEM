   M S B A M L   `   `   `  ����P  LTranGiaPhuFall2024WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:TranGiaPhuFall2024WPFTranGiaPhuFall2024WPF  5   	   /    )TranGiaPhuFall2024WPF.PopupCategoryWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:TranGiaPhuFall2024WPF     5   	     � Title$  PopupCategoryWindow��5   	   $	��650��6%   $	��800��62    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowStyle$
 None=�5
   	   
������  � AllowsTransparency$
 True��5   	   .��5      � $��0,0,0,10q�6    � ColumnDefinitions 5   
   �� 5      $	��350 �6   �� 5      $��* �6   .+�5   
   �� 
������ �� Padding$ 30q�6)    �� CornerRadius$ 	25 0 0 25��66   ._�5      �� $��Center=�6   .+�5      �� -   5        $��	txtHeader��5   0   $
��Wrap=�6    �� TextAlignment$ Center=�6B   $��SemiBold"�6Y   $��40(�6o   ���#3636366�   5      5      �� 5   
   -   5        $��1��5      $ 28q�6!   ���#ffffff$ 	0 25 25 0��6C   ._�5      �� $��Center=�6   .+�5      � -   5        $��grdId��5       5      �� 5      $��* �6+   �� 5      $	��20* �6+   .+�5      �� $��0��6!   .+�5      �� $
��Id: ��6$   $
��left=�60   $
��Bold"�6K   5!      �� 5"      $��1��6!   .+�5#      �� -   5        $��txtCategoryId��5#   #   $��50��6q   $
��left=�6}   ${�False��6�   $��0q�6�   ��68   �� *CurrentCategory.CategoryId+ �� Mode$ TwoWay=�6�   5%      5&      �� 5(      $
��Name��6   $
��0 10q�6(   $	��Top=�66   $
��left=�6N   $
��Bold"�6i   �� 5)      -   5        $��txtCategoryName��5)      $��30��6l   $	��200��6x   $	��Top=�6�   $
��left=�6�   $��1q�6�   
���   ���61   �� *CurrentCategory.CategoryName+$ TwoWay=�6�   �� 5+      $��
Desciption��6   $
��0 10q�6/   $	��Top=�6>   $
��left=�6V   $
��Bold"�6q   �� 5,      -   5        $��txtCategoryDesciption��5,      $��60��69   $	��350��6E   $	��Top=�6�   $
��left=�6�   $��1q�6�   
���   �	 �� TextWrapping$
	 Wrap=�6�   
 �� AcceptsReturn$

 True��6  " �� VerticalScrollBarVisibility$ Visible=�6  ��6Q   �� *$"CurrentCategory.CategoryDesciption+$ TwoWay=�6  �� 5-      $��Parent Category��6   $
��0 10q�63   $	��Top=�6B   $
��Left=�6Z   $
��Bold"�6u   �� 5.      -   5        $��cbbParentCategory��5.      $��5q�66    �� SelectedIndex$ 0��6B    �� DisplayMemberPath$ CategoryName��6y    �� SelectedValuePath$ ParentCategoryId��6�   
���   �$��1q�6  ��6T   �� *CategoryList+ �� SelectedValue 6�   �� *" CurrentCategory.ParentCategoryId+$ TwoWay=�5/      � 50      $
��0 20q�6    51      �� 52      $��* �6+   �� 53      $��7* �6+   .+�55      �� $��0��6!   .+�56      �� -   5        $��tbActice��56   %   $��Active��65   $	��Top=�6E   $
��left=�6]   $
��Bold"�6x   59      �� 5:      $��1��6!   .+�5;      �� -	   5        $��
cbIsActice��5;   $   $��0 2 0 0q�6x   
���   �$
��Bold"�6�    d� 	IsChecked 66   ��  �� Path$ CurrentCategory.IsActive�$ TwoWay=�6�   5=      5>      � 5?       5@      �� 5A      $��5* �6+   �� 5B      $
��2.2* �6+   .+�5D      �� -
   5        $��0��5D      $
��Save��6.   $��70��6=   $��Center=�6I   $��5q�6k   $
��0 25q�6w   $��Bottom=�6�   $��Right=�6�   $��1q�6�   
���   �
������6�   �� 5E      -   5        $��1��5E      $��Cancle��6.   $��70��6?   $��Center=�6K   $��5q�6m   $��25q�6y   $��Bottom=�6�   $��Right=�6�   $��1q�6�   
���   �
������6�   5F      5I      5J      5K      5L      