   M S B A M L   `   `   `  ����B  >WpfApp7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp7WpfApp7  5   	       WpfApp7.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp7     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � WindowState$ 	Maximized=�65   .��5	      � .+�5
   
   � -   5        $��LogInWindow��5
      
�������.+�5      �� $��Center=�6   $��Center=�66    �� Orientation$ Vertical=�6Q   .+�5      �� -   5        $��
LoginPanel��5         StackPanelStyle#��[  6/   .+�5      �� $��
Логин��6   $��60��6,     LabelFontStyle#��[ 67   �� 5      -   5        $��
LoginField��5        
LogInStyle#��[ 60   5      �� 5      -   5        $��PasswordPanel��5      #��[  62   .+�5      �� $��Пароль��6   $��60��6-   #��[ 68   G� 5      -   5        $��PasswordField��5   "     PasswordFieldStyle#��[ 67   5      �� 5      -   5        $��
ErrorLabel��5      $��0,5,0,0q�6*   $	��255��6;   $��50��6G   #��[ 6S   �� 5      -   5        $��LogInButton��5      $��
Войти��6,   $��50��6<   $��0,5,0,0q�6G     ButtonFontStyle#��[ 6r     ButtonRoundAngle#���  6�   5      5      � 5   
   -   5        $��Window��5      
���iii� � ColumnDefinitions 5       �� 5!      $��* �6#   �� 5"      $��5* �6#    � RowDefinitions 5$      �� 5%      $��* �6    �� 5&      $��3* �6    .+�5)       � -	   5        $��MainMenu��5)      $��1��6$   $��1��61     � NavigationUIVisibility$ Hidden=�6A   $��5,5,5,5q�6a   
�������6r    � 5*      -
   5        $��PersonalCabinetFrame��5*      $��2��60   $��2��6D   �� 5,      -   5        $��LogOut��5,        ExitButtonStyle#��[ 68   #���  6a   �� 5-      -   5        $��	MenuPanel��5-      $��1��6*   $��0��67   $��5,5,5,5q�6G   .+�5.      �� -   5        $��ReceptionButton��5.      $��
Прием��60   $��0,5,0,5q�6@   #��[ 6o   #���  6�   �� 5/      -   5        $��CompleteWheelsButton��5/      $��Комплектация��65   $��0,5,0,5q�6L   #��[ 6�   #���  6�   �� 50      -   5        $��CheckCellsButton��50      $��Ячейки��61   $��0,5,0,5q�6B   #��[ 6r   #���  6�   �� 51      -   5        $��RealizationButton��51      $��Реализация��62   $��0,5,0,5q�6G   #��[ 6x   #���  6�   52      53      55      56      