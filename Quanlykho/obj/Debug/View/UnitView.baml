   M S B A M L   `   `   `  ����D  @Quanlykho, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Quanlykho.ViewModelQuanlykho.ViewModel  5          Quanlykho.View.UnitView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      4unitvm!clr-namespace:Quanlykho.ViewModel     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      h dMicrosoft.Expression.Interactions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5	        � DataContext  5          Quanlykho.ViewModel.UnitVM  5   
   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *GetDataCommand+5      .��5      � $
��auto��6   
������� � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      $��* �6   .+�5   
   �� $
��10 0q�6   $��0��6#    �� Orientation$ 
Horizontal=�60   .+�5      �� $	��450��6   $��Center=�5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nhập tên đơn vị��5       %  !MaterialDesignFloatingHintTextBox#��[  5       ��5      �� *Unitview.Units.DisplayName+5       �� 5!      $��90��5#      $
��10 0q�5$      
�������$
��Bold"�5&      ���#09434f + 'MaterialDesignRaisedSecondaryDarkButton#��[ 5)       � ToolTip$ Tìm kiếm��5*      ��5"      �� *FindDataCommand+{�5(      �� *DataContext.ControlsEnabled+	 �� RelativeSource	 �� *FindAncestor+
 �� AncestorType$
 WindowL�.��5+      '  !MaterialDesignThemes.Wpf.PackIcon  $��50��5,      $
��auto��5-         Kind$ 
Crosshairs=�5.      5/      �� 50      $��250 0q�51       7 3MaterialDesignFloatingActionMiniSecondaryDarkButton#��[ 54      $ Add Unit��55      ��52      �� *SaveCommand+{�53      �� *DataContext.ControlsEnabled+	 �� *FindAncestor+$
 WindowL�.��56        $��30��57      $
��auto��58      $
 Plus=�59      5:      5;      �� 5<   
   $��1��6   $ Vertical=�6"   .+�5=      �� -   5        $��	list_unit��5?      $	��Top=�5@      $	��420��5A      $��Visible=�5B      ��.  ��5>      �� *Unitview.UnitModels+ �� SelectedItem 5C      �� *Unitview.Units+ �� View 5E      �� 5F      .P�5G      ��  �� Width$	 150��5H      $��Id��5J       �� DisplayMemberBinding 5I      �� *Id+5J      �� 5K      $	 550��5L      $
��Tên��5N       5M      �� *DisplayName+5N      �� 5O      $	 150��5P      $��Chức năng��5Q       �� CellTemplate 5R      �� 5S   "   .R�5T   &   �� $��30��5U   +   $��30��5X   +   ���#820d05 3 /MaterialDesignFloatingActionMiniSecondaryButton#��[ 5Z   +   $ 	Xóa bỏ��5[   +   ��5V   )   ��  �� Path$# DataContext.RemoveDataCommand�	 �� *FindAncestor+"
 ����5W   )   �� .��5\   *     ���#dddddd$��25��5^   -   $��25��5_   -   $ Delete=�5`   -   5a   '   5b   #   5d      5e      5g      �� 5i      $ 
Horizontal=�6   $
��Left=�62   $��Center=�6M   .+�5j      � $��20 0 0 0q�6   .+�5k      �� $
��Bold"�6!   $��14(�63   $��Page: ��6A   �� 5l      $
��Bold"�6    $��14(�62   ��6A   �� *Unitview.PageIndex+�� 5m      $
��Thin"�6!   $��14(�63   $	�� | ��6A   �� 5n      $
��Bold"�6!   $��14(�63   $�� TotalPage: ��6A   �� 5o      $
��Bold"�6    $��14(�62   ��6A   �� *Unitview.PageSize+5p      5q      �� 5r      $ 
Horizontal=�6   $��Right=�63   $��Center=�6O   .+�5s      �� #��[ 5v      $ 
Lùi lại��5w      {�5t      �� *Unitview.IsEnablePrevious+��5u      �� *PreviousPageCommand+.��5x        $��20��5y      $��20��5z      $ 	ArrowLeft=�5{      5|      �� 5}      $��20 0 0 0q�5~      #��[ 5�      $ Tiến lên��5�      ��5      �� *NextPageCommand+{�5�      �� *Unitview.IsEnableNext+.��5�        $��20��5�      $��20��5�      $ 
ArrowRight=�5�      5�      5�      5�      5�      5�      