   M S B A M L   `   `   `  ���� I  ETeacingManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:StartWindowStartWindow      StartWindow.Window1   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:StartWindow     -     � Title$  TeacingManager��$	��640��$	��480�� � WindowStyle$
 None=� � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�$	��480��$	��480��$	��640��$	��640�� � Icon$9 3/TeacingManager;component/icons8-школа-512.ico����Z�  � 	Resources    StartAnimation �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime	 O� Value��%z  &	        �� .��U� $ (UIElement.Opacity)�$ LoginBox��.\�  $ 0��$	 0Q�  $ 0:0:0.2��$	 0Q�  $ 0:0:3.2��$	 1Q�U� $ (UIElement.Opacity)�$ EnterButton��.\�  $ 0��$	 0Q�  $ 0:0:0.5��$	 0Q�  $ 0:0:3.5��$	 1Q�U� $ (UIElement.Opacity)�$ 	RegButton��.\�  $ 0��$	 0Q�  $ 0:0:0.5��$	 0Q�  $ 0:0:3.5��$	 1Q�U� $ (UIElement.Opacity)�$ TeachingManagerText��.\�  $ 0��$	 0Q�  $ 0:0:3��$	 1Q�U� $ (UIElement.Opacity)�$ 	LoginText��.\�  $ 0��$	 0Q�  $ 0:0:0.1��$	 0Q�  $ 0:0:3.1��$	 1Q�U� $ (UIElement.Opacity)�$ Surname��.\�  $ 0��$	 0Q�  $ 0:0:0.1��$	 0Q�  $ 0:0:3.1��$	 1Q�U� $ (UIElement.Opacity)�$ Phone��.\�  $ 0��$	 0Q�  $ 0:0:0.1��$	 0Q�  $ 0:0:3.1��$	 1Q�U� $ (UIElement.Opacity)�$ PasswordText��.\�  $ 0��$	 0Q�  $ 0:0:0.3��$	 0Q�  $ 0:0:3.3��$	 1Q�U� $ (UIElement.Opacity)�$
 Name��.\�  $ 0��$	 0Q�  $ 0:0:0.3��$	 0Q�  $ 0:0:3.3��$	 1Q�U� $ (UIElement.Opacity)�$ PasswordText1��.\�  $ 0��$	 0Q�  $ 0:0:0.5��$	 0Q�  $ 0:0:3.3��$	 1Q�U� $ (UIElement.Opacity)�$ 
Patronymic��.\�  $ 0��$	 0Q�  $ 0:0:0.5��$	 0Q�  $ 0:0:3.3��$	 1Q�U� $ (UIElement.Opacity)�$
 Mail��.\�  $ 0��$	 0Q�  $ 0:0:0.5��$	 0Q�  $ 0:0:3.3��$	 1Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ TeachingManagerText��.\�  $ 0��$	 0Q�  $ 0:0:3��$	 1Q����� 
 �� ImageSource$<
 6/TeacingManager;component/shkolnaya-doska-zelenaya.png�� � Triggers :�  :� RoutedEvent$ FrameworkElement.Loaded��.[��� #��[  .��� -    �Name$ 
LayoutRoot��.+��� -    ��Name$ TeachingManagerText��$��	10,64,6,0q�$
��Wrap=���. $	��Top=� �� TextAlignment$ Center=�$��48(�$��TT Walls Rough)�$��89�� J� RenderTransformOrigin$ 0.5,0.5&�
�������$��Регистрация����Z� z�V� .~��� �� �� T� �� -   $ 	LoginText��$��50,158,404,0q�$
��Wrap=���. $ Center=�$��16(�$��TT Walls Rough)�$��70��$	��Top=�
���������Z� �� $���Придумайте логин                                                                                                                                                                                                                                                                          ���� .F��� -    ��Name$ LoginBox�� � Cursor$ IBeam��$��30��$	��177��
�������
�������$��20(�$��Yu Gothic UI Semibold)� �� SelectionBrush Z� .������ .���� -   $ PasswordText��$��50,214,404,196q�$
��Wrap=���. $ Center=�$��16(�$��TT Walls Rough)�
���������Z� �� $'�!Придумайте пароль���� .F�G� -    G�Name$ PasswordBox��$ IBeam��$��30��$	��183��
�������
�������$��20(�$��Yu Gothic UI Semibold)���Z�  G� SelectionBrush Z� �� -   $ PasswordText1��$��50,268,404,142q�$
��Wrap=���. $ Center=�$��16(�$��TT Walls Rough)�
���������Z� �� $%�Повторите пароль���� .F�G� -	   $ PasswordBox1��$ IBeam��$��30��$	��183��
�������
�������$��20(�$��Yu Gothic UI Semibold)���Z�  Z� �� -
   $ Surname��$��240,158,230,0q�$
��Wrap=���. $ Center=�$��16(�$��TT Walls Rough)�$��70��$	��Top=�
���������Z� �� $���Введите фамилию                                                                                                                                                                                                                            ���� .F��� -   $ 
SurnameBox��$ IBeam��$��30��$	��148��
�������
�������$��20(�$��Yu Gothic UI Semibold)� Z� .������ .���� -   $
 Name��$��240,214,230,0q�$
��Wrap=���. $ Center=�$��16(�$��TT Walls Rough)�$��70��$	��Top=�
���������Z� �� $���Введите имя                                                                                                                                                                                                                                                                       ���� .F��� -   $ NameBox��$ IBeam��$��30��$	��148��
�������
�������$��20(�$��Yu Gothic UI Semibold)� Z� .������ .���� -   $ 
Patronymic��$��240,268,230,0q�$
��Wrap=���. $ Center=�$��16(�$��TT Walls Rough)�$��70��$	��Top=�
���������Z� �� $���Введите отчество                                                                                                                                                                                                                                                                          ���� .F��� -   $ PatronymicBox��$ IBeam��$��30��$	��148��
�������
�������$��20(�$��Yu Gothic UI Semibold)� Z� .������ .���� -   $ Phone��$��410,158,44,0q�$
��Wrap=���. $ Center=�$��16(�$��TT Walls Rough)�$��70��$	��Top=�
���������Z� �� $���Введите телефон                                                                                                                                                                                                                                                                          ���� .F��� -   $ PhoneBox��$ IBeam��$��30��$	��177��
�������
�������$��20(�$��Yu Gothic UI Semibold)� Z� .������ .���� -   $
 Mail��$��410,248,44,0q�$
��Wrap=���. $ Center=�$��16(�$��TT Walls Rough)�$��82��$	��Top=�
���������Z� �� $���Введите адрес электронной почты                                                                                                                                                                                                                                                                     ���� .F��� -   $ MailBox��$ IBeam��
�������
�������$��20(�$��Yu Gothic UI Semibold)�$��30��$	��177�� Z� .������ .���� -    ��Name$ EnterButton��$*��$Зарегистрироваться��$��184,343,184,107q�$
 Hand��$��Center=�$	��272��$��TT Walls Rough)�$��21(�$	��Top=�
����������	#3FADD8E6��Z� ����  �� 
TargetType" ��.R���  �� CornerRadius$ 25��#��z��#��z��#��z��#��z������ BorderColor�� �� Color$ 	#00DDDDDD��'  !System.Windows.VisualStateManager   VisualStateGroups %  System.Windows.VisualStateGroup  CommonStates��   States.    System.Windows.VisualState  	MouseOver��   
Storyboard. �� .���� $ BorderColor��$ Color�	 �� To$ 	#3FADD8E6X�  
Normal��. �� .���� $ BorderColor��$ Color�$ 	#00DDDDDDX�._��� #��z��#��z��#��z��#��z���� -   $ 
ExitButton��$��X��$
��Left=�$��	597,3,0,0q�$	��Top=�$��26��
�������$��TT Walls Rough)�$��22(�$��33����Z� ��Z� ���� " ��.R��� $ 3��#��z��#��z��#��z��$
��Auto��$��2,0,0,0q����� BorderColor��$ 	#00DDDDDD��   CommonStates��.   	MouseOver��. �� .���� $ BorderColor��$ Color�$ 	#3FADD8E6X�  
Normal��. �� .���� $ BorderColor��$ Color�$ 	#00DDDDDDX�._��� #��z��#��z��#��z��#��z���� -   $
��Left=�$��31��$	��Top=�$	��587�����	#00000000���	#00000000$��10,0,0,0q��� -   $ 	RegButton��$��Авторизация��$��Right=�$��28��$��	0,0,42,52q�$��Bottom=�$	��150��$��TT Walls Rough)�$��16(�
���������Z� ��Z� ���� " ��.R��� $ 25��#��z��#��z��#��z��#��z������ BorderColor��$ 	#00DDDDDD��   CommonStates��.   	MouseOver��. �� .���� $ BorderColor��$ Color�$ 	#3FADD8E6X�  
Normal��. �� .���� $ BorderColor��$ Color�$ 	#00DDDDDDX�._��� #��z��#��z��#��z��#��z��