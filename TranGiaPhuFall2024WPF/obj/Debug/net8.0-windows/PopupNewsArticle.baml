   M S B A M L   `   `   `  ����P  LTranGiaPhuFall2024WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:TranGiaPhuFall2024WPFTranGiaPhuFall2024WPF  5   	   ,    &TranGiaPhuFall2024WPF.PopupNewsArticle   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:TranGiaPhuFall2024WPF     5   	     � Title$  PopupNewsArticle��5   	   $	��750��6"   $	��800��6/    � WindowStartupLocation$ CenterScreen=�6B    � WindowStyle$
 None=�5	      
������  � AllowsTransparency$
 True��5      .��5      � $��0,0,0,10q�6    � ColumnDefinitions 5   
   �� 5      $	��300 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   
������ �� Padding$ 30q�69    �� CornerRadius$ 	25 0 0 25��6F   ._�5      �� $��Center=�6   .+�5      �� -   5        $��	txtHeader��5   0   $
��Wrap=�6    �� TextAlignment$ Center=�6B   $��SemiBold"�6Y   $��40(�6o   ���#3636366�   5      5      �� 5   
   -   5        $��1��5      $ 28q�6!   ���#ffffff$ 	0 25 25 0��6C   ._�5      �� $��Stretch=�6   .+�5      � -   5        $��grdId��5       5      �� 5      $��* �6+   �� 5      $	��20* �6+   .+�5      �� $��0��6!   .+�5      �� $
��Id: ��6$   $
��left=�60   $
��Bold"�6K   5       �� 5!      $��1��6!   .+�5"      �� -   5        $��tbNewsArticleId��5"   #   $��50��6y   $
��left=�6�   ${�False��6�   $��0q�6�   ��6:   �� *" CurrentNewsArticle.NewsArticleId+ �� Mode$ TwoWay=�6�   5$      5%      � 5&       5'      �� 5(      $
��auto �6+   �� 5)      $��* �6+   .+�5+      �� $��0��6!   .+�5,      �� $��
News Title��6$   $
��0 10q�66   $	��Top=�6D   $
��left=�6\   $
��Bold"�6w   �� 5-      -   5        $��tbNewsTitle��5-   "   $��30��6p   $	��200��6|   $	��Top=�6�   $
��left=�6�   $��1q�6�   
���   ���65   �� *CurrentNewsArticle.NewsTitle+$ TwoWay=�6�   �� 5.      $��Headline��6$   $
��0 10q�64   $	��Top=�6B   $
��left=�6Z   $
��Bold"�6u   �� 5/      -   5        $��
tbHeadline��5/   "   $��30��6n   $	��200��6z   $	��Top=�6�   $
��left=�6�   $��1q�6�   
���   ���64   �� *CurrentNewsArticle.Headline+$ TwoWay=�6�   51      �� 52      $��1��6!   .+�53      �� $��Available Tags��6$   $
��0 10q�6:   $	��Top=�6H   $
��left=�6`   $
��Bold"�6{   �� 56      $��10 0 0 0q�6%   	 �� Orientation$	 
Horizontal=�67   .+�57      �� -   5        
 ��Name$
 AvailableTagsComboBox��57   '   $��30��58      $	��100��59       �� DisplayMemberPath$ TagName��5:      ��5;      �� *AvailableTags+ �� SelectedItem 5<      �� *SelectedTag+�� 5>      -   5        $��Add Tag��5>   %   $��60��5?      $��10,0,0,0q�5@      
������5A   &   5B      �� 5D      $��
Added Tags��6$   $
��0 10q�66   $	��Top=�6D   $
��left=�6\   $
��Bold"�6w   �� 5E      $	��150��6'   $
��Auto=�64   .��5F      �� -	   5         ��Name$ AddedTagsItemsControl��5F   =   $��10 0 0 0q�6+   ��6\   �� *
AddedTag+��5G   "   �� 5H   &   .R�5I   *   � 5J   '   ��5L   "   �� 5M   &   .R�5N   *   �� $	 
Horizontal=�65   $��5q�6N   .+�5O   .   �� $��0,0,10,0q�6Q   ��68   �� *	TagName+6Q   �� 5P   .   -
   5        $��Remove��5P   5   $��50��5Q       � DataContext 5S      �� 5T   +   5U   '   5W      5X      5Y      5Z      �� 5\      $��News Content��6   $
��0 10q�61   $	��Top=�6@   $
��left=�6X   $
��Bold"�6s   �� 5]      -   5        $��tbNewsContent��5]      $	��100��61   $	��350��6>   $	��Top=�6�   $
��left=�6�   $��1q�6�   
���   � �� TextWrapping$
 Wrap=�6�    �� AcceptsReturn$
 True��6�   " �� VerticalScrollBarVisibility$ Visible=�6  ��6J   �� * CurrentNewsArticle.NewsContent+$ TwoWay=�6  �� 5^      $��News Source��6   $
��0 10q�6/   $	��Top=�6=   $
��left=�6U   $
��Bold"�6p   �� 5_      -   5        $��tbNewsSource��5_      $��30��6j   $	��350��6v   $	��Top=�6�   $
��left=�6�   $��1q�6�   
���   ���6.   �� *CurrentNewsArticle.NewsSource+$ TwoWay=�6�   �� 5a      $��Category��6   $
��0 10q�6,   $	��Top=�6;   $
��Left=�6S   $
��Bold"�6n   �� 5b      -   5        $��cbbCategory��5b      $��5q�60   $ CategoryName��6a    �� SelectedValuePath$ 
CategoryId��6�   
���   �$��1q�6�   ��6<   �� *CategoryList+ �� SelectedValue 6�   �� *CurrentNewsArticle.CategoryId+$ TwoWay=�5c      � 5d      $
��0 20q�6    5e      �� 5f      $��* �6+   �� 5g      $��7* �6+   .+�5i      �� $��0��6!   .+�5j      �� -   5        $��tbActice��5j   %   $��Status��65   $	��Top=�6E   $
��left=�6]   $
��Bold"�6x   5m      �� 5n      $��1��6!   .+�5o      �� -   5        $��
cbIsActice��5o   $   $��0 2 0 0q�6}   
���   �$
��Bold"�6�    d� 	IsChecked 66   ��  �� Path$# CurrentNewsArticle.NewsStatus�$ TwoWay=�6�   5q      5r      � 5s       5t      �� 5u      $��5* �6+   �� 5v      $
��2.2* �6+   .+�5x      �� -   5        $��0��5x      $
��Save��6.   $��70��6=   $��Center=�6I   $��5q�6k   $
��0 25q�6w   $��Bottom=�6�   $��Right=�6�   $��1q�6�   
���   �
������6�   �� 5y      -   5        $��1��5y      $��Cancle��6.   $��70��6?   $��Center=�6K   $��5q�6m   $��25q�6y   $��Bottom=�6�   $��Right=�6�   $��1q�6�   
���   �
������6�   5z      5}      5~      5      5�      