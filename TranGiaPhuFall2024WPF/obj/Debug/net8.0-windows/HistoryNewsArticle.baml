   M S B A M L   `   `   `  ����P  LTranGiaPhuFall2024WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:TranGiaPhuFall2024WPFTranGiaPhuFall2024WPF  5   	   .    (TranGiaPhuFall2024WPF.HistoryNewsArticle   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:TranGiaPhuFall2024WPF     5   	     � Title$  HistoryNewsArticle��5   	   $	��500��6$   $	��800��61    � WindowStartupLocation$ CenterScreen=�6=    � 
ResizeMode$ NoResize=�6b    � WindowStyle$
 None=�5	   	   .��5
      � ���#bffff0.+�5   
   �  � RowDefinitions 5      �� 5      $��* �6    �� 5      $
��auto �6    .+�5      �� -   5        $��lvNewArticles��5      ���#cdcdcd$��
10,0,10,10q�6C   $��0q�6W   $
��auto��6c   $
��auto��6p    �� View 5      �� 5      .P�5      �� $��NewsArticle ID��6)    �� Width$	 100��6A    �� DisplayMemberBinding 5      ��  �� Path$ NewsArticleId��� 5      $��NewsArticle��6)   $	 200��6>    5      �� $ 	NewsTitle��� 5      $��Headline��6)   $	 200��6;    5      �� $ Headline��� 5      $��
CreateDate��6)   $	 150��6=    5      �� $ CreatedDate��� 5      $��NewsContent��6)   $	 300��6>   	 �� CellTemplate	 5      �� 5   "   .R�5    &   �� $
��Wrap=�6R   ��60   �� $ NewsContent�6R   5!   #   5#      �� 5$      $��
NewsSource��6)   $	 100��6=    5%      �� $ 
NewsSource��� 5&      $��Category��6)   $	 100��6;    5'      �� $ Category.CategoryName��� 5(      $��
NewsStatus��6)   $	 100��6=    5)      �� $ 
NewsStatus��� 5*      $��
CreateById��6)   $	 100��6=    5+      �� $ CreatedById��� 5,      $��
UpdateById��6)   $	 100��6=    5-      �� $ UpdatedById��� 5.      $��ModifiedDate��6)   $	 100��6?    5/      �� $ ModifiedDate�50      52      �� 53      -   5        
 ��Name$
 btnClose��53   "   $��1��6   $��10q�64   $��Right=�54      $��80��55      $��Close��6   6   56      57      58      