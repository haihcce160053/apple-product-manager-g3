   M S B A M L   `   `   `  ����E  AManagerApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ManagerApp
ManagerApp  5   	   "    ManagerApp.AccountManagement   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ManagerApp     5   	     � Title$  Account Management��5   	   $	��800��6$   $
��1150��61    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�5
   	   .��5      � .+�5   
   �� $��ACCOUNT MANAGEMENT��6   $��33(�6-   $
��Bold"�6;   $
��Left=�6M   $��404,8,0,677q�6h   �� 5   
   $��131,62,512,342q�6   .+�5      �� $��	User Name��6   $��14(�6(    J� RenderTransformOrigin$ -0.945,0.606&�66   �� 5      -   5         ��Name$ txtUserName��5       �� TextWrapping$
 Wrap=�6+   $	��475��6?   $��22��6K   ��6W   �� *
Username+ �� Mode$ OneWay=� � DataContext 6~   �� *SelectedItem+ �� ElementName$ 	lvAccount���� 5      $��Password��6   $��14(�6'   �� 5      -   5        $ txtPassword��5      $
 Wrap=�6+   $	��475��6?   $��22��6K   ��6W   �� *
Password+$ OneWay=� 6~   �� *SelectedItem+$ 	lvAccount���� 5      $��	Full Name��6   $��14(�6(   �� 5      -   5        $ txtFullName��5      $
 Wrap=�6+   $	��475��6?   $��22��6K   ��6W   �� *
Fullname+$ OneWay=� 6~   �� *SelectedItem+$ 	lvAccount���� 5      $��Phone��6   $��14(�6$   $ 0.472,1.889&�62   �� 5      -   5        $ txtPhone��5      $
 Wrap=�6(   $	��475��6<   $��22��6H   ��6T   �� *Phone+$ OneWay=� 6x   �� *SelectedItem+$ 	lvAccount���� 5      $��Email��6   $��14(�6$   �� 5      -   5        $ txtEmail��5      $
 Wrap=�6(   $	��475��6<   $��22��6H   ��6T   �� *Email+$ OneWay=� 6x   �� *SelectedItem+$ 	lvAccount���� 5      $��Address��6   $��14(�6&   �� 5      -   5        $ 
txtAddress��5      $
 Wrap=�6*   $	��474��6>   $��22��6J   ��6V   �� *	Address+$ OneWay=� 6|   �� *SelectedItem+$ 	lvAccount���� 5      $
��Type��6   $��14(�6#   �� 5      -   5        $ txtType��5      $
 Wrap=�6'   $	��474��6;   $��22��6G   ��6S   �� *Type+$ OneWay=� 6v   �� *SelectedItem+$ 	lvAccount��5      �� 5   
   $��750,145,186,425q�6   .+�5      �� -   5        	 ��Name$	 btnAdd��5      $	��Add��6%   $��30��63   $	��180��6?   $��0,0,0,20q�6K   6]   �� 5       -	   5        $	 	btnUpdate��5       $��Update��6(   $��30��69   $	��180��6E   $��0,0,0,20q�6Q   6c   �� 5!      -
   5        $	 	btnDelete��5!      $��Delete��6(   $��30��69   $	��180��6E   $��0,0,0,20q�6Q   6c   �� 5"      -   5        $	 btnBack��5"      $��Back To Menu��6&   $��30��6=   $	��180��6I   6U   5#      �� 5$   
   $
��Left=�6   $��58��6+   $��	332,1,0,0q�67   $	��Top=�6J   $��74��6b   $��
/apple.png��6m   $
��Fill=�6�   $ 0.5,0.5&�6�   z�5%      V� 5&      .~�5'      �� �� 5(      
 �� AngleY$

 0.46Q�6$   �� 5)      T� 5*       T� Y$ -0.325Q�6)   5+      5-      �� 5.   
   $��Search By UserName:��6   $
��Left=�6.   $��333,429,0,0q�6I   $	��Top=�6^   $	��175��6v   $��14(�6�   �� 5/   
   -   5        $ 	txtSearch��5/      $
��Left=�6%   $��28��6@   $��508,430,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $	��325��6�   $��14(�6�   6�   �� 50   
   -   5         ��Name$ 	lvAccount��50      $��	0,476,0,0q�6&    �� View 51      �� 52      .P�53      �� $��UserName��6%    �� Width$	 170��67    �� DisplayMemberBinding 6C   ��  �� Path$ Username��� 54      $��Password��6%   $	 170��67    6C   �� $ Password��� 55      $��	Full Name��6%   $	 170��68    6D   �� $ Fullname��� 56      $��Phone��6%   $	 170��64    6@   �� $ Phone��� 57      $��Email��6%   $	 170��64    6@   �� $ Email��� 58      $��Address��6%   $	 170��66    6B   �� $ Address��� 59      $
��Type��6%   $ 80��63    6>   �� $ TypeName�5:      5<      5=      5>      