   M S B A M L   `   `   `  ����C  ?APoffice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:APoffice.ViewModelAPoffice.ViewModel  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	       APoffice.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:APoffice.ViewModel     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	     � Title$  
MainWindow��5	   	   $	��350��6   $	��525��6)    � DataContext 5
      0   *APoffice.ViewModel.EmployeeEditorViewModel  5   
   .��5      � .+�5   
   �� -   5         ��Name$ 	textBlock��5      $
��Left=�6'   $��	16,10,0,0q�6B   $
��Wrap=�6U   $
��Name��6i   $	��Top=�6u   �� 5   
   -   5         ��Name$ textBox��5      $
��Left=�6#   $��23��6>   $��65,9,0,0q�6J    �� TextWrapping$
 Wrap=�6\   $	��Top=�6p   $	��120��6�   ��6�   ��  �� Path$ CurrentEmployee.Name� �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   -   5        $ textBlock_Copy��5      $
��Left=�6,   $��	13,44,0,0q�6G   $
��Wrap=�6Z   $��Surname��6n   $	��Top=�6}   �� 5   
   -   5        $ textBox1��5      $
��Left=�6$   $��23��6?   $��	65,37,0,0q�6K   $
 Wrap=�6^   $	��Top=�6r   $	��120��6�   ��6�   �� $ CurrentEmployee.Surname�$ PropertyChanged=��� 5   
   -   5         ��Name$ button��5      $��Apply��6!   $
��Left=�61   $��	65,91,0,0q�6l   $	��Top=�6   $	��120��6�   $��32��6�   ��6L   �� *AddEmployee+6�   �� 5   
   -   5         ��Name$ EmployeesListBox��5      $
��Left=�6�   $	��114��6�   $��	201,9,0,0q�6�   $	��Top=�6�   $	��123��6�   	 �� SelectedItem	 6,   �� $ EditingEmployee���6[   �� $ 	Employees�.  (System.Windows.Interactivity.Interaction
   Triggers
 5      /  )System.Windows.Interactivity.EventTrigger  5         	EventName$ MouseDoubleClick��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6,   �� *StartEditing+5      5      5'      5(      