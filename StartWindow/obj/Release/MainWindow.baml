   M S B A M L   `   `   `  ���� I  ETeacingManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:StartWindowStartWindow      StartWindow.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:StartWindow     -     �Name$  Window�� � Title$ 
MainWindow��$	��640��$	��480�� � WindowStyle$
 None=� � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�$	��480��$	��480��$	��640��$	��640�� � Icon$ icons8-школа-512.ico����Z�  � 	Resources    StartAnimation �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame	 O� KeyTime
 O� Value��%�  &	        �� .��U� $ (UIElement.Opacity)�$ LoginBox��.\�  $	 0��$
 0Q�  $	 0:0:0.1��$
 0Q�  $	 0:0:0.2��$
 0Q�  $	 0:0:3.2��$
 1Q�U� $ (UIElement.Opacity)�$ EnterButton��.\�  $	 0��$
 0Q�  $	 0:0:0.1��$
 0Q�  $	 0:0:0.2��$
 0Q�  $	 0:0:0.3��$
 0Q�  $	 0:0:0.4��$
 0Q�  $	 0:0:0.5��$
 0Q�  $	 0:0:3.5��$
 1Q�U� $ (UIElement.Opacity)�$ TeachingManagerText��.\�  $	 0��$
 0Q�  $	 0:0:3��$
 1Q�U� $ (UIElement.Opacity)�$ 	LoginText��.\�  $	 0��$
 0Q�  $	 0:0:0.1��$
 0Q�  $	 0:0:3.1��$
 1Q�U� $ (UIElement.Opacity)�$ PasswordBox��.\�  $	 0��$
 0Q�  $	 0:0:0.1��$
 0Q�  $	 0:0:0.2��$
 0Q�  $	 0:0:0.3��$
 0Q�  $	 0:0:0.4��$
 0Q�  $	 0:0:3.4��$
 1Q�U� $ (UIElement.Opacity)�$ PasswordText��.\�  $	 0��$
 0Q�  $	 0:0:0.1��$
 0Q�  $	 0:0:0.2��$
 0Q�  $	 0:0:0.3��$
 0Q�  $	 0:0:3.3��$
 1Q�U� $ (UIElement.Opacity)�$ 	RegButton��.\�  $	 0��$
 0Q�  $	 0:0:0.1��$
 0Q�  $	 0:0:0.2��$
 0Q�  $	 0:0:0.3��$
 0Q�  $	 0:0:0.4��$
 0Q�  $	 0:0:0.5��$
 0Q�  $	 0:0:1��$
 0Q�  $	 0:0:1.6��$
 0Q�  $	 0:0:4��$
 1Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ TeachingManagerText��.\�  $	 0��$
 0Q�  $	 0:0:3��$
 1Q�����  �� ImageSource$" shkolnaya-doska-zelenaya.png�� � Triggers :�  :� RoutedEvent$ FrameworkElement.Loaded��.[��� #��[  .��� -    �Name$ 
LayoutRoot��.+��� -    ��Name$ TeachingManagerText��$��8,71,8,0q�$
��Wrap=���. $	��Top=� �� TextAlignment$ Center=�$��48(�$��TT Walls Rough)�$��88.703�� J� RenderTransformOrigin$ 0.5,0.5&�
���������Z� z�V� .~��� �� �� T� �� $�Teaching Manager���� -   $ 	LoginText��$��228,160,227,0q�$
��Wrap=���. $ Center=�$��21.333(�$��TT Walls Rough)�$��70��$	��Top=�
���������Z� �� $�
Логин���� .F��� -    ��Name$ LoginBox�� � Cursor$ IBeam��$��30��$	��177��
�������
�������$��20(�$��Yu Gothic UI Semibold)� �� SelectionBrush Z� .������ .���� -   $ PasswordText��$��228,230,227,180q�$
��Wrap=���. $ Center=�$��21.333(�$��TT Walls Rough)�
���������Z� �� $�Пароль���� .F�G� -    G�Name$ PasswordBox��$ IBeam��$��30��$	��183��
�������
�������$��20(�$��Yu Gothic UI Semibold)���Z�  G� SelectionBrush Z� �� -    ��Name$ EnterButton��$��
Войти��$��267,305,267,145q�$
 Hand��$��Center=�$	��106��$��TT Walls Rough)�$��21(�$	��Top=�
����������	#3FADD8E6��Z� ����  �� 
TargetType" ��.R���  �� CornerRadius$ 25��#��z��#��z��#��z��#��z������ BorderColor�� �� Color$ 	#00DDDDDD��._��� #��z��#��z��#��z��#��z��'  !System.Windows.VisualStateManager   VisualStateGroups %  System.Windows.VisualStateGroup     Name$ CommonStates��   States.    System.Windows.VisualState     Name$ 	MouseOver��   
Storyboard. �� .���� $ BorderColor��$ Color�	  �� To$  	#3FADD8E6X�  $ Normal��. �� .���� $ BorderColor��$ Color�$  	#00DDDDDDX��� -	   $ 	RegButton��$��Регистрация��$��Right=�$��28��$��0,0,42.5,52q�$��Bottom=�$	��136��$��TT Walls Rough)�$��16(�
���������Z� ��Z� ���� " ��.R��� $ 25��#��z��#��z��#��z��#��z������ BorderColor��$ 	#00DDDDDD��._��� #��z��#��z��#��z��#��z��   $ CommonStates��.   $ 	MouseOver��. �� .���� $ BorderColor��$ Color�$  	#3FADD8E6X�  $ Normal��. �� .���� $ BorderColor��$ Color�$  	#00DDDDDDX��� -
   $��
ExitButton��$��X��$
��Left=�$��	597,3,0,0q�$	��Top=�$��26��
�������$��TT Walls Rough)�$��22(�$��33����Z� ��Z� ���� " ��.R��� $ 3��#��z��#��z��#��z��$
��Auto��$��2,0,0,0q����� BorderColor��$ 	#00DDDDDD��._��� #��z��#��z��#��z��#��z��   $ CommonStates��.   $ 	MouseOver��. �� .���� $ BorderColor��$ Color�$  	#3FADD8E6X�  $ Normal��. �� .���� $ BorderColor��$ Color�$  	#00DDDDDDX��� -   $
��Left=�$��31��$��17,3,0,0q�$	��Top=�$	��581�����	#00000000���	#00000000