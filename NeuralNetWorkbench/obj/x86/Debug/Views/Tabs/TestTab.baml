   M S B A M L   `   `   `  ����M  INeuralNetWorkbench, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:NeuralNetWorkbench.ConvertersNeuralNetWorkbench.Converters  5      +    %NeuralNetWorkbench.Views.Tabs.TestTab   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      B
converters+clr-namespace:NeuralNetWorkbench.Converters     5        � 	Resources  5	      E   ?NeuralNetWorkbench.Converters.BooleanToPauseButtonTextConverter %  !BooleanToPauseButtonTextConverter@   :NeuralNetWorkbench.Converters.BooleanToVisibilityConverter   BooleanToVisibilityConverter��%:   &	        &	        5
   
   67     5   
   62   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6   .+�5      �� $
��Test��6   ��6$   �� *TestCommand+5      � 5   
   $��1��6   $��20��6#    � Value 6/   �� *TestingProgress+y�6Q   �� *TestingInProgress+ �� 	Converter# [ 6�   5      5      