   M S B A M L   `   `   `  ����E  AManagerApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ManagerApp
ManagerApp  5   	   "    ManagerApp.ProductManagement   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ManagerApp     5   	     � Title$  Product Management��5   	   $	��800��6$   $	��800��61    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�5
   	   .��5      � $��10,0,0,0q�6   .+�5   
   �� $��PRODUCT MANAGEMENT��6   $��33(�6-   $
��Bold"�6;   $
��Left=�6M   $��220,10,0,675q�6h   �� 5   
   $��0,66,296,392q�6   .+�5      �� $��
Product ID��6   $��14(�6)    J� RenderTransformOrigin$ -0.945,0.606&�67   �� 5      -   5         ��Name$ txtProductId��5       �� TextWrapping$
 Wrap=�6,   $	��475��6@   $��22��6L   ��6X   �� *	Productid+ �� Mode$ OneWay=� � DataContext 6�   �� *SelectedItem+ �� ElementName$ 
lvProducts���� 5      $��Product Name��6   $��14(�6+   �� 5      -   5        $ txtProductName��5      $
 Wrap=�6.   $	��475��6B   $��22��6N   ��6Z   �� *Name+$ OneWay=� 6}   �� *SelectedItem+$ 
lvProducts���� 5      $��Description��6   $��14(�6*   �� 5      -   5        $ txtDescription��5      $
 Wrap=�6.   $	��475��6B   $��22��6N   ��6Z   �� *Description+$ OneWay=� 6�   �� *SelectedItem+$ 
lvProducts���� 5      $��Quantity��6   $��14(�6'   $ 0.472,1.889&�65   �� 5      -   5        $ txtQuantity��5      $
 Wrap=�6+   $	��475��6?   $��22��6K   ��6W   �� *
Quantity+$ OneWay=� 6~   �� *SelectedItem+$ 
lvProducts���� 5      $
��Sold��6   $��14(�6#   �� 5      -   5        $ txtSold��5      $
 Wrap=�6'   $	��475��6;   $��22��6G   ��6S   �� *Sold+$ OneWay=� 6v   �� *SelectedItem+$ 
lvProducts���� 5      $
��Type��6   $��14(�6#   �� 5      -   5        	 ��Name$	 cbType��5      $	��474��6'   $��22��63   
 �� Text
 6?   �� *Type+$ OneWay=� 6b   �� *SelectedItem+$ 
lvProducts��.@�5      �� $��iPhone��6   �� 5      $
��iPad��6   �� 5      $��Macbook��6   5      5      �� 5   
   $��482,142,6,429q�6   .+�5       �� -   5         ��Name$ btnAdd��5       $	��Add��6%   $��30��63   $	��180��6?   $��0,0,0,20q�6K   6]   �� 5!      -   5        $ 	btnUpdate��5!      $��Update��6(   $��30��69   $	��180��6E   $��0,0,0,20q�6Q   6c   �� 5"      -	   5        $ 	btnDelete��5"      $��Delete��6(   $��30��69   $	��180��6E   $��0,0,0,20q�6Q   6c   �� 5#      -
   5        $ btnBack��5#      $��Back To Menu��6&   $��30��6=   $	��180��6I   6U   5$      �� 5%   
   $
��Left=�6   $��58��6+   $��	148,3,0,0q�67   $	��Top=�6J   $��74��6b   $��
/apple.png��6m   $
��Fill=�6�   $ 0.5,0.5&�6�   z�5&      V� 5'      .~�5(      �� �� 5)       �� AngleY$
 0.46Q�6$   �� 5*      T� 5+       T� Y$ -0.325Q�6)   5,      5.      �� 5/   
   $��Search By Product Name:��6   $
��Left=�62   $��156,392,0,0q�6M   $	��Top=�6b   $	��175��6z   $��14(�6�   �� 50   
   -   5        $ 	txtSearch��50      $
��Left=�6%   $��28��6@   $��331,393,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $	��325��6�   $��14(�6�   6�   �� 51   
   -   5         ��Name$ 
lvProducts��51      $��-12,435,0,0q�6'    �� View 52      �� 53      .P�54      �� $��
Product ID��6%    �� Width$ 65��69    �� DisplayMemberBinding 6D   ��  �� Path$ 	ProductId��� 55      $��Product Name��6%   $	 220��6;    6G   �� $
 Name��� 56      $��Description��6%   $	 200��6:    6F   �� $ Description��� 57      $��Quantity��6%   $ 70��67    6B   �� $ Quantity��� 58      $��	Type Name��6%   $	 120��68    6D   �� $ TypeName�59      5;      5<      5=      