   M S B A M L   `   `   `  ����E  AManagerApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ManagerApp
ManagerApp  5   	        ManagerApp.OrderManagement   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ManagerApp     5   	     � Title$  Order Management��5   	   $	��600��6"   $	��800��6/    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�5
   	   .��5      � .+�5   
   �� -   5         ��Name$ lvOrder��5      $��
0,152,0,70q�6$    �� View 5      �� 5      .P�5      �� $��Order ID��6%    �� Width$ 65��67    �� DisplayMemberBinding 6B   ��  �� Path$ Orderid��� 5      $��UserName��6%   $	 200��67    6C   �� $ Username��� 5      $��
Order Date��6%   $	 170��69    6E   �� $ 	Orderdate� �� StringFormat$ 
dd/MM/yyyy���� 5      $��
Product ID��6%   $ 70��69    6D   �� $ 	Productid��� 5      $��Quantity��6%   $	 100��67    6C   �� $ Quantity��� 5      $��Total Price��6%   $	 170��6:    6F   �� $ 
Totalprice�5      5      �� 5   
   $
��Left=�6   $��56��6+   $��	223,7,0,0q�67   $	��Top=�6J   $��64��6b   $��
/apple.png��6m   $
��Fill=�6�   	 J� RenderTransformOrigin$	 0.5,0.5&�6�   z�5      V� 5      .~�5      �� �� 5      
 �� AngleY$

 0.46Q�6$   �� 5      T� 5       T� Y$ -0.325Q�6)   5      5!      �� 5"   
   $��ORDER DETAILS��6   $
��Left=�6(   $��
297,10,0,0q�6C   $	��Top=�6W   $	��260��6o   $��33(�6{   $
��Bold"�6�   �� 5#   
   $��Search Order by UserName:��6   $
��Left=�64   $��
128,98,0,0q�6O   $	��Top=�6c   $	��192��6{   $��15(�6�   �� 5$   
   -   5         ��Name$ 	txtSearch��5$      $��26��6%   $��325,100,0,0q�61    �� TextWrapping$
 Wrap=�6F   $	��Top=�6Z   $	��335��6r   $
��Left=�6~   $��15(�6�   �� 5%   
   -   5         ��Name$ btnBack��5%      $��Back To Menu��6"   $��Center=�69   $��	0,519,0,0q�6V   $	��Top=�6i   $��27��6�   $	��180��6�   6�   5&      5'      