   M S B A M L   `   `   `  ����B  >WpfApp7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfApp7.PagesWpfApp7.Pages  5      &     WpfApp7.Pages.CompleteWheelsPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WpfApp7.Pages     5      -   5          N� Title$  CompleteWheelsPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   .+�5      �� $��Комплектация��6      LabelFontStyle#��[  6+   $��20(�6S   $��Center=�6a   $��0,10,0,0q�6~   �� 5      -   5        $%��CompleteWheelsWithoutTubeButton��5      $;��5Закомплектовать бескамерные��6<     ButtonFontStyle#��[ 6b   $��0,5,0,0q�6�   $	��210��6�     ButtonRoundAngle#���  6�   6  �� 5      -   5        $"��CompleteWheelsWithTubeButton��5      $5��/Закомплектовать камерные��69   #��[ 6\   $��	0,10,0,10q�6�   $	��210��6�   #���  6�   6�   5      �� 5   
   $��1��6   .+�5      �� $��Покрышки��6   #��[  6'   $��Center=�5      $��0,5,0,0q�61   5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��TyreDataGridComplete��5      $��1��6/   $��10,42,10,10q�6?      AutoGenerateColumns .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Название��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *name_of_tyre+  5      $, &Количество на складе��6%    6C   �� *how_many_took+  5       -   5         CountTyresWithdrawInDataGrid��$ Списано��5    K      
Visibility$ Hidden=�6\    6p   �� *
withdraw+5"      �� 5$   
   $��2��6   .+�5%      �� $��Камеры��6   #��[  6%   $��Center=�6M   $��0,5,0,0q�6j   5&        5'   
   -   5        $��TubeDataGridComplete��5'      $��2��6/   $��10,42,10,10q�6?    .   .  5(        5)      $ Название��6%    67   �� *name_of_tube+  5*      $, &Количество на складе��6%    6C   �� *how_many_took+  5+      -   5         CountTubesWithdrawInDataGrid��$ Списано��5+   K   $ Hidden=�6\    6p   �� *
withdraw+5-      5/      50      