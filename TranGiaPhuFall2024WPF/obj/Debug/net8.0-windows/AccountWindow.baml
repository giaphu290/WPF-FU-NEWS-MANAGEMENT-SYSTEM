   M S B A M L   `   `   `  ����P  LTranGiaPhuFall2024WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:TranGiaPhuFall2024WPFTranGiaPhuFall2024WPF  5   	   )    #TranGiaPhuFall2024WPF.AccountWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:TranGiaPhuFall2024WPF     5   	     � Title$  AccountWindow��5   	   $	��710��6    $	��400��6.    � 
ResizeMode$ NoResize=�5	   
    � WindowStyle$
 None=�6     � WindowStartupLocation$ CenterScreen=�5
   	   .��5      � ���#bffff0.+�5   
   ]� $��Center=�6   $��10q�61   .+�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$   �� 5      $
��auto �6$   .+�5      � $��0��6    � ColumnDefinitions 5      �� 5      $
��auto �6+   �� 5      $��3* �6+   .+�5      �� $��0��6!    �� Orientation$ 
Horizontal=�61   $��Center=�6J   $
��Left=�6e   .+�5      �� -   5         ��Name$ 	txtSearch��5   "   $	��200��65   $��30��6A   $��10q�6M   6Y   �� 5      -   5         ��Name$ 	btnSearch��5   !   $��80��64   $��Search��6?   
����d�$��10q�6l   6x   5      �� 5       $��1��6!   $ 
Horizontal=�61   $��Center=�6J   $��Right=�5!      .+�5"      �� -   5        $ 	btnInsert��5"   !   $��10q�64   $��80��6@   $��Create��6K   5#      �� 5$      -   5        $ 	btnUpdate��5$   !   $��10q�64   $��80��6@   $��Update��6K   5%      �� 5&      -   5        $ 	btnDelete��5&   !   $��10q�64   $��80��6@   $��Delete��6K   5'      5(      5)      �� 5+      -   5        $��
lvAccounts��5+   e   	 �� SelectionMode$	 Single=�6   $��False��62   $��1��6X   $
��Auto��6w   $
��Auto��6�   
 �� View
 5,      �� 5-      .P�5.      �� $��
Account ID��6-    �� Width$ 80��6A    �� DisplayMemberBinding 5/      ��  �� Path$ 	AccountId��� 50      $��Account Name��6-   $	 150��6C    52      �� $ AccountName��� 53      $��Account Email��6-   $	 300��6D    54      �� $ AccountEmail��� 55      $��Account Role��6-   $	 120��6C    56      �� $ AccountRole��� 57      $��Account Password��6-   $	 120��6G    58      �� $ AccountPassword�59      5;      �� 5<      -   5        $ btnClose��5<   &   $��2��6   $��10q�68   $��Right=�5=      $��Bottom=�6   $��80��5>      $��Close��6   6   5?      5@      5A      5B      