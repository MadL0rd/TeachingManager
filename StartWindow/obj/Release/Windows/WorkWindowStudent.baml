   M S B A M L   `   `   `  ���� I  ETeacingManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:StartWindowStartWindow  3clr-namespace:StartWindow.DataStartWindow.Data  =#clr-namespace:StartWindow.ViewModelStartWindow.ViewModel  #    StartWindow.WorkWindowStudent   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:StartWindow     /Dataclr-namespace:StartWindow.Data     9	ViewModel#clr-namespace:StartWindow.ViewModel       � Title$  TeacingManager��$��528.5��$��880.5�� � WindowStartupLocation$ CenterScreen=� � Icon$9 3/TeacingManager;component/icons8-школа-512.ico�� � 	Resources +   %StartWindow.Data.AducationBaseDataSet   aducationBaseDataSet��%   &	           � DataContext 1  +StartWindow.ViewModel.TasksViewModelStudent  .��� ����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF5F0041�� � Offset$ 0.009Q�� $ 	#FFE6B2D6��$ 1Q�	 � ColumnDefinitions	 �� $	��190 ��� .+�� $y�Visible=�$��2��
 J� Opacity$	
 0.7Q� J� Effect -  'System.Windows.Media.Effects.BlurEffect  ����  �� ImageSource$K E/TeacingManager;component/a-abstract_pink_gradient_gradient-30993.jpg���� $��0�����	#7FA0A0A0$��0,34,0,0q�.+��� -   $#��Отправить ответ��$��40��
�������$��16(�$��2q�
����������	#60AA4030�� -   $%��Просмотр заданий��$��40��
�������$��16(�$��2q�
����������	#60AA4030�� -   $��Журнал��$��40��
�������$��16(�$��2q�
����������	#60AA4030�� -    ��Name$ 	UsrIDBuff��$��5q�$y�Hidden=�$	��130������ *
FilterText+ �� UpdateSourceTrigger$ PropertyChanged=��� -    ��Name$ HalloBox��$ ��Здравствуйте, ��$��34��$
��Wrap=�$	��Top=�$��Century Schoolbook)�$��22(�
������� �� TextAlignment$ Center=����	#7FA0A0A0$��2���� $� ���� -    ��Name$ Avatar��$"��shkolnaya-doska-zelenaya.png��$��1��$��42��$	��Top=�$��Right=�$��42��� -    �Name$ 
AnswerGrid��$y�Hidden=�$��1��$��0,34,0,0q�.+��� $��10,20,10,314q�.���� -   $��OneTaskView��$��0q����	#7FA0A0A0.+���  �� Orientation$ Vertical=�$��20,5,5,5q�.+��� $ 
Horizontal=�.+��� -	   $��CurrentSubject��
�������$��5q�$	��100��$��16(��� -
   $��CurrentTitle��
�������$��5q�$	��120��$��16(��� -   $��CurrentDateBeginStr��
�������$��5q�$��16(��� -   $��CurrentLine��$y�Hidden=�$��-��$��2q�
�������$��16(��� -   $��CurrentDateEndStr��
�������$��5q�$��16(��� $ Vertical=�.+��� -   $��CurrentTaskText��$��	5,20,5,30q�
�������$��16(��� -   $��CurrentIMGS��$
��Auto��$
��Auto��$	��100��$	��100��$��5q�$
��Left=� � ToolTip$5 /Нажмите, чтобы посмотреть���� -   $ 
AnswerText�� �� AcceptsReturn . $��10,0,10,163q����	#7FA0A0A0 �� SelectionBrush �	#7F0078D7$��14(�
�������$	��126��$��Bottom=���Z� �� $
��Left=�$��
10,0,0,289q�$
��Wrap=�$��Введите ответ��$��Bottom=�$	��230��$��25��$��16(�
��������� -   $��Отправить��$��183,0,183,13q�$��1��$��2��$��29��$��Bottom=��� -   $��Выбрать файл��$
��Left=�$��	10,0,0,52q�$	��108�� J� RenderTransformOrigin$ 0.5,0.5&�$	��106��$��Bottom=�z�V� .~��� �� �� T�  T� X$ -1.4210854715202004E-14Q��� -   $��DopFilesListView��$��123,0,10,51q����	#7FA0A0A0
�������$ 0.5,0.5&�$	��107��$��Bottom=����� *ItemsAnswerFiles+ �� Mode$ TwoWay=���Z� ���� .R�� ���� * (FrameworkElement.ActualWidth)+ �� RelativeSource ��  �� AncestorType$ ScrollContentPresenterL� � 	ItemWidth �� *(ListView.View).ItemWidth+ �� $ ListViewL����� *	ItemWidth+ �� *Self+ � 
ItemHeight �� *(ListView.View).ItemHeight+ �� $ ListViewL����� .R��� -   $��90��$��90������ *IMGS+�� $
��Left=�$��10,0,0,0q�$
��Wrap=�$��Задание��$	��230��$��16(�
�������$��20��$	��Top=�� -   $ TasksViewGrid��$y�Hidden=�$��1��$��0,50,0,0q� � RowDefinitions �� $
��auto ��� .+��� $��1��$��15q���.  ���	#7FA0A0A0
����������� *Items+���� .R��� $ Vertical=�.+��� $ 
Horizontal=�.+��� $��30,5,5,5q�$��50��$��16(����� *Klass+�� $��5q�$	��100��$��16(����� *	Subject+�� $��5q�$	��120��$��16(����� *Title+�� $��5q�$��16(����� *DateBeginStr+�� $��-��$��2q�$��16(��� $��5q�$��16(����� *
DateEndStr+9� $��	0,-23,0,0q�.���� $ Vertical=�.+��� $��	5,20,5,30q�
�������$��16(����� *
TaskText+�� -   $
��Auto��$
��Auto��$	��100��$	��100��$��5q�$
��Left=����� *IMGS+$5 /Нажмите, чтобы посмотреть���� -   $��Ответить��$��14(�� -   $ SubjectChoice_Copy��$
��Left=�$��	114,0,0,0q�$	��Top=�$	��266��$��32�� �� $
��Auto �.+��� -    ��Name$ SubjectComboBox1��$��	81,5,17,0q�$	��Top=�$��22��  �� Text  �� *SubjectFilter+���� *ItemsUsrSubjects+�� $��Предмет:��$��0��$
��Left=�$��3,-2,0,3q�$��0��$��Center=�$��31��$��77��
�������$��16(���Z� �� -   $��Сброс фильтра��$
��Left=�$��	384,4,0,0q�$	��Top=�$	��128��$��22��� -   $��JournalGrid��$y�Hidden=�$��1��$��0,42,0,0q�.+�� -   $ SubjectChoice_Copy1��$
��Left=�$��10,9,0,0q�$	��Top=�$	��265��$��32�� �� $
��Auto �.+��� -   $ JSubjectComboBox��$��	81,5,17,0q�$	��Top=�$��22������ *ItemsUsrSubjects+�� $��Предмет:��$��0��$
��Left=�$��3,-2,0,3q�$��0��$��Center=�$��31��$��77��
�������$��16(���Z� �� -   $��Обновить��$��275,14,132,0q�$��22��$	��Top=��� -   $��PrintButton��{�.  $��Распечатать��$��	0,14,10,0q�$��22��$	��Top=�$��Right=�$	��102��&   System.Windows.Controls.DataGrid  -    !  Name$! JournalDataGrid��$��10,50,10,10q�$��16(����	#99F0F0F0� -!   $��ImageViewGrid��$y�Hidden=����	#7FA0A0A0$��2��.+��� -"   $��ImageForView��