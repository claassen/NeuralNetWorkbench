   M S B A M L   `   `   `  ����M  INeuralNetWorkbench, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:NeuralNetWorkbench.ControlsNeuralNetWorkbench.Controls  5      S.clr-namespace:NeuralNetWorkbench.ControlModels NeuralNetWorkbench.ControlModels  5      M+clr-namespace:NeuralNetWorkbench.ConvertersNeuralNetWorkbench.Converters  5      3    -NeuralNetWorkbench.Controls.InputLayerControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      DcustomControls)clr-namespace:NeuralNetWorkbench.Controls     5      HcontrolModels.clr-namespace:NeuralNetWorkbench.ControlModels     5      B
converters+clr-namespace:NeuralNetWorkbench.Converters     5        � DataContext  5
      6   0NeuralNetWorkbench.ControlModels.InputLayerModel  5   
    � 	Resources 5      @   :NeuralNetWorkbench.Converters.BooleanToVisibilityConverter    BooleanToVisibilityConverter��%   &	          5   
   62   5      .��5      � $��
2, 2, 2, 0q�6   
�������.+�5   
   �� 
�������$��2q�6$   ]� 5   
   .+�5      ��  �� Orientation$ Vertical=�6   $��5q�60   $
��Left=�6;   .+�5      �� $��Input Layer��6   $
��Left=�6.   $
��Bold"�6I   �� 5      $ 
Horizontal=�6   .+�5      �� $ Vertical=�6!   .+�5      �� $ 
Horizontal=�6%   .+�5      �� $��Data source��6$   �� 5      ��6'   �� *DataSetProviders+ �� SelectedItem 6P   �� *DataSetProvider+5      5      5,      5.      5/      50      51      