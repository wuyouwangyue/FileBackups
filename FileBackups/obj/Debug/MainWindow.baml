   M S B A M L   `   `   `  ����F  BFileBackups, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:FileBackupsFileBackups  5   	       FileBackups.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:FileBackups     5   	   -   5        
�������  � Title$  文件保存��5
   	   $	��450��6   $	��600��6#    � DataContext 5	   	   ��    Locator �� Source# [   �� Path$
 Main�.��5      � $��15q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ Vertical=�6   .+�5      � $��25��6    � ColumnDefinitions 5      �� 5      $
��Auto �6'   �� 5      $��* �6'   �� 5      $
��Auto �6'   .+�5      �� $��0��6   $��源文件目录：��6,   $��Center=�6:   $��80��6U   �� 5      $��1��6   $��Center=�6*   ��5      �� *
SourcePath+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5      $��2��6   $��打开��6)   $��80��66   $	��5,0q�6A   ��5      �� *OpenSourcePathCommand+5       � 5#      $��25��6   $��0,10,0,0q�6    5$      �� 5%      $
��Auto �6'   �� 5&      $��* �6'   �� 5'      $
��Auto �6'   .+�5*      �� $��0��6   $��存储标签：��6,   $��Center=�69   $��80��6T   �� 5+      $��1��6   $��Center=�6*   ��5,      �� *SaveDescription+$ TwoWay=�$ PropertyChanged=��� 5-      $��2��6   $��存储��6)   $��80��66   $	��5,0q�6A   ��5.      �� *SaveCommand+50      52      �� 55   
   $��1��6   $��0,15,5,0q�6   ��61   �� *
ItemSource+	 � 	Resources	 56      
 �� 
TargetType �� Property �� Value �� 
TargetType � ToolTip �� RelativeSource �� Mode��%'  '��       7   7   �� 57      "
 ��6   .�58      ��  � ��$ 25��6/   �� 59       � ��$	 2,2q�6/   �� 5:       � ��
 �����63   �� 5;       � �� 5<      �� 5=      " ��6.   .R�5>   "   � $��Center=�6'    5?   &   �� 5@   *   $
��Auto �6;   �� 5A   *   $
��Auto �6;   �� 5B   *   $��* �6;   �� 5C   *   $
��Auto �6;   .+�5F   &   �� $��0��60   ��6@   �� *Time+�� 5G   &   $��1��60   $
��10,0q�6@   $	��100��5I   0   $��CharacterEllipsis=�5K   0   ��5H   0   �� *Path+ 5J   0   ��  �� $
 Self=�$
 Text�5K   0   �� 5M   &   $��2��60   $��CharacterEllipsis=�5N   0   ��5O   0   �� *Description+�� 5Q   &   $ 
Horizontal=�61   $��3��6J   .+�5R   *   �� $��还原��61   $��60��6>   ��5S   1   �� 8   $ Main.UnDoCommand���5T   1   �� *Self+�� 5U   *   $��删除��61   $��60��6>   $��5,0,0,0q�6I   ��5V   1   �� 8  $ Main.DeleteCommand���5W   1   �� *Self+5X   '   5Y   #   5Z      5\      5]      5^      5_      5a      5b      