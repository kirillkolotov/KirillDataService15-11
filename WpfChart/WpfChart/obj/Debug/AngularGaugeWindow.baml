   M S B A M L   `   `   `  ����C  ?WpfChart, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WpfChartWpfChart  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5      !    WpfChart.AngularGaugeWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:WpfChart     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5        � Title$  AngularGaugeWindow��5	   	   $	��450��6$   $	��800��61   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)   .+�5   
   �� -   5        $��10q�5      .��68   Update6@   !  LiveCharts.Wpf.AngularGauge  5   
   $��1��6      	FromValue$ 50Q�6@      ToValue$	 250Q�6O      
LabelsStep$ 50Q�5         	TicksStep$ 25Q�6+      Wedge$	 300Q�6:      TicksForeground
 �����
�������$
��Bold"�5      $��16(�6-      SectionsInnerRadius$ .5Q�5      	   Value	 5   (   �� *Value+
   Sections
 5      #  LiveCharts.Wpf.AngularSection     	FromValue$ 50Q�6%      ToValue$	 200Q�64      Fill �#F8A7256B     5      $	 200Q�6%   $	 250Q�65    �#FF39396C   5      5      5      