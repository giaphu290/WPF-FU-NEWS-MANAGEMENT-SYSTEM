   M S B A M L   `   `   `  ����P  LTranGiaPhuFall2024WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:TranGiaPhuFall2024WPFTranGiaPhuFall2024WPF  5   	   -    'TranGiaPhuFall2024WPF.ReportNewsArticle   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:TranGiaPhuFall2024WPF     5   	     � Title$  ReportNewsArticle��5   	   $	��450��6#   $	��800��60    � WindowStyle$
 None=�6<    � 
ResizeMode$ NoResize=�6O    � WindowStartupLocation$ CenterScreen=�6e   .��5	      � ���	#FF2E333A � ColumnDefinitions 5
   
   �� 5      $	��240 �6   �� 5      $��* �6   .+�5   
   �� 
������$��0��6-   $��10q�6=   .+�5      �� $��
Start Date��6   $
��Bold"�6*   $��0,0,0,5q�6<   (  "System.Windows.Controls.DatePicker  5      -   5        $��dpStartDate��5      $	��200��6,   $��0,0,0,10q�68   �� 5      $��End Date��6   $
��Bold"�6(   $��0,0,0,5q�6:     5      -   5        $��	dpEndDate��5      $	��200��6*   $��0,0,0,10q�66   �� 5      -   5        $��Generate Report��5      $	��200��60   $��0,20,0,0q�6<   6O   �� 5      -   5        $	��200��5      $��0,20,0,0q�6!   $��Close��63   6C   5      �� 5   
   $��1��6   $��0q�6%   .+�5      �� $��Report��6   ���	#FF7EF3F3 �� TextAlignment$ Center=�6=   $
��Bold"�6T   $��24(�6f   $��0,0,0,10q�6t   �� 5      -   5        $��lvNewArticles��5   T    �� SelectionMode$ Single=�6   $��False��6.   ���#cdcdcd$��
10,0,10,10q�6   $��0q�6�   $	��540��6�   $	��400��6�   $��Visible=�6�    �� View 5      �� 5      .P�5      �� $��NewsArticle ID��6)    �� Width$	 100��6A   	 �� DisplayMemberBinding	 5      �� 
 �� Path$
 NewsArticleId��� 5      $��
News Title��6)   $	 200��6=   	 5       �� $
 	NewsTitle��� 5!      $��Headline��6)   $	 200��6;   	 5"      �� $
 Headline��� 5#      $��
CreateDate��6)   $	 150��6=   	 5$      �� $
 CreatedDate��� 5%      $��NewsContent��6)   $	 300��6>    �� CellTemplate 5&      �� 5'   "   .R�5(   &   �� $
��Wrap=�6R   ��60   �� $
 NewsContent�6R   5)   #   5+      �� 5,      $��
NewsSource��6)   $	 100��6=   	 5-      �� $
 
NewsSource��� 5.      $��Category��6)   $	 100��6;   	 5/      �� $
 Category.CategoryName��� 50      $��
NewsStatus��6)   $	 100��6=   	 51      �� $
 
NewsStatus��� 52      $��
CreateById��6)   $	 100��6=   	 53      �� $
 CreatedById��� 54      $��
UpdateById��6)   $	 100��6=   	 55      �� $
 UpdatedById��� 56      $��ModifiedDate��6)   $	 100��6?   	 57      �� $
 ModifiedDate�58      5:      5<      5=      5>      