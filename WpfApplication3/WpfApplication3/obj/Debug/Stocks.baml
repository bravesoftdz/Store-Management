   M S B A M L   `   `   `  ����  WpfApplication3    WpfApplication3.Stocks   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #��� ��5      #��� ��6]     � Cursor$
  Hand��6�    N� Title$ Stocks��5      .��5
      � -   5         �Name$ AdicionaStockGrid��5
      .+�5   
   �� -   5         ��Name$ AdicionaStockCanvas��5      .+�5      �� -   5        $ AddProductPanel��5      
�������6C   �� 5      -   5        $ AddStockPanel��5      
�������6A   �� 5      -   5        $ BlueBarCanvas1��5      .+�5      d� -   5         d�Name$ 
addProduto��5      $��Adicionar Produto��63   $��20(�6e   $��
ExtraBlack"�6s   
���������6O   Z� ��6�   Z� 6�   d� 5      -   5        $ addStock��5      $��Adicionar Stock��61   $��20(�6a   $��
ExtraBlack"�6o   
���������6K   Z� ��6�   Z� 6�   d� 5      -   5        $ changeProduct��5      $��Editar Produtos��66   $��20(�6f   $��
ExtraBlack"�6t   
���������6P   Z� ��6�   Z� 6�   d� 5      -	   5        $ 	consultas��5      $��Consultar Produtos��62   $��20(�6e   $��
ExtraBlack"�6s   
���������6O   Z� ��6�   Z� 6�   5      �� 5      -
   5         ��Name$ selected��5      $
��Fill=�6&   5      �� 5      -   5         ��Name$
 sale��5      ��68   Z� ��5      Z� ��6,   Z� 5      �� 5      -   5        $ stocks��5      ��6:   Z� ��5      Z� ��6,   Z� 5      �� 5       -   5        $ dados��5       ��69   Z� ��5!      Z� ��6,   Z� 5"      �� 5#      -   5        $ logOut��5#      ��6:   Z� ��5$      Z� ��6,   Z� 5%      �� 5&      -   5        $ settings��5&      ��6<   Z� ��5'      Z� ��6,   Z� 5(      (� 5)      -   5         (�Name$ lojaView��5)      .��5*      �� -   5         ��Name$ lojaData��5*      $
��Wrap=�6.   5+      (� 5-      -   5        $ funcView��5-      .��5.      �� -   5        $ funcData��5.      $
��Wrap=�6.   5/      �� 50      -   5        	 ��Name$	 ScrollerProdutos��50      .��51      &   System.Windows.Controls.DataGrid  -   5        
  Name$
 ProdutosGrid��51      $��20(�61      CanUserAddRows .  52      53      �� 55      -   5        $	 ScrollerLoja��55      .��56        -   5        $
 LojaGrid��56      $��20(�6-    .  57      58      5:      ��5;   
   �� 5<       �� ImageSource$B </WpfApplication3;component/Images/Background/LeftBarPage.jpg��6    j� Stretch$
 Fill=�6d   5>      5?      