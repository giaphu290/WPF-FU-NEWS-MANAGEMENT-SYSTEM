   M S B A M L   `   `   `  ����P  LTranGiaPhuFall2024WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:TranGiaPhuFall2024WPFTranGiaPhuFall2024WPF  5   	   .    (TranGiaPhuFall2024WPF.PopupAccountWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:TranGiaPhuFall2024WPF     5   	     � Title$  PopupAccountWindow��5   	   $	��650��6$   $	��800��61    � WindowStartupLocation$ CenterScreen=�5	   
    � WindowStyle$
 None=�5
      
������  � AllowsTransparency$
 True��5      .��5      � $��0,0,0,10q�6    � ColumnDefinitions 5   
   �� 5      $	��350 �6   �� 5      $��* �6   .+�5   
   �� 
������ �� Padding$ 30q�6)    �� CornerRadius$ 	25 0 0 25��66   ._�5      �� $��Center=�6   .+�5      �� -   5        $��	txtHeader��5   0   $
��Wrap=�6    �� TextAlignment$ Center=�6B   $��SemiBold"�6Y   $��40(�6o   ���#3636366�   5      5      �� 5   
   -   5        $��1��5      $ 28q�6!   ���#ffffff$ 	0 25 25 0��6C   ._�5      �� $��Center=�6   .+�5      � -   5        $��grdId��5       5      �� 5      $
��auto �6+   �� 5      $
��auto �6+   .+�5      �� $��0��6!   .+�5       �� $
��Id: ��6$   $
��left=�60   $
��Bold"�6K   5"      �� 5#      $��1��6!   $
��left=�61   .+�5$      �� -   5        $��txtAccountId��5$   #   $��50��6n   $
��left=�6z   ${�False��6�   $��0q�6�   ��67   �� *CurrentAccount.AccountId+ �� Mode$ TwoWay=�6�   5&      5(      �� 5*      $
��Name��6   $
��0 10q�6(   $	��Top=�66   $
��left=�6N   $
��Bold"�6i   �� 5+      -   5        $��txtAccountName��5+      $��30��6i   $	��200��6u   $	��Top=�6�   $
��left=�6�   $��1q�6�   
���   ���60   �� *CurrentAccount.AccountName+$ TwoWay=�6�   �� 5-      $��Email��6   $
��0 10q�6*   $	��Top=�69   $
��left=�6Q   $
��Bold"�6l   �� 5.      -   5        $��txtAccountEmail��5.      $��40��63   $	��350��6?   $	��Top=�6�   $
��left=�6�   $��1q�6�   
���   �	 �� TextWrapping$
	 Wrap=�6�   
 �� AcceptsReturn$

 True��6�   " �� VerticalScrollBarVisibility$ Visible=�6
  ��6K   �� *CurrentAccount.AccountEmail+$ TwoWay=�6
  �� 5/      $��Password��6   $
��0 10q�6,   $	��Top=�6;   $
��Left=�6S   $
��Bold"�6n   �� 50      -   5        $��txtAccountPassword��50      $��40��66   $	��350��6B   $	��Top=�6�   $
��left=�6�   $��1q�6�   
���   �$
	 Wrap=�6�   ��6N   �� * CurrentAccount.AccountPassword+$ TwoWay=�6�   �� 51      $��Account Role��6   $
��0 10q�60   $	��Top=�6>   $
��Left=�6V   $
��Bold"�6q   �� 52      -   5        $��cmbAccountRole��52       �� SelectedValuePath$	 Tag��61   $	��150��54      $��30��6   $	��Top=�55      $
��Left=�6#    �� SelectedValue 53      �� *CurrentAccount.AccountRole+$ TwoWay=�.@�56      �� $��Staff��6#   
 � Tag$ 1��63   �� 57      $��Lecture��6#   $ 2��65   58      � 5:       5;      �� 5<      $��5* �6+   �� 5=      $
��2.2* �6+   .+�5?      �� -	   5        $��0��5?      $
��Save��6.   $��70��6=   $��Center=�6I   $��5q�6k   $
��0 25q�6w   $��Bottom=�6�   $��Right=�6�   $��1q�6�   
���   �
������6�   �� 5@      -
   5        $��1��5@      $��Cancle��6.   $��70��6?   $��Center=�6K   $��5q�6m   $��25q�6y   $��Bottom=�6�   $��Right=�6�   $��1q�6�   
���   �
������6�   5A      5D      5E      5F      5G      