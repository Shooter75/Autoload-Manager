   M S B A M L   `   `   `  ����  AutorunMonitor    AutorunMonitor.Pages.Home   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $��395.455��5      $
��Auto��60   .��5      �    ContentRoot#��[  6   .+�5   
   �� $
��Auto��6   .��5	      �� $
��Auto��6   .+�5
      &   System.Windows.Controls.DataGrid  -   5           Name$  RegisterField_DG��5
   (   $
��Auto��6      AutoGenerateColumns .     SelectionMode$ Single=�6^      
IsReadOnly . $
��Auto��6�      RowDetailsVisibilityMode$ VisibleWhenSelected=�6�   ��6�   ��  � ContextMenu 5      �� 5      .@�5      �� -   5        $��Remove_B��5   $   $��Remove��65   6G   �� 5      -   5        $��Add_B��5   $   $	��Add��65   6G   �� 5      -   5        $��Refresh��5   $   $��Refresh��65   6G   �� 5      -   5        $
��Save��5   $   $
��Save��65   6G   �� 5      -   5        $��Compare��5   $   $��Compare��65   6G   5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        Key��,  &System.Windows.Controls.DataGridColumn   Header$	 Key��5   V      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6e   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6<   �� *Key+6e     5      -   5        	Value��$ Value��5   V   $
 Auto 6e   	 6<   �� *Value+6e   5      5      5      5      5      